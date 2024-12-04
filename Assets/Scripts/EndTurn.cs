using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public Button endButton;
    public Button instaLockinButton;
    private int turn = 0;
    public Deck deck;
    public Template playerTemplate;
    [SerializeField] BattleManager batt;

    void Start()
    {   
		endButton.GetComponent<Button>().onClick.AddListener(()=>{TaskOnClick(false);});
		instaLockinButton.GetComponent<Button>().onClick.AddListener(()=>{TaskOnClick(true);});
    }

    void TaskOnClick(bool skip)
    {
        turn += 1;
        if (turn < 3 && !skip){
            deck.DrawHand();
        }
        else{
            //call battle manager
            batt.SetPlayer(playerTemplate);
            batt.SetNPC(deck.createNPCRobot(deck.NPCDeck));
            batt.BeginBattle();
        }
    }


}
