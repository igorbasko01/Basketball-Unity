using NUnit.Framework;
using UnityEngine;

public class MockInputProvider : IInputProvider
{
    public bool IsPrimaryInputEnded(out Vector2 release) {
        release = new Vector2(20, 25);
        return true;
    }
}

[TestFixture]
public class InputHandlerTests
{
    private InputHandler inputHandler;

    [SetUp]
    public void SetUp()
    {
        inputHandler = new InputHandler(new MockInputProvider());
    }

    [Test]
    public void PrimaryInput_WhenMouseButtonUp_EventIsPublished() {
        bool eventPublished = false;
        inputHandler.OnPrimaryInput += (_) => eventPublished = true;

        inputHandler.Update();

        Assert.IsTrue(eventPublished);
    }

    [Test]
    public void PrimaryInput_ContainsReleaseCoordinates() {
        Vector2 coordinates = Vector2.zero;
        inputHandler.OnPrimaryInput += (Vector2 release) => coordinates = release;

        inputHandler.Update();

        Assert.AreEqual(coordinates, new Vector2(20, 25));
    }

}