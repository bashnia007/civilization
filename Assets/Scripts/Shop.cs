using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Art stuff

    [SerializeField] private GameObject BuyMenu;
    [SerializeField] private GameObject Map;

    #endregion

    public static bool AdministrationToBuild;
    public static bool LegionToBuild;
    public static bool ShipToBuild;
    public static bool TowerToBuild;
    public static bool ResourceToBuild;

    void Start()
    {
        BuyMenu.SetActive(true);
        AdministrationToBuild = false;
    }

    #region Buy Menu
    public void OnBuyAdministrationButton()
    {
        BuyMenu.SetActive(false);
        AdministrationToBuild = true;
    }

    public void OnBuyLegionButton()
    {
        BuyMenu.SetActive(false);
        LegionToBuild = true;
    }

    public void OnBuyTriremeButton()
    {
        BuyMenu.SetActive(false);
        ShipToBuild = true;
    }

    public void OnBuyTowerButton()
    {
        BuyMenu.SetActive(false);
        TowerToBuild = true;
    }

    public void OnBuyCityButton()
    {

    }

    public void OnBuyCaravanButton()
    {

    }

    public void OnBuyTempleButton()
    {

    }

    public void OnBuyMarketButton()
    {

    }

    public void OnBuyHeroButton()
    {
        BuyMenu.transform.GetChild(0).gameObject.SetActive(false);
        BuyMenu.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void OnBuyWonderButton()
    {
        BuyMenu.transform.GetChild(0).gameObject.SetActive(false);
        BuyMenu.transform.GetChild(1).gameObject.SetActive(true);
    }
    #endregion

    public void OnBuySelectedWonderButton()
    {

    }

    public void OnBuySelectedHeroButton()
    {

    }

    public void OnBackButton()
    {
        BuyMenu.transform.GetChild(0).gameObject.SetActive(true);
        BuyMenu.transform.GetChild(1).gameObject.SetActive(false);
        BuyMenu.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void GetRegionsAvailableForBuilding()
    {

    }

}
