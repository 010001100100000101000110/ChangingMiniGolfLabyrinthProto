using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject selected;
    Rigidbody rigidbody;
    Helper helper;

    [SerializeField]bool canLaunch;
    public bool ballSelected { get; private set; }

    public int launchAmount { get; private set; }
    float originalDrag;
    float originalAngularDrag;
    [SerializeField] float launchForce;
    [SerializeField] float maxPullDistance;

    Vector3 startPosition;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        originalDrag = rigidbody.drag;
        originalAngularDrag = rigidbody.angularDrag;
        helper = FindObjectOfType<Helper>();
        startPosition = transform.position;
    }

    

    void Update()
    {
        if (rigidbody.velocity.magnitude > 0 || !IsGrounded()) canLaunch = false;
        if (canLaunch && (GamePhaseManager.Instance.gamePhase == GamePhaseManager.GamePhase.movePhase)) LaunchBallMode();
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

            // (Otson lisäys) Vaihdetaan GamePhase
            GamePhaseManager.Instance.UpdateGamePhase(GamePhaseManager.GamePhase.labyrinthMovePhase);
        }         
    }


    void StopBallVelocity()
    {
        if (IsGrounded())
        {
            rigidbody.angularDrag = originalAngularDrag;
            if (rigidbody.velocity.magnitude < 0.7 && rigidbody.velocity.magnitude > 0)
            {
                rigidbody.drag = 50;
                rigidbody.angularDrag = 50;
            }
            if (rigidbody.velocity.magnitude == 0)
            {
                rigidbody.drag = originalDrag;
                rigidbody.angularDrag = originalAngularDrag;
                canLaunch = true;
                helper.eventMethods.BallStopped();
            }
        }       
    }

    public void ResetPlayerPosition()
    {
        this.transform.position = startPosition;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularDrag = 70000;
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

    bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            if (hit.collider.CompareTag("Ground")) return true;
            else return false;
        }
        else return false;
    }
}
