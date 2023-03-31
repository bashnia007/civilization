using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using Unity.Networking.Transport;

public class NetCreateGameMessage : NetMessage
{
	public Game Game { get; set; }
	// Creating
	public NetCreateGameMessage()
	{
		Code = OpCode.CREATE_GAME;
	}

	// Receiving
	public NetCreateGameMessage(DataStreamReader reader) : this()
	{
		Deserialize(reader);
	}

	public override void Serialize(ref DataStreamWriter writer)
	{
		writer.WriteByte((byte)Code);
		writer.WriteByte((byte)Game.ConnectedPlayers.Count);
		writer.WriteByte((byte)Game.MaxPlayers);
		writer.WriteFixedString32(Game.Creator);
		writer.WriteFixedString64(Game.GuidId.ToString());
		foreach (var user in Game.ConnectedPlayers)
		{
			writer.WriteFixedString32(user.Login);
			//writer.WriteFixedString32(user.SelectedCountry);
			writer.WriteByte(Convert.ToByte(user.IsReady));
		}
	}

	public override void Deserialize(DataStreamReader reader)
	{
		Game = new Game();
		Game.CurrentPlayersConnected = reader.ReadByte();
		Game.MaxPlayers = reader.ReadByte();
		Game.Creator = reader.ReadFixedString32().ToString();
		Game.GuidId = Guid.Parse(reader.ReadFixedString64().ToString());
		int players = Game.CurrentPlayersConnected;
		for (int i = 0; i < players; i++)
		{
			var connectedPlayer = new ConnectedPlayer();
			connectedPlayer.Login = reader.ReadFixedString32().ToString();
			//connectedPlayer.SelectedCountry = reader.ReadFixedString32().ToString();
			connectedPlayer.IsReady = reader.ReadByte() != 0;
			Game.AddPlayer(connectedPlayer);
		}
	}

	public override void ReceivedOnClient()
	{
		NetUtility.C_CREATE_GAME?.Invoke(this);
	}

	public override void ReceivedOnServer(NetworkConnection connection)
	{
		NetUtility.S_CREATE_GAME?.Invoke(this, connection);
	}
}
