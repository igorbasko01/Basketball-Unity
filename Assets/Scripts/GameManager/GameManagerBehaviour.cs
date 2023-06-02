using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    private GameManager _gameManager;
    
    public void Initialize(GameManager gameManager) {
        _gameManager = gameManager;
    }

    private void OnDestroy() {
        _gameManager.Dispose();
    }
}
