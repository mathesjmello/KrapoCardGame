using UnityEngine;

namespace DefaultNamespace
{
    public class Card : MonoBehaviour
    {
        public enum Suits
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }

        public enum Colors
        {
            Red,
            Black
        }

        public float num;
        public Suits suit;
        public Colors color;

        public void GenCard(float v)
        {
            switch (Mathf.Ceil(v/13))
            {
                case 1:
                    suit = Suits.Hearts;
                    color = Colors.Red;
                    num = v;
                    break;
                case 2:
                    suit = Suits.Diamonds;
                    color = Colors.Red;
                    num = v - 13;
                    break;
                case 3:
                    suit = Suits.Spades;
                    color = Colors.Black;
                    num = v - 26;
                    break;
                case 4:
                    suit = Suits.Clubs;
                    color = Colors.Black;
                    num = v - 39;
                    break;
            }
        }
    }
}