using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] InputHandlerBehaviour _inputHandlerBehaviour;
    private GameManager _gameManager;
    public GameManager GameManager => _gameManager;
    void Awake()
    {
        _gameManager = new GameManager(_inputHandlerBehaviour.InputHandler);
    }

    private void OnDestroy() {
        _gameManager.Dispose();
    }
}
