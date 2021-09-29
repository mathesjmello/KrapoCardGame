using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class DiscartDeck : MonoBehaviour, IAddtable , IPickable, ICheckable
    {
        public bool empty;
        private Stack<Card> _discartDeck = new Stack<Card>();
        [Inject] private LinesManager _lm;
        public void AddCard(Card card)
        {
            _discartDeck.Push(card);
            card.SetParent(transform,0);
            card.DisableCard(_discartDeck.Count);
        }

        public Card PickCard(out Card c)
        {
            c = empty&&_lm.HaveEmpty ? _discartDeck.Pop() : null;
            return c;
        }

        public bool CheckCard(Card c)
        {
            var currentCard = _discartDeck.Peek();
            if (currentCard.suit == c.suit && (currentCard.num + 1 == c.num || currentCard.num - 1 == c.num))
            {
                return true;
            }
            return false;
        }
    }
}