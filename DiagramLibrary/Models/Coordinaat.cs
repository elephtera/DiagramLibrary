using System;

namespace DiagramLibrary.Models
{
    public struct Coordinaat
    {
        public Coordinaat(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {  get; }

        public int Y { get; }

        #region Equal definition
        public override bool Equals(object? obj)
        {
            return obj is Coordinaat coordinaat &&
                   X == coordinaat.X &&
                   Y == coordinaat.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Coordinaat left, Coordinaat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinaat left, Coordinaat right)
        {
            return !(left == right);
        }
        #endregion

    }
}