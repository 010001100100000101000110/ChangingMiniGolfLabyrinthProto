using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendering : MonoBehaviour
{
    [SerializeField] BallController controller;
    [SerializeField] LineRenderer lineRenderer;
    void Start()
    {
        controller = FindObjectOfType<BallController>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (controller.ballSelected)
        {
            lineRenderer.enabled = true;
            RenderLine();
        }
        if (!controller.ballSelected)
        {
            lineRenderer.enabled = false;
        }
    }
    void RenderLine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        lineRenderer.SetPosition(0, controller.transform.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~3)) lineRenderer.SetPosition(1, hit.point);
    }
}
