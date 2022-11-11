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
    [SerializeField] TMP_Text infoDescriptionText;

    [Header("Inventory card image and card button prefabs")]
    [SerializeField] Image cardImage;
    [SerializeField] GameObject playCardButton;

    [Header("Panels and their child layouts")]
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playCardPanel;
    [SerializeField] GameObject pickCardPanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject playCardPanelLayout;
    [SerializeField] GameObject cardInventoryLayout;
    [SerializeField] GameObject playCardOrMove;
    
    Helper helper;
    [SerializeField] private InfoDescription tutorialText;
    public enum CardPresenting { Start, Randomized, Inventory}

    void Start()
    {
        helper = FindObjectOfType<Helper>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
        UpdateGamePhaseText();
        ResetUI();
        PresentStartCards();
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

    public void UpdateTutorialText(InfoDescription tutorialText)
    {
        infoDescriptionText.text = tutorialText.tutorialText;
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

    public void ActivatePlayCardOrMovePanel()
    {
        playCardOrMove.SetActive(true);
    }

    public void PresentStartCards()
    {
        PresentCards(CardPresenting.Start);
    }
    public void PresentRandomizedCards()
    {
        PresentCards(CardPresenting.Randomized);
    }
    public void PresentInventoryCards()
    {
        PresentCards(CardPresenting.Inventory);
    }

    void PresentCards(CardPresenting type)
    {
        List<SOCardProperties> cardList = new List<SOCardProperties>();
        switch (type)
        {
            case CardPresenting.Start:
                cardList = helper.cardRandomizer.cards;
                pickCardPanel.SetActive(true);
                break;
            case CardPresenting.Randomized:
                cardList = helper.cardRandomizer.GetRandomizedCards();
                pickCardPanel.SetActive(true);
                break;
            case CardPresenting.Inventory:
                cardList = helper.playerCardInventory.cardInventory;
                playCardPanel.SetActive(true);
                break;      
        }
        playCardPanelLayout.SetActive(true);
        List<GameObject> cards = new List<GameObject>();        

        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject card = Instantiate(playCardButton, playCardPanelLayout.transform);
            UICardProperties cardProperties = card.GetComponent<UICardProperties>();
            cards.Add(card);
            cardProperties.CardImage.sprite = cardList[i].CardImage;
            cardProperties.CardName.text = cardList[i].CardName;
            cardProperties.CardDescription.text = cardList[i].CardDescription;
            int number = i;

            if (type == CardPresenting.Start)
            {
                cardProperties.CardButton.onClick.AddListener(delegate { AddPickCardEventListener(cardList[number], cards); });
                cardProperties.CardButton.onClick.AddListener(delegate { UpdateTutorialText(tutorialText); });
                cardProperties.CardButton.onClick.AddListener(delegate { playCardOrMove.SetActive(true); });
            }
            if (type == CardPresenting.Randomized)
            {
                cardProperties.CardButton.onClick.AddListener(delegate { AddPickCardEventListener(cardList[number], cards); });
            }
            if (type == CardPresenting.Inventory)
            {
                cardProperties.CardButton.onClick.AddListener(delegate { AddInventoryCardEventListener(cardList[number], cards); });
            }    
        }
    }

    void AddPickCardEventListener(SOCardProperties card, List<GameObject> cardUI)
    {
        AddCardImageToInventory(card);
        helper.playerCardInventory.AddCardToInventory(card);

        for (int i = 0; i < cardUI.Count; i++)
        {
            cardUI[i].SetActive(false);
        }
        pickCardPanel.SetActive(false);
    }

    void AddInventoryCardEventListener(SOCardProperties card, List<GameObject> cardUI)
    {
        card.CardEvent?.Raise();
        helper.playerCardInventory.RemoveCardFromInventory(card);
        RemoveCardImageFromInventory(card);

        for (int i = 0; i < cardUI.Count; i++)
        {
            cardUI[i].SetActive(false);
        }
        playCardPanel.SetActive(false);
    }
    public void ResetCardInventory()
    {
        for (var i = cardInventoryLayout.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(cardInventoryLayout.transform.GetChild(i).gameObject);
        }
    }

    public void ResetCardsOnScreen()
    {
        for (int i = 0; i < playCardPanelLayout.transform.childCount; i++)
        {
            playCardPanelLayout.transform.GetChild(i).gameObject.SetActive(false);
        }

        
    }
}
