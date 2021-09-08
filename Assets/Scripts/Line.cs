using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Line : MonoBehaviour, IAddtable,IPickable
{
    public Stack<Card> line= new Stack<Card>();

    [Inject] private StartManager _sm;
   
    public void AddCard(Card card)
    {
        if (line.Count == 0)
        {
            line.Push(card);
            card.SetParent(transform);
            card.EnableCard();
            _sm.CheckPile(card);
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

    public Card PickCard(out Card c)
    {
        c = line.Pop();
        return c;
    }
}
