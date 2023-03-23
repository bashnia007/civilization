using System;

namespace Assets.Scripts
{
	public class Game
	{
		public Game()
		{
		}

		public Guid GuidId { get; set; }
		public string Creator { get; set; }
		public byte Players { get; set; }
		public byte CurrentPlayersConnected { get; set; }
	}
}
