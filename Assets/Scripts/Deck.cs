using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Sprite> MainDeck;
    private List<Sprite> Hand;

    public Deck()
    {
        MainDeck = new List<Sprite>();
    }
    void Shuffle(List<Sprite> cards)
    {
        for (int i = (cards.Count-1); i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Sprite tmp = cards[i];
            cards[i] = cards[j];
            cards[j] = tmp;
        }
    }
    void takeFive()
    {
        Shuffle(MainDeck);
        for (int i = 0; i < 5; i++)
        {
            Hand.Add(MainDeck[0]);
            MainDeck.RemoveAt(0);
        }
    }
}
