using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreSystem : MonoBehaviour
    {
        private static int _scoreTotal = 0;
        public static int ScoreTotal
        { get { return _scoreTotal; } }

        public static void AddScore(int score) 
        {
            _scoreTotal += score;
        }
    }
}