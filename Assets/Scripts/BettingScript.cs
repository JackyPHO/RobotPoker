using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BettingScript : MonoBehaviour
{
    [SerializeField] TMP_Text MoneyText;
    [SerializeField] TMP_Text PotText;

    private int playerMoney;
    private int pot;
    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 100;
        pot = 0;
        MoneyText.text = "$" + playerMoney;
        Bet(5);
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "$" + playerMoney;
        PotText.text = "Pot: $" + pot;
    }
    public void Fold()
    {
        pot = 0;
    }
    public void Bet(int amount)
    {
        playerMoney -= amount;
        pot += amount;
    }
    public void NPCBet(int amount)
    {
        pot += amount;
    }
    public void Win()
    {
        playerMoney += pot;
        pot = 0;
    }
    public void Lose()
    {
        pot = 0;
    }
}
