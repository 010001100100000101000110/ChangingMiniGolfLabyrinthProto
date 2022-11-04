using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject selected;
    Rigidbody rigidbody;

    Helper helper;

    [SerializeField] bool canLaunch;
    public bool ballSelected { get; private set; }
    bool isGrounded;

    public int launchAmount { get; private set; }
    float currentDrag;
    float currentAngularDrag;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();        
        currentDrag = rigidbody.drag;
        currentAngularDrag = rigidbody.angularDrag;
        helper = FindObjectOfType<Helper>();
    }

    void Update()
    {
        if (rigidbody.velocity.magnitude > 0 || !isGrounded) canLaunch = false;
        if (canLaunch) LaunchBallMode();
        if (!canLaunch) StopBallVelocity();
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
                    ballSelected = true;
                    selected = hit.transform.gameObject;
                }                    
            }                
        }
        if (Input.GetMouseButtonUp(0) && selected && selected.tag == "Player")
        {            
            LaunchBall();
            ballSelected = false;
            selected = null;
        }
    }    

    void LaunchBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~3))
        {
            Vector3 playerPos = this.transform.position;
            Vector3 trajectoryDir = (new Vector3(this.transform.position.x, hit.point.y, this.transform.position.z) - hit.point).normalized;
            float distance = Vector3.Distance(playerPos, hit.point); 
            float clampDistance = Mathf.Clamp(distance, 0, maxPullDistance);
            float force = clampDistance * launchForce;
                        
            rigidbody.AddForce(trajectoryDir * force, ForceMode.Impulse);
            helper.eventMethods.BallLaunched();
        }         
    }


    void StopBallVelocity()
    {
        if (isGrounded)
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
                helper.eventMethods.BallStopped();
            }
        }       
    }

    public void ResetPlayerPosition()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
    
    public float GetDistance()
    {
        float distance = 0;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~3)) distance = Vector3.Distance(new Vector3(this.transform.position.x, hit.point.y, transform.position.z), hit.point);
        return distance;
    }
    public float GetMaxDistance()
    {
        return maxPullDistance; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = false;
    }
}
