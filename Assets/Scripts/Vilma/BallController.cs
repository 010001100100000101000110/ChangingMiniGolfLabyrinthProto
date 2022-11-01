using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject selected;
    Rigidbody rigidbody;
    LineRenderer lineRenderer;
    EventMethods eventMethods;

    [SerializeField] bool canLaunch;
    bool canRenderLine;
    public int launchAmount { get; private set; }
    float currentDrag;
    float currentAngularDrag;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;
    

   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        currentDrag = rigidbody.drag;
        currentAngularDrag = rigidbody.angularDrag;
        canLaunch = true;
        eventMethods = FindObjectOfType<EventMethods>();
    }

    void Update()
    {
        if (rigidbody.velocity.magnitude > 0) canLaunch = false;
        if (canLaunch) LaunchBallMode();
        if (!canLaunch) StopBallVelocity();
        if (canRenderLine) LineRendering();
    }
    void LaunchBallMode()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {           
            if (Physics.Raycast(ray, out hit))
            {                
                if (hit.transform.tag == "Player")
                {
                    CanLineRender();
                    selected = hit.transform.gameObject;
                }                    
            }                
        }
        if (Input.GetMouseButtonUp(0) && selected && selected.tag == "Player")
        {            
            LaunchBall();
            CantLineRender();            
            selected = null;
        }
    }
    

    void LaunchBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 playerPos = this.transform.position;
            Vector3 trajectoryDir = (new Vector3(this.transform.position.x, hit.point.y, this.transform.position.z) - hit.point).normalized;
            float distance = Vector3.Distance(playerPos, hit.point); 
            float clampDistance = Mathf.Clamp(distance, 0, maxPullDistance);
            float force = clampDistance * launchForce;
                        
            rigidbody.AddForce(trajectoryDir * force, ForceMode.Impulse);
            eventMethods.BallLaunched();
        }         
    }
    void StopBallVelocity()
    {
        if (rigidbody.velocity.magnitude < 0.7 && rigidbody.velocity.magnitude > 0)
        {
            rigidbody.drag = 50;
            rigidbody.angularDrag = 50;
        }
        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.drag = currentDrag;
            rigidbody.angularDrag = currentAngularDrag;
            canLaunch = true;
        }
    }
    void LineRendering()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        lineRenderer.SetPosition(0, this.transform.position);
        if (Physics.Raycast(ray, out hit)) lineRenderer.SetPosition(1, hit.point);
    }
    public void CanLineRender()
    {
        canRenderLine = true;
        lineRenderer.enabled = true;
    }

    public void CantLineRender()
    {
        canRenderLine = false;
        lineRenderer.enabled = false;
    }
}
