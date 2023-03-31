using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using Unity.Networking.Transport;

public class NetJoinGameMessage : NetMessage
{
	public Guid GameId { get; set; }
	public Game Game { get; set; }
	public string Login { get; set; }

	// Creating
	public NetJoinGameMessage()
	{
		Code = OpCode.JOIN_GAME;
	}

	// Receiving
	public NetJoinGameMessage(DataStreamReader reader) : this()
	{
		Deserialize(reader);
	}

	public override void Serialize(ref DataStreamWriter writer)
	{
		writer.WriteByte((byte)Code);
		writer.WriteFixedString64(GameId.ToString());
		writer.WriteFixedString32(Login);
		if (Game != null)
		{
			writer.WriteByte(1);
			writer.WriteByte((byte)Game.ConnectedPlayers.Count);
			foreach (var user in Game.ConnectedPlayers)
			{
				writer.WriteFixedString32(user.Login);
				writer.WriteByte(Convert.ToByte(user.IsReady));
			}
		}	
		else
		{
			writer.WriteByte(0);
		}
	}

	public override void Deserialize(DataStreamReader reader)
	{
		Game = new Game();
		GameId = Guid.Parse(reader.ReadFixedString64().ToString());
		Login = reader.ReadFixedString32().ToString();
		byte b = reader.ReadByte();
		if (b != 0)
		{
			Game.CurrentPlayersConnected = reader.ReadByte();
			for (int i = 0; i < Game.CurrentPlayersConnected; i++)
			{
				var connectedPlayer = new ConnectedPlayer();
				connectedPlayer.Login = reader.ReadFixedString32().ToString();
				connectedPlayer.IsReady = reader.ReadByte() != 0;
				Game.AddPlayer(connectedPlayer);
			}
		}
	}

	public override void ReceivedOnClient()
	{
		NetUtility.C_JOIN_GAME?.Invoke(this);
	}

	public override void ReceivedOnServer(NetworkConnection connection)
	{
		NetUtility.S_JOIN_GAME?.Invoke(this, connection);
	}
}
