using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class LinesManager: MonoBehaviour
    {
        public List<Line> Lines = new List<Line>();
        public bool HaveEmpty;

        private void Start()
        {
            Lines = FindObjectsOfType<Line>().ToList();
        }

        public void CheckFree()
        {
            HaveEmpty = Lines.Find(line => line.empty);
        }
    }
}