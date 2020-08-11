using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Line : MonoBehaviour, IAddtable
{
    public Stack<Card> line= new Stack<Card>();

    [Inject] private GameManeger gm;
   
    public void AddCard(Card card)
    {
        if (line.Count == 0)
        {
            line.Push(card);
            card.SetParent(transform);
            card.EnableCard();
            gm.CheckPile(card);
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
    
}
