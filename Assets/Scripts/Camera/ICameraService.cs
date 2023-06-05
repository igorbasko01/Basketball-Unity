using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraService
{
    Vector3 ScreenToWorldPoint(Vector2 position);
}
