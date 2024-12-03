using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Template : MonoBehaviour
{
    public Dictionary<Slot, Card> slots;

    public Slot head;
    public Slot chest;
    public Slot armL;
    public Slot armR;
    public Slot leg;


    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<Slot>();
        chest = GetComponent<Slot>();
        armL = GetComponent<Slot>();
        armR = GetComponent<Slot>();
        leg = GetComponent<Slot>();

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
    public int Speed
    {
        get
        {
            List<Card> vs = slots.Values.ToList();
            int speed = 0;
            vs.ForEach((card) =>
            {
                speed += card.speed;
            });
            return speed;
        }
    }
    public int Health
    {
        get
        {
            List<Card> vs = slots.Values.ToList();
            int health = 0;
            vs.ForEach((card) =>
            {
                health += card.health;
            });
            return health;
        }
    }
    public int Attack
    {
        get
        {
            List<Card> vs = slots.Values.ToList();
            int atk = 0;
            vs.ForEach((card) =>
            {
                atk += card.attack;
            });
            return atk;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
