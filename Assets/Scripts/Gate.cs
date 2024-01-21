using UnityEngine;
using System;

public class Gate : MonoBehaviour {
    [SerializeField] private int maxScore = 1;
    public event Action<int> AddScoreEvent;
   private void OnCollisionExit(Collision other) {
       var currentObject = other.gameObject;
       if (currentObject.TryGetComponent(out Ball ball) == false) return;
       Hit(currentObject);
   }

   private void Hit(GameObject currentObject) {
       currentObject.SetActive(false);
       AddScoreEvent?.Invoke(maxScore);
   }
}
