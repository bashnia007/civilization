using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
	public class Game
	{
		public Game()
		{
			ConnectedPlayers = new List<ConnectedPlayer>();
		}

		public Guid GuidId { get; set; }
		public string Creator { get; set; }
		public byte MaxPlayers { get; set; }
		public byte CurrentPlayersConnected { get; set; }
		public List<ConnectedPlayer> ConnectedPlayers { get; }

		public void AddPlayer(ConnectedPlayer player)
		{
			ConnectedPlayers.Add(player);
			//CurrentPlayersConnected++;
		}

		public void RemovePlayer(string playerLogin)
		{
			var player = ConnectedPlayers.First(p => p.Login == playerLogin);
			ConnectedPlayers.Remove(player);
		}
	}
}
