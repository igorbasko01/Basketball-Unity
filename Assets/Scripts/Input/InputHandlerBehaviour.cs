using UnityEngine;

public class InputHandlerBehaviour : MonoBehaviour
{
    private InputHandler _inputHandler;
    void Awake()
    {
        _inputHandler = new InputHandler(new UnityInputProvider());
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
