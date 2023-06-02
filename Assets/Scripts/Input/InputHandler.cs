using System;

public class InputHandler
{
    private IInputProvider _inputProvider;
    public event Action OnPrimaryInput;

    public InputHandler(IInputProvider inputProvider) {
        _inputProvider = inputProvider;
    }

    private void HandlePrimaryInput() {
        OnPrimaryInput?.Invoke();
    }

    public void Update()
    {
        if (_inputProvider.IsPrimaryInputEnded()) 
            HandlePrimaryInput();
    }
}