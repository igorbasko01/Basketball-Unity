using System;
using UnityEngine;

public class BasketRimHandler {
    private Vector2 _worldPosition;
    public event Action OnBallWentThroughBasket;

    public BasketRimHandler(Vector2 worldPosition) {
        _worldPosition = worldPosition;
    }

    public void OnBallExitBasketRim(IRigidbody2D ballRigidBody) {
        if (ballRigidBody.Position().y < _worldPosition.y) {
            OnBallWentThroughBasket?.Invoke();
        }
    }
}