using UnityEngine;
using NUnit.Framework;
using Moq;

[TestFixture]
public class GameManagerTests
{
    private GameManager gameManager;
    private InputHandler inputHandler;
    private Mock<ICameraService> cameraService;

    [SetUp]
    public void SetUp() {
        inputHandler = new InputHandler(new MockInputProvider());
        cameraService = new Mock<ICameraService>();
        cameraService.Setup(camera => camera.ScreenToWorldPoint(It.IsAny<Vector2>())).Returns(new Vector2(20, 25));
        gameManager = new GameManager(inputHandler, cameraService.Object);
    }

    [Test]
    public void Publish_PrimaryInputDuringGameplay_WhenPrimaryInput() {
        Vector2 coordinates = Vector2.zero;
        gameManager.OnPrimaryInputDuringGameplay += (Vector2 release) => coordinates = release;

        inputHandler.Update();

        Assert.AreEqual(new Vector2(20, 25), coordinates);
    }
}
