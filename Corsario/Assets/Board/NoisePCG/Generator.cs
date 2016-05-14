using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	#pragma warning disable 78
	
	public GameObject dirtPrefab; 
	public GameObject grassPrefab;
    private Transform boardHolder;
    private Transform local;

    public int localNumber;

    public int minX = -16;
    public int maxX = 16;
    public int minY = -10;
    public int maxY = 10;

    public 
	
	PerlinNoise noise;
	
	void Start() { 
        boardHolder = new GameObject("Board").transform;
        StartCoroutine(Regenerate());
	}
	
	private IEnumerator Regenerate(){
		
		float width = dirtPrefab.transform.lossyScale.x;
		float height = dirtPrefab.transform.lossyScale.y;

        for (int k = 0; k < localNumber; k++) {
            local = new GameObject("Local" + k).transform;
            long noiseLong = Random.Range(1000000, 100000000);
            noise = new PerlinNoise(noiseLong);
            for (int i = minX; i < maxX; i++){//columns (x values
                int columnHeight = 2 + noise.getNoise(i - minX, maxY - minY - 2);
                for (int j = minY; j < minY + columnHeight; j++)
                {//rows (y values)
                    GameObject block = (j == minY + columnHeight - 1) ? grassPrefab : dirtPrefab;
                    GameObject instance;
                    if ((i == minX && j == minY + columnHeight) || (i == maxX && j == minY + columnHeight)){
                        instance = Instantiate(block, new Vector2(i * width, 0 * height), Quaternion.identity) as GameObject;
                    }
                    else {
                        instance = Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity) as GameObject;
                    }
                    
                    instance.transform.SetParent(local);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            if (local.name != "Local0") {
                local.position = new Vector3(local.position.x + (40* k), 0, 0);
            }
            local.transform.SetParent(boardHolder);
        }

        Debug.Log("BoardHolder tem "+boardHolder.childCount);

    }
}
