using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public class FakeTarget : ITarget
    {
        public int Health => 10;

        public int GiveExperience() => 20;

        public bool IsDead()
        {
           return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
