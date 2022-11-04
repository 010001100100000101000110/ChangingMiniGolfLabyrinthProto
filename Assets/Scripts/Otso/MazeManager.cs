using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cells;
    [SerializeField] private List<GameObject> nextRotatingCells;
    [SerializeField] private List<GameObject> cloneList;
    [SerializeField] private List<GameObject> pickAndSwapList;

    Helper helper;
    private int randomNum;
    private int randomNum2;
    private float[] randomRotation = new float[] { 90f, 180f, 270f };

    [SerializeField] private Material originalMat;
    [SerializeField] private Material transparentMat;
    private GameObject showRotationObject;

    private void Awake()
    {
        helper = FindObjectOfType<Helper>();
    }

    void Start()
    {
        PickRandomCells();
        ShowCellRotationInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && GamePhaseManager.Instance.gamePhase == GamePhaseManager.GamePhase.cardPhase)
        {
            PickAndSwapCells();
        }
    }

    private void PickRandomCells()
    {
        randomNum = Random.Range(0, cells.Length);
        randomNum2 = Random.Range(0, cells.Length);
        nextRotatingCells.Add(cells[randomNum]);
        nextRotatingCells.Add(cells[randomNum2]);
        Debug.Log("Random cells added to list");
    }

    public void RotateCells()
    {
        Debug.Log("RotateCells method called");
        if (GamePhaseManager.Instance.gamePhase != GamePhaseManager.GamePhase.labyrinthMovePhase)
        {
             return;
        }
        else
        {
            foreach (GameObject cell in nextRotatingCells)
            {
                cell.gameObject.transform.Rotate(0, 90, 0);
                Debug.Log("Cells rotated");
            }
            ClearNextRotatingCellsList();
            PickRandomCells();
            ShowCellRotationInfo();
            GamePhaseManager.Instance.UpdateGamePhase(GamePhaseManager.GamePhase.cardPhase);
        }
    }

    IEnumerator RotateCell(GameObject cell, Vector3 byAngle, float inTime)
    {
        Debug.Log("kiki");
        var fromAngle = cell.transform.rotation;
        var toAngle = Quaternion.Euler(cell.transform.eulerAngles + byAngle);

        for (var t = 0f; t <= 1; t += Time.deltaTime/inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    private void ClearNextRotatingCellsList()
    {
        nextRotatingCells.Clear();
        DestroyClones();
        Debug.Log("nextRotatingCellsList cleared");
    }

    public void ShowCellRotationInfo()
    {
        foreach (GameObject cell in nextRotatingCells)
        {
            showRotationObject = Instantiate(cell, cell.transform.position, Quaternion.Euler(0, 90, 0));

            MeshRenderer[] meshRenderers = showRotationObject.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer renederer in meshRenderers)
            {
                renederer.material = transparentMat;
            }

            BoxCollider[] boxColliders = showRotationObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider boxCollider in boxColliders)
            {
                boxCollider.enabled = false;
            }

            cloneList.Add(showRotationObject);
        }
    }

    public void DestroyClones()
    {
        foreach (GameObject clone in cloneList)
        {
            Destroy(clone);
        }

        cloneList.Clear();
    }

    public void PickAndSwapCells()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,
            out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                GameObject objectToAdd = hit.transform.gameObject;
                pickAndSwapList.Add(objectToAdd);
            }
        }
    }
}
