using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    private GameManager _gameManager;
    void Awake()
    {
        _gameManager = new GameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        _gameManager.Dispose();
    }
}
