using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraService : ICameraService
{
    public Vector3 ScreenToWorldPoint(Vector2 position)
    {
        return Camera.main.ScreenToWorldPoint(position);
    }
}
