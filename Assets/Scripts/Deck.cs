using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<GameObject> FullDeck;
    public List<GameObject> UsedDeck;
    public List<GameObject> Hand;
    public List<GameObject> DisplayedCards;
    public List<GameObject> SavedCards;

    public Canvas myCanvas;

    void Start()
    {
        ResetDeck();
        DrawHand();
    }
    void ResetDeck()
    {
        UsedDeck = new List<GameObject>(FullDeck);
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
        for (int i = 0; i < 5; i++)
        {
            Hand.Add(UsedDeck[0]);
            UsedDeck.RemoveAt(0);
        }
    }
    public void DrawHand()
    {
        foreach (var cardObj in DisplayedCards)
        {
            Destroy(cardObj);
        }
        takeFive();
        int offset = -100;
        foreach (var card in Hand)
        {
            GameObject tmpCard = Instantiate(card, myCanvas.transform);
            tmpCard.transform.localPosition = new Vector2(offset, 100);
            DisplayedCards.Add(tmpCard);
            offset += 100;
        }
    }
}
