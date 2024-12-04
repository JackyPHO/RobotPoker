using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<GameObject> FullDeck;
    public List<GameObject> NPCDeck;
    public List<GameObject> UsedDeck;
    public List<GameObject> Hand;
    public List<GameObject> SavedCards;

    public GameObject NO_CARD;

    [SerializeField] GameObject cardSelector;

    private GameObject selectedCard;

    [SerializeField] Template playerTemplate;
    [SerializeField] Template npcRobot;

    public Canvas myCanvas;

    void Start()
    {
        NPCDeck = new List<GameObject>(FullDeck);
        ResetDeck();
        DrawHand();
    }
    public void ResetDeck()
    {
        selectedCard = null;
        playerTemplate.ClearSlots();
        npcRobot.ClearSlots();
        for (int i = 0; i < Hand.Count; i++)
        {
            if (Hand[i] != NO_CARD)
            {
                Destroy(Hand[i]);
            }
        }
        for (int i = 0; i < SavedCards.Count; i++)
        {
            if (SavedCards[i] != NO_CARD)
            {
                Destroy(SavedCards[i]);
            }
        }
        Hand.Clear();
        SavedCards.Clear();
        UsedDeck = new List<GameObject>(FullDeck);
        Shuffle(NPCDeck);
        Shuffle(UsedDeck);
    }

    public void Shuffle(List<GameObject> cards)
    {
        for (int i = (cards.Count - 1); i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject tmp = cards[i];
            cards[i] = cards[j];
            cards[j] = tmp;
        }
    }

    public void takeFive()
    {
        int offset = -300;

        for (int i = 0; i < 5; i++)
        {
            GameObject tmpCard = Instantiate(UsedDeck[0], myCanvas.transform);
            Hand.Add(tmpCard);
            tmpCard.transform.localPosition = new Vector3(offset, -400, -2);
            tmpCard.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            offset += 200;

            UsedDeck.RemoveAt(0);
        }
    }
    public void DrawHand()
    {
        selectedCard = null;
        for (int i = 0; i < Hand.Count; i++)
        {
            if (Hand[i] != NO_CARD)
            {
                Destroy(Hand[i]);
            }
        }
        Hand.Clear();
        takeFive();
    }

    public Template createNPCRobot(List<GameObject> cards)
    {

        for (int i = 0; i < cards.Count; i++)
        {
            GameObject card = cards[i];
            if (npcRobot.head.IsCompatible(card.GetComponent<Card>()))
            {
                npcRobot.SetCard(card, npcRobot.head);
            }
            if (npcRobot.chest.IsCompatible(card.GetComponent<Card>()))
            {
                npcRobot.SetCard(card, npcRobot.chest);
            }
            if (npcRobot.leg.IsCompatible(card.GetComponent<Card>()))
            {
                npcRobot.SetCard(card, npcRobot.leg);
            }
            if (npcRobot.armR.IsCompatible(card.GetComponent<Card>()))
            {
                npcRobot.SetCard(card, npcRobot.armR);
            }
            if (npcRobot.armL.IsCompatible(card.GetComponent<Card>()))
            {
                npcRobot.SetCard(card, npcRobot.armL);
            }
        }
        return npcRobot;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cardSelector.transform.localPosition = new Vector2(-300, -400);
            selectedCard = Hand[0];
            Debug.Log("card is:" + selectedCard.GetComponent<Card>().name);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardSelector.transform.localPosition = new Vector2(-100, -400);
            selectedCard = Hand[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cardSelector.transform.localPosition = new Vector2(100, -400);
            selectedCard = Hand[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cardSelector.transform.localPosition = new Vector2(300, -400);
            selectedCard = Hand[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cardSelector.transform.localPosition = new Vector2(500, -400);
            selectedCard = Hand[4];
        }

        if (Input.GetKeyDown(KeyCode.E) && selectedCard != null && selectedCard != NO_CARD)
        {
            Slot found = null;

            foreach (var slot in playerTemplate.slots)
            {
                if (found != null) { continue; }
                Debug.Log("slotkey:" + slot.Key);

                found = playerTemplate.TestCard(selectedCard.GetComponent<Card>(), slot.Key) ? slot.Key : null;
            }
            if (found != null)
            {
                Debug.Log("found a place for the card to go.");
                playerTemplate.SetCard(selectedCard, found);
                int index = Hand.IndexOf(selectedCard);
                Hand[index] = NO_CARD;
                SavedCards.Add(selectedCard);

                selectedCard.transform.position = new Vector2(found.transform.position.x, found.transform.position.y);
                selectedCard = null;
                cardSelector.transform.position = new Vector2(10000, 100000);
            }
        }

    }
}
