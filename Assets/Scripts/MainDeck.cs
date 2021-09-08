
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace DefaultNamespace
{
    public class MainDeck: MonoBehaviour, IDeckable, IPickable
    {
        public bool you;
        public Krapo krapo;
        public Card CardPrefab;
        private List<Card> deck;
        public Stack<Card> shuffledDeck;
        [Inject] private StartManager _sm;
        private void Start()
        {
            shuffledDeck = new Stack<Card>();
            deck = new List<Card>();
            CardPrefab = Resources.Load<Card>("CardPrefab");
            DeckBuild();
        }


        public void DeckBuild()
        {
            for (int i = 1; i < 53; i++)
            {
                var card = Instantiate(CardPrefab);
                card.GenCard(i);
                deck.Add(card);
                card.SetParent(transform);
            }
            Shuffle();
        }

        public void Shuffle()
        {
            var rng = new Random();
            if (you)
            {
                rng.Next();
            }
            int n = deck.Count;
            for (int i = 0; i < 4; i++)
            {
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    (deck[k], deck[n]) = (deck[n], deck[k]);
                }
            }
            
            foreach (var card in deck)
            {
                shuffledDeck.Push(card);
                card.gameObject.transform.parent = transform;
            }
            SetKrapo();
            PrepareLines();
        }

        private void PrepareLines()
        {
            if (you)
            {
                foreach (var line in _sm.lineDir)
                {
                    line.AddCard(shuffledDeck.Pop());
                }
            }
            else
            {
                foreach (var line in _sm.lineEsq)
                {
                    line.AddCard(shuffledDeck.Pop());
                }
            }
        }

        public void SetKrapo()
        {
            for (int i = 0; i < 13; i++)
            {
                krapo.AddCard(shuffledDeck.Pop());
            }
            krapo.TurnLastCard();
        }

        public Card PickCard(out Card c)
        {
            c = shuffledDeck.Pop();
            return c;
        }
    }
}