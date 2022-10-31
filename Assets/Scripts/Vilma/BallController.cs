using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject selected;
    Rigidbody rigidbody;
    LineRenderer lineRenderer;
    [SerializeField] bool canLaunch;
    bool canRenderLine;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;
    public int launchAmount { get; private set; }
    public Vector3 lastPosition { get; private set; }
    Vector2 mousePosition;
    float currentDrag;
    float currentAngularDrag;

    [SerializeField] int launchesLeft;
    [SerializeField] int launchCapacity;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        currentDrag = rigidbody.drag;
        currentAngularDrag = rigidbody.angularDrag;
        canLaunch = true;
    }

    void Update()
    {
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
            canLaunch = false;
            selected = null;
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
    void LaunchBall()
    {
        //rigidbody.bodyType = RigidbodyType2D.Dynamic;
        //rigidbody.constraints = RigidbodyConstraints2D.None;
        //rigidbody.freezeRotation = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 playerPos = this.transform.position;
            Vector3 trajectoryDir = (playerPos - hit.point).normalized;
            float distance = Vector3.Distance(playerPos, hit.point); 
            float clampDistance = Mathf.Clamp(distance, 0, maxPullDistance);
            float force = clampDistance * launchForce;
                        
            rigidbody.AddForce(trajectoryDir * force, ForceMode.Impulse);
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
            Debug.Log("caca doodoo");
            //canLaunch = true;
        }
    }
}
