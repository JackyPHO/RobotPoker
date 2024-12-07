using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Template player;
    private Template npc;

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
    private AudioClip Hit;


    void Start(){
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
        turnTracker.text = "" + whoIsFaster + " moves first.";
        int fHP = fastest.Health, sHP = slowest.Health;
        ourAudioSource.PlayOneShot(Slash);
        Thread.Sleep(300);
        ourAudioSource.PlayOneShot(Bang);
        Thread.Sleep(300);
        ourAudioSource.PlayOneShot(Clang);
        Thread.Sleep(300);
        ourAudioSource.PlayOneShot(Hit);
        Thread.Sleep(300);
        ourAudioSource.PlayOneShot(Woosh);
        Thread.Sleep(300);
        ourAudioSource.PlayOneShot(Dong);
        Thread.Sleep(500);
        while (fHP > 0 && sHP > 0)
        {
            for (int i = 0; i < extraTurns; i++)
            {
                turnTracker.text = turnTracker.text + "\n" + whoIsFaster + " attacked for " + fastest.Attack;
                sHP -= fastest.Attack;
            }
            turnTracker.text = turnTracker.text + "\n" + whoIsSlower + " attacked for " + slowest.Attack;
            fHP -= slowest.Attack;
        }
        if (fHP <= 0)
        {
            trackerText = turnTracker.text + "\nwinner = " + whoIsSlower;
            turnTracker.text = trackerText;

            return whoIsSlower;
        }
        else
        {
            trackerText = turnTracker.text + "\nwinner = " + whoIsFaster;
            turnTracker.text = trackerText;

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
