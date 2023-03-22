using Unity.Networking.Transport;

namespace Assets.Scripts.Net.NetMessages
{
	public class NetWelcomeMessage : NetMessage
	{
		public NetWelcomeMessage() 
		{
			Code = Enums.OpCode.WELCOME;
		}
		// Receiving
		public NetWelcomeMessage(DataStreamReader reader) : this()
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
			NetUtility.C_WELCOME?.Invoke(this);
		}

		public override void ReceivedOnServer(NetworkConnection connection)
		{
			NetUtility.S_WELCOME?.Invoke(this, connection);
		}
	}
}
