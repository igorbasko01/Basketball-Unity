using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    BallHandler _ballHandler;

    public void Initialize(GameManager gameManager) {
        _ballHandler = new BallHandler(gameManager, new Rigidbody2DWrapper(GetComponent<Rigidbody2D>()));
    }

    void FixedUpdate()
    {
        _ballHandler.ResetOnHighVelocity();
    }

    private void OnDestroy()
    {
        _ballHandler.Dispose();
    }
}
