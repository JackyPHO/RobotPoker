using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Template : MonoBehaviour
{
    enum PartType {Head, Chest, Arm, Leg};
    Dictionary<string, Card> slots;
    Robot robot;

    // Start is called before the first frame update
    void Start()
    {
        robot = new Robot();
        slots = new Dictionary<string, Card>();
        slots.Add("Head", null);
        slots.Add("Chest", null);
        slots.Add("ArmL", null);
        slots.Add("ArmR", null);
        slots.Add("LegL", null);
        slots.Add("LegR", null);   
    }

    private void TestCard(Card card, string slotTitle)
    {
        if (slotTitle.StartsWith(card.type))
        {
            // add new part to robot
        }
    }

    void GetRobot()
    {
        return robot;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}