using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public Card SelectedCard;
        public IListable LastPlace;
        public MainDeck myDeck;
        public MainDeck yourDeck;
        public DiscartDeck dDeck;
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                RaycastHit2D hit =Physics2D.Raycast(ray, Vector2.zero); 
                if ( hit.collider != null)
                {
                    Debug.Log("acertou o correto");
                    var pile = hit.transform.GetComponent<IPickable>();
                    SelectedCard = pile.PickCard(out _);
                    Debug.Log(hit.transform);
                }
                //dDeck.AddCard(myDeck.shuffledDeck.Pop());
            }
            if (Input.GetMouseButtonUp(1))
            {
               // dDeck.AddCard(yourDeck.shuffledDeck.Pop());
            }
        }
    }
}