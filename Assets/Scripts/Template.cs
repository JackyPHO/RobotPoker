using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Template : MonoBehaviour
{
    enum Type {Head, Chest, Arm, Leg};
    Slot[] slots;

    struct Slot
    {
        Type type;
        Card card;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
