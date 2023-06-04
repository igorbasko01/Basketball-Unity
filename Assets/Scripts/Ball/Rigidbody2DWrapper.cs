using UnityEngine;

public class Rigidbody2DWrapper : IRigidbody2D
{
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2DWrapper(Rigidbody2D rigidbody2D) {
        _rigidbody2D = rigidbody2D;
    }

    public void AddForce(Vector2 vector2) {
        _rigidbody2D.AddForce(vector2);
    }

    public Vector2 Position() {
        return _rigidbody2D.transform.position;
    }

    public float VelocitySqrMagnitude() {
        return _rigidbody2D.velocity.sqrMagnitude;
    }

    public Vector2 Velocity() {
        return _rigidbody2D.velocity;
    }

    public void Reset() {
        _rigidbody2D.transform.position = Vector2.zero;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
