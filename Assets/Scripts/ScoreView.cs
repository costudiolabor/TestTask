using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour {
 [SerializeField] private TMP_Text score;

 public void SetScore(int value) {
     score.text = value.ToString();
 }
 
}
