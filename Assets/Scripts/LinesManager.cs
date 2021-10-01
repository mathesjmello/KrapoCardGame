using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class LinesManager: MonoBehaviour
    {
        public List<Line> lines = new List<Line>();
        public bool haveEmpty;

        private void Start()
        {
            lines = FindObjectsOfType<Line>().ToList();
        }

        public void CheckFree()
        {
            haveEmpty = lines.Find(line => line.empty);
        }
    }
}