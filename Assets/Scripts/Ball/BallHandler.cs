using System;
using UnityEngine;

public class BallHandler : IDisposable
{
    private float _speedLimit = 10f;
    private int _numberOfHits = 0;
    public int NumberOfHits => _numberOfHits;

    private IRigidbody2D _ballRigidbody;
    private GameManager _gameManager;

    public BallHandler(GameManager gameManager, IRigidbody2D ballRigidbody) {
        _gameManager = gameManager;
        _ballRigidbody = ballRigidbody;
        _gameManager.OnPrimaryInputDuringGameplay += HandlePrimaryInputDuringGameplay;
    }

    private void HandlePrimaryInputDuringGameplay(Vector2 worldPosition) {
        Vector2 forceDirection = new Vector2(
            _ballRigidbody.Position().x - worldPosition.x, 
            _ballRigidbody.Position().y - worldPosition.y
        );
        _ballRigidbody.AddForce(forceDirection.normalized * 300f);
        
        _numberOfHits++;
    }

    public void ResetOnHighVelocity() {
        if (_ballRigidbody.VelocitySqrMagnitude() > _speedLimit * _speedLimit) {
            _ballRigidbody.Reset();
        }
    }

    public void Dispose()
    {
        _gameManager.OnPrimaryInputDuringGameplay -= HandlePrimaryInputDuringGameplay;
    }
}
