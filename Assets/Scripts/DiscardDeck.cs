using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class DiscardDeck : StackOfCards, IPickable, ICheckable
    {
        public bool krapoEmpty;
        public MainDeck md;
        [Inject] private LinesManager _lm;
        public override void AddCard(Card card)
        {
            Pile.Push(card);
            card.SetParent(transform,0);
            card.ChangeOrder(Pile.Count);
        }

        public Card PickCard()
        {
            var c = krapoEmpty&&_lm.haveEmpty ? Pile.Pop() : null;
            return c;
        }

        public void SendMain()
        {
            while (Pile.Count>0)
            {
                md.TurnDeck(Pile.Pop());
            }
        }

        public bool CheckCard(Card c)
        {
            var currentCard = Pile.Peek();
            return currentCard.suit == c.suit && (currentCard.num + 1 == c.num || currentCard.num - 1 == c.num);
        }
    }
}