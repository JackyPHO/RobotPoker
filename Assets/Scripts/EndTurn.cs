
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public Button endButton;
    public Button foldButton;
    public Button instaLockinButton;
    private int turn = 0;
    public Deck deck;
    public Template playerTemplate;
    [SerializeField] BattleManager batt;
    [SerializeField] BettingScript moneyMGR;

    void Start()
    {
        endButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(false); });
        foldButton.GetComponent<Button>().onClick.AddListener(() => { Fold(); });
        instaLockinButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(true); });
    }

    void TaskOnClick(bool skip)
    {
        if (turn < 2 && !skip)
        {
            moneyMGR.Bet(5);
            deck.DrawHand();
            turn += 1;
            if (turn == 2)
            {
                endButton.interactable = false;
            }
        }
        else if (turn == 3 || skip)
        {
            moneyMGR.Bet(10);
            int npcDraws = Random.Range(0, 3);
            moneyMGR.NPCBet(15 + 5 * npcDraws);
            deck.battleMode = true;
            //call battle manager
            batt.SetPlayer(playerTemplate);
            batt.SetNPC(deck.createNPCRobot(deck.NPCDeck));
            StartCoroutine(batt.BeginBattle());
            instaLockinButton.interactable = false;
            foldButton.interactable = false;
            endButton.interactable = true;

            endButton.GetComponentInChildren<TMP_Text>().text = "Next round";
            endButton.onClick.RemoveAllListeners();
            endButton.GetComponent<Button>().onClick.AddListener(() => { DoResetStuff(); });

        }

    }
    void Fold()
    {
        moneyMGR.Fold();
        DoResetStuff();
    }

    void DoResetStuff()
    {
        instaLockinButton.interactable = true;
        foldButton.interactable = true;
        endButton.interactable = true;
        endButton.GetComponentInChildren<TMP_Text>().text = "Discard/Draw";
        endButton.onClick.RemoveAllListeners();
        endButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(false); });
        deck.battleMode = false;
        deck.ResetDeck();
        deck.DrawHand();
        turn = 0;
        moneyMGR.Bet(5);
        batt.clearBattleText();
        batt.SetPlayer(null);
        batt.SetNPC(null);
    }


}
