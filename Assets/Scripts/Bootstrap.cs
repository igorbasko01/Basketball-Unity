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
        var gameManager = new GameManager(inputHandler, new CameraService());

        _inputHandlerBehaviour.Initialize(inputHandler);
        _gameManagerBehaviour.Initialize(gameManager);
        _ballBehaviour.Initialize(gameManager);
    }
}
