using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using NUnit.Framework;
using System.Collections;

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
        gameManager = new GameManager();
    }

    [Test]
    public void BallNumberOfHitsIncreasedByOneOnPrimaryInput() {
        BallHandler ballHandler = new BallHandler(new MockRigidbody2D());
        inputHandler.Update();

        Assert.AreEqual(1, ballHandler.NumberOfHits);
    }

    [Test]
    public void BallMovesUpWhenPrimaryInput()
    {
        MockRigidbody2D rigidbody2D = new MockRigidbody2D();
        BallHandler ballHandler = new BallHandler(rigidbody2D);
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
