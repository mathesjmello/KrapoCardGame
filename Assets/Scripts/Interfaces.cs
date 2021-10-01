using System.Collections.Generic;

namespace DefaultNamespace
{
 
    public interface IDeckable
    {
        void DeckBuild();
        void Shuffle();
        
        void SetKrapo();
    }

    public interface IAddtable
    {
        void AddCard(Card card);
    }
    
    public interface IPickable
    {
        Card PickCard();
    }

    public interface ICheckable
    {
        bool CheckCard(Card c);
    }


}