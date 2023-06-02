using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private InputHandlerBehaviour _inputHandlerBehaviour;
    [SerializeField] private GameManagerBehaviour _gameManagerBehaviour;
    [SerializeField] private BallBehaviour _ballBehaviour;
    
    void Awake() {

        var inputHandler = new InputHandler(new UnityInputProvider());
        var gameManager = new GameManager(inputHandler);

        _inputHandlerBehaviour.Initialize(inputHandler);
        _gameManagerBehaviour.Initialize(gameManager);
        _ballBehaviour.Initialize(gameManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
