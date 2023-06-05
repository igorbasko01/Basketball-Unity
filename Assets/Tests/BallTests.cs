using UnityEngine;
using NUnit.Framework;

public class MockRigidbody2D : IRigidbody2D
{
    public Vector2 velocity;
    public Vector2 position = new Vector2(10, 10);
    public Vector2 forceAdded;
    public Vector2 Position() {
        return position;
    }

    public void AddForce(Vector2 vector2)
    {
        forceAdded = vector2;
    }

    public Vector2 Velocity()
    {
        return Vector2.zero;
    }

    public float VelocitySqrMagnitude()
    {
        return velocity.sqrMagnitude;
    }

    public void Reset()
    {
        position = Vector2.zero;
        velocity = Vector2.zero;
    }
}

public class MockCameraService : ICameraService
{
    public Vector3 ScreenToWorldPoint(Vector2 worldPosition)
    {
        return new Vector2(20, 25);
    }
}

[TestFixture]
public class BallTests
{
    private InputHandler inputHandler;
    private GameManager gameManager;
    private MockInputProvider inputProvider;
    private ICameraService cameraService;

    [SetUp]
    public void SetUp()
    {
        inputProvider = new MockInputProvider();
        inputHandler = new InputHandler(inputProvider);
        cameraService = new MockCameraService();
        gameManager = new GameManager(inputHandler, cameraService);
    }

    [Test]
    public void BallNumberOfHitsIncreasedByOneOnPrimaryInput() {
        BallHandler ballHandler = new BallHandler(gameManager, new MockRigidbody2D());
        inputHandler.Update();

        Assert.AreEqual(1, ballHandler.NumberOfHits);
    }

    [Test]
    public void BallMovesUpWhenPrimaryInput()
    {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D);
        inputProvider.SetPrimaryInputCoordinates(new Vector2(10, -20));
        inputHandler.Update();

        Assert.AreEqual(100, rigidbody2D.forceAdded.y);
    }

    [Test]
    public void BallForceIsOppositeDirectionFromTheInputCoordinates() {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D);
        inputProvider.SetPrimaryInputCoordinates(new Vector2(30, 10));        
        inputHandler.Update();

        Assert.AreEqual(-100, rigidbody2D.forceAdded.x);
        Assert.AreEqual(0, rigidbody2D.forceAdded.y);
    }

    [Test]
    public void ResetBallPositionOnHighVelocity() {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D);
        rigidbody2D.velocity = new Vector2(100, 100);
        ballHandler.ResetOnHighVelocity();

        Assert.AreEqual(Vector2.zero, rigidbody2D.Position());
        Assert.AreEqual(Vector2.zero, rigidbody2D.Velocity());
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
            GameObject.Destroy(obj.gameObject);
    }
}
