using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPhase : MonoBehaviour
{
    public Button endButton;
    private int phase = 0;
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
        phase += 1;
        if (phase < 3){
            deck.takeFive();
        }
        else{
            //call battle manager
        }
    }


}
