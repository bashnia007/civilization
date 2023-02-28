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
    void Start()
    {
        GenerateMap();

        StartGame();
    }


    private void GenerateMap()
    {
    }

    private void StartGame()
    {
    }

	private void Processing()
	{
		while (!IsAnyoneWin())
        {
            GatheringPhase();
			TradingPhase();
            BuildingPhase();
            MovingPhase();
		}
	}

    private bool IsAnyoneWin()
    {
        return false;
    }

	private void GatheringPhase()
	{
		foreach (var player in Players)
        {

        }
	}

    private void TradingPhase()
    {

    }

    private void BuildingPhase()
    {

    }

    private void MovingPhase()
    {

    }
}
