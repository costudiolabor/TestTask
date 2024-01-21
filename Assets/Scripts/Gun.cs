using System;
using UnityEngine;

[Serializable]
public class Gun {
    [SerializeField] private Transform gunObj;
    [SerializeField] private Transform spawnBall;
    [SerializeField] private Ball prefabBall;
    [SerializeField] private float maxSpeedBall = 10.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] private int maxCountBall = 1000;
    private PoolObjects _poolObjects = new();
    public void Initialize() => _poolObjects.Initialize(prefabBall, maxCountBall, false, spawnBall);
    public void RotateCanon(Vector3 targetPoint) {
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - gunObj.position);
        gunObj.rotation = Quaternion.Slerp(gunObj.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void Shoot(float timePush) {
        var speedBall = maxSpeedBall * timePush;
        
        var ball = _poolObjects.GetFreeElement();
        var transform = ball.transform;
        transform.position = spawnBall.position;
        transform.rotation = spawnBall.rotation;
        
        var direction = transform.forward;
        var rigidbodyBall = ball.GetComponent<Rigidbody>();
        rigidbodyBall.AddForce(direction * speedBall, ForceMode.Impulse);
    }
}