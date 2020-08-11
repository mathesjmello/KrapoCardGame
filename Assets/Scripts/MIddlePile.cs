using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MIddlePile : MonoBehaviour, IAddtable
{
    public Stack<Card> pile =new Stack<Card>();
    public Suits suits;
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    private void Start()
    {
    }

    public void AddCard(Card card)
    {
        {
            if (pile.Count == 0 && card.num == 1)
            {
                pile.Push(card);
                card.SetParent(transform);
                card.DisableCard();
            }
            else
            {
                var currentCard = pile.Peek();
                if (currentCard.suit!= card.suit && currentCard.num-1 == card.num)
                {
                    currentCard.DisableCard();
                    pile.Push(card);
                    card.SetParent(transform);
                }
            }
        }
    }
}
