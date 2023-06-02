using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private GameManagerBehaviour _gameManagerBehaviour;
    BallHandler _ballHandler;
    void Awake()
    {
        _ballHandler = new BallHandler(_gameManagerBehaviour.GameManager, new Rigidbody2DWrapper(GetComponent<Rigidbody2D>()));
    }

    private void OnDestroy()
    {
        _ballHandler.Dispose();
    }
}
