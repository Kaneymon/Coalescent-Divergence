using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{
    private int money;

    [SerializeField]
    Text moneyText;

    public int GetPlayerMoneyCount()
    {
        return money;
    }

    public void SetPlayerMoneyCount(int newMoneyCount)
    {
        money = newMoneyCount;
    }

    public void AddToMoneyToCount(int additionalMoney)
    {
        money += additionalMoney;
    }

    public void TakeFromMoneyCount(int subtractedMoney)
    {
        if (money <=0)
        {
            return;
        }
        money -= subtractedMoney;
    }

    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
