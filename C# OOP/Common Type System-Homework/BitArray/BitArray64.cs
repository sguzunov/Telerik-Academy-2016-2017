namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class BitArray64 : IEnumerable<int>, ICloneable
    {
        private const int Count = 64;

        private ulong value;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException($"BitArray64 has values only in range [{0}, {Count}]");
                }

                return (int)((this.value >> (Count - index)) & 1);
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException($"BitArray64 index must be in range [{0}, {Count - 1}]");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException($"BitArray64 has values only in range [{0}, {1}]");
                }

                int offset = Count - index;
                if (value == 1)
                {
                    this.value = this.value | ((ulong)1 << offset);
                }
                else
                {
                    int bit = (int)((this.value >> offset) & 1);
                    this.value = this.value & (~((ulong)1 << offset));
                }
            }
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            unchecked
            {
                hashCode = hashCode * 23 + value.GetHashCode();
            }

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(BitArray64 firstArr, BitArray64 secondArr)
        {
            return firstArr.value == secondArr.value;
        }

        public static bool operator !=(BitArray64 firstArr, BitArray64 secondArr)
        {
            return firstArr.value != secondArr.value;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return (int)((this.value >> i) & (ulong)1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
