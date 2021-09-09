using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DiscartDeck : MonoBehaviour, IAddtable, IRecivable , IPickable
    {
        public bool empty;
        private Stack<Card> _discartDeck = new Stack<Card>();
        public void AddCard(Card card)
        {
            _discartDeck.Push(card);
            card.SetParent(transform);
        }

        public void ReciveCard(Card card)
        {
            var currentCard = _discartDeck.Peek();
            if (currentCard.suit == card.suit && (currentCard.num+1 == card.num || currentCard.num-1 == card.num))
            {
                AddCard(card);
                card.SetParent(transform);
            }
            else
            {
                Debug.LogError("invalid command");
            }
        }

        public Card PickCard(out Card c)
        {
            c = empty ? _discartDeck.Pop() : null;
            return c;
        }
    }
}