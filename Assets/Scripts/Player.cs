using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public bool turn;
        public Krapo krapo;
        public Card selectedCard;
        public Transform lastPlace;
        public DiscardDeck dDeck;
        public MainDeck mDeck;
        public MiddlePileManager mpm;
        [Inject] private TurnManager _tm;
        [Inject] private LinesManager _lm;

        private void Start()
        {
            mpm = FindObjectOfType<MiddlePileManager>();
        }

        private void Update()
        {
            if (turn)
            {
                CheckInputs();
            }
        }

        private void CheckInputs()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                RaycastHit2D hit =Physics2D.Raycast(ray, Vector2.zero); 
                if ( hit.collider != null)
                {
                    if (selectedCard==null)
                    {
                        lastPlace = hit.transform;
                        var pick = lastPlace.GetComponent<IPickable>();
                        if (lastPlace.GetComponentInChildren<Card>())
                        {
                            selectedCard = pick.PickCard();
                            if (mDeck.empty && !_lm.haveEmpty)
                            {
                                dDeck.SendMain();
                                return;
                            }
                            selectedCard.picked = true;
                            selectedCard.PushUp();
                            if(mpm.CheckCard(selectedCard))
                            {
                                mpm.PushCard(selectedCard);
                                selectedCard.picked = false;
                                selectedCard = null;
                            }
                        }
                    }
                    else
                    {
                        var newPlace = hit.transform;
                        if(newPlace.GetComponent<Krapo>() == krapo) return;
                        if (newPlace.GetComponent<DiscardDeck>() == dDeck) return;
                        var check = newPlace.GetComponent<ICheckable>();
                        var place = newPlace.GetComponent<IAddtable>();
                        var Lastkrapo = lastPlace.GetComponent<Krapo>();
                        if (check.CheckCard(selectedCard))
                        {
                            place.AddCard(selectedCard);
                            selectedCard.picked = false;
                            selectedCard = null;
                        }
                        if (Lastkrapo!= null && Lastkrapo.Pile.Count!=0)
                        {
                            Lastkrapo.TurnLastCard();
                        }
                        else
                        {
                            dDeck.krapoEmpty = true;
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (selectedCard == null)return;
               
                selectedCard.picked = false;
                if (lastPlace.GetComponent<MainDeck>() == null)
                {
                    lastPlace.GetComponent<IAddtable>().AddCard(selectedCard);
                }
                else
                {
                    dDeck.AddCard(selectedCard);
                    _tm.ChangeTurns();
                }
                selectedCard = null;
            }
        }
    }
}