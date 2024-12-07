using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        endButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(false); });
        instaLockinButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(true); });
    }

    void TaskOnClick(bool skip)
    {
        if (turn < 2 && !skip)
        {
            deck.DrawHand();

        }
        else
        {
            deck.battleMode = true;
            //call battle manager
            batt.SetPlayer(playerTemplate);
            batt.SetNPC(deck.createNPCRobot(deck.NPCDeck));
            StartCoroutine(batt.BeginBattle());

            endButton.GetComponentInChildren<TMP_Text>().text = "Next round";
            endButton.onClick.RemoveAllListeners();
            endButton.GetComponent<Button>().onClick.AddListener(() => { DoResetStuff(); });

        }
        turn += 1;
        if (turn == 2)
        {
            endButton.GetComponentInChildren<TMP_Text>().text = "Begin Battle!";
        }
    }

    void DoResetStuff()
    {

        endButton.GetComponentInChildren<TMP_Text>().text = "Discard/Draw";
        endButton.onClick.RemoveAllListeners();
        endButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(false); });
        deck.battleMode = false;
        deck.ResetDeck();
        deck.DrawHand();
        turn = 0;
        batt.clearBattleText();
        batt.SetPlayer(null);
        batt.SetNPC(null);
    }


}
