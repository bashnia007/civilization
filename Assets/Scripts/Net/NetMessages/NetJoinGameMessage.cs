using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using Unity.Networking.Transport;

public class NetJoinGameMessage : NetMessage
{
	public Guid GameId { get; set; }
	public Game Game { get; set; }

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
	}

	public override void Deserialize(DataStreamReader reader)
	{
		GameId = Guid.Parse(reader.ReadFixedString64().ToString());
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
