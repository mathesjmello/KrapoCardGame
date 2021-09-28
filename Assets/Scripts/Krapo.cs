using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Krapo : MonoBehaviour, IPickable, ICheckable, IAddtable

    {
    public Stack<Card> kDeck = new Stack<Card>();
    [Inject] private MiddlePileManager _mpm;

    public void AddCard(Card card)
    {
        kDeck.Push(card);
        card.SetParent(transform, 0);
        card.EnableCard(kDeck.Count);
    }

    public void TurnLastCard()
    {
        var lastCard = kDeck.Peek();
        lastCard.EnableCard(kDeck.Count);
    }

    public Card PickCard(out Card c)
    {
        c = kDeck.Pop();
        return c;
    }

    public bool CheckCard(Card c)
    {
        var topCard = kDeck.Peek();
        if (c.suit == topCard.suit && (c.num == topCard.num - 1 || c.num == topCard.num + 1))
        {
            return true;
        }

        return false;
    }
    }
}