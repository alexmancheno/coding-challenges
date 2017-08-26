using System;

namespace coding_challenges.DataStructures
{
    public abstract class Card
    {
        public int Balance = 1000;

        public virtual void Charge()
        {
            Balance -= 100;
        }
    }

    public class CreditCard : Card
    {
        public override void Charge()
        {
            Balance -= 50;
        }
    }
}