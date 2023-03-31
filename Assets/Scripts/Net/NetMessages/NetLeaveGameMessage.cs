using Assets.Scripts.Enums;
using System;
using Unity.Networking.Transport;

public class NetLeaveGameMessage : NetMessage
{
	public string Login { get; set; }
	public Guid GameId { get; set; }

	// Creating
	public NetLeaveGameMessage()
	{
		Code = OpCode.LEAVE_GAME;
	}

	// Receiving
	public NetLeaveGameMessage(DataStreamReader reader) : this()
	{
		Deserialize(reader);
	}

	public override void Serialize(ref DataStreamWriter writer)
	{
		writer.WriteByte((byte)Code);
		writer.WriteFixedString64(GameId.ToString());
		writer.WriteFixedString32(Login);
	}

	public override void Deserialize(DataStreamReader reader)
	{
		GameId = Guid.Parse(reader.ReadFixedString64().ToString());
		Login = reader.ReadFixedString32().ToString();
	}

	public override void ReceivedOnClient()
	{
		NetUtility.C_LEAVE_GAME?.Invoke(this);
	}

	public override void ReceivedOnServer(NetworkConnection connection)
	{
		NetUtility.S_LEAVE_GAME?.Invoke(this, connection);
	}
}
