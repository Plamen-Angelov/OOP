using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 10, 10);
        }

        [Test]
        [TestCase(" ", 10, 10)]
        [TestCase(null, 10, 10)]
        [TestCase(" ", -1, 10)]
        [TestCase(" ", 10, -10)]
        [TestCase(" ", 10, 0)]
        public void Ctor_ThrowsException(string name, int damage, int HP)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, HP));
        }

        [Test]
        [TestCase("Pesho", 1, 0)]
        [TestCase("Pesho", 40, 40)]
        public void Ctor_CreateWarriorWithValidInitialInput(string name, int damage, int HP)
        {
            warrior = new Warrior(name, damage, HP);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(HP));
        }

        [Test]
        [TestCase(25, 40, 50)]
        [TestCase(30, 40, 50)]
        [TestCase(40, 20, 50)]
        [TestCase(40, 30, 50)]
        [TestCase(40, 35, 50)]
        public void Attack_ThrowsException(int myHP, int enemyHP, int enemyDamage)
        {
            warrior = new Warrior("Pesho", 40, myHP);
            Warrior enemy = new Warrior("Enemy", enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        [TestCase(50, 50, 40, 50)]
        [TestCase(45, 50, 40, 50)]
        public void Attack_FightWhenEnemyHPIsHigherThanMyDamage(int myDamage, int myHp, int enemyDamage, int enemyHp)
        {
            warrior = new Warrior("Pesho", myDamage, myHp);
            Warrior enemy = new Warrior("Enemy", enemyDamage, enemyHp);
            warrior.Attack(enemy);

            int enemyHPAfterAttack = enemyHp - myDamage;
            Assert.That(enemy.HP == enemyHPAfterAttack);
        }

        [Test]
        public void Attack_FightWhenMyDamageIsHigherThanEnemyHP()
        {
            int myDamage = 60;
            int myHp = 50;
            int enemyDamage = 40;
            int enemyHp = 50;

            warrior = new Warrior("Pesho", myDamage, myHp);
            Warrior enemy = new Warrior("Enemy", enemyDamage, enemyHp);
            warrior.Attack(enemy);

            Assert.That(enemy.HP == 0);
        }

        [Test]
        public void Attack_FightWhenMyHPIsHigherThanEnemyDamage()
        {
            int myDamage = 60;
            int myHp = 50;
            int enemyDamage = 40;
            int enemyHp = 50;

            warrior = new Warrior("Pesho", myDamage, myHp);
            Warrior enemy = new Warrior("Enemy", enemyDamage, enemyHp);
            warrior.Attack(enemy);

            Assert.That(warrior.HP == myHp - enemyDamage);
        }
    }
}