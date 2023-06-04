using UnityEngine;
using NUnit.Framework;

public class MockRigidbody2D : IRigidbody2D
{
    public Vector2 forceAdded;
    public Vector2 Position() {
        return new Vector2(10, 10);
    }

    public void AddForce(Vector2 vector2)
    {
        forceAdded = vector2;
    }
}

[TestFixture]
public class BallTests
{
    private InputHandler inputHandler;
    private GameManager gameManager;
    private MockInputProvider inputProvider;

    [SetUp]
    public void SetUp()
    {
        inputProvider = new MockInputProvider();
        inputHandler = new InputHandler(inputProvider);
        gameManager = new GameManager(inputHandler);
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

        Assert.AreEqual(30, rigidbody2D.forceAdded.y);
    }

    [Test]
    public void BallForceIsOppositeDirectionFromTheInputCoordinates() {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(gameManager, rigidbody2D);
        inputProvider.SetPrimaryInputCoordinates(new Vector2(30, 10));        
        inputHandler.Update();

        Assert.AreEqual(-20, rigidbody2D.forceAdded.x);
        Assert.AreEqual(0, rigidbody2D.forceAdded.y);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
            GameObject.Destroy(obj.gameObject);
    }
}
