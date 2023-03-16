using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance { get; set; }

	[SerializeField] private Animator menuAnimator;

	private void Awake()
	{
		Instance= this;
	}

	public void OnCreateGameButton()
	{
		menuAnimator.SetTrigger("OpenCreateGameMenu");
	}

	public void OnJoinGameButton()
	{
		menuAnimator.SetTrigger("OpenAvailableGamesMenu");
	}

	public void OnBackButton()
	{
		menuAnimator.SetTrigger("OpenMainMenu");
	}

	public void OnStartGameButton()
	{
		menuAnimator.SetTrigger("InGameMenu"); // TODO
	}

	public void OnCreateNewGameButton()
	{
		menuAnimator.SetTrigger("OpenSelectedGameMenu");
	}
}
