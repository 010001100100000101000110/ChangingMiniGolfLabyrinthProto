//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class UIHandler_G : Helper_G
//{
//    LineRenderer line;
//    [SerializeField] Image loadForceImage;
//    [SerializeField] TMP_Text strokeCountingText;

//    bool canRenderLine;

//    void Start()
//    {
//        line = GetComponent<LineRenderer>();
//        UpdateStrokeAmount();
//    }

//    void Update()
//    {
//        if (canRenderLine)
//        {
//            LineRendererTing();
//            UpdateSlider();
//        }
//    }

//    void LineRendererTing()
//    {
//        line.SetPosition(0, player.transform.position);
//        line.SetPosition(1, GetMousePosition());
//    }

//    public void CanLineRender()
//    {
//        canRenderLine = true;
//        line.enabled = true;
//    }

//    public void CantLineRender()
//    {
//        canRenderLine = false;
//        line.enabled = false;
//    }

//    void UpdateSlider()
//    {
//        loadForceImage.fillAmount = GetDistance() / movement.GetMaxDistance();
//    }

//    public void UpdateStrokeAmount()
//    {
//        //strokeCountingText.text = "Launches: " + movement.launchAmount.ToString();

//        strokeCountingText.text = "Launches left: " + movement.LaunchesLeft().ToString(); //        
//    }
//}
