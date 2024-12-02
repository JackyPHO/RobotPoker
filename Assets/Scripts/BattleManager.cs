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

    [SerializeField] TMP_Text playerDisplay;
    [SerializeField] TMP_Text npcDisplay;
    [SerializeField] TMP_Text turnTracker;
    private string trackerText;


    public void SetPlayer(Template t)
    {
        this.player = t;
        playerDisplay.text = "Player:\n" + "hp: " + player.Health + "\nattack: " + player.Attack + "\nSpeed: " + player.Speed;
    }
    public void SetNPC(Template t)
    {
        this.npc = t;
    }

    public string BeginBattle()
    {
        // ---------- Battle calcs ----------

        string whoIsFaster = determineFastest(in player, in npc, out Template fastest, out Template slowest);
        string whoIsSlower = whoIsFaster == "player" ? "npc" : "player";
        int tmpSpeed = fastest.Speed;
        int extraTurns = 0;
        while (tmpSpeed > slowest.Speed)
        {
            extraTurns++;
            tmpSpeed /= 2;
        }
        trackerText = "faster is " + whoIsFaster + "\nwill move " + extraTurns + " per one move of " + whoIsSlower;
        turnTracker.text = trackerText;
        int fHP = fastest.Health, sHP = slowest.Health;
        while (fHP > 0 && sHP > 0)
        {
            for (int i = 0; i < extraTurns; i++)
            {
                trackerText += "\n" + whoIsFaster + " attacked for " + fastest.Attack;
                sHP -= fastest.Attack;
            }
            trackerText += "\n" + whoIsSlower + " attacked for " + slowest.Attack;
            fHP -= slowest.Attack;
        }
        if (fHP <= 0)
        {
            trackerText += "winner = " + whoIsSlower;
            return whoIsSlower;
        }
        else
        {
            trackerText += "winner = " + whoIsFaster;
            return whoIsFaster;
        }



    }
    string determineFastest(in Template player, in Template npc, out Template fastest, out Template slowest)
    {
        if (player.Speed > npc.Speed)
        {
            fastest = player;
            slowest = npc;
            return "player";
        }
        else
        {
            fastest = npc;
            slowest = player;
            return "npc";
        }
    }
}
