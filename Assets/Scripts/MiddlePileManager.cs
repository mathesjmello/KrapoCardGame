using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class MiddlePileManager: MonoBehaviour
    {
        public List<MIddlePile> Piles = new List<MIddlePile>();

        private void Start()
        {
            Piles = FindObjectsOfType<MIddlePile>().ToList();
        }

        public void CheckCard(Card card)
        {
            foreach (var pile in Piles)
            {
                if (card.num == pile.pile.Count+1 && card.suit == (Card.Suits) pile.suits)
                {
                    Debug.Log("achei");
                    pile.AddCard(card);
                    
                    break;
                }
            }
        }
    }
}