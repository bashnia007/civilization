using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Assets.Scripts
{
	internal class Trading : MonoBehaviour
	{
		[SerializeField] private GameObject cardPrefab;
		[SerializeField] private GameObject handPrefab;
		[SerializeField] private GameObject cardsForTradingSelectorPrefab;

		private Camera currentCamera;

		private List<Player> players;

		public void TradingPhase(List<Player> players)
		{
			gameObject.SetActive(true);
			this.players = players;
			PrintSelectionCardsForTrading();
			//DrawHands();
		}

		private void PrintSelectionCardsForTrading()
		{
			var cardsForTradingSelector = Instantiate(cardsForTradingSelectorPrefab);
			cardsForTradingSelector.transform.SetParent(gameObject.transform, false);

			foreach (var card in players[0].AvailableResources)
			{
				var resourceCard = (GameObject)Instantiate(cardPrefab);
				resourceCard.transform.SetParent(cardsForTradingSelector.transform, false);
				var resourceName = card.ResourceType.ToString();
				resourceCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Cards/{resourceName}");
			}

			for (int i = 0; i < players[0].MoneyAmount; i++)
			{
				var moneyCard = (GameObject)Instantiate(cardPrefab);
				moneyCard.transform.SetParent(cardsForTradingSelector.transform, false);
				moneyCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/Money");
			}
		}

		private void DrawHands()
		{
			var background = gameObject.transform.GetChild(0);
			foreach (var player in players)
			{
				var hand = Instantiate(handPrefab);
				hand.transform.SetParent(background, false);
				var cardsSet = hand.transform.GetChild(0);

				foreach (var card in player.AvailableResources)
				{
					var resourceCard = (GameObject)Instantiate(cardPrefab);
					resourceCard.transform.SetParent(cardsSet.transform, false);
					var resourceName = card.ResourceType.ToString();
					resourceCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Cards/{resourceName}");
				}

				for (int i = 0; i < player.MoneyAmount; i++)
				{
					var moneyCard = (GameObject)Instantiate(cardPrefab);
					moneyCard.transform.SetParent(cardsSet.transform, false);
					moneyCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/Money");
				}
			}
		}

		void Update()
		{
			if (!currentCamera)
			{
				currentCamera = Camera.main;
				//Fetch the Raycaster from the GameObject (the Canvas)
				m_Raycaster = GetComponent<GraphicRaycaster>();
				//Fetch the Event System from the Scene
				m_EventSystem = GetComponent<EventSystem>();
			}

			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			SelectCardForTrading();
		}
		private List<GameObject> selectedCardsForTrading = new List<GameObject>();

		GraphicRaycaster m_Raycaster;
		PointerEventData m_PointerEventData;
		EventSystem m_EventSystem;

		private void SelectCardForTrading()
		{
			RaycastHit info;
			Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);


			//Set up the new Pointer Event
			m_PointerEventData = new PointerEventData(m_EventSystem);
			//Set the Pointer Event Position to that of the mouse position
			m_PointerEventData.position = Input.mousePosition;

			//Create a list of Raycast Results
			List<RaycastResult> results = new List<RaycastResult>();

			//Raycast using the Graphics Raycaster and mouse click position
			m_Raycaster.Raycast(m_PointerEventData, results);

			//For every result returned, output the name of the GameObject on the Canvas hit by the Ray
			var selectedCard = results.Select(r => r.gameObject).FirstOrDefault(r => r.layer == 10);
			if (!selectedCardsForTrading.Contains(selectedCard))
			{
				selectedCardsForTrading.Add(selectedCard);
				selectedCard.GetComponent<Image>().color = Color.green;
			}
			else
			{
				selectedCardsForTrading.Remove(selectedCard);
				selectedCard.GetComponent<Image>().color = Color.red;
			}
			/*foreach (RaycastResult result in results)
			{
				Debug.Log("Hit " + result.gameObject.name);
			}*/



			/*
			GameObject selectedCard;
			if (Physics.Raycast(ray, out info, 100))
			{ 
				Debug.DrawLine(ray.origin, info.point);
				Debug.Log(info.transform.name);
			}
			if (Physics.Raycast(ray, out info, 10000, LayerMask.GetMask("TradingCard")))
			{
				Debug.Log("info");
				selectedCard = info.transform.gameObject;
				if (!selectedCardsForTrading.Contains(selectedCard))
				{
					selectedCardsForTrading.Add(selectedCard);
					selectedCard.GetComponent<Image>().color = Color.green;
				}
				else
				{
					selectedCardsForTrading.Remove(selectedCard);
					selectedCard.GetComponent<Image>().color = Color.red;
				}
			}
			else
			{
				selectedCard = null;
				Debug.Log("nope");
			}*/
		}

	}
}
