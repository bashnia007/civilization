using Assets.Scripts.Enums;
using Assets.Scripts.Net.NetMessages;
using System;
using Unity.Networking.Transport;
using UnityEngine;

public static class NetUtility
{
	public static Action<NetMessage> C_KEEP_ALIVE;
	public static Action<NetMessage> C_WELCOME;
	public static Action<NetMessage> C_CREATE_GAME;
	public static Action<NetMessage> C_START_GAME;
	public static Action<NetMessage> C_LOBBY;
	public static Action<NetMessage> C_JOIN_GAME;

	public static Action<NetMessage, NetworkConnection> S_KEEP_ALIVE;
	public static Action<NetMessage, NetworkConnection> S_WELCOME;
	public static Action<NetMessage, NetworkConnection> S_CREATE_GAME;
	public static Action<NetMessage, NetworkConnection> S_START_GAME;
	public static Action<NetMessage, NetworkConnection> S_LOBBY;
	public static Action<NetMessage, NetworkConnection> S_JOIN_GAME;

	public static void OnData(DataStreamReader reader, NetworkConnection connection, Server server = null)
	{
		NetMessage message = null;
		var opCode = (OpCode)reader.ReadByte();
		switch (opCode)
		{
			case OpCode.KEEP_ALIVE:
				message = new NetKeepAliveMessage(reader);
				break;
			case OpCode.WELCOME:
				message = new NetWelcomeMessage(reader);
				break; 
			case OpCode.CREATE_GAME:
				message = new NetCreateGameMessage(reader);
				break;
			//case OpCode.START_GAME:
			//	message = new NetStartGameMessage(reader);
			//	break;
			case OpCode.LOBBY:
				message = new NetLobbyMessage(reader);
				break;
			case OpCode.JOIN_GAME:
				message = new NetJoinGameMessage(reader);
				break;
			default:
				Debug.LogError("Message received has incorrect OpCode!");
				break;
		}

		if (server != null)
		{
			message.ReceivedOnServer(connection);
		}
		else
		{
			message.ReceivedOnClient();
		}
	}

}
