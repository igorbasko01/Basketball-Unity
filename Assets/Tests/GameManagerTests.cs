using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class GameManagerTests
{
    private GameManager gameManager;
    private InputHandler inputHandler;

    [SetUp]
    public void SetUp() {
        inputHandler = new InputHandler(new MockInputProvider());
        gameManager = new GameManager(inputHandler);
    }

    [Test]
    public void Publish_PrimaryInputDuringGameplay_WhenPrimaryInput() {
        Vector2 coordinates = Vector2.zero;
        gameManager.OnPrimaryInputDuringGameplay += (Vector2 release) => coordinates = release;

        inputHandler.Update();

        Assert.AreEqual(new Vector2(20, 25), coordinates);
    }
}
