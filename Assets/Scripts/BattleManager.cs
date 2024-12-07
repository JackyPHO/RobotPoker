using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Template player;
    private Template npc;

    [SerializeField] BettingScript MoneyMGR;

    [SerializeField] TMP_Text playerDisplay;
    [SerializeField] TMP_Text npcDisplay;
    [SerializeField] TMP_Text turnTracker;
    private string trackerText;

    private AudioSource ourAudioSource;

    [SerializeField] 
    private AudioClip Slash;
    [SerializeField]
    private AudioClip Woosh;
    [SerializeField]
    private AudioClip Bang;
    [SerializeField]
    private AudioClip Clang;
    [SerializeField]
    private AudioClip Dong;
    [SerializeField]
    private AudioClip Bell;
    [SerializeField]
    private AudioClip Hit;


    void Start()
    {
        ourAudioSource = GetComponent<AudioSource>();
    }

    public void SetPlayer(Template t)
    {
        this.player = t;
        if (t)
        {
            playerDisplay.text = "Player:\n" + "hp: " + player.Health + "\nattack: " + player.Attack + "\nSpeed: " + player.Speed;

        }
        else
        {
            playerDisplay.text = "Player";
        }
    }
    public void SetNPC(Template t)
    {
        this.npc = t;
        if (t)
        {
            npcDisplay.text = "Joe:\n" + "hp: " + npc.Health + "\nattack: " + npc.Attack + "\nSpeed: " + npc.Speed;

        }
        else
        {
            npcDisplay.text = "Joe";

        }

    }
    public void clearBattleText()
    {
        turnTracker.text = "";
    }


    public IEnumerator BeginBattle()
    {
        // ---------- Battle calcs ----------

        string whoIsFaster = determineFastest(in player, in npc, out Template fastest, out Template slowest);
        string whoIsSlower = whoIsFaster == "Player" ? "Joe" : "Player";
        int tmpSpeed = fastest.Speed;
        int extraTurns = 0;
        while (tmpSpeed >= slowest.Speed)
        {
            extraTurns++;
            tmpSpeed /= 2;
        }
        turnTracker.text = "" + whoIsFaster + " moves first.";
        int fHP = fastest.Health, sHP = slowest.Health;

        ourAudioSource.PlayOneShot(Bell);

        yield return new WaitForSeconds(1f);
        while (fHP > 0 && sHP > 0)
        {
            for (int i = 0; i < extraTurns; i++)
            {
                turnTracker.text = turnTracker.text + "\n" + whoIsFaster + " attacked for " + fastest.Attack;
                sHP -= fastest.Attack;
                ourAudioSource.PlayOneShot(Slash);
                yield return new WaitForSeconds(0.5f);
                if (sHP <= 0)
                {
                    trackerText = turnTracker.text + "\nwinner = " + whoIsFaster;
                    turnTracker.text = trackerText;
                    ourAudioSource.PlayOneShot(Clang);
                    yield return new WaitForSeconds(0.3f);
                    declareWinner(whoIsFaster);
                    yield break;
                }

            }
            yield return new WaitForSeconds(0.5f);
            turnTracker.text = turnTracker.text + "\n" + whoIsSlower + " attacked for " + slowest.Attack;
            fHP -= slowest.Attack;
            ourAudioSource.PlayOneShot(Bang);
            yield return new WaitForSeconds(0.3f);
            if (fHP <= 0)
            {

                trackerText = turnTracker.text + "\nwinner = " + whoIsSlower;
                turnTracker.text = trackerText;
                ourAudioSource.PlayOneShot(Hit);
                yield return new WaitForSeconds(0.3f);
                declareWinner(whoIsSlower);
                yield break;
            }
            yield return new WaitForSeconds(0.5f);

        }




    }
    string determineFastest(in Template player, in Template npc, out Template fastest, out Template slowest)
    {
        if (player.Speed > npc.Speed)
        {
            fastest = player;
            slowest = npc;
            return "Player";
        }
        else
        {
            fastest = npc;
            slowest = player;
            return "Joe";
        }
    }

    void declareWinner(string who)
    {
        if (who == "Player")
        {
            MoneyMGR.Win();
        }
        else
        {
            MoneyMGR.Lose();
        }
    }
}
