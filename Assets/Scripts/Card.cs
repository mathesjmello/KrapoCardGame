﻿using System;
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

            CoverImg = _sm.sprites[0];
            RealImg = _sm.sprites[v];
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
            _canvas.sortingOrder = 1; 
            playable = true;
            SetSprite();
            _mgm.CheckCard(this);
        }
        

        public void DisableCard()
        {
            _canvas.sortingOrder = -1; 
            playable = false;
            SetSprite();
        }
    }
}