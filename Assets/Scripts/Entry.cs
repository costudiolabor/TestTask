using UnityEngine;

public class Entry : MonoBehaviour {
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Gate gate;
    [SerializeField] private Score score;
    [SerializeField] private Gun gun;
    private readonly HandlerMouse _handlerMouse = new ();

    private void Awake() {
        gun.Initialize();
        _handlerMouse.Initialize();
        gate.AddScoreEvent += OnAddScore;
        _handlerMouse.UpButtonEvent += OnButtonUp;
        _handlerMouse.MoveMouseEvent += OnLookMouse;
    }

    private void OnAddScore(int value) { score.SetScore(value); }
    
    private void OnLookMouse(Vector2 positionMouse) {
        Vector3 positionScreen = positionMouse;
        positionScreen.z = 10;
        var targetPoint = cameraMain.ScreenToWorldPoint(positionScreen);
        gun.RotateCanon(targetPoint);
    }

    private void OnButtonUp(float timePush) => gun.Shoot(timePush); 
    private void OnDestroy() {
        gate.AddScoreEvent -= OnAddScore;
        _handlerMouse.UpButtonEvent -= OnButtonUp;
        _handlerMouse.MoveMouseEvent -= OnLookMouse;
    }
}