using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Line : MonoBehaviour, IAddtable,IPickable
{
    public Stack<Card> line= new Stack<Card>();
    public int CardsCount;
    public void AddCard(Card card)
    {
        if (line.Count == 0)
        {
            line.Push(card);
            card.SetParent(transform);
            card.EnableCard();
        }
        else
        {
            var currentCard = line.Peek();
            if (currentCard.color!= card.color && currentCard.num-1 == card.num)
            {
                currentCard.DisableCard();
                line.Push(card);
                card.SetParent(transform);
                card.EnableCard();
            }
        }
    }

    private void Update()
    {
        CardsCount = line.Count;
    }

    public Card PickCard(out Card c)
    {
        c = line.Pop();
        return c;
    }
}
