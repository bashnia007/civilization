using System;

namespace Assets.Scripts
{
	public class Game
	{
		public Game()
		{
			GuidId = Guid.NewGuid();
		}

		public Guid GuidId { get; }
		public string Creator { get; set; }
		public byte Players { get; set; }
		public byte CurrentPlayersConnected { get; set; }
	}
}
