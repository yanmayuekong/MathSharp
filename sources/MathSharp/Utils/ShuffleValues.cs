﻿using System.Runtime.Intrinsics;

// ReSharper disable InconsistentNaming
namespace MathSharp.Utils
{
    /// <summary>
    /// Values used in <see cref="Vector.Shuffle(Vector128{float}, Vector128{float}, byte)"/>,
    /// <see cref="Vector.Shuffle(Vector256{double}, Vector256{double}, byte)"/>,
    /// <see cref="Vector.Permute(Vector128{float}, byte)"/>,
    /// <see cref="Vector.Permute(Vector256{double}, byte)"/>,
    /// methods to dictate the ordering of the resultant vectors
    /// </summary>
    /// <example>
    /// To reverse a vector (x, y, z, w), to (w, z, y, x), you would do
    /// <code>
    /// Vector.Permute(vector, <see cref="_3_2_1_0"/>)
    /// </code>
    /// which selects the 4th, then 3rd, then 2nd, then 1st element
    /// </example>
    public static class ShuffleValues
    {
        public const byte _0_0_0_0 = (0 << 6) | (0 << 4) | (0 << 2) | 0;
        public const byte _1_0_0_0 = (0 << 6) | (0 << 4) | (0 << 2) | 1;
        public const byte _2_0_0_0 = (0 << 6) | (0 << 4) | (0 << 2) | 2;
        public const byte _3_0_0_0 = (0 << 6) | (0 << 4) | (0 << 2) | 3;
        public const byte _0_1_0_0 = (0 << 6) | (0 << 4) | (1 << 2) | 0;
        public const byte _1_1_0_0 = (0 << 6) | (0 << 4) | (1 << 2) | 1;
        public const byte _2_1_0_0 = (0 << 6) | (0 << 4) | (1 << 2) | 2;
        public const byte _3_1_0_0 = (0 << 6) | (0 << 4) | (1 << 2) | 3;
        public const byte _0_2_0_0 = (0 << 6) | (0 << 4) | (2 << 2) | 0;
        public const byte _1_2_0_0 = (0 << 6) | (0 << 4) | (2 << 2) | 1;
        public const byte _2_2_0_0 = (0 << 6) | (0 << 4) | (2 << 2) | 2;
        public const byte _3_2_0_0 = (0 << 6) | (0 << 4) | (2 << 2) | 3;
        public const byte _0_3_0_0 = (0 << 6) | (0 << 4) | (3 << 2) | 0;
        public const byte _1_3_0_0 = (0 << 6) | (0 << 4) | (3 << 2) | 1;
        public const byte _2_3_0_0 = (0 << 6) | (0 << 4) | (3 << 2) | 2;
        public const byte _3_3_0_0 = (0 << 6) | (0 << 4) | (3 << 2) | 3;
        public const byte _0_0_1_0 = (0 << 6) | (1 << 4) | (0 << 2) | 0;
        public const byte _1_0_1_0 = (0 << 6) | (1 << 4) | (0 << 2) | 1;
        public const byte _2_0_1_0 = (0 << 6) | (1 << 4) | (0 << 2) | 2;
        public const byte _3_0_1_0 = (0 << 6) | (1 << 4) | (0 << 2) | 3;
        public const byte _0_1_1_0 = (0 << 6) | (1 << 4) | (1 << 2) | 0;
        public const byte _1_1_1_0 = (0 << 6) | (1 << 4) | (1 << 2) | 1;
        public const byte _2_1_1_0 = (0 << 6) | (1 << 4) | (1 << 2) | 2;
        public const byte _3_1_1_0 = (0 << 6) | (1 << 4) | (1 << 2) | 3;
        public const byte _0_2_1_0 = (0 << 6) | (1 << 4) | (2 << 2) | 0;
        public const byte _1_2_1_0 = (0 << 6) | (1 << 4) | (2 << 2) | 1;
        public const byte _2_2_1_0 = (0 << 6) | (1 << 4) | (2 << 2) | 2;
        public const byte _3_2_1_0 = (0 << 6) | (1 << 4) | (2 << 2) | 3;
        public const byte _0_3_1_0 = (0 << 6) | (1 << 4) | (3 << 2) | 0;
        public const byte _1_3_1_0 = (0 << 6) | (1 << 4) | (3 << 2) | 1;
        public const byte _2_3_1_0 = (0 << 6) | (1 << 4) | (3 << 2) | 2;
        public const byte _3_3_1_0 = (0 << 6) | (1 << 4) | (3 << 2) | 3;
        public const byte _0_0_2_0 = (0 << 6) | (2 << 4) | (0 << 2) | 0;
        public const byte _1_0_2_0 = (0 << 6) | (2 << 4) | (0 << 2) | 1;
        public const byte _2_0_2_0 = (0 << 6) | (2 << 4) | (0 << 2) | 2;
        public const byte _3_0_2_0 = (0 << 6) | (2 << 4) | (0 << 2) | 3;
        public const byte _0_1_2_0 = (0 << 6) | (2 << 4) | (1 << 2) | 0;
        public const byte _1_1_2_0 = (0 << 6) | (2 << 4) | (1 << 2) | 1;
        public const byte _2_1_2_0 = (0 << 6) | (2 << 4) | (1 << 2) | 2;
        public const byte _3_1_2_0 = (0 << 6) | (2 << 4) | (1 << 2) | 3;
        public const byte _0_2_2_0 = (0 << 6) | (2 << 4) | (2 << 2) | 0;
        public const byte _1_2_2_0 = (0 << 6) | (2 << 4) | (2 << 2) | 1;
        public const byte _2_2_2_0 = (0 << 6) | (2 << 4) | (2 << 2) | 2;
        public const byte _3_2_2_0 = (0 << 6) | (2 << 4) | (2 << 2) | 3;
        public const byte _0_3_2_0 = (0 << 6) | (2 << 4) | (3 << 2) | 0;
        public const byte _1_3_2_0 = (0 << 6) | (2 << 4) | (3 << 2) | 1;
        public const byte _2_3_2_0 = (0 << 6) | (2 << 4) | (3 << 2) | 2;
        public const byte _3_3_2_0 = (0 << 6) | (2 << 4) | (3 << 2) | 3;
        public const byte _0_0_3_0 = (0 << 6) | (3 << 4) | (0 << 2) | 0;
        public const byte _1_0_3_0 = (0 << 6) | (3 << 4) | (0 << 2) | 1;
        public const byte _2_0_3_0 = (0 << 6) | (3 << 4) | (0 << 2) | 2;
        public const byte _3_0_3_0 = (0 << 6) | (3 << 4) | (0 << 2) | 3;
        public const byte _0_1_3_0 = (0 << 6) | (3 << 4) | (1 << 2) | 0;
        public const byte _1_1_3_0 = (0 << 6) | (3 << 4) | (1 << 2) | 1;
        public const byte _2_1_3_0 = (0 << 6) | (3 << 4) | (1 << 2) | 2;
        public const byte _3_1_3_0 = (0 << 6) | (3 << 4) | (1 << 2) | 3;
        public const byte _0_2_3_0 = (0 << 6) | (3 << 4) | (2 << 2) | 0;
        public const byte _1_2_3_0 = (0 << 6) | (3 << 4) | (2 << 2) | 1;
        public const byte _2_2_3_0 = (0 << 6) | (3 << 4) | (2 << 2) | 2;
        public const byte _3_2_3_0 = (0 << 6) | (3 << 4) | (2 << 2) | 3;
        public const byte _0_3_3_0 = (0 << 6) | (3 << 4) | (3 << 2) | 0;
        public const byte _1_3_3_0 = (0 << 6) | (3 << 4) | (3 << 2) | 1;
        public const byte _2_3_3_0 = (0 << 6) | (3 << 4) | (3 << 2) | 2;
        public const byte _3_3_3_0 = (0 << 6) | (3 << 4) | (3 << 2) | 3;
        public const byte _0_0_0_1 = (1 << 6) | (0 << 4) | (0 << 2) | 0;
        public const byte _1_0_0_1 = (1 << 6) | (0 << 4) | (0 << 2) | 1;
        public const byte _2_0_0_1 = (1 << 6) | (0 << 4) | (0 << 2) | 2;
        public const byte _3_0_0_1 = (1 << 6) | (0 << 4) | (0 << 2) | 3;
        public const byte _0_1_0_1 = (1 << 6) | (0 << 4) | (1 << 2) | 0;
        public const byte _1_1_0_1 = (1 << 6) | (0 << 4) | (1 << 2) | 1;
        public const byte _2_1_0_1 = (1 << 6) | (0 << 4) | (1 << 2) | 2;
        public const byte _3_1_0_1 = (1 << 6) | (0 << 4) | (1 << 2) | 3;
        public const byte _0_2_0_1 = (1 << 6) | (0 << 4) | (2 << 2) | 0;
        public const byte _1_2_0_1 = (1 << 6) | (0 << 4) | (2 << 2) | 1;
        public const byte _2_2_0_1 = (1 << 6) | (0 << 4) | (2 << 2) | 2;
        public const byte _3_2_0_1 = (1 << 6) | (0 << 4) | (2 << 2) | 3;
        public const byte _0_3_0_1 = (1 << 6) | (0 << 4) | (3 << 2) | 0;
        public const byte _1_3_0_1 = (1 << 6) | (0 << 4) | (3 << 2) | 1;
        public const byte _2_3_0_1 = (1 << 6) | (0 << 4) | (3 << 2) | 2;
        public const byte _3_3_0_1 = (1 << 6) | (0 << 4) | (3 << 2) | 3;
        public const byte _0_0_1_1 = (1 << 6) | (1 << 4) | (0 << 2) | 0;
        public const byte _1_0_1_1 = (1 << 6) | (1 << 4) | (0 << 2) | 1;
        public const byte _2_0_1_1 = (1 << 6) | (1 << 4) | (0 << 2) | 2;
        public const byte _3_0_1_1 = (1 << 6) | (1 << 4) | (0 << 2) | 3;
        public const byte _0_1_1_1 = (1 << 6) | (1 << 4) | (1 << 2) | 0;
        public const byte _1_1_1_1 = (1 << 6) | (1 << 4) | (1 << 2) | 1;
        public const byte _2_1_1_1 = (1 << 6) | (1 << 4) | (1 << 2) | 2;
        public const byte _3_1_1_1 = (1 << 6) | (1 << 4) | (1 << 2) | 3;
        public const byte _0_2_1_1 = (1 << 6) | (1 << 4) | (2 << 2) | 0;
        public const byte _1_2_1_1 = (1 << 6) | (1 << 4) | (2 << 2) | 1;
        public const byte _2_2_1_1 = (1 << 6) | (1 << 4) | (2 << 2) | 2;
        public const byte _3_2_1_1 = (1 << 6) | (1 << 4) | (2 << 2) | 3;
        public const byte _0_3_1_1 = (1 << 6) | (1 << 4) | (3 << 2) | 0;
        public const byte _1_3_1_1 = (1 << 6) | (1 << 4) | (3 << 2) | 1;
        public const byte _2_3_1_1 = (1 << 6) | (1 << 4) | (3 << 2) | 2;
        public const byte _3_3_1_1 = (1 << 6) | (1 << 4) | (3 << 2) | 3;
        public const byte _0_0_2_1 = (1 << 6) | (2 << 4) | (0 << 2) | 0;
        public const byte _1_0_2_1 = (1 << 6) | (2 << 4) | (0 << 2) | 1;
        public const byte _2_0_2_1 = (1 << 6) | (2 << 4) | (0 << 2) | 2;
        public const byte _3_0_2_1 = (1 << 6) | (2 << 4) | (0 << 2) | 3;
        public const byte _0_1_2_1 = (1 << 6) | (2 << 4) | (1 << 2) | 0;
        public const byte _1_1_2_1 = (1 << 6) | (2 << 4) | (1 << 2) | 1;
        public const byte _2_1_2_1 = (1 << 6) | (2 << 4) | (1 << 2) | 2;
        public const byte _3_1_2_1 = (1 << 6) | (2 << 4) | (1 << 2) | 3;
        public const byte _0_2_2_1 = (1 << 6) | (2 << 4) | (2 << 2) | 0;
        public const byte _1_2_2_1 = (1 << 6) | (2 << 4) | (2 << 2) | 1;
        public const byte _2_2_2_1 = (1 << 6) | (2 << 4) | (2 << 2) | 2;
        public const byte _3_2_2_1 = (1 << 6) | (2 << 4) | (2 << 2) | 3;
        public const byte _0_3_2_1 = (1 << 6) | (2 << 4) | (3 << 2) | 0;
        public const byte _1_3_2_1 = (1 << 6) | (2 << 4) | (3 << 2) | 1;
        public const byte _2_3_2_1 = (1 << 6) | (2 << 4) | (3 << 2) | 2;
        public const byte _3_3_2_1 = (1 << 6) | (2 << 4) | (3 << 2) | 3;
        public const byte _0_0_3_1 = (1 << 6) | (3 << 4) | (0 << 2) | 0;
        public const byte _1_0_3_1 = (1 << 6) | (3 << 4) | (0 << 2) | 1;
        public const byte _2_0_3_1 = (1 << 6) | (3 << 4) | (0 << 2) | 2;
        public const byte _3_0_3_1 = (1 << 6) | (3 << 4) | (0 << 2) | 3;
        public const byte _0_1_3_1 = (1 << 6) | (3 << 4) | (1 << 2) | 0;
        public const byte _1_1_3_1 = (1 << 6) | (3 << 4) | (1 << 2) | 1;
        public const byte _2_1_3_1 = (1 << 6) | (3 << 4) | (1 << 2) | 2;
        public const byte _3_1_3_1 = (1 << 6) | (3 << 4) | (1 << 2) | 3;
        public const byte _0_2_3_1 = (1 << 6) | (3 << 4) | (2 << 2) | 0;
        public const byte _1_2_3_1 = (1 << 6) | (3 << 4) | (2 << 2) | 1;
        public const byte _2_2_3_1 = (1 << 6) | (3 << 4) | (2 << 2) | 2;
        public const byte _3_2_3_1 = (1 << 6) | (3 << 4) | (2 << 2) | 3;
        public const byte _0_3_3_1 = (1 << 6) | (3 << 4) | (3 << 2) | 0;
        public const byte _1_3_3_1 = (1 << 6) | (3 << 4) | (3 << 2) | 1;
        public const byte _2_3_3_1 = (1 << 6) | (3 << 4) | (3 << 2) | 2;
        public const byte _3_3_3_1 = (1 << 6) | (3 << 4) | (3 << 2) | 3;
        public const byte _0_0_0_2 = (2 << 6) | (0 << 4) | (0 << 2) | 0;
        public const byte _1_0_0_2 = (2 << 6) | (0 << 4) | (0 << 2) | 1;
        public const byte _2_0_0_2 = (2 << 6) | (0 << 4) | (0 << 2) | 2;
        public const byte _3_0_0_2 = (2 << 6) | (0 << 4) | (0 << 2) | 3;
        public const byte _0_1_0_2 = (2 << 6) | (0 << 4) | (1 << 2) | 0;
        public const byte _1_1_0_2 = (2 << 6) | (0 << 4) | (1 << 2) | 1;
        public const byte _2_1_0_2 = (2 << 6) | (0 << 4) | (1 << 2) | 2;
        public const byte _3_1_0_2 = (2 << 6) | (0 << 4) | (1 << 2) | 3;
        public const byte _0_2_0_2 = (2 << 6) | (0 << 4) | (2 << 2) | 0;
        public const byte _1_2_0_2 = (2 << 6) | (0 << 4) | (2 << 2) | 1;
        public const byte _2_2_0_2 = (2 << 6) | (0 << 4) | (2 << 2) | 2;
        public const byte _3_2_0_2 = (2 << 6) | (0 << 4) | (2 << 2) | 3;
        public const byte _0_3_0_2 = (2 << 6) | (0 << 4) | (3 << 2) | 0;
        public const byte _1_3_0_2 = (2 << 6) | (0 << 4) | (3 << 2) | 1;
        public const byte _2_3_0_2 = (2 << 6) | (0 << 4) | (3 << 2) | 2;
        public const byte _3_3_0_2 = (2 << 6) | (0 << 4) | (3 << 2) | 3;
        public const byte _0_0_1_2 = (2 << 6) | (1 << 4) | (0 << 2) | 0;
        public const byte _1_0_1_2 = (2 << 6) | (1 << 4) | (0 << 2) | 1;
        public const byte _2_0_1_2 = (2 << 6) | (1 << 4) | (0 << 2) | 2;
        public const byte _3_0_1_2 = (2 << 6) | (1 << 4) | (0 << 2) | 3;
        public const byte _0_1_1_2 = (2 << 6) | (1 << 4) | (1 << 2) | 0;
        public const byte _1_1_1_2 = (2 << 6) | (1 << 4) | (1 << 2) | 1;
        public const byte _2_1_1_2 = (2 << 6) | (1 << 4) | (1 << 2) | 2;
        public const byte _3_1_1_2 = (2 << 6) | (1 << 4) | (1 << 2) | 3;
        public const byte _0_2_1_2 = (2 << 6) | (1 << 4) | (2 << 2) | 0;
        public const byte _1_2_1_2 = (2 << 6) | (1 << 4) | (2 << 2) | 1;
        public const byte _2_2_1_2 = (2 << 6) | (1 << 4) | (2 << 2) | 2;
        public const byte _3_2_1_2 = (2 << 6) | (1 << 4) | (2 << 2) | 3;
        public const byte _0_3_1_2 = (2 << 6) | (1 << 4) | (3 << 2) | 0;
        public const byte _1_3_1_2 = (2 << 6) | (1 << 4) | (3 << 2) | 1;
        public const byte _2_3_1_2 = (2 << 6) | (1 << 4) | (3 << 2) | 2;
        public const byte _3_3_1_2 = (2 << 6) | (1 << 4) | (3 << 2) | 3;
        public const byte _0_0_2_2 = (2 << 6) | (2 << 4) | (0 << 2) | 0;
        public const byte _1_0_2_2 = (2 << 6) | (2 << 4) | (0 << 2) | 1;
        public const byte _2_0_2_2 = (2 << 6) | (2 << 4) | (0 << 2) | 2;
        public const byte _3_0_2_2 = (2 << 6) | (2 << 4) | (0 << 2) | 3;
        public const byte _0_1_2_2 = (2 << 6) | (2 << 4) | (1 << 2) | 0;
        public const byte _1_1_2_2 = (2 << 6) | (2 << 4) | (1 << 2) | 1;
        public const byte _2_1_2_2 = (2 << 6) | (2 << 4) | (1 << 2) | 2;
        public const byte _3_1_2_2 = (2 << 6) | (2 << 4) | (1 << 2) | 3;
        public const byte _0_2_2_2 = (2 << 6) | (2 << 4) | (2 << 2) | 0;
        public const byte _1_2_2_2 = (2 << 6) | (2 << 4) | (2 << 2) | 1;
        public const byte _2_2_2_2 = (2 << 6) | (2 << 4) | (2 << 2) | 2;
        public const byte _3_2_2_2 = (2 << 6) | (2 << 4) | (2 << 2) | 3;
        public const byte _0_3_2_2 = (2 << 6) | (2 << 4) | (3 << 2) | 0;
        public const byte _1_3_2_2 = (2 << 6) | (2 << 4) | (3 << 2) | 1;
        public const byte _2_3_2_2 = (2 << 6) | (2 << 4) | (3 << 2) | 2;
        public const byte _3_3_2_2 = (2 << 6) | (2 << 4) | (3 << 2) | 3;
        public const byte _0_0_3_2 = (2 << 6) | (3 << 4) | (0 << 2) | 0;
        public const byte _1_0_3_2 = (2 << 6) | (3 << 4) | (0 << 2) | 1;
        public const byte _2_0_3_2 = (2 << 6) | (3 << 4) | (0 << 2) | 2;
        public const byte _3_0_3_2 = (2 << 6) | (3 << 4) | (0 << 2) | 3;
        public const byte _0_1_3_2 = (2 << 6) | (3 << 4) | (1 << 2) | 0;
        public const byte _1_1_3_2 = (2 << 6) | (3 << 4) | (1 << 2) | 1;
        public const byte _2_1_3_2 = (2 << 6) | (3 << 4) | (1 << 2) | 2;
        public const byte _3_1_3_2 = (2 << 6) | (3 << 4) | (1 << 2) | 3;
        public const byte _0_2_3_2 = (2 << 6) | (3 << 4) | (2 << 2) | 0;
        public const byte _1_2_3_2 = (2 << 6) | (3 << 4) | (2 << 2) | 1;
        public const byte _2_2_3_2 = (2 << 6) | (3 << 4) | (2 << 2) | 2;
        public const byte _3_2_3_2 = (2 << 6) | (3 << 4) | (2 << 2) | 3;
        public const byte _0_3_3_2 = (2 << 6) | (3 << 4) | (3 << 2) | 0;
        public const byte _1_3_3_2 = (2 << 6) | (3 << 4) | (3 << 2) | 1;
        public const byte _2_3_3_2 = (2 << 6) | (3 << 4) | (3 << 2) | 2;
        public const byte _3_3_3_2 = (2 << 6) | (3 << 4) | (3 << 2) | 3;
        public const byte _0_0_0_3 = (3 << 6) | (0 << 4) | (0 << 2) | 0;
        public const byte _1_0_0_3 = (3 << 6) | (0 << 4) | (0 << 2) | 1;
        public const byte _2_0_0_3 = (3 << 6) | (0 << 4) | (0 << 2) | 2;
        public const byte _3_0_0_3 = (3 << 6) | (0 << 4) | (0 << 2) | 3;
        public const byte _0_1_0_3 = (3 << 6) | (0 << 4) | (1 << 2) | 0;
        public const byte _1_1_0_3 = (3 << 6) | (0 << 4) | (1 << 2) | 1;
        public const byte _2_1_0_3 = (3 << 6) | (0 << 4) | (1 << 2) | 2;
        public const byte _3_1_0_3 = (3 << 6) | (0 << 4) | (1 << 2) | 3;
        public const byte _0_2_0_3 = (3 << 6) | (0 << 4) | (2 << 2) | 0;
        public const byte _1_2_0_3 = (3 << 6) | (0 << 4) | (2 << 2) | 1;
        public const byte _2_2_0_3 = (3 << 6) | (0 << 4) | (2 << 2) | 2;
        public const byte _3_2_0_3 = (3 << 6) | (0 << 4) | (2 << 2) | 3;
        public const byte _0_3_0_3 = (3 << 6) | (0 << 4) | (3 << 2) | 0;
        public const byte _1_3_0_3 = (3 << 6) | (0 << 4) | (3 << 2) | 1;
        public const byte _2_3_0_3 = (3 << 6) | (0 << 4) | (3 << 2) | 2;
        public const byte _3_3_0_3 = (3 << 6) | (0 << 4) | (3 << 2) | 3;
        public const byte _0_0_1_3 = (3 << 6) | (1 << 4) | (0 << 2) | 0;
        public const byte _1_0_1_3 = (3 << 6) | (1 << 4) | (0 << 2) | 1;
        public const byte _2_0_1_3 = (3 << 6) | (1 << 4) | (0 << 2) | 2;
        public const byte _3_0_1_3 = (3 << 6) | (1 << 4) | (0 << 2) | 3;
        public const byte _0_1_1_3 = (3 << 6) | (1 << 4) | (1 << 2) | 0;
        public const byte _1_1_1_3 = (3 << 6) | (1 << 4) | (1 << 2) | 1;
        public const byte _2_1_1_3 = (3 << 6) | (1 << 4) | (1 << 2) | 2;
        public const byte _3_1_1_3 = (3 << 6) | (1 << 4) | (1 << 2) | 3;
        public const byte _0_2_1_3 = (3 << 6) | (1 << 4) | (2 << 2) | 0;
        public const byte _1_2_1_3 = (3 << 6) | (1 << 4) | (2 << 2) | 1;
        public const byte _2_2_1_3 = (3 << 6) | (1 << 4) | (2 << 2) | 2;
        public const byte _3_2_1_3 = (3 << 6) | (1 << 4) | (2 << 2) | 3;
        public const byte _0_3_1_3 = (3 << 6) | (1 << 4) | (3 << 2) | 0;
        public const byte _1_3_1_3 = (3 << 6) | (1 << 4) | (3 << 2) | 1;
        public const byte _2_3_1_3 = (3 << 6) | (1 << 4) | (3 << 2) | 2;
        public const byte _3_3_1_3 = (3 << 6) | (1 << 4) | (3 << 2) | 3;
        public const byte _0_0_2_3 = (3 << 6) | (2 << 4) | (0 << 2) | 0;
        public const byte _1_0_2_3 = (3 << 6) | (2 << 4) | (0 << 2) | 1;
        public const byte _2_0_2_3 = (3 << 6) | (2 << 4) | (0 << 2) | 2;
        public const byte _3_0_2_3 = (3 << 6) | (2 << 4) | (0 << 2) | 3;
        public const byte _0_1_2_3 = (3 << 6) | (2 << 4) | (1 << 2) | 0;
        public const byte _1_1_2_3 = (3 << 6) | (2 << 4) | (1 << 2) | 1;
        public const byte _2_1_2_3 = (3 << 6) | (2 << 4) | (1 << 2) | 2;
        public const byte _3_1_2_3 = (3 << 6) | (2 << 4) | (1 << 2) | 3;
        public const byte _0_2_2_3 = (3 << 6) | (2 << 4) | (2 << 2) | 0;
        public const byte _1_2_2_3 = (3 << 6) | (2 << 4) | (2 << 2) | 1;
        public const byte _2_2_2_3 = (3 << 6) | (2 << 4) | (2 << 2) | 2;
        public const byte _3_2_2_3 = (3 << 6) | (2 << 4) | (2 << 2) | 3;
        public const byte _0_3_2_3 = (3 << 6) | (2 << 4) | (3 << 2) | 0;
        public const byte _1_3_2_3 = (3 << 6) | (2 << 4) | (3 << 2) | 1;
        public const byte _2_3_2_3 = (3 << 6) | (2 << 4) | (3 << 2) | 2;
        public const byte _3_3_2_3 = (3 << 6) | (2 << 4) | (3 << 2) | 3;
        public const byte _0_0_3_3 = (3 << 6) | (3 << 4) | (0 << 2) | 0;
        public const byte _1_0_3_3 = (3 << 6) | (3 << 4) | (0 << 2) | 1;
        public const byte _2_0_3_3 = (3 << 6) | (3 << 4) | (0 << 2) | 2;
        public const byte _3_0_3_3 = (3 << 6) | (3 << 4) | (0 << 2) | 3;
        public const byte _0_1_3_3 = (3 << 6) | (3 << 4) | (1 << 2) | 0;
        public const byte _1_1_3_3 = (3 << 6) | (3 << 4) | (1 << 2) | 1;
        public const byte _2_1_3_3 = (3 << 6) | (3 << 4) | (1 << 2) | 2;
        public const byte _3_1_3_3 = (3 << 6) | (3 << 4) | (1 << 2) | 3;
        public const byte _0_2_3_3 = (3 << 6) | (3 << 4) | (2 << 2) | 0;
        public const byte _1_2_3_3 = (3 << 6) | (3 << 4) | (2 << 2) | 1;
        public const byte _2_2_3_3 = (3 << 6) | (3 << 4) | (2 << 2) | 2;
        public const byte _3_2_3_3 = (3 << 6) | (3 << 4) | (2 << 2) | 3;
        public const byte _0_3_3_3 = (3 << 6) | (3 << 4) | (3 << 2) | 0;
        public const byte _1_3_3_3 = (3 << 6) | (3 << 4) | (3 << 2) | 1;
        public const byte _2_3_3_3 = (3 << 6) | (3 << 4) | (3 << 2) | 2;
        public const byte _3_3_3_3 = (3 << 6) | (3 << 4) | (3 << 2) | 3;
    }
}