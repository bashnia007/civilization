using Assets.Scripts;
using System;
using UnityEngine;

public class RoomItemView : MonoBehaviour
{
    public Guid GameId { get; set; }
    public Game Game { get; set; }
    public string Login { get; set; }

	public void OnJoinGameButton()
    {
		Client.Instance.SendToServer(new NetJoinGameMessage { GameId = GameId, Game = Game, Login = Login });
    }	
}
