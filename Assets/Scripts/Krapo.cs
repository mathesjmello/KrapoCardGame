using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Krapo : MonoBehaviour
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
    }
}