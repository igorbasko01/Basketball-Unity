using UnityEngine;
using NUnit.Framework;

public class MockRigidbody2D : IRigidbody2D
{
    public Vector2 forceAdded;

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

    [SetUp]
    public void SetUp()
    {
        inputHandler = new InputHandler(new MockInputProvider());
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
        inputHandler.Update();

        Assert.AreEqual(100, rigidbody2D.forceAdded.y);
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
            GameObject.Destroy(obj.gameObject);
    }
}
