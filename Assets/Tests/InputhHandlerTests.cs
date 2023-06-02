using NUnit.Framework;

public class MockInputProvider : IInputProvider
{
    public bool IsPrimaryInputEnded() {
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
        InputHandler.OnPrimaryInput += () => eventPublished = true;

        inputHandler.Update();

        Assert.IsTrue(eventPublished);
    }

}