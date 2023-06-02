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
        gameManager = new GameManager();
    }

    [Test]
    public void Publish_PrimaryInputDuringGameplay_WhenPrimaryInput() {
        bool eventPublished = false;
        GameManager.OnPrimaryInputDuringGameplay += () => eventPublished = true;

        inputHandler.Update();

        Assert.IsTrue(eventPublished);
    }
}
