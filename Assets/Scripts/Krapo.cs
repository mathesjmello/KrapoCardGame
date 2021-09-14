using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Krapo : MonoBehaviour, IAddtable, IPickable, ICheckable
    {
        public Stack<Card> kDeck= new Stack<Card>();
        [Inject] private MiddlePileManager _mpm;

        public void AddCard(Card card)
        { 
            kDeck.Push(card);
            card.SetParent(transform);
        }

        public void TurnLastCard()
        {
            var lastCard = kDeck.Peek();
            lastCard.EnableCard();
            if (_mpm.CheckCard(lastCard))
            {
                _mpm.PushCard(kDeck.Pop());
                TurnLastCard();
            }
        }

        public Card PickCard(out Card c)
        {
            c = kDeck.Pop();
            return c;
        }

        public bool CheckCard(Card c)
        {
            var topCard = kDeck.Peek();
            if (c.suit == topCard.suit && (c.num == topCard.num-1|| c.num == topCard.num+1))
            {
                return true;
            }
            return false;
        }
    }
}