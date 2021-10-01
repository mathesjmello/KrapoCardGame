using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public abstract class StackOfCards: MonoBehaviour, IAddtable
{
    public Stack<Card> Pile = new Stack<Card>();
    public virtual void AddCard(Card card)
    {
        Pile.Push(card);
        card.SetParent(transform, 0);
    }
    
}
