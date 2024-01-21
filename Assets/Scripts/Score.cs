using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Score {
   [FormerlySerializedAs("_scoreView")] [SerializeField] private ScoreView scoreView;
   private int currentScore; 
   public void Initialize() { }

   public void SetScore(int value) {
      currentScore += value;
      scoreView.SetScore(currentScore);
   }
}
