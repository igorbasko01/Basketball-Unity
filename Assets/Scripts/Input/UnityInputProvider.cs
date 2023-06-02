using UnityEngine;

public class UnityInputProvider : IInputProvider
{
    public bool IsPrimaryInputEnded(out Vector2 release)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                release = Input.GetTouch(0).position;
                return true;
            }
        }
        else if(Input.GetMouseButtonUp(0)) {
            release = Input.mousePosition;
            return true;
        }
        release = Vector2.zero;
        return false;
    }
}
