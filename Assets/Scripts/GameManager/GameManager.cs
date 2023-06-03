using UnityEngine;
using System;

public class GameManager : IDisposable
{
    private InputHandler _inputHandler;
    public event Action<Vector2> OnPrimaryInputDuringGameplay;

    public GameManager(InputHandler inputHandler) {
        _inputHandler = inputHandler;
        _inputHandler.OnPrimaryInput += HandlePrimaryInput;
    }

    public void Dispose()
    {
        _inputHandler.OnPrimaryInput -= HandlePrimaryInput;
    }

    private void HandlePrimaryInput(Vector2 release) {
        OnPrimaryInputDuringGameplay?.Invoke(release);
    }
}
