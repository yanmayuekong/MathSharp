﻿using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using MathSharp.Utils;
using static MathSharp.Utils.Helpers;

namespace MathSharp
{
    

    public static unsafe partial class Vector
    {
        #region Loads

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load4DAligned(in float p)
        {
            return Unsafe.As<float, Vector128<float>>(ref Unsafe.AsRef(in p));
            //fixed (float* pp = &p)
            //{
            //    return Load4DAligned(pp);
            //}
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load4DAligned(float* p)
            => Load4D(p);

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load3DAligned(in float p)
        {
            fixed (float* pp = &p)
            {
                return Load3DAligned(pp);
            }
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load3DAligned(float* p)
            => Load4DAligned(p);

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load2DAligned(in float p)
        {
            return Load4DAligned(in p);
            //fixed (float* pp = &p)
            //{
            //    return Load2DAligned(pp);
            //}
        }
        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load2DAligned(float* p) 
            => Load4DAligned(p);

        [MethodImpl(MaxOpt)]
        public static Vector256<float> Load8D(float* p)
        {
            if (Avx.IsSupported)
            {
                return Avx.LoadVector256(p);
            }

            if (Sse.IsSupported)
            {
                return FromLowHigh(Sse.LoadVector128(p), Sse.LoadVector128(p + 4));
            }

            return SoftwareFallback(p);

            static Vector256<float> SoftwareFallback(float* p)
            {
                return Vector256.Create(p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7]);
            }
        }


        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load4D(in float p)
        {
            fixed (float* pp = &p)
            {
                return Load4D(pp);
            }
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load4D(float* p)
        {
            if (Sse.IsSupported)
            {
                return Sse.LoadVector128(p);
            }

            return SoftwareFallback(p);

            static Vector128<float> SoftwareFallback(float* p)
            {
                return Vector128.Create(p[0], p[1], p[2], p[3]);
            }
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load3D(in float p)
        {
            fixed (float* pp = &p)
            {
                return Load3D(pp);
            }
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load3D(float* p)
        {
            if (Sse.IsSupported)
            {
                // Construct 3 separate vectors, each with the first element being the value
                // and the rest being undefined (shown as ?)
                Vector128<float> hi = Sse.LoadScalarVector128(&p[2]);
                hi = And(hi, SingleConstants.MaskY);
                return Sse.LoadLow(hi, p);
            }

            return SoftwareFallback(p);

            static Vector128<float> SoftwareFallback(float* p)
            {
                return Vector128.Create(p[0], p[1], p[2], 0);
            }
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load2D(in float p)
        {
            return Vector128.CreateScalarUnsafe(Unsafe.As<float, double>(ref Unsafe.AsRef(in p))).AsSingle();
            //fixed (float* pp = &p)
            //{
            //    return Load2D(pp);
            //}
        }

        [MethodImpl(MaxOpt)]
        public static Vector128<float> Load2D(float* p)
        {
            if (Sse2.IsSupported)
            {
                return Sse2.LoadScalarVector128((double*)p).AsSingle();
            }
            if (Sse.IsSupported)
            {
                // Construct 2 separate vectors, each having the first element being the value
                // and the rest being undefined
                Vector128<float> upper = SingleConstants.Zero;

                return Sse.LoadLow(upper, p);
            }

            return SoftwareFallback(p);

            static Vector128<float> SoftwareFallback(float* p)
            {
                return Vector128.Create(p[0], p[1], 0f, 0f);
            }
        }

        #endregion

        #region Stores

        public static void Store8DAligned(this Vector256<float> vector, float* destination)
            => Store8D(vector, destination);

        public static void Store4DAligned(this Vector128<float> vector, out float destination)
            => Store4D(vector, out destination);
        public static void Store4DAligned(this Vector128<float> vector, float* destination)
            => Store4D(vector, destination);

        public static void Store3DAligned(this Vector128<float> vector, out float destination)
            => Store4DAligned(vector, out destination);
        public static void Store3DAligned(this Vector128<float> vector, float* destination)
            => Store4DAligned(vector, destination);

        public static void Store2DAligned(this Vector128<float> vector, out float destination)
            => Store4DAligned(vector, out destination);
        public static void Store2DAligned(this Vector128<float> vector, float* destination) 
            => Store4DAligned(vector, destination);

        [MethodImpl(MaxOpt)]
        public static void Store8D(Vector256<float> vector, float* destination)
        {
            if (Avx.IsSupported)
            {
                Avx.Store(destination, vector);

                return;
            }

            if (Sse.IsSupported)
            {
                Store4D(vector.GetLower(), destination);
                Store4D(vector.GetUpper(), destination + 4);

                return;
            }

            SoftwareFallback(vector, destination);

            static void SoftwareFallback(Vector256<float> vector, float* destination)
            {
                destination[0] = vector.GetElement(0);
                destination[1] = vector.GetElement(1);
                destination[2] = vector.GetElement(2);
                destination[3] = vector.GetElement(3);
                destination[4] = vector.GetElement(4);
                destination[5] = vector.GetElement(5);
                destination[6] = vector.GetElement(6);
                destination[7] = vector.GetElement(7);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void Store4D(this Vector128<float> vector, out float destination)
        {
            fixed (void* _ = &destination) { } // TODO use Unsafe.SkipInit<T>(out T);
            Unsafe.As<float, Vector128<float>>(ref destination) = vector;
        }

        [MethodImpl(MaxOpt)]
        public static void Store4D(this Vector128<float> vector, float* destination)
        {
            if (Sse.IsSupported)
            {
                Sse.Store(destination, vector);

                return;
            }

            SoftwareFallback(vector, destination);

            static void SoftwareFallback(Vector128<float> vector, float* destination)
            {
                destination[0] = vector.GetElement(0);
                destination[1] = vector.GetElement(1);
                destination[2] = vector.GetElement(2);
                destination[3] = vector.GetElement(3);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void Store3D(this Vector128<float> vector, ref float destination)
        {
            fixed (float* p = &destination)
            {
                Store3D(vector, p);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void Store3D(this Vector128<float> vector, float* destination)
        {
            if (Sse.IsSupported)
            {
                Vector128<float> hiBroadcast = Sse.Shuffle(vector, vector, ShuffleValues.ZZZZ);

                Sse.StoreLow(destination, vector);
                Sse.StoreScalar(&destination[3], hiBroadcast);

                return;
            }

            SoftwareFallback(vector, destination);

            static void SoftwareFallback(Vector128<float> vector, float* destination)
            {
                destination[0] = vector.GetElement(0);
                destination[1] = vector.GetElement(1);
                destination[2] = vector.GetElement(2);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void Store2D(this Vector128<float> vector, ref float destination)
        {
            fixed (float* p = &destination)
            {
                Store2D(vector, p);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void Store2D(this Vector128<float> vector, float* destination)
        {
            if (Sse.IsSupported)
            {
                Sse.StoreLow(destination, vector);

                return;
            }

            SoftwareFallback(vector, destination);

            static void SoftwareFallback(Vector128<float> vector, float* destination)
            {
                destination[0] = vector.GetElement(0);
                destination[1] = vector.GetElement(1);
            }
        }

        [MethodImpl(MaxOpt)]
        public static void StoreScalar(Vector128<float> scalar, float* destination)
        {
            *destination = scalar.ToScalar();
        }

        // remove pinning codegen as is unnecessary
        [MethodImpl(MaxOpt)]
        public static void StoreScalar(Vector128<float> scalar, out float destination)
        {
            destination = scalar.ToScalar();
        }

        #endregion

        #region Movement


        [MethodImpl(MaxOpt)]
        public static Vector128<float> ScalarToVector(Vector128<float> scalar)
        {
            if (Avx2.IsSupported)
            {
                // TODO is path better than Avx path or the same?
                return Avx2.BroadcastScalarToVector128(scalar);
            }
            else if (Avx.IsSupported)
            {
                return Avx.Permute(scalar, 0b_0000_0000);
            }
            else if (Sse.IsSupported)
            {
                return Sse.Shuffle(scalar, scalar, 0b_0000_0000);
            }

            return SoftwareFallback(scalar);

            static Vector128<float> SoftwareFallback(Vector128<float> scalar)
            {
                return Vector128.Create(X(scalar));
            }

        }
        #endregion
    }
}
