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

    public void AddCard(Card card)
    {
        pile.Push(card);
        card.SetParent(transform);
        card.DisableCard();
    }
}
