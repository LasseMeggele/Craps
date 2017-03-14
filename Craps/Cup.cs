using System;

namespace Craps
{
    internal class Cup : IEquatable<Cup>
    {
        public Dice Dice1 { get; private set; }
        public Dice Dice2 { get; private set; }

        public Cup()
        {
            Roll();
        }

        public void Roll()
        {
            Dice1 = new Dice();
            Dice2 = new Dice();
        }

        public int Sum() => Dice1.Eyes + Dice2.Eyes;

        public bool IsSnakeEyes() => Dice1.Eyes == 1 && Dice2.Eyes == 1;

        public bool IsThree() => Sum() == 3;

        public bool IsSeven() => Sum() == 7;

        public bool IsEleven() => Sum() == 11;

        public bool IsTwelve() => Sum() == 12;

        public override string ToString() => $"Cup rolled: {Dice1.Eyes}, {Dice2.Eyes}";

        public override int GetHashCode()
        {
            unchecked
            {
                return (Dice1.GetHashCode() * 397) ^ Dice2.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            var dice = obj as Cup;
            if (dice == null) return false;

            return Dice1.Equals(dice.Dice1) && Dice2.Equals(dice.Dice2);
        }

        public static bool operator ==(Cup a, Cup b)
        {
            if (ReferenceEquals(a, b)) return true;
            
            if (((object) a == null) || ((object) b == null)) return false;

            return (a.Dice1 == b.Dice1 && a.Dice2 == b.Dice2) || (a.Dice1 == b.Dice2 && a.Dice2 == b.Dice1);
        }

        public static bool operator !=(Cup a, Cup b)
        {
            return !(a == b);
        }

        public bool Equals(Cup other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Dice1 == other.Dice1 && Dice2 == other.Dice2;
        }
    }
}
