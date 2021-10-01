
using DefaultNamespace;
using Zenject;

public class Line : StackOfCards,IPickable, ICheckable
{
    public bool empty;
    [Inject] private LinesManager _lm;
    public override void AddCard(Card card)
    {
        Pile.Push(card);
        card.SetParent(transform,Pile.Count-1);
        card.ChangeOrder(Pile.Count);
        empty = false;
        _lm.CheckFree();
    }
    
    public bool CheckCard(Card card)
    {
        if (Pile.Count == 0)
        {
            return true;
        }
        var currentCard = Pile.Peek();
        return currentCard.color != card.color && currentCard.num - 1 == card.num;
    }

    public Card PickCard()
    {
        var c = Pile.Pop();
        if (Pile.Count != 0) return c;
        empty = true;
        _lm.CheckFree();
        return c;
    }
}
