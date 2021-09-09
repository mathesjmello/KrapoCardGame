
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace DefaultNamespace
{
    public class MainDeck: MonoBehaviour, IDeckable, IPickable
    {
        public bool Other;
        public Krapo krapo;
        public Card CardPrefab;
        private List<Card> deck;
        public Stack<Card> shuffledDeck;
        [Inject] private StartManager _sm;
        [Inject] private MiddlePileManager _mpm;
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
            if (Other)
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
        }
        
        public void SetKrapo()
        {
            for (int i = 0; i < 13; i++)
            {
                krapo.AddCard(shuffledDeck.Pop());
            }
            krapo.TurnLastCard();
            PrepareLines();
        }

        private void PrepareLines()
        {
            if (Other)
            {
                foreach (var line in _sm.lineDir)
                {
                    if (shuffledDeck.Peek().num != 1)
                    {
                        line.AddCard(shuffledDeck.Pop());
                    }
                    else
                    {
                        _mpm.CheckCard(shuffledDeck.Pop());
                    }
                    
                }
            }
            else
            {
                foreach (var line in _sm.lineEsq)
                {
                    if (shuffledDeck.Peek().num != 1)
                    {
                        Debug.Log("joga na linha");
                        line.AddCard(shuffledDeck.Pop());
                    }
                    else
                    {
                        Debug.Log("jogar no meio");
                        _mpm.CheckCard(shuffledDeck.Pop());
                    }
                }
            }
        }

        public Card PickCard(out Card c)
        {
            c = shuffledDeck.Pop();
            c.EnableCard();
            return c;
        }
    }
}