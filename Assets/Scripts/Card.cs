using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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

        private bool playable;
        public float num;
        public Suits suit;
        public Colors color;
        public Sprite CoverImg;
        public Sprite RealImg;
        private GameManeger gm;
        public Image Img;

        private void Awake()
        {
            Img = GetComponentInChildren<Image>();
            gm = FindObjectOfType<GameManeger>();
        }
        public void GenCard(int v)
        {
            switch (Mathf.Ceil(f: v/13))
            {
                case 1:
                    suit = Suits.Clubs;
                    color = Colors.Red;
                    num = v;
                    break;
                case 2:
                    suit = Suits.Diamonds;
                    color = Colors.Red;
                    num = v - 13;
                    break;
                case 3:
                    suit = Suits.Hearts;
                    color = Colors.Black;
                    num = v - 26;
                    break;
                case 4:
                    suit = Suits.Spades;
                    color = Colors.Black;
                    num = v - 39;
                    break;
            }

            CoverImg = gm.sprites[0];
            RealImg = gm.sprites[v];
            SetSprite();
        }
        
        private void SetSprite()
        {
            Img.sprite = playable ? RealImg : CoverImg;
        }

    public void SetParent(Transform p0)
        {
            transform.parent = p0;
            transform.localPosition = Vector3.zero;
        }

        public void EnableCard()
        {
            playable = true;
            SetSprite();
        }
        

        public void DisableCard()
        {
            playable = false;
            SetSprite();
        }
    }
}