using UnityEngine;
using System;

[Serializable]
public class FloorSettings{
    public string nameFloorTile;
    public GameObject[] floorTile;
    public GameObject floorLimit;
    public GameObject floorLimit2;
    public GameObject background;
    public Vector3 bgPosition;
    public GameObject enemyPrefab;

    public float minCameraX = 50, maxCameraX = 50, minCameraY = 50, maxCameraY = 50;

}
