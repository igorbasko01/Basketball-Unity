using System;
using UnityEngine;

public class BallHandler : IDisposable
{
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
        _ballRigidbody.AddForce(new Vector2(0, 500));
        _numberOfHits++;
    }

    public void Dispose()
    {
        _gameManager.OnPrimaryInputDuringGameplay -= HandlePrimaryInputDuringGameplay;
    }
}
