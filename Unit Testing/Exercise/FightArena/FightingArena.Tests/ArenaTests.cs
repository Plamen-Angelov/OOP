using NUnit.Framework;
using FightingArena;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior warrior1;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Gosho", 50, 50);
            warrior1 = new Warrior("Pesho", 50, 50);
        }

        [Test]
        public void Ctor_CreateAnInstanceOfArena()
        {
            Assert.That(arena != null);
        }

        [Test]
        public void Ctor_InitializeListOfWarrior()
        {
            Assert.That(arena.Warriors is List<Warrior>);
        }

        [Test]
        public void Count_ReturnsTheCountOfWarriors()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.That(arena.Count == 2);
            Assert.That(arena.Warriors.Count == arena.Count);
        }

        [Test]
        public void Enroll_ThrowExceptionWhenWarriorIsAlreaduEnrolled()
        {
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Enroll_AddlWarriorWhemHeIsntEnrolled()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.That(arena.Count == 2);
        }

        [Test]
        [TestCase("Gosho", "Misho")]
        [TestCase("Misho", "Pesho")]
        [TestCase("Tosho", "Misho")]

        public void Fight_ThrowsExceptionWhenWhenOneOfTheFightersIsNull(string attackerName, string defenderName)
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        //[Test]
        //public void Fight_WarriorsFight()
        //{
        //    arena.Enroll(warrior);
        //    arena.Enroll(warrior1);

        //    Assert.That()
        //}

        [Test]
        public void Fight_WarriorsFight()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            int warriorHp = warrior.HP - warrior1.Damage;
            int warrior1Hp = warrior1.HP - warrior.Damage;

            arena.Fight("Gosho", "Pesho");

            Assert.AreEqual(warriorHp, warrior.HP);
            Assert.AreEqual(warrior1Hp, warrior1.HP);
        }
    }
}
