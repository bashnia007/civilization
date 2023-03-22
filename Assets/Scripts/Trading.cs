using Assets.Scripts.Buildings;
using Assets.Scripts.Enums;
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
//using static UnityEditor.PlayerSettings.SplashScreen;

namespace Assets.Scripts
{
	internal class Trading : MonoBehaviour
	{
		[SerializeField] private GameObject cardPrefab;
		[SerializeField] private GameObject handPrefab;
		[SerializeField] private GameObject cardsForTradingSelectorPrefab;

		private GameObject cardsForTradingSelector;
		private Button readyButton;

		private const string Money = "money";

		private Camera currentCamera;

		private List<Player> players;
		private Player CurrentPlayer;
		private List<GameObject> selectedCardsForTrading = new List<GameObject>();


		GraphicRaycaster m_Raycaster;
		PointerEventData m_PointerEventData;
		EventSystem m_EventSystem;

		private TradingPhase CurrentPhase;


		public void TradingPhase(List<Player> players)
		{
			CurrentPhase = Enums.TradingPhase.CardsSelection;
			gameObject.SetActive(true);
			this.players = players;

			players.First().IsMe = true;
			CurrentPlayer = players.First();

			PrintSelectionCardsForTrading();
		}

		private void PrintSelectionCardsForTrading()
		{
			cardsForTradingSelector = Instantiate(cardsForTradingSelectorPrefab);
			cardsForTradingSelector.transform.SetParent(gameObject.transform.GetChild(0), false);

			readyButton = cardsForTradingSelector.GetComponentInChildren<Button>();
			readyButton.onClick.AddListener(OnReadyButtonClick);

			var cardArea = cardsForTradingSelector.transform.GetChild(0);

			foreach (var card in players[0].AvailableResources)
			{
				var resourceCard = Instantiate(cardPrefab);
				resourceCard.transform.SetParent(cardArea.transform, false);
				var resourceName = card.ResourceType.ToString();
				resourceCard.name = resourceName;
				resourceCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Cards/{resourceName}");
			}

			for (int i = 0; i < players[0].MoneyAmount; i++)
			{
				var moneyCard = Instantiate(cardPrefab);
				moneyCard.transform.SetParent(cardArea.transform, false);
				moneyCard.name = Money;
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

				if (player.IsMe)
				{
					foreach (var selectedCard in selectedCardsForTrading)
					{
						if (selectedCard.name == Money)
						{
							CurrentPlayer.SpendMoney();
							DrawMoneyCard(cardsSet);
						}
						else
						{
							ResourceType resourceType = (ResourceType)Enum.Parse(typeof(ResourceType), selectedCard.name);
							DrawResourceCard(cardsSet, selectedCard.name);
							CurrentPlayer.SpendResources(new List<ResourceType> { resourceType });
						}
					}
				}
				else
				{
					foreach (var card in player.AvailableResources)
					{
						DrawResourceCard(cardsSet, card.ResourceType.ToString());
					}

					for (int i = 0; i < player.MoneyAmount; i++)
					{
						DrawMoneyCard(cardsSet);
					}
				}
			}
		}

		private void DrawResourceCard(Transform transform, string name)
		{

			var resourceCard = Instantiate(cardPrefab);
			resourceCard.transform.SetParent(transform.transform, false);
			resourceCard.name = name;
			resourceCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Cards/{name}");
		}

		private void DrawMoneyCard(Transform parent)
		{
			var moneyCard = Instantiate(cardPrefab);
			moneyCard.transform.SetParent(parent.transform, false);
			moneyCard.name = Money;
			moneyCard.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Cards/Money");
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
			if (selectedCard == null)
			{
				return;
			}
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

		public void OnReadyButtonClick()
		{
			cardsForTradingSelector.SetActive(false);
			DrawHands();
		}

	}
}
