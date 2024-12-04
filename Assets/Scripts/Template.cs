using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Template : MonoBehaviour
{
    public Dictionary<Slot, GameObject> slots;

    public Slot head;
    public Slot chest;
    public Slot armL;
    public Slot armR;
    public Slot leg;

    [SerializeField] GameObject noCard;


    // Start is called before the first frame update
    void Start()
    {
        Slot[] tmp_slots = GetComponentsInChildren<Slot>();
        head = tmp_slots[0];
        chest = tmp_slots[1];
        armL = tmp_slots[2];
        armR = tmp_slots[3];
        leg = tmp_slots[4];

        slots = new Dictionary<Slot, GameObject>
        {
            { head, noCard },
            { chest, noCard },
            { armL, noCard },
            { armR, noCard },
            { leg, noCard }
        };
    }
    public void TestCard(Card card, Slot slot)
    {
        if (slot != null && slot.IsCompatible(card))
        {
            slots[slot] = card.gameObject;
        }
    }
    public Dictionary<Slot, GameObject> GetSlots()
    {
        return slots;
    }
    public List<Card> GetCardData()
    {
        List<GameObject> obj_list = slots.Values.ToList();
        List<Card> retList = new();
        foreach (var obj in obj_list)
        {
            retList.Add(obj.GetComponent<Card>());
        }
        return retList;
    }
    public int Speed
    {
        get
        {
            List<Card> vs = GetCardData();
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
            List<Card> vs = GetCardData();
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
            List<Card> vs = GetCardData();
            int atk = 0;
            vs.ForEach((card) =>
            {
                atk += card.attack;
            });
            return atk;
        }
    }


    public bool isComplete()
    {
        if (slots.ContainsValue(null))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
