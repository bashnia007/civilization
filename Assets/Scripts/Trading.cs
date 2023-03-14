using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Assets.Scripts
{
	internal class Trading : MonoBehaviour
	{
		private GameObject tradingCanvas;
		private GameObject cardPrefab;
		private GameObject handPrefab;

		public Trading(GameObject tradingCanvas, GameObject cardPrefab, GameObject handPrefab)
		{
			this.tradingCanvas = tradingCanvas;
			this.cardPrefab = cardPrefab;
			this.handPrefab = handPrefab;
		}

		public void TradingPhase(List<Player> players)
		{
			DrawHands(players);
		}

		private void DrawHands(List<Player> players)
		{
			tradingCanvas.SetActive(true);

			var background = tradingCanvas.transform.GetChild(0);
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
	}
}
