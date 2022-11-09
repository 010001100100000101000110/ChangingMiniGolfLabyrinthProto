using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Handler : MonoBehaviour
{
    [Header("LaunchPowerIndicator")]
    [SerializeField] Image launchPowerFillImage;

    [Header("UI Texts")]

    [SerializeField] TMP_Text launchesLeftText;
    [SerializeField] TMP_Text keysCollectedText;
    [SerializeField] TMP_Text resourcesCollectedText;
    [SerializeField] TMP_Text gamePhaseText;

    [Header("Inventory card image and card button prefabs")]
    [SerializeField] Image cardImage;
    [SerializeField] GameObject playCardButton;

    [Header("Panels and their child layouts")]
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playCardPanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject playCardPanelLayout;
    [SerializeField] GameObject cardInventoryLayout;
    
    Helper helper;

    void Start()
    {
        helper = FindObjectOfType<Helper>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
        UpdateGamePhaseText();
        ResetUI();
        StartInventory();
    }

    void ResetUI()
    {
        inGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        playCardPanel.SetActive(false);
        finishPanel.SetActive(false);
    }

    void Update()
    {
        if (helper.controller.ballSelected) UpdateSlider();
    }

    void UpdateSlider()
    {
        launchPowerFillImage.fillAmount = helper.controller.GetDistance() / helper.controller.GetMaxDistance();
    }

    public void UpdateLaunchesLeftAmount()
    {
        launchesLeftText.text = "Launches left: " + helper.launchTracker.launchesLeft.ToString();
    }

    public void UpdateKeysCollectedAmount()
    {
        keysCollectedText.text = "Keys collected: " + helper.inventory.KeysCollected;
    }

    public void UpdateResourcesCollectedAmount()
    {
        resourcesCollectedText.text = "Resources collected: " + helper.inventory.ResourcesCollected;
    }

    public void SetActiveGameOverPanel()
    {
        if (helper.launchTracker.launchesLeft <= 0) gameOverPanel.SetActive(true);
    }

    public void UpdateGamePhaseText()
    {
        gamePhaseText.text = "Game Phase: " + GamePhaseManager.Instance.gamePhase;
    }

    public void AddCardImageToInventory(SOCardProperties card)
    {
        Image image = Instantiate(cardImage, cardInventoryLayout.transform);
        image.sprite = card.CardImage;
    }

    public void RemoveCardImageFromInventory(SOCardProperties card)
    {
        Image[] images = cardInventoryLayout.GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].sprite.name == card.CardImage.name) Destroy(images[i]);
        }
    }

    void StartInventory()
    {
        for (int i = 0; i < helper.playerCardInventory.cardInventory.Count; i++)
        {
            AddCardImageToInventory(helper.playerCardInventory.cardInventory[i]);
        }
    }

    public void PresentCardsFromInventory()
    {
        List<GameObject> cards = new List<GameObject>();
        for (int i = 0; i < helper.playerCardInventory.cardInventory.Count; i++)
        {
            GameObject card = Instantiate(playCardButton, playCardPanelLayout.transform);            
            UICardProperties cardProperties = card.GetComponent<UICardProperties>();
            cards.Add(card);
            cardProperties.CardImage.sprite = helper.playerCardInventory.cardInventory[i].CardImage;
            cardProperties.CardName.text = helper.playerCardInventory.cardInventory[i].CardName;
            cardProperties.CardDescription.text = helper.playerCardInventory.cardInventory[i].CardDescription;
            cardProperties.CardButton.onClick.AddListener(DeactivatePlayCardPanel);
            int number = i;
            cardProperties.CardButton.onClick.AddListener(delegate { AddCardEventListenerToButton(helper.playerCardInventory.cardInventory[number], cards); });
        }
    }

    void AddCardEventListenerToButton(SOCardProperties card, List<GameObject> cardUI)
    {
        card.CardEvent?.Raise();
        helper.playerCardInventory.RemoveCardFromInventory(card);
        RemoveCardImageFromInventory(card);

        for (int i = 0; i < cardUI.Count; i++)
        {
            cardUI[i].SetActive(false);
        }        
    }

    void DeactivatePlayCardPanel()
    {
        playCardPanel.SetActive(false);
    }  
    
    public void ResetCardInventory()
    {
        for (var i = cardInventoryLayout.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(cardInventoryLayout.transform.GetChild(i).gameObject);
        }
    }
}
