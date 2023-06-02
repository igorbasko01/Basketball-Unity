using UnityEngine;

public class UnityInputProvider : IInputProvider
{
    public bool IsPrimaryInputEnded()
    {
        if (UnityEngine.Input.touchCount > 0)
        {
            return UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended;
        }

        return Input.GetMouseButtonUp(0);
    }
}
