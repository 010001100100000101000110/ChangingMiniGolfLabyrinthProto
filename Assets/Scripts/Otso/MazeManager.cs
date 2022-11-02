using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cells;
    [SerializeField] private List<GameObject> nextRotatingCells;
    private int randomNum;
    private int randomNum2;
    private float[] randomRotation = new float[] { 90f, 180f, 270f };

    void Start()
    {
        PickRandomCells();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateCells();
        }
    }

    private void PickRandomCells()
    {
        randomNum = Random.Range(0, cells.Length);
        randomNum2 = Random.Range(0, cells.Length);
        nextRotatingCells.Add(cells[randomNum]);
        nextRotatingCells.Add(cells[randomNum2]);
    }

    private void RotateCells()
    {
        foreach(GameObject cell in nextRotatingCells)
        {
            //float rotation = Random.Range(randomRotation[0], randomRotation.Length);
            cell.gameObject.transform.Rotate(0, 90, 0);
        }
    }

    private void ClearNextRotatingCellsList()
    {
        nextRotatingCells.Clear();
    }
}
