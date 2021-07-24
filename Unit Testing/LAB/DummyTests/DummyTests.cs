using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void InitializeTest()
    {
        dummy = new Dummy(10, 15);
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        dummy.TakeAttack(5);

        Assert.IsTrue(dummy.Health == 5);
    }

    [Test]
    public void DeadDummyThrowsExceptionAfterAttack()
    {
        Axe axe = new Axe(10, 6);
        dummy.TakeAttack(12);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGiveEX()
    {
        dummy.TakeAttack(10);

        Assert.That(dummy.GiveExperience() == 15);
    }

    [Test]
    public void AliveDummyCannotGiveEX()
    {
        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message
            .EqualTo("Target is not dead."));
    }
}

