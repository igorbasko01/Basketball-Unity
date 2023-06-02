using System;
using UnityEngine;

public class BallHandler : IDisposable
{
    private int _numberOfHits = 0;
    public int NumberOfHits => _numberOfHits;

    private IRigidbody2D _ballRigidbody;

    public BallHandler(IRigidbody2D ballRigidbody) {
        GameManager.OnPrimaryInputDuringGameplay += HandlePrimaryInputDuringGameplay;
        _ballRigidbody = ballRigidbody;
    }

    public void HandlePrimaryInputDuringGameplay() {
        Debug.Log("BallHandler.HandlePrimaryInputDuringGameplay");
        _ballRigidbody.AddForce(new Vector2(0, 100));
        _numberOfHits++;
    }

    public void Dispose()
    {
        GameManager.OnPrimaryInputDuringGameplay -= HandlePrimaryInputDuringGameplay;
    }
}
