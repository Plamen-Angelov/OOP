//using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

namespace HeroTests
{
    public class Tests
    {
        [Test]
        public void Attack_HeroGainsXPWhenTargetDies()
        {
            string name = "Pesho";
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeWeapon.Setup(p => p.Attack(It.IsAny<ITarget>()))
                .Callback((ITarget target) => target.TakeAttack(10));

            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);

            Hero hero = new Hero(name, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);
            Assert.That(hero.Experience == 20);
        }
    }
}