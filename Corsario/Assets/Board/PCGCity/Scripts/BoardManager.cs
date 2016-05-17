using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    public int rows;
    [SerializeField]
    private int floorIndex;

    [SerializeField]
    public FloorSettings[] floorSettings;

    private Transform boardHolder;
    private List<Vector3> gridPosition = new List<Vector3>(); //Lista de Posicoes para os tiles

    void initialiseList(int _maxX)
    {
        //Limpar as posicoes
        gridPosition.Clear();
        for (int x = 0; x < _maxX - 1; x++){
            for (int y = 0; y <= rows - 1; y++){
                    gridPosition.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void FloorGenerate(int index)
    {
        for (int i = 0; i < gridPosition.Count; i++)
        {
            GameObject toInstantiate;
            if ((gridPosition[i].y == 0) || (gridPosition[i].y == rows - 1)){
                toInstantiate = gridPosition[i].y == 0 ? floorSettings[floorIndex].floorLimit as GameObject : floorSettings[floorIndex].floorLimit2 as GameObject;

            }else{
                int floorRandom = Random.Range(0, floorSettings[floorIndex].floorTile.Length);
                toInstantiate = floorSettings[floorIndex].floorTile[floorRandom];
            }
            GameObject instance = Instantiate(toInstantiate,
                                    new Vector3(gridPosition[i].x, gridPosition[i].y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
    }


    // Use this for initialization
    void Start () {
        boardHolder = new GameObject("Board").transform;
        GameObject bg = Instantiate(floorSettings[floorIndex].background, new Vector3(0.35f, 5.11f, 0f), Quaternion.identity) as GameObject;
        bg.transform.position = floorSettings[floorIndex].bgPosition;
        Renderer render = bg.GetComponent<Renderer>();
        initialiseList((int)render.bounds.size.x + 1);
        FloorGenerate(floorIndex);

    }

}
