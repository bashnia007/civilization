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
}
