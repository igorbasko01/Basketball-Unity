using UnityEngine;

public interface IRigidbody2D
{
    Vector2 Position();
    void AddForce(Vector2 vector2);
    Vector2 Velocity();
    float VelocitySqrMagnitude();
    void Reset();
    void StopVelocity();
}
