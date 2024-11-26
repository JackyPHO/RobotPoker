using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> playerDeck = new List<GameObject>();
    public List<GameObject> playerHand = new List<GameObject>();
    private GameObject[] GetAllCards()
    {
        return GameObject.FindGameObjectsWithTag("Card");
    }
    void Start()
    {
        GameObject[] deck = GetAllCards();
        foreach (GameObject items in deck)
        {
            playerDeck.Add(items);
        }
    }
    void Shuffle(List<GameObject> cards)
    {
        for (int i = (cards.Count-1); i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject tmp = cards[i];
            cards[i] = cards[j];
            cards[j] = tmp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shuffle(playerDeck);
            for(int i = 0; i < 5; i++)
            {
                playerHand.Add(playerDeck[i]);
            }
        }
    }

}
