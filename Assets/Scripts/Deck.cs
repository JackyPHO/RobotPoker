using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Sprite> Deck;
    private List<Sprite> Hand;

    public Deck()
    {
        List<Sprite> Deck;
    }
    void Shuffle(List<Sprite> cards)
    {
        for (int i = (cards.Count-1); i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject tmp = cards[i];
            cards[i] = cards[j];
            cards[j] = tmp;
        }
    }
    void takeFive()
    {
        Shuffle(Deck);
        for (int i = 0; i < 5; i++)
        {
            Hand.Add(Deck[0]);
            Deck.RemoveAt(0);
        }
    }
}
