using System;

namespace Craps
{
    internal class Dice : IEquatable<Dice>
    {
        private static readonly Random Random = new Random();
        private static readonly Guid Id = Guid.NewGuid();
        public int Eyes { get; private set; }

        public Dice()
        {
            Roll();
        }

        public int Roll() => Eyes = Random.Next(1, 7);

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"Number of eyes: {Eyes}";

        public bool Equals(Dice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Eyes == other.Eyes;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Dice) obj);
        }

        public static bool operator ==(Dice a, Dice b)
        {
            if (ReferenceEquals(a, b)) return true;

            if (((object)a == null) || ((object)b == null)) return false;

            return a.Eyes == b.Eyes;
        }

        public static bool operator !=(Dice a, Dice b)
        {
            return !(a == b);
        }
    }
}
