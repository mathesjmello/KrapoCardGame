using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MiddlePile : StackOfCards
{
    public Suits suits;
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public override void AddCard(Card card)
    {
        card.picked = false;
        Pile.Push(card);
        card.SetParent(transform,0);
        card.transform.position = transform.position;
        card.MiddleCard();
    }
}
