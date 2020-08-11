using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public MainDeck myDeck;
        public MainDeck yourDeck;
        public DiscartDeck dDeck;
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                dDeck.AddCard(myDeck.shuffledDeck.Pop());
            }
            if (Input.GetMouseButtonUp(1))
            {
                dDeck.AddCard(yourDeck.shuffledDeck.Pop());
            }
        }
    }
}