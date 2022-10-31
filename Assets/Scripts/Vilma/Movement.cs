//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Movement : Helper_G
//{
//    UIHandler_G ballUI; 
//    GameObject selected;
//    [SerializeField] bool canLaunch;
//    [SerializeField] float launchForce;
//    [SerializeField] float maxPullDistance;
//    public int launchAmount { get; private set; }
//    public Vector3 lastPosition { get; private set; }
//    float currentDrag;
//    float currentAngularDrag;

//    [SerializeField] int launchesLeft; //
//    [SerializeField] int launchCapacity; //

//    private void OnEnable()
//    {
//        launchesLeft = launchCapacity;
//    }

//    void Start()
//    {
//        ballUI = FindObjectOfType<UIHandler_G>();
//        canLaunch = true;
//        currentDrag = rigidbody.drag;
//        currentAngularDrag = rigidbody.angularDrag;        
//    }


//    void Update()
//    {
//        if (canLaunch) LaunchBallMode();
//        if (!canLaunch) StopBallVelocity();        
//    }

//    void LaunchBallMode()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Collider2D targetObject = Physics2D.OverlapPoint(GetMousePosition());
//            if (targetObject) selected = targetObject.transform.gameObject;
//        }
//        if (selected && selected.tag == "Player") ballUI.CanLineRender();
//        if (Input.GetMouseButtonUp(0) && selected && selected.tag == "Player")
//        {
//            selected = null;
//            ballUI.CantLineRender();
//            LaunchBall();
//        }
//    }

//    void LaunchBall()
//    {
//        rigidbody.bodyType = RigidbodyType2D.Dynamic;
//        rigidbody.constraints = RigidbodyConstraints2D.None;        
//        rigidbody.freezeRotation = false;        

//        Vector2 playerPos = transform.position;
//        Vector2 trajectoryDir = (playerPos - GetMousePosition()).normalized;
//        float clampDistance = Mathf.Clamp(GetDistance(), 0, maxPullDistance);
//        float force = clampDistance * launchForce;

//        lastPosition = this.transform.position;
//        rigidbody.AddForce(trajectoryDir * force, ForceMode2D.Impulse);
//        eventMethods.BallLaunched();
//        canLaunch = false;
//    }
//    public void CanLaunch()
//    {
//        canLaunch = true;
//    }
//    public void CantLaunch()
//    {
//        canLaunch = false;
//    }
//    public float GetMaxDistance()
//    {
//        return maxPullDistance;
//    }

//    public void ResetMovement()
//    {
//        rigidbody.velocity = new Vector3(0, 0, 0);
//        rigidbody.freezeRotation = true;
//        this.transform.rotation = Quaternion.identity;
//        rigidbody.freezeRotation = false;
//    }
//    void StopBallVelocity()
//    {
//        if (rigidbody.velocity.magnitude < 0.7 && rigidbody.velocity.magnitude > 0)
//        {
//            rigidbody.drag = 50;
//            rigidbody.angularDrag = 50;
//        }
//        if (rigidbody.velocity.magnitude == 0)
//        {
//            eventMethods.BallStopped();
//            rigidbody.drag = currentDrag;
//            rigidbody.angularDrag = currentAngularDrag;
//        }
//    }

//    public void AddToLaunchAmount()
//    {
//        launchAmount++;
//    }
//    public void ResetLaunchAmount()
//    {
//        launchAmount = 0;
//    }

//    //
//    public int LaunchesLeft()
//    {
//        return launchesLeft;
//    }
//    public void RechargeLaunchAmount()
//    {
//        launchesLeft = launchCapacity;
//    }
//    public void SubtractFromLaunchAmountLeft()
//    {
//        launchesLeft--;
//    }

//    public void CheckIfNoCharges()
//    {
//        if (launchesLeft == 0) eventMethods.ChargesDrained();
//    }
//    //
//}
