using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using Unity.Networking.Transport;

public class NetLobbyMessage : NetMessage
{
	public List<Game> Games { get; set; }

	public NetLobbyMessage() 
	{
		Code = OpCode.LOBBY;
	}
	
	// Receiving
	public NetLobbyMessage(DataStreamReader reader) : this()
	{
		Deserialize(reader);
	}

	public override void Serialize(ref DataStreamWriter writer)
	{
		writer.WriteByte((byte)Code);
		writer.WriteByte((byte)Games.Count);
		foreach (Game game in Games)
		{
			writer.WriteByte((byte)game.CurrentPlayersConnected);
			writer.WriteByte((byte)game.Players);
			writer.WriteFixedString32(game.Creator);
			writer.WriteFixedString64(game.GuidId.ToString());
		}
	}

	public override void Deserialize(DataStreamReader reader)
	{
		Games = new List<Game>();
		var gamesCount = reader.ReadByte();
		for (byte i = 0; i < gamesCount; i++)
		{
			var game = new Game();
			game.CurrentPlayersConnected = reader.ReadByte();
			game.Players = reader.ReadByte();
			game.Creator = reader.ReadFixedString32().ToString();
			game.GuidId = Guid.Parse(reader.ReadFixedString64().ToString());
			Games.Add(game);
		}
	}

	public override void ReceivedOnClient()
	{
		NetUtility.C_LOBBY?.Invoke(this);
	}

	public override void ReceivedOnServer(NetworkConnection connection)
	{
		NetUtility.S_LOBBY?.Invoke(this, connection);
	}
}
