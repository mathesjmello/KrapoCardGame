using DefaultNamespace;

public class Krapo : StackOfCards, IPickable, ICheckable
{

    public override void AddCard(Card card)
    {
        Pile.Push(card);
        card.SetParent(transform, 0);
        card.ChangeOrder(Pile.Count);
    }

    public void TurnLastCard()
    {
        var lastCard = Pile.Peek();
        lastCard.ChangeOrder(Pile.Count);
    }

    public Card PickCard()
    {
        var c = Pile.Pop();
        return c;
    }

    public bool CheckCard(Card c)
    {
        var topCard = Pile.Peek();
        if (c.suit == topCard.suit && (c.num == topCard.num - 1 || c.num == topCard.num + 1))
        {
            return true;
        }
        return false;
    }
}