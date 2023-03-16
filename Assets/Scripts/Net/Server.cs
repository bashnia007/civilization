using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Networking.Transport;
using UnityEngine;

public class Server : MonoBehaviour
{
	#region "Singleton" implementation
	public static Server Instance { get; private set; }

	private void Awake()
	{
		Instance = this; 
	}

	#endregion

	public NetworkDriver driver;
	private NativeList<NetworkConnection> connections;

	private bool isActive = false;
	private const float keepAliveTickRate = 20.0f;
	private float lastKeepAlive;

	public Action connectionDropped;

	#region Methods
	public void Init(ushort port)
	{
		driver = NetworkDriver.Create();
		NetworkEndPoint endpoint = NetworkEndPoint.AnyIpv4;
		endpoint.Port = port;

		if (driver.Bind(endpoint) != 0)
		{
			Debug.Log("Unable to bind on port " + endpoint.Port);
			return;
		}
		else
		{
			driver.Listen();
			Debug.Log("Listening to port " + endpoint.Port);
		}

		connections = new NativeList<NetworkConnection>();
		isActive = true;
	}

	public void Shutdown()
	{
		if (isActive)
		{
			driver.Dispose();
			connections.Dispose();
			isActive = false;
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

		//KeepAlive();

		driver.ScheduleUpdate().Complete();
		CleanupConnections();
		AcceptNewConnections();
		UpdateMessagePump();
	}

	private void CleanupConnections()
	{
		for (int i = 0; i < connections.Length; i++)
		{
			if (!connections[i].IsCreated)
			{
				connections.RemoveAtSwapBack(i);
				--i;
			}
		}
	}

	private void AcceptNewConnections()
	{
		NetworkConnection connection;
		while ((connection = driver.Accept()) != default)
		{
			connections.Add(connection);
		}
	}

	private void UpdateMessagePump()
	{
		DataStreamReader stream;
		for (int i = 0; i < connections.Length; i++)
		{
			NetworkEvent.Type cmd;
			while ((cmd = driver.PopEventForConnection(connections[i], out stream)) != NetworkEvent.Type.Empty)
			{
				if (cmd == NetworkEvent.Type.Data) 
				{
					///NetUtility.OnData(stream, connections[i], this);
				}
				else if (cmd == NetworkEvent.Type.Disconnect)
				{
					Debug.Log("Client disconnected from server");
					connections[i] = default;
					connectionDropped?.Invoke();
				}
			}
		}
	}

	// Serve specific
	public void SendToClient(NetworkConnection connection, NetMessage message)
	{
		DataStreamWriter writer;
		driver.BeginSend(connection, out writer);
		//message.Serialize(ref writer);
		driver.EndSend(writer);
	}

	public void Broadcast(NetMessage message)
	{
		for (int i = 0; i < connections.Length; i++)
		{
			if (connections[i].IsCreated)
			{
				//Debug.Log($"Sending {message.Code} to : {connections[i].InternalId}");
				SendToClient(connections[i], message);
			}
		}
	}

	#endregion
}
