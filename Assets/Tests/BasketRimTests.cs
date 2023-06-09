using NUnit.Framework;
using Moq;
using UnityEngine;

[TestFixture]
public class BasketRimTests {
    [Test]
    public void Publish_BallWentThroughBasket_WhenBallExitBasketRim() {
        BasketRimHandler basketRimHandler = new BasketRimHandler(new Vector2(0,0));
        var mockBallRigidBody = new Mock<IRigidbody2D>();
        mockBallRigidBody.Setup(ballRigidBody => ballRigidBody.Position()).Returns(new Vector2(0, -10));
        bool ballWentThroughBasket = false;
        basketRimHandler.OnBallWentThroughBasket += () => ballWentThroughBasket = true;

        basketRimHandler.OnBallExitBasketRim(mockBallRigidBody.Object);

        Assert.IsTrue(ballWentThroughBasket);
    }

    [Test]
    public void DontPublish_BallWentThroughBasket_WhenBallExitBasketRimUp() {
        BasketRimHandler basketRimHandler = new BasketRimHandler(new Vector2(0, 0));
        var mockBallRigidBody = new Mock<IRigidbody2D>();
        mockBallRigidBody.Setup(ballRigidBody => ballRigidBody.Position()).Returns(new Vector2(0, 10));
        bool ballWentThroughBasket = false;
        basketRimHandler.OnBallWentThroughBasket += () => ballWentThroughBasket = true;

        basketRimHandler.OnBallExitBasketRim(mockBallRigidBody.Object);

        Assert.IsFalse(ballWentThroughBasket);
    }
}