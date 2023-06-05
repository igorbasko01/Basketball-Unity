using UnityEngine;
using System;

public class GameManager : IDisposable
{
    private InputHandler _inputHandler;
    private ICameraService _cameraService;
    public event Action<Vector2> OnPrimaryInputDuringGameplay;

    public GameManager(InputHandler inputHandler, ICameraService cameraService) {
        _inputHandler = inputHandler;
        _cameraService = cameraService;
        _inputHandler.OnPrimaryInput += HandlePrimaryInput;
    }

    public void Dispose()
    {
        _inputHandler.OnPrimaryInput -= HandlePrimaryInput;
    }

    private void HandlePrimaryInput(Vector2 release) {
        var worldPosition = _cameraService.ScreenToWorldPoint(release);
        OnPrimaryInputDuringGameplay?.Invoke(worldPosition);
    }
}
