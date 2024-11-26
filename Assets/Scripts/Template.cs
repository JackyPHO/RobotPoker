using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Template : MonoBehaviour
{
    enum PartType {Head, Chest, Arm, Leg};
    Dictionary<string, Card> slots = new Dictionary<string, Card>();

    // Start is called before the first frame update
    void Start()
    {
        slots.Add("Head", null);
        slots.Add("Chest", null);
        slots.Add("ArmL", null);
        slots.Add("ArmR", null);
        slots.Add("LegL", null);
        slots.Add("LegR", null);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
