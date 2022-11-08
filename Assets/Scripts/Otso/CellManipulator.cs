using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManipulator : MonoBehaviour
{
    [SerializeField] private List<Transform> cellList;
    [SerializeField] private Color originalColor;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (GamePhaseManager.Instance.gamePhase == GamePhaseManager.GamePhase.cardPhase))
        {
            SelectCell();
            //SwapCells();
        }
    }

    public void SelectCell()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                Debug.Log("Cell added to cell list");
                Transform transformToAdd = hit.transform;
                transformToAdd.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                cellList.Add(transformToAdd);

                SwapCells();
            }
        }
    }

    public void SwapCells()
    {
        if (cellList.Count < 2) return;
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
        }
    }
}
