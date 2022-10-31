//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Collisions_G : Helper_G
//{
//    Vector3 lastVelocity;
//    [SerializeField] float bouncePadForce;
//    float linearDrag;
//    [SerializeField] float frictionAreaDrag;
//    List<GameObject> teleports = new List<GameObject>(2);

//    private void Start()
//    {
//        linearDrag = rigidbody.drag;
//    }
//    void Update()
//    {
//        lastVelocity = rigidbody.velocity;        
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        float speed = lastVelocity.magnitude;
//        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

//        if (collision.gameObject.tag == "Wall")
//        {
//            rigidbody.velocity = direction * speed;
//            audioHandler.PlayWallBonk();
//        }
//        if (collision.gameObject.tag == "Bounce")
//        {
//            rigidbody.velocity = direction * (speed + bouncePadForce);
//            audioHandler.PlayBoing();
//        }
//    }

//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Hole")
//        {
//            transform.position = collision.gameObject.transform.position;
//            movement.ResetMovement();
//            StartCoroutine(HoleAnimation());
//            audioHandler.PlayFallIntoHole();
//        }

//        if (collision.gameObject.tag == "Friction") rigidbody.drag = frictionAreaDrag;

//        if (collision.gameObject.tag == "Finish") eventMethods.GameFinished();
//        if (collision.gameObject.tag == "Teleport")
//        {
//            PlayerPrefs.SetInt("LaunchesAfterTeleport", 0);
//            teleports.Add(collision.gameObject);
//            teleports.Add(collision.gameObject.GetComponent<Teleportation>().partnerPortal);
//        }
//        if (collision.gameObject.tag == "Recharge") //
//        {
//            movement.RechargeLaunchAmount(); //
//            uiHandler.UpdateStrokeAmount(); //
//            collision.gameObject.SetActive(false); //
//        }
//    }

//    void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Friction")  rigidbody.drag = linearDrag;
//    }

//    public void ActivateTeleports()
//    {
//        if (teleports.Count != 0 && PlayerPrefs.GetInt("LaunchesAfterTeleport") == 1)
//        {
//            for (int i = 0; i < teleports.Count; i++)
//            {
//                teleports[i].GetComponent<Teleportation>().canTeleport = true;
//                teleports[i].GetComponent<Teleportation>().ReturnOriginalColor();
//                teleports[i].GetComponent<Collider2D>().enabled = true;
//            }
//            teleports.Clear();
//        }        
//    }

//    public void AddToTeleportPlayerPrefs()
//    {
//        PlayerPrefs.SetInt("LaunchesAfterTeleport", 1);
//    }
//    public void RestartTeleportPlayerPrefs()
//    {
//        PlayerPrefs.SetInt("LaunchesAfterTeleport", 1);
//        for (int i = 0; i < teleports.Count; i++)
//        {
//            teleports[i].GetComponent<Teleportation>().canTeleport = true;
//            teleports[i].GetComponent<Teleportation>().ReturnOriginalColor();
//            teleports[i].GetComponent<Collider2D>().enabled = true;
//        }
//        teleports.Clear();
//    }

//    IEnumerator HoleAnimation()
//    {
//        float elapsedTime = 0;
//        float totalTime = 1.5f;
//        Vector3 currentScale = transform.localScale;
//        Vector3 endScale = new Vector3 (0, 0, 0);

//        while (elapsedTime < totalTime)
//        {
//            elapsedTime += Time.deltaTime;
//            transform.localScale = Vector3.Lerp(currentScale, endScale, elapsedTime / totalTime);
//            yield return null;
//        }
//        transform.position = movement.lastPosition;
//        movement.ResetMovement();
//        transform.localScale = currentScale;
//    }
//}
