using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MiddlePile : MonoBehaviour, IAddtable
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
        card.Picked = false;
        pile.Push(card);
        card.SetParent(transform);
        card.transform.position = transform.position;
        card.SetSprite();
    }
}
