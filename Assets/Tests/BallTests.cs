using UnityEngine;
using NUnit.Framework;
using Moq;

public class MockRigidbody2D : IRigidbody2D
{
    public Vector2 velocity;
    public Vector2 position = new Vector2(0, 0);
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

    public void StopVelocity() {
        velocity = Vector2.zero;
    }
}

[TestFixture]
public class BallTests
{
    private InputHandler inputHandler;
    private GameManager gameManager;
    private MockInputProvider inputProvider;
    private Mock<ICameraService> cameraService;

    [SetUp]
    public void SetUp()
    {
        inputProvider = new MockInputProvider();
        inputHandler = new InputHandler(inputProvider);
        cameraService = new Mock<ICameraService>();
        gameManager = new GameManager(inputHandler, cameraService.Object);
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
        var inputClick = new Vector2(0, -1);
        var mockCameraService = new Mock<ICameraService>();
        mockCameraService.Setup(x => x.ScreenToWorldPoint(It.IsAny<Vector2>())).Returns(inputClick);
        var gameManager = new GameManager(inputHandler, mockCameraService.Object);
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D, forceMagnitudeMultiplier: 1f);
        inputHandler.Update();

        Assert.AreEqual(1, rigidbody2D.forceAdded.y);
    }

    [Test]
    public void BallForceIsOppositeDirectionFromTheInputCoordinates() {
        var mockCameraService = new Mock<ICameraService>();
        mockCameraService.Setup(x => x.ScreenToWorldPoint(It.IsAny<Vector2>())).Returns(new Vector2(1, 0));
        var gameManager = new GameManager(inputHandler, mockCameraService.Object);
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D, forceMagnitudeMultiplier: 1f);
        inputHandler.Update();

        Assert.AreEqual(-1, rigidbody2D.forceAdded.x);
        Assert.AreEqual(0, rigidbody2D.forceAdded.y);
    }

    [Test]
    public void BallForceHigherWhenInputFurther() {
        var mockCameraService = new Mock<ICameraService>();
        mockCameraService.Setup(x => x.ScreenToWorldPoint(It.IsAny<Vector2>())).Returns(new Vector2(10, 0));
        var gameManager = new GameManager(inputHandler, mockCameraService.Object);
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D, forceMagnitudeMultiplier: 1f);
        inputHandler.Update();

        Assert.AreEqual(-10, rigidbody2D.forceAdded.x);
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

    [Test]
    public void StopVelocityOnLowVelocity() {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D);
        rigidbody2D.velocity = new Vector2(0.01f, 0.01f);
        ballHandler.StopOnLowVelocity();

        Assert.AreEqual(Vector2.zero, rigidbody2D.Velocity());
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
            GameObject.Destroy(obj.gameObject);
    }
}
