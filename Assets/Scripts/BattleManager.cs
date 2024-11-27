using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Template player;
    private Template npc;


    public void SetPlayer(Template t)
    {
        this.player = t;
    }
    public void SetNPC(Template t)
    {
        this.npc = t;
    }

    public void BeginBattle()
    {
        
    }
}
