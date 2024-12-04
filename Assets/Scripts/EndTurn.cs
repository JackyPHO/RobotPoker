using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public Button endButton;
    private int turn = 0;
    public Deck deck;

    void Start()
    {   
        Button btn = endButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        turn += 1;
        if (turn < 3){
            deck.DrawHand();
        }
        else{
            //call battle manager
        }
    }


}
