using Assets.Scripts.Net.NetMessages;
using System;
using Unity.Networking.Transport;
using UnityEngine;

public class Client : MonoBehaviour
{
	#region "Singleton" implementation
	public static Client Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	#endregion

	public NetworkDriver driver;
	private NetworkConnection connection;

	private bool isActive = false;

	public Action connectionDropped;

	#region Methods
	public void Init(string ip, ushort port)
	{
		driver = NetworkDriver.Create();
		// TODO add validation
		NetworkEndPoint endpoint = NetworkEndPoint.Parse(ip, port);

		connection = driver.Connect(endpoint);

		Debug.Log("Attempting to connect to Server on " + endpoint.Address);

		isActive = true;

		RegisterToEvent();
	}

	public void Shutdown()
	{
		if (isActive)
		{
			UnregisterToEvent();
			driver.Dispose();
			isActive = false;
			connection = default;
		}
	}

	public void OnDestroy()
	{
		Shutdown();
	}


	public void Update()
	{
		if (!isActive)
		{
			return;
		}

		driver.ScheduleUpdate().Complete();
		CheckAlive();

		UpdateMessagePump();
	}


	private void CheckAlive()
	{
		if (!connection.IsCreated && isActive)
		{
			Debug.Log("Lost connection to server");
			connectionDropped?.Invoke();
			Shutdown();
		}
	}

	private void UpdateMessagePump()
	{
		DataStreamReader stream;
		NetworkEvent.Type cmd;
		while ((cmd = connection.PopEvent(driver, out stream)) != NetworkEvent.Type.Empty)
		{
			if (cmd == NetworkEvent.Type.Connect)
			{
				SendToServer(new NetWelcomeMessage());
				Debug.Log("We are connected!");
			}
			else if (cmd == NetworkEvent.Type.Data)
			{
				NetUtility.OnData(stream, default);
			}
			else if (cmd == NetworkEvent.Type.Disconnect)
			{
				Debug.Log("Client got disconnected from server");
				connection = default;
				connectionDropped?.Invoke();
				Shutdown();
			}
		}
	}

	public void SendToServer(NetMessage message)
	{
		DataStreamWriter writer;
		driver.BeginSend(connection, out writer);
		message.Serialize(ref writer);
		driver.EndSend(writer);
	}

	// Event parsing
	private void RegisterToEvent()
	{
		NetUtility.C_KEEP_ALIVE += OnKeepAlive;
	}

	private void UnregisterToEvent()
	{
		NetUtility.C_KEEP_ALIVE -= OnKeepAlive;
	}

	private void OnKeepAlive(NetMessage message)
	{
		// Send it back to keep both sides alive
		SendToServer(message);
	}

	#endregion
}
