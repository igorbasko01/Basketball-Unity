using UnityEngine;
using System;

public class GameManager : IDisposable
{
    private InputHandler _inputHandler;
    public event Action OnPrimaryInputDuringGameplay;

    public GameManager(InputHandler inputHandler) {
        _inputHandler = inputHandler;
        _inputHandler.OnPrimaryInput += HandlePrimaryInput;
    }

    public void Dispose()
    {
        _inputHandler.OnPrimaryInput -= HandlePrimaryInput;
    }

    private void HandlePrimaryInput() {
        OnPrimaryInputDuringGameplay?.Invoke();
    }
}
