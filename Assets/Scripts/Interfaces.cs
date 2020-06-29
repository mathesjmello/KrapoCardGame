using System.Collections.Generic;

namespace DefaultNamespace
{
    public interface IPlayable
    {
        bool Playable { get; set; }
    }

    public interface IListable
    {
        void PutCard();

        void TakeCard();
    }

    public interface IDeckable
    {
        void DeckBuild();
        void Shuffle();

        void TurnCard();

        void SetKrapo();
    }

    public interface IAddtable
    {
        void AddCard(Card card);

    }

    public interface IRecivable
    {
        void ReciveCard(Card card);
    }


}