using System;
using UnityEngine;

public class BallHandler : IDisposable
{
    private float _speedLimit = 50f;
    private int _numberOfHits = 0;
    public int NumberOfHits => _numberOfHits;

    private IRigidbody2D _ballRigidbody;
    private GameManager _gameManager;

    public BallHandler(GameManager gameManager, IRigidbody2D ballRigidbody) {
        _gameManager = gameManager;
        _ballRigidbody = ballRigidbody;
        _gameManager.OnPrimaryInputDuringGameplay += HandlePrimaryInputDuringGameplay;
    }

    public void HandlePrimaryInputDuringGameplay(Vector2 release) {
        Vector2 forceDirection = new Vector2(
            _ballRigidbody.Position().x - release.x, 
            _ballRigidbody.Position().y - release.y
        );
        _ballRigidbody.AddForce(forceDirection.normalized * 100f);
        
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
