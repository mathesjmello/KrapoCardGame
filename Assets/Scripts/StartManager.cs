using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class StartManager : MonoBehaviour

    {
    public List<Line> lineEsq;
    public List<Line> lineDir;
    public DiscartDeck myDiscard;
    public DiscartDeck yourDiscard;
    public List<MIddlePile> mpClub, mpDimonds, mpSpades, mpHearts;
    public Sprite[] sprites;

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("card");
    }
    
    }
}