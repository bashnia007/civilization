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
		writer.WriteByte((byte)Game.CurrentPlayersConnected);
		writer.WriteByte((byte)Game.Players);
		writer.WriteFixedString32(Game.Creator);
		writer.WriteFixedString64(Game.GuidId.ToString());
	}

	public override void Deserialize(DataStreamReader reader)
	{
		Game = new Game();
		Game.CurrentPlayersConnected = reader.ReadByte();
		Game.Players = reader.ReadByte();
		Game.Creator = reader.ReadFixedString32().ToString();
		Game.GuidId = Guid.Parse(reader.ReadFixedString64().ToString());
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
