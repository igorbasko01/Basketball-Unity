using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    BallHandler _ballHandler;
    void Awake() {
        _ballHandler = new BallHandler(new Rigidbody2DWrapper(GetComponent<Rigidbody2D>()));
    }

    private void OnDestroy() {
        _ballHandler.Dispose();
    }
}
