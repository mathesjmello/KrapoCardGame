using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class MiddlePileManager: MonoBehaviour
    {
        public List<MiddlePile> Piles = new List<MiddlePile>();
        public MiddlePile oneToSend;
        private void Start()
        {
            Piles = FindObjectsOfType<MiddlePile>().ToList();
        }

        public bool CheckCard(Card card)
        {
            foreach (var pile in Piles)
            {
                if (card.num == pile.pile.Count && (int) pile.suits == (int) card.suit)
                {
                    Debug.Log($"carta {card.num} de nipe {card.suit} entra aqui {pile.suits}");
                    oneToSend = pile;
                    return true;
                }
            }
            return false;
        }

        public void PushCard(Card card)
        {
            oneToSend.AddCard(card);
        }
    }
}