using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class TurnManager: MonoBehaviour
    {
        public int _playerCount=0;
        private List<Player> players;

        private void Start()
        {
            players = FindObjectsOfType<Player>().ToList();
        }

        public void PlayerCheck()
        {
            _playerCount++;
            if (_playerCount>1)
            {
                Debug.Log("tem dois player");
                CheckStart();
            }
        }

        public void CheckStart()
        {
            if (players[0].krapo.kDeck.Peek().num>players[1].krapo.kDeck.Peek().num)
            {
                players[0].turn = true;
                Debug.Log("player 1 start");
            }
            else
            {
                players[1].turn = true;
                Debug.Log("player 2 start");
            }
            
        }

        public void ChangeTurns()
        {
            foreach (var player in players)
            {
                var b = !player.turn;
                player.turn = b;
            }
        }
    }
}