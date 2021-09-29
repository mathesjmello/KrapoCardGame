using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Line : MonoBehaviour, IAddtable,IPickable, ICheckable
{
    public Stack<Card> line= new Stack<Card>();
    public bool empty;
    [Inject] private LinesManager _lm;
    public void AddCard(Card card)
    {
        if (line.Count != 0)
        {
            var currentCard = line.Peek();
            if (currentCard!=null)
            {
                currentCard.DisableCard(line.Count);
            }
        }
        line.Push(card);
        card.SetParent(transform,line.Count-1);
        card.EnableCard(line.Count);
        empty = false;
        _lm.CheckFree();
    }

    public bool CheckCard(Card card)
    {
        if (line.Count == 0)
        {
            return true;
        }
        else
        {
            var currentCard = line.Peek();
            if (currentCard.color != card.color && currentCard.num - 1 == card.num)
            {
                return true;
            }
        }
        return false;
    }
    

    public Card PickCard(out Card c)
    {
        c = line.Pop();
        if (line.Count == 0)
        {
            empty = true;
            _lm.CheckFree();
        }
        return c;
    }
}
