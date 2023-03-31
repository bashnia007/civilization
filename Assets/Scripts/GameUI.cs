using Assets.Scripts;
using Assets.Scripts.Net.NetMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Networking.Transport;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance { get; set; }

	public Server server;
	public Client client;

	public List<GameObject> AvailableGames;
	public List<Game> Games;

	[SerializeField] private GameObject AvailableGamesView;
	[SerializeField] private GameObject ListOfPlayersToJoinView;

	[SerializeField] private Animator menuAnimator;
	[SerializeField] private TMP_InputField login;
	[SerializeField] private GameObject AvailableGamePrefab;
	[SerializeField] private TMP_Dropdown SelectedPlayersAmount;
	[SerializeField] private GameObject CountrySelectorPrefab;

	private ConnectedPlayer CurrentUser;
	private Game CurrentGame;

	private void Awake()
	{
		Instance = this;
		AvailableGames = new List<GameObject>();
		Games = new List<Game>();
		RegisterEvents();
		CurrentUser = new ConnectedPlayer();
	}

	private void OnDestroy()
	{
		UnRegisterEvents();
	}

	#region Button events
	public void OnCreateGameButton()
	{
		if (login.text.Length > 0)
		{
			CurrentUser.Login = login.text;
			menuAnimator.SetTrigger("OpenCreateGameMenu");
			client.Init("127.0.0.1", 8007);
		}
	}

	public void OnJoinGameButton()
	{
		if (login.text.Length > 0)
		{
			CurrentUser.Login = login.text;
			client.Init("127.0.0.1", 8007);
			menuAnimator.SetTrigger("OpenAvailableGamesMenu");
		}
	}

	public void OnBackButton()
	{
		server.Shutdown();
		client.Shutdown();
		menuAnimator.SetTrigger("OpenMainMenu");
	}

	public void OnBackToMainButton()
	{
		client.Shutdown();
		menuAnimator.SetTrigger("OpenMainMenu");
	}

	public void OnBackToAvailableGamesButton()
	{
		LeaveGameLobby();
		menuAnimator.SetTrigger("OpenAvailableGamesMenu");
	}

	public void OnStartGameButton()
	{
		menuAnimator.SetTrigger("OpenGame"); // TODO
	}

	public void OnCreateNewGameButton()
	{
		//var availableGame = Instantiate(AvailableGamePrefab);
		//availableGame.transform.SetParent(AvailableGamesView.transform, false);
		//AvailableGames.Add(availableGame);

		var game = new Game();
		game.GuidId = Guid.NewGuid();
		game.Creator = login.text;
		game.AddPlayer(CurrentUser);
		game.MaxPlayers = byte.Parse(SelectedPlayersAmount.options[SelectedPlayersAmount.value].text);
		game.CurrentPlayersConnected++;

		//AddNewGameOnAvailabeGamesList(game);

		// don't like it. Maybe it is possible to do it in a better way?
		//
		//var countrySelector = Instantiate(CountrySelectorPrefab);
		//countrySelector.transform.SetParent(ListOfPlayersToJoinView.transform, false);
		//countrySelector.transform.GetChild(0).GetComponent<TMP_Text>().text = login.text;
		//
		//menuAnimator.SetTrigger("OpenSelectedGameMenu");

		client.SendToServer(new NetCreateGameMessage { Game = game });
	}

	public void OnStartServer()
	{
		server.Init(8007);
	}

	#endregion

	private void LeaveGameLobby()
	{
		var leaveGameMessage = new NetLeaveGameMessage();
		leaveGameMessage.GameId = CurrentGame.GuidId;
		leaveGameMessage.Login = CurrentUser.Login;
		Client.Instance.SendToServer(leaveGameMessage);
	}

	private void AddNewGameOnAvailabeGamesList(Game game)
	{
		var availableGame = Instantiate(AvailableGamePrefab);
		availableGame.transform.SetParent(AvailableGamesView.transform, false);
		AvailableGames.Add(availableGame);

	}

	private void CleanAvailableGamesScreen()
	{
		// Cleaning games list
		foreach (Transform child in AvailableGamesView.transform)
		{
			Destroy(child.gameObject);
		}
	}

	private void DrawAvailableGames()
	{
		CleanAvailableGamesScreen();
		foreach (var game in Games)
		{
			var availableGame = Instantiate(AvailableGamePrefab);
			availableGame.transform.SetParent(AvailableGamesView.transform, false);
			availableGame.transform.GetChild(0).GetComponent<TMP_Text>().text = game.Creator;
			availableGame.transform.GetChild(1).GetComponent<TMP_Text>().text = $"{game.CurrentPlayersConnected}/{game.MaxPlayers}";
			availableGame.GetComponent<RoomItemView>().GameId = game.GuidId;
			availableGame.GetComponent<RoomItemView>().Login= CurrentUser.Login;
		}
	}

	private void RegisterEvents()
	{
		NetUtility.S_LOBBY += OnLobbyServer;
		NetUtility.C_LOBBY += OnLobbyClient;
		NetUtility.S_WELCOME += OnWelcomeServer;
		NetUtility.C_WELCOME += OnWelcomeClient;
		NetUtility.S_CREATE_GAME += OnCreateGameServer;
		NetUtility.C_CREATE_GAME += OnCreateGameClient;
		NetUtility.S_JOIN_GAME += OnJoinGameServer;
		NetUtility.C_JOIN_GAME += OnJoinGameClient;
		NetUtility.S_LEAVE_GAME += OnLeaveGameServer;
	}

	private void UnRegisterEvents()
	{
		NetUtility.S_LOBBY -= OnLobbyServer;
		NetUtility.C_LOBBY -= OnLobbyClient;
		NetUtility.S_WELCOME -= OnWelcomeServer;
		NetUtility.C_WELCOME -= OnWelcomeClient;
		NetUtility.S_CREATE_GAME -= OnCreateGameServer;
		NetUtility.C_CREATE_GAME -= OnCreateGameClient;
		NetUtility.S_JOIN_GAME -= OnJoinGameServer;
		NetUtility.C_JOIN_GAME -= OnJoinGameClient;
		NetUtility.S_LEAVE_GAME += OnLeaveGameServer;
	}

	private void OnLobbyServer(NetMessage msg, NetworkConnection cnn)
	{
		NetLobbyMessage lobbyMessage = msg as NetLobbyMessage;
		lobbyMessage.Games = Games;
		Debug.Log($"Server sent msg with {Games.Count} games");

		//Server.Instance.SendToClient(cnn, lobbyMessage);
		//DrawAvailableGames();
	}

	private void OnLobbyClient(NetMessage msg)
	{
		NetLobbyMessage lobbyMessage = msg as NetLobbyMessage;
		Games = lobbyMessage.Games;
		Debug.Log($"Client received message with {lobbyMessage.Games.Count} games");
		DrawAvailableGames();
	}

	private void OnWelcomeServer(NetMessage msg, NetworkConnection cnn)
	{
		Debug.Log("Server received WELCOME message. Sending LOBBY message");
		Server.Instance.SendToClient(cnn, new NetLobbyMessage { Games = Games });
	}

	private void OnWelcomeClient(NetMessage msg)
	{
		NetWelcomeMessage lobbyMessage = msg as NetWelcomeMessage;
		Debug.Log($"Client received WELCOME message");
	}

	private void OnCreateGameServer(NetMessage msg, NetworkConnection cnn)
	{
		var createGameMsg = msg as NetCreateGameMessage;
		Games.Add(createGameMsg.Game);
		Debug.Log($"Server received CREATE GAME message from {createGameMsg.Game.Creator}");

		Server.Instance.Broadcast(new NetLobbyMessage { Games = Games });
		Server.Instance.SendToClient(cnn, createGameMsg);
	}

	private void OnJoinGameServer(NetMessage msg, NetworkConnection cnn)
	{
		Debug.Log("Join message on server");
		var joinGameMessage = msg as NetJoinGameMessage;
		var game = Games.First(g => g.GuidId == joinGameMessage.GameId);
		var newPlayer = new ConnectedPlayer
		{
			Login = joinGameMessage.Login,
		};
		game.AddPlayer(newPlayer);
		game.CurrentPlayersConnected++;
		joinGameMessage.Game = game;
		//var createGameMsg = new NetCreateGameMessage { Game = game };

		Server.Instance.Broadcast(new NetLobbyMessage { Games = Games });
		//Server.Instance.SendToClient(cnn, createGameMsg);
		Server.Instance.SendToClient(cnn, joinGameMessage);
	}

	private void OnJoinGameClient(NetMessage msg)
	{
		Debug.Log("Join message on client");
		var joinGameMsg = msg as NetJoinGameMessage;
		//DrawSelectors();
		menuAnimator.SetTrigger("OpenSelectedGameMenu");

		CurrentGame = joinGameMsg.Game;

		foreach (var player in CurrentGame.ConnectedPlayers)
		{
			var countrySelector = Instantiate(CountrySelectorPrefab);
			countrySelector.transform.SetParent(ListOfPlayersToJoinView.transform, false);
			countrySelector.transform.GetChild(0).GetComponent<TMP_Text>().text = player.Login;
		}
	}

	private void OnCreateGameClient(NetMessage msg)
	{
		Debug.Log("Create game message on client");
		var createGameMsg = msg as NetCreateGameMessage;
		CurrentGame = createGameMsg.Game;
		foreach (var player in createGameMsg.Game.ConnectedPlayers)
		{
			var countrySelector = Instantiate(CountrySelectorPrefab);
			countrySelector.transform.SetParent(ListOfPlayersToJoinView.transform, false);
			countrySelector.transform.GetChild(0).GetComponent<TMP_Text>().text = player.Login;
		}
		menuAnimator.SetTrigger("OpenSelectedGameMenu");
	}

	private void OnLeaveGameServer(NetMessage msg, NetworkConnection cnn)
	{
		var leaveGameMsg = msg as NetLeaveGameMessage;
		var game = Games.First(x => x.GuidId == leaveGameMsg.GameId);
		game.RemovePlayer(leaveGameMsg.Login);
		if (game.ConnectedPlayers.Count == 0)
		{
			Games.Remove(game);
		}
		Server.Instance.Broadcast(new NetLobbyMessage { Games = Games });
	}

	// TODO draw all players
	private void DrawSelectors()
	{
		var countrySelector = Instantiate(CountrySelectorPrefab);
		countrySelector.transform.SetParent(ListOfPlayersToJoinView.transform, false);
		countrySelector.transform.GetChild(0).GetComponent<TMP_Text>().text = login.text;
	}
}
