using System;
using UnityEngine;

public class RoomItemView : MonoBehaviour
{
    public Guid GameId { get; set; }

	public void OnJoinGameButton()
    {
		Client.Instance.SendToServer(new NetJoinGameMessage { GameId = GameId });
    }	
}
