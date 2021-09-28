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
        public Card SelectedCard;
        public Transform LastPlace;
        public DiscartDeck dDeck;
        public MiddlePileManager mpm;
        [Inject] private TurnManager _tm;

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
                                    SelectedCard.Picked = false;
                                    SelectedCard = null;
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
                        if (krapo!= null && krapo.kDeck.Count!=0)
                        {
                            krapo.TurnLastCard();
                        }
                    }
                    
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (SelectedCard == null)return;
               
                SelectedCard.Picked = false;
                if (LastPlace.GetComponent<IAddtable>()!= null)
                {
                    LastPlace.GetComponent<IAddtable>().AddCard(SelectedCard);
                }
                else
                {
                    dDeck.AddCard(SelectedCard);
                    _tm.ChangeTurns();
                }
                SelectedCard = null;
            }
        }
    }
}