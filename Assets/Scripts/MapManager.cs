using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region Art stuff

    [SerializeField] private GameObject BuyMenu;
    
    #endregion

    void Start()
    {
        BuyMenu.SetActive(false);
    }

    #region Buy Menu
    public void OnBuyAdministrationButton()
    {

    }

    public void OnBuyLegionButton()
    {

    }

    public void OnBuyTriremeButton()
    {

    }

    public void OnBuyTowerButton()
    {

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

}
