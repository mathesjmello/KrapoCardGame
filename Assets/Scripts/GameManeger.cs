using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManeger : MonoBehaviour
    {
        public List<Line> lineEsq;
        public List<Line> lineDir;
        public DiscartDeck myDiscard;
        public DiscartDeck yourDiscard;
        public List<MIddlePile> mpClub, mpDimonds , mpSpades , mpHearts;
        public Sprite[] sprites;
        private void Awake()
        {
            sprites = Resources.LoadAll<Sprite>("card");
        }

        public void CheckPile(Card card)
        {
            switch (card.suit)
            {
                case Card.Suits.Clubs:
                    foreach (var mp in mpClub)
                    {
                        if (mp.pile.Count == 0 && card.num == 1)
                        {
                            mp.AddCard(card);
                            card.DisableCard();
                            card.SetParent(mp.transform);
                        }
                        else
                        {
                            if (mp.pile.IsEmpty())
                            {
                                return;
                            }
                            if (mp.pile.Peek().num == card.num - 1)
                            {
                                mp.AddCard(card);
                                card.DisableCard();
                                card.SetParent(mp.transform);
                            }
                        }
                    }
                    break;
                case Card.Suits.Diamonds:
                    foreach (var mp in mpDimonds)
                    {
                        if (mp.pile.Count == 0 && card.num == 1)
                        {
                            mp.AddCard(card);
                            card.DisableCard();
                            card.SetParent(mp.transform);
                        }
                        else
                        {
                            if (mp.pile.IsEmpty())
                            {
                                return;
                            }
                            if (mp.pile.Peek().num == card.num - 1)
                            {
                                mp.AddCard(card);
                                card.DisableCard();
                                card.SetParent(mp.transform);
                            }
                        }
                    }
                    break;
                case Card.Suits.Hearts:
                    foreach (var mp in mpHearts)
                    {
                        if (mp.pile.Count == 0 && card.num == 1)
                        {
                            mp.AddCard(card);
                            card.DisableCard();
                            card.SetParent(mp.transform);
                        }
                        else
                        {
                            if (mp.pile.IsEmpty())
                            {
                                return;
                            }
                            if (mp.pile.Peek().num == card.num - 1)
                            {
                                mp.AddCard(card);
                                card.DisableCard();
                                card.SetParent(mp.transform);
                            }
                        }
                    }
                    break;
                case Card.Suits.Spades:
                    foreach (var mp in mpSpades)
                    {
                        if (mp.pile.Count == 0 && card.num == 1)
                        {
                            mp.AddCard(card);
                            card.DisableCard();
                            card.SetParent(mp.transform);
                        }
                        else
                        {
                            if (mp.pile.IsEmpty())
                            {
                                return;
                            }
                            if (mp.pile.Peek().num == card.num - 1)
                            {
                                mp.AddCard(card);
                                card.DisableCard();
                                card.SetParent(mp.transform);
                            }
                        }
                    }
                    break;
            }
        }
    }
}