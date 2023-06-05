using UnityEngine;

public class UnityInputProvider : IInputProvider
{
    public bool IsPrimaryInputEnded(out Vector2 releaseCoordinates)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                releaseCoordinates = Input.GetTouch(0).position;
                return true;
            }
        }
        else if(Input.GetMouseButtonUp(0)) {
            releaseCoordinates = Input.mousePosition;
            return true;
        }
        releaseCoordinates = Vector2.zero;
        return false;
    }
}
