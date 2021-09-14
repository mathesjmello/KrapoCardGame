using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public Card SelectedCard;
        public Transform LastPlace;
        public MainDeck myDeck;
        public MainDeck yourDeck;
        public DiscartDeck dDeck;
        public MiddlePileManager mpm;

        private void Start()
        {
            mpm = FindObjectOfType<MiddlePileManager>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                RaycastHit2D hit =Physics2D.Raycast(ray, Vector2.zero); 
                if ( hit.collider != null)
                {
                    if (SelectedCard==null)
                    {
                        LastPlace = hit.transform;
                        var pick = LastPlace.GetComponent<IPickable>();
                        if (LastPlace.GetComponentInChildren<Card>())
                        {
                            SelectedCard = pick.PickCard(out _);
                            if (SelectedCard!=null)
                            {
                                SelectedCard.Picked = true;
                                if(mpm.CheckCard(SelectedCard))
                                {
                                    mpm.PushCard(SelectedCard);
                                };
                            }
                        }
                    }
                    else
                    {
                        var newPlace = hit.transform;
                        var check = newPlace.GetComponent<ICheckable>();
                        var place = newPlace.GetComponent<IAddtable>();
                        var krapo = LastPlace.GetComponent<Krapo>();
                        if (check.CheckCard(SelectedCard))
                        {
                            place.AddCard(SelectedCard);
                            SelectedCard.Picked = false;
                            SelectedCard = null;
                        }
                        if (krapo!= null)
                        {
                            krapo.TurnLastCard();
                        }
                    }
                    
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                SelectedCard.Picked = false;
                if (LastPlace.GetComponent<IAddtable>()!= null)
                {
                    LastPlace.GetComponent<IAddtable>().AddCard(SelectedCard);
                }
                else
                {
                    dDeck.AddCard(SelectedCard);
                }

                SelectedCard = null;
            }
        }
    }
}