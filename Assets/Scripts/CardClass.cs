using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string type;
    public int health;
    public int speed;
    public int attack;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetCardType()
    {
        return type;
    }
}
