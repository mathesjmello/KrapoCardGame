
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace DefaultNamespace
{
    public class MainDeck: MonoBehaviour, IDeckable, IPickable
    {
        public bool Empty;
        public bool Other;
        public Krapo krapo;
        public Card CardPrefab;
        private List<Card> deck = new List<Card>();
        public Stack<Card> shuffledDeck = new Stack<Card>();
        [Inject] private TurnManager _tm;
        [Inject] private StartManager _sm;
        [Inject] private MiddlePileManager _mpm;
        private void Start()
        {
            CardPrefab = Resources.Load<Card>("CardPrefab");
            DeckBuild();
        }
        
        public void DeckBuild()
        {
            for (int i = 0; i < 52; i++)
            {
                var card = Instantiate(CardPrefab);
                card.GenCard(i);
                deck.Add(card);
                card.SetParent(transform,0);
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
                card.SetParent(transform, 0);
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
                    var peek = shuffledDeck.Peek();
                    if (peek.num != 0)
                    {
                        line.AddCard(shuffledDeck.Pop());
                    }
                    else
                    {
                        if (_mpm.CheckCard(peek))
                        {
                            _mpm.PushCard(shuffledDeck.Pop());
                        }
                    }
                    
                }
            }
            else
            {
                foreach (var line in _sm.lineEsq)
                {
                    if (shuffledDeck.Peek().num != 0)
                    {
                        line.AddCard(shuffledDeck.Pop());
                    }
                    else
                    {
                        if (_mpm.CheckCard(shuffledDeck.Peek()))
                        {
                            _mpm.PushCard(shuffledDeck.Pop());
                        }
                    }
                }
            }
            _tm.PlayerCheck();
        }

        public void TurnDeck(Card c)
        {
            shuffledDeck.Push(c);
            c.SetParent(transform, 0);
            c.FlipCard();
            if (Empty)
            {
                Empty = false;
            }
        }

        public Card PickCard(out Card c)
        {
            c = shuffledDeck.Pop();
            c.EnableCard(shuffledDeck.Count);
            if (shuffledDeck.Count<1)
            {
                Empty = true;
            }
            return c;
        }
    }
}