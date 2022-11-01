using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] cells;
    [SerializeField] private int horizontalSize = 4;
    [SerializeField] private int verticallSize = 4;
    [SerializeField] private float cellSpacingOffset = 1f;
    [SerializeField] private Vector3 mazeOrigin = Vector3.zero;


    void Start()
    {
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        for (int z = 0; z < horizontalSize; z++)
        {
            for (int x = 0; x < verticallSize; x++)
            {
                Vector3 spawnPosition = new Vector3(x * cellSpacingOffset, 0, z * cellSpacingOffset) + mazeOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            } 
        }
    }
    public void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, cells.Length);
        GameObject go = Instantiate(cells[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
