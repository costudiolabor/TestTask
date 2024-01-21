using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private float timeLife = 2.0f;
    private Coroutine _coroutine;
    private void OnEnable() { _coroutine = StartCoroutine(TimerLife()); }

    private IEnumerator TimerLife() {
        yield return new WaitForSeconds(timeLife);
       gameObject.SetActive(false);
       _coroutine = null;
    }
    
    private void OnDisable() {
        if (_coroutine == null) return; 
        StopCoroutine(_coroutine);
    }
}
