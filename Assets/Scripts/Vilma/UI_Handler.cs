using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] TMP_Text launchesLeftText;
    [SerializeField] TMP_Text keysCollectedText;
    [SerializeField] TMP_Text resourcesCollectedText;
    [SerializeField] TMP_Text gamePhaseText;

    [SerializeField] Image launchPowerFillImage;
    [SerializeField] Image cardImage;

    [SerializeField] GameObject playCardButton;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playCardPanel;
    [SerializeField] GameObject playCardPanelLayout;
    [SerializeField] GameObject cardInventoryPanel;
    
    Helper helper;

    void Start()
    {
        helper = FindObjectOfType<Helper>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
        UpdateGamePhaseText();
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
        Image image = Instantiate(cardImage, cardInventoryPanel.transform);
        image.sprite = card.CardImage;
    }

    public void PresentCardsFromInventory()
    {
        for (int i = 0; i < helper.playerCardInventory.cardInventory.Count; i++)
        {
            GameObject card = Instantiate(playCardButton, playCardPanelLayout.transform);

            UICardProperties cardProperties = card.GetComponent<UICardProperties>();
            cardProperties.CardImage.sprite = helper.playerCardInventory.cardInventory[i].CardImage;
            cardProperties.CardName.text = helper.playerCardInventory.cardInventory[i].CardName;
            cardProperties.CardDescription.text = helper.playerCardInventory.cardInventory[i].CardDescription;
            cardProperties.CardButton.onClick.AddListener(DeactivatePlayCardPanel);
            Debug.Log(i);
            cardProperties.CardButton.onClick.AddListener(delegate { AddCardEventListenerToButton(helper.playerCardInventory.cardInventory[0]); });
        }
    }

    //MIKS SE EI KUTSU TOTA METODIA
    void AddCardEventListenerToButton(SOCardProperties card)
    {
        Debug.Log(card.name);
        card.CardEvent?.Raise();
    }

    void DeactivatePlayCardPanel()
    {
        playCardPanel.SetActive(false);
    }
}
