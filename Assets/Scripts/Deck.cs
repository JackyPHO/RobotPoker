using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Deck : MonoBehaviour
{

    public List<GameObject> FullDeck;
    public List<GameObject> NPCDeck;
    public List<GameObject> UsedDeck;
    public List<GameObject> Hand;
    public List<GameObject> SavedCards;
    public bool battleMode = false;

    public GameObject NO_CARD;

    [SerializeField] GameObject cardSelector;

    private GameObject selectedCard;
    private GameObject checkCard;

    [SerializeField] Template playerTemplate;
    [SerializeField] Template npcRobot;

    [SerializeField] BattleManager battMGR;

    public Canvas myCanvas;

    private AudioSource audioData;

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
        int offset = -600;

        for (int i = 0; i < 5; i++)
        {
            GameObject tmpCard = Instantiate(UsedDeck[0], myCanvas.transform);
            Hand.Add(tmpCard);
            tmpCard.transform.localPosition = new Vector3(offset, -400, -2);
            tmpCard.transform.localScale = new Vector3(20, 20, 1f);
            offset += 250;

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
            Slot found = null;
            foreach (var slot in npcRobot.slots)
            {
                if (found != null) { continue; }
                Debug.Log("slotkey:" + slot.Key);

                found = npcRobot.TestCard(card.GetComponent<Card>(), slot.Key) ? slot.Key : null;
            }
            if (found != null)
            {
                GameObject tmp_card = Instantiate(card, myCanvas.transform);
                npcRobot.SetCard(tmp_card, found);
                SavedCards.Add(tmp_card);

                tmp_card.transform.position = new Vector2(found.transform.position.x, found.transform.position.y);
                tmp_card.transform.localScale = new Vector3(20f, 20f, 1f);

            }

        }
        return npcRobot;
    }

    void Update()
    {
        if (!battleMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D check = Physics2D.Raycast(mouse, Vector2.zero);
                if (check.collider != null && check.collider.gameObject.CompareTag("Card"))
                {
                    if (check.collider.gameObject == Hand[0])
                    {
                        cardSelector.transform.localPosition = new Vector2(-600, -400);
                        selectedCard = Hand[0];
                    }
                    else if (check.collider.gameObject == Hand[1])
                    {
                        cardSelector.transform.localPosition = new Vector2(-350, -400);
                        selectedCard = Hand[1];
                    }
                    else if (check.collider.gameObject == Hand[2])
                    {
                        cardSelector.transform.localPosition = new Vector2(-100, -400);
                        selectedCard = Hand[2];
                    }
                    else if (check.collider.gameObject == Hand[3])
                    {
                        cardSelector.transform.localPosition = new Vector2(150, -400);
                        selectedCard = Hand[3];
                    }
                    else if (check.collider.gameObject == Hand[4])
                    {
                        cardSelector.transform.localPosition = new Vector2(400, -400);
                        selectedCard = Hand[4];
                    }
                }
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
                    audioData = GetComponent<AudioSource>();
                    audioData.Play();
                    int index = Hand.IndexOf(selectedCard);
                    Hand[index] = NO_CARD;
                    SavedCards.Add(selectedCard);

                    selectedCard.transform.position = new Vector2(found.transform.position.x, found.transform.position.y);
                    selectedCard = null;
                    cardSelector.transform.position = new Vector2(10000, 100000);
                    battMGR.SetPlayer(playerTemplate);
                }
            }
        }


    }
}
