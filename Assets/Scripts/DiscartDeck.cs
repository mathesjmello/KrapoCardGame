using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DiscartDeck : MonoBehaviour, IAddtable, IRecivable
    {
        private Stack<Card> _discartDeck = new Stack<Card>();
        public void AddCard(Card card)
        {
            _discartDeck.Push(card);
            card.transform.parent = transform;
        }

        public void ReciveCard(Card card)
        {
            var currentCard = _discartDeck.Peek();
            if (currentCard.suit == card.suit && (currentCard.num+1 == card.num || currentCard.num-1 == card.num))
            {
                AddCard(card);
            }
            else
            {
                Debug.LogError("invalid command");
            }
        }
    }
}