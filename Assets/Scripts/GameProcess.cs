using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Country> Countries = new List<Country>();

    public List<Player> Players = new List<Player>();
    private GameObject tradingCanvas;
    private GameObject handPrefab;
	private GameObject cardPrefab;

	public GameProcess(List<Country> countries, GameObject tradingCanvas, GameObject cardPrefab, GameObject handPrefab)
    {
        Countries = countries;
        this.tradingCanvas = tradingCanvas;
        this.handPrefab = handPrefab;
        this.cardPrefab = cardPrefab;

        for (int i = 0; i < 5; i++)
        {
            var player = new Player();
            player.Country = countries[i];
            Players.Add(player);
        }
    }
    
    private void GenerateMap()
    {
    }

    public void StartGame()
    {
        Processing();
	}

	private void Processing()
	{
		//while (!IsAnyoneWin())
        {
            ResourcesPhase();
			TradingPhase();
            BuildingPhase();
            MovingPhase();
		}
	}

    private bool IsAnyoneWin()
    {
        return false;
    }

	private void ResourcesPhase()
	{
		foreach (var player in Players)
        {
            player.GetResources();
            player.GetTaxes();
		}
	}

    private void TradingPhase()
    {
        var trading = tradingCanvas.GetComponent<Trading>();
        trading.TradingPhase(Players);

	}

    private void BuildingPhase()
    {

    }

    private void MovingPhase()
    {

    }
}
