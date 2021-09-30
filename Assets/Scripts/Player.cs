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
        public DiscartDeck dDeck;
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
                            selectedCard = pick.PickCard(out _);
                            
                            if (mDeck.Empty && !_lm.HaveEmpty)
                            {
                                if (selectedCard == null)
                                {
                                    dDeck.SendMain();
                                    return;
                                }
                                
                            }
                            if (selectedCard!=null)
                            {
                                selectedCard.Picked = true;
                                selectedCard.PushUp();
                                if(mpm.CheckCard(selectedCard))
                                {
                                    mpm.PushCard(selectedCard);
                                    selectedCard.Picked = false;
                                    selectedCard = null;
                                };
                            }
                        }
                    }
                    else
                    {
                        var newPlace = hit.transform;
                        var check = newPlace.GetComponent<ICheckable>();
                        var place = newPlace.GetComponent<IAddtable>();
                        var Lastkrapo = lastPlace.GetComponent<Krapo>();
                        if (check.CheckCard(selectedCard))
                        {
                            place.AddCard(selectedCard);
                            selectedCard.Picked = false;
                            selectedCard = null;
                        }
                        if (Lastkrapo!= null && Lastkrapo.kDeck.Count!=0)
                        {
                            Lastkrapo.TurnLastCard();
                        }
                        else
                        {
                            dDeck.empty = true;
                        }
                    }
                    
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (selectedCard == null)return;
               
                selectedCard.Picked = false;
                if (lastPlace.GetComponent<IAddtable>()!= null)
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