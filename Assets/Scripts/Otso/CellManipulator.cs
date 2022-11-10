using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManipulator : MonoBehaviour
{
    [SerializeField] private List<Transform> cellList;
    [SerializeField] private Color originalColor;
    private int maxListLength;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (GamePhaseManager.Instance.gamePhase == GamePhaseManager.GamePhase.cardPhase))
        {
            SelectCell();
        }
    }

    public void SelectCell()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Ground") && cellList.Contains(hit.transform))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = originalColor;
                cellList.Remove(hit.transform);
            }
            else if (hit.transform.CompareTag("Ground") && cellList.Count <= 1)
            {
                Debug.Log("Cell added to cell list");
                Transform transformToAdd = hit.transform;
                cellList.Add(transformToAdd);
                CellHelper.ChangeColor(cellList, Color.green);
            }
        }
    }

    public void SwapCells()
    {
            if (cellList.Count != 2)
            {
                return;
            }
            else
            {
                Transform cell1 = cellList[0];
                Transform cell2 = cellList[1];

                Vector3 tempPos = cell1.position;
                cell1.position = cell2.position;
                cell2.position = tempPos;

                Debug.Log("Cells swapped");
                CellHelper.ChangeColor(cellList, originalColor);

                cellList.Clear();
            GamePhaseManager.Instance.UpdateGamePhase(GamePhaseManager.GamePhase.movePhase);
        }
        
    }

    public void RotateCell()
    {
            if (cellList.Count != 1)
            {
                return;
            }
            else
            {
                GameObject cellToRotate = cellList[0].gameObject;

                cellToRotate.transform.Rotate(0, 90, 0);
                CellHelper.ChangeColor(cellList, originalColor);
                cellList.Clear();
            GamePhaseManager.Instance.UpdateGamePhase(GamePhaseManager.GamePhase.movePhase);
        }
        
    }

}
