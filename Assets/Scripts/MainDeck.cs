
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public class MainDeck: MonoBehaviour, IDeckable
    {
        public Krapo krapo;
        public Card CardPrefab;
        private List<Card> deck;
        public Stack<Card> shuffledDeck;
        private void Start()
        {
            shuffledDeck = new Stack<Card>();
            deck = new List<Card>();
            CardPrefab = Resources.Load<Card>("CardPrefab");
            DeckBuild();
            Shuffle();
        }


        public void DeckBuild()
        {
            for (int i = 1; i < 53; i++)
            {
                var card = Instantiate(CardPrefab);
                card.GenCard(i);
                deck.Add(card);
            }
            Shuffle();
        }

        public void Shuffle()
        {
            var rng = new Random();
            int n = deck.Count;
            for (int i = 0; i < 4; i++)
            {
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = deck[k];
                    deck[k] = deck[n];
                    deck[n] = value;
                }
            }
            
            foreach (var card in deck)
            {
                shuffledDeck.Push(card);
                card.gameObject.transform.parent = transform;
            }
            SetKrapo();
        }

        public void TurnCard()
        {
            throw new System.NotImplementedException();
        }

        public void SetKrapo()
        {
            for (int i = 0; i < 13; i++)
            {
                krapo.AddCard(shuffledDeck.Pop());
            }
        }
    }
}