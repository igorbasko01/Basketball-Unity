using System;
using UnityEngine;

public class InputHandler
{
    private IInputProvider _inputProvider;
    public event Action<Vector2> OnPrimaryInput;

    public InputHandler(IInputProvider inputProvider) {
        _inputProvider = inputProvider;
    }

    private void HandlePrimaryInput(Vector2 release) {
        OnPrimaryInput?.Invoke(release);
    }

    public void Update()
    {
        if (_inputProvider.IsPrimaryInputEnded(out var release)) 
            HandlePrimaryInput(release);
    }
}