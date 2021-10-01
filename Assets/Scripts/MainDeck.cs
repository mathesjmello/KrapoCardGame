using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class MainDeck: StackOfCards, IDeckable, IPickable
{
    public bool empty;
    public bool other;
    public Krapo krapo;
    public Card cardPrefab;
    private readonly List<Card> _deck = new List<Card>();
    [Inject] private TurnManager _tm;
    [Inject] private StartManager _sm;
    [Inject] private MiddlePileManager _mpm;
    private void Start()
    {
        cardPrefab = Resources.Load<Card>("CardPrefab");
        DeckBuild();
    }
        
    public void DeckBuild()
    {
        for (int i = 0; i < 52; i++)
        {
            var card = Instantiate(cardPrefab);
            card.GenCard(i);
            _deck.Add(card);
            card.SetParent(transform,0);
        } 
        Shuffle();
    }

    public void Shuffle()
    {
        var rng = new Random();
        if (other)
        {
            rng.Next();
        }
        var n = _deck.Count;
        for (var i = 0; i < 4; i++)
        {
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (_deck[k], _deck[n]) = (_deck[n], _deck[k]);
            }
        }
            
        foreach (var card in _deck)
        {
            AddCard(card);
        }
        SetKrapo();
    }
        
    public void SetKrapo()
    {
        for (int i = 0; i < 13; i++)
        {
            krapo.AddCard(Pile.Pop());
        }
        krapo.TurnLastCard();
        PrepareLines();
    }

    private void PrepareLines()
    {
        if (other)
        {
            foreach (var line in _sm.lineDir)
            {
                var peek = Pile.Peek();
                if (peek.num != 0)
                {
                    line.AddCard(Pile.Pop());
                }
                else
                {
                    if (_mpm.CheckCard(peek))
                    {
                        _mpm.PushCard(Pile.Pop());
                    }
                }
                    
            }
        }
        else
        {
            foreach (var line in _sm.lineEsq)
            {
                if (Pile.Peek().num != 0)
                {
                    line.AddCard(Pile.Pop());
                }
                else
                {
                    if (_mpm.CheckCard(Pile.Peek()))
                    {
                        _mpm.PushCard(Pile.Pop());
                    }
                }
            }
        }
        _tm.PlayerCheck();
    }

    public void TurnDeck(Card c)
    {
        Pile.Push(c);
        c.SetParent(transform, 0);
        c.TurnDown();
        if (empty)
        {
            empty = false;
        }
    }

    public Card PickCard()
    {
        var c = Pile.Pop();
        c.ChangeOrder(Pile.Count);
        if (Pile.Count<1)
        {
            empty = true;
        }
        return c;
    }
        
}