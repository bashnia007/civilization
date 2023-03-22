using Assets.Scripts.Enums;
using Unity.Networking.Transport;

public class NetKeepAliveMessage : NetMessage
{
	// Creating
	public NetKeepAliveMessage()
	{
		Code = OpCode.KEEP_ALIVE;
	}

	// Receiving
	public NetKeepAliveMessage(DataStreamReader reader) : this()
	{
		Deserialize(reader);
	}

	public override void Serialize(ref DataStreamWriter writer)
	{
		base.Serialize(ref writer);
	}

	public override void Deserialize(DataStreamReader reader)
	{
		base.Deserialize(reader);
	}

	public override void ReceivedOnClient()
	{
		NetUtility.C_KEEP_ALIVE?.Invoke(this);
	}

	public override void ReceivedOnServer(NetworkConnection connection)
	{
		NetUtility.S_KEEP_ALIVE?.Invoke(this, connection);
	}
}
