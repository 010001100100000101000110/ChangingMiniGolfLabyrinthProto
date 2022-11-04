using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendering : MonoBehaviour
{    
    LineRenderer lineRenderer;
    Helper helper;
    void Start()
    {
        helper = FindObjectOfType<Helper>();
        lineRenderer = GetComponent<LineRenderer>();       
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (helper.controller.ballSelected)
        {
            lineRenderer.enabled = true;
            RenderLine();
        }
        if (!helper.controller.ballSelected)
        {
            lineRenderer.enabled = false;
        }
    }
    void RenderLine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        lineRenderer.SetPosition(0, helper.controller.transform.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~3)) lineRenderer.SetPosition(1, hit.point);
    }

}
