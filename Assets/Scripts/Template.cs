using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Template : MonoBehaviour
{
    public Dictionary<Slot, Card> slots;

    Slot head = new Slot("Head");
    Slot chest = new Slot("Chest");
    Slot armL = new Slot("Arm");
    Slot armR = new Slot("Arm");
    Slot leg = new Slot("Leg");


    // Start is called before the first frame update
    void Start()
    {
        // robot = new Robot();
        slots = new Dictionary<Slot, Card>
        {
            { head, null },
            { chest, null },
            { armL, null },
            { armR, null },
            { leg, null }
        };
    }
    public void TestCard(Card card, Slot slot)
    {
        if (slot != null && slot.IsCompatible(card))
        {
            slots[slot] = card;
        }
    }
    public Dictionary<Slot, Card> GetSlots()
    {
        return slots;
    }
    public List<Card> GetCardData()
    {
        return slots.Values.ToList();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
