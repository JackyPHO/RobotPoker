using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Template : MonoBehaviour
{
    Dictionary<string, Card> slots;

    // Start is called before the first frame update
    void Start()
    {
        // robot = new Robot();
        slots = new Dictionary<string, Card>
        {
            { "Head", null },
            { "Chest", null },
            { "ArmL", null },
            { "ArmR", null },
            { "Legs" , null }
        };
    }

    public void TestCard(Card card, string slotTitle)
    {
        if (slotTitle.StartsWith(card.GetCardType()))
        {
            slots[slotTitle] = card;
        }
    }

    public void GetRobot()
    {
        // return robot;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
