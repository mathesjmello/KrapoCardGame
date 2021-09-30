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
        public bool Picked;
        public int num;
        public Suits suit;
        public Colors color;
        public Sprite CoverImg;
        public Sprite RealImg;
        [Inject]private StartManager _sm;
        [Inject] private MiddlePileManager _mgm;
        private Canvas _canvas;
        public Image Img;

        private void Awake()
        {
            _canvas = GetComponentInChildren<Canvas>();
            Img = GetComponentInChildren<Image>();
            _sm = FindObjectOfType<StartManager>();
            _mgm = FindObjectOfType<MiddlePileManager>();
        }

        private void Update()
        {
            if (Picked)
            {
                FollowMouse();
            }
        }

        private void FollowMouse()
        {
            
            var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mPos.x, mPos.y, 3);
        }

        public void GenCard(int v)
        {
            switch (Mathf.Ceil(f: v/13))
            {
                case 0:
                    suit = Suits.Clubs;
                    color = Colors.Black;
                    num = v;
                    break;
                case 1:
                    suit = Suits.Diamonds;
                    color = Colors.Red;
                    num = v - 13;
                    break;
                case 2:
                    suit = Suits.Hearts;
                    color = Colors.Red;
                    num = v - 26;
                    break;
                case 3:
                    suit = Suits.Spades;
                    color = Colors.Black;
                    num = v - 39;
                    break;
            }

            CoverImg = _sm.sprites[0];
            RealImg = _sm.sprites[v+1];
            SetSprite();
        }
        
        public void SetSprite()
        {
            Img.sprite = playable ? RealImg : CoverImg;
        }

        public void SetParent(Transform p0, int n)
        {
            transform.parent = p0;
            transform.localPosition = new Vector3(n*30, 0, 0 );
        }

        public void EnableCard(int i)
        {
            _canvas.sortingOrder = i; 
            playable = true;
            SetSprite();
        }
        
        public void DisableCard(int i)
        {
            _canvas.sortingOrder = i; 
            playable = false;
            //SetSprite();
        }

        public void FlipCard()
        {
            SetSprite();
        }

        public void PushUp()
        {
            _canvas.sortingOrder = 60;
        }
        
        public void MiddleCard()
        {
            _canvas.sortingOrder= num;
            playable = false;
            Img.sprite = RealImg;
        }
    }
}