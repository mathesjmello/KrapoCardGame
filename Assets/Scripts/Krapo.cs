using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Krapo : MonoBehaviour, IRecivable, IAddtable, IPickable
    {
        public Stack<Card> kDeck;

        public void Start()
        {
            kDeck = new Stack<Card>();
        }

        public void AddCard(Card card)
        {
            kDeck.Push(card);
            card.SetParent(transform);
        }

        public void TurnLastCard()
        {
            var lastCard = kDeck.Peek();
            lastCard.EnableCard();
        }

        public void ReciveCard(Card card)
        {
            var currentCard = kDeck.Peek();
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
            c = kDeck.Pop();
            return c;
        }
    }
}