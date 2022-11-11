using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cells;
    [SerializeField] private List<GameObject> nextRotatingCells;
    [SerializeField] private List<GameObject> cloneList;
    [SerializeField] private bool stopCardPlayed = false;

    Helper helper;
    private int randomNum;
    private int randomNum2;

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
            RotateCells();
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
        if (!stopCardPlayed)
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

                
                
            }
        }
        // Vaihdetaan GameState
        GamePhaseManager.Instance.UpdateGamePhase(GamePhaseManager.GamePhase.cardPhase);
        helper.uiHandler.UpdateGamePhaseText();
    }

    public void StopLabyrinthChange()
    {
        stopCardPlayed = true;
    }

    public void EnableLabyrinthChange()
    {
        stopCardPlayed = false;
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
            showRotationObject = Instantiate(cell.gameObject, cell.transform.position, Quaternion.Euler(0, 90, 0));

            MeshRenderer[] meshRenderers = showRotationObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renederer in meshRenderers)
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
}
