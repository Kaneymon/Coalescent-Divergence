using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameObject UpgradesPanel;
    [SerializeField]
    GunScript myGun;
    [SerializeField]
    MoneyHandler moneyScript;

    [Header("Upgrade Cost Text Components")]
    [SerializeField]
    Text DmgCostText;
    [SerializeField]
    Text FireRateCostText;
    [SerializeField]
    Text MagSizeCostText;
    [SerializeField]
    Text ReloadSpeedCostText;

    [Header("Gun Stat Count Text Components")]
    [SerializeField]
    Text DmgText;
    [SerializeField]
    Text FireRateText;
    [SerializeField]
    Text MagSizeText;
    [SerializeField]
    Text ReloadSpeedText;

    private void Update()
    {
        DmgCostText.text = upgradeBulletDmgCost.ToString();
        FireRateCostText.text = upgradeFireRateCost.ToString();
        MagSizeCostText.text = upgradeMagSizeCost.ToString();
        ReloadSpeedCostText.text = upgradeReloadSpeedCost.ToString();

        DmgText.text = myGun.GetBulletDamage().ToString();
        FireRateText.text = myGun.GetFireRate().ToString();
        MagSizeText.text = myGun.GetMagSize().ToString();
        ReloadSpeedText.text = myGun.GetReloadTime().ToString();
    }

    public void ToggleUpgrades()
    {
        UpgradesPanel.SetActive(!UpgradesPanel.activeSelf);
        if (UpgradesPanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    int upgradeBulletDmgCost = 1;
    int upgradeMagSizeCost = 1;
    int upgradeFireRateCost = 1;
    int upgradeReloadSpeedCost = 1;

    public void UpgradeBulletDamage()
    {
        if (moneyScript.GetPlayerMoneyCount() < upgradeBulletDmgCost) { return; }
        myGun.SetBulletDamage(myGun.GetBulletDamage() + 1);
        DeductCost(upgradeBulletDmgCost);
        upgradeBulletDmgCost += 5;
    }

    public void UpgradeFireRate()
    {
        if (moneyScript.GetPlayerMoneyCount() < upgradeFireRateCost) { return; }
        myGun.SetFireRate(myGun.GetFireRate() + 0.5f);
        DeductCost(upgradeFireRateCost);
        upgradeFireRateCost += 2;
    }

    public void UpgradeMagSize()
    {
        if (moneyScript.GetPlayerMoneyCount() < upgradeMagSizeCost) { return; }
        myGun.SetMagSize(myGun.GetMagSize() + 1);
        DeductCost(upgradeMagSizeCost);
        upgradeMagSizeCost += 1;
    }

    public void UpgradeReloadSpeed()
    {
        if (myGun.GetReloadTime() > 0.11f && moneyScript.GetPlayerMoneyCount() >= upgradeReloadSpeedCost)
        {
            myGun.SetReloadTime(myGun.GetReloadTime() - 0.1f);
            DeductCost(upgradeMagSizeCost);
            upgradeReloadSpeedCost += 3;
        }
        else
        {
            //disable button
        }

    }

    void DeductCost(int cost)
    {
        moneyScript.SetPlayerMoneyCount(moneyScript.GetPlayerMoneyCount() - cost);
    }

    enum Guns
    {
        pistol,
        mp5,
        pumpy,
        dragunov
    }

    Guns currentGun;
    public void SelectPistol()
    {
        //swap out the current gun model
        //create a struct that stores all required info for gun script instances
        //set current gun to pistol
        //adjust UI based on the stored pistol stats ?
    }

}
