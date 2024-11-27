using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Template : MonoBehaviour
{
    Dictionary<Slot, Card> slots;

    public Slot head = new Slot("Head");
    public Slot chest = new Slot("Chest");
    public Slot armL = new Slot("Arm");
    public Slot armR = new Slot("Arm");
    public Slot leg = new Slot("Leg");


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
    public void GetRobot()
    {
        // return robot;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
