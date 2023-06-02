using UnityEngine;

public class InputHandlerBehaviour : MonoBehaviour
{
    private InputHandler _inputHandler;
    public void Initialize(InputHandler inputHandler) {
        _inputHandler = inputHandler;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputHandler.Update();    
    }
}
