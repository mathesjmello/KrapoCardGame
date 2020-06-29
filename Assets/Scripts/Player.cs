using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public MainDeck deck;
        public DiscartDeck dDeck;
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                dDeck.AddCard(deck.shuffledDeck.Pop());
            }
        }
    }
}