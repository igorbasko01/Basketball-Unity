using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    bool IsPrimaryInputEnded(out Vector2 release);
}
