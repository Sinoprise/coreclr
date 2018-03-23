// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void TestCSByte()
        {
            var test = new BooleanBinaryOpTest__TestCSByte();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates calling via reflection works, using Load
                    test.RunReflectionScenario_Load();

                    // Validates calling via reflection works, using LoadAligned
                    test.RunReflectionScenario_LoadAligned();
                }

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.Read
                test.RunLclVarScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates passing a local works, using Load
                    test.RunLclVarScenario_Load();

                    // Validates passing a local works, using LoadAligned
                    test.RunLclVarScenario_LoadAligned();
                }

                // Validates passing the field of a local works
                test.RunLclFldScenario();

                // Validates passing an instance member works
                test.RunFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class BooleanBinaryOpTest__TestCSByte
    {
        private static readonly int LargestVectorSize = 32;

        private static readonly int Op1ElementCount = Unsafe.SizeOf<Vector256<SByte>>() / sizeof(SByte);
        private static readonly int Op2ElementCount = Unsafe.SizeOf<Vector256<SByte>>() / sizeof(SByte);

        private static SByte[] _data1 = new SByte[Op1ElementCount];
        private static SByte[] _data2 = new SByte[Op2ElementCount];

        private static Vector256<SByte> _clsVar1;
        private static Vector256<SByte> _clsVar2;

        private Vector256<SByte> _fld1;
        private Vector256<SByte> _fld2;

        private BooleanBinaryOpTest__DataTable<SByte, SByte> _dataTable;

        static BooleanBinaryOpTest__TestCSByte()
        {
            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<SByte>, byte>(ref _clsVar1), ref Unsafe.As<SByte, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector256<SByte>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<SByte>, byte>(ref _clsVar2), ref Unsafe.As<SByte, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector256<SByte>>());
        }

        public BooleanBinaryOpTest__TestCSByte()
        {
            Succeeded = true;

            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<SByte>, byte>(ref _fld1), ref Unsafe.As<SByte, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector256<SByte>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<SByte>, byte>(ref _fld2), ref Unsafe.As<SByte, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector256<SByte>>());

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = (sbyte)(random.Next(sbyte.MinValue, sbyte.MaxValue)); }
            _dataTable = new BooleanBinaryOpTest__DataTable<SByte, SByte>(_data1, _data2, LargestVectorSize);
        }

        public bool IsSupported => Avx.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            var result = Avx.TestC(
                Unsafe.Read<Vector256<SByte>>(_dataTable.inArray1Ptr),
                Unsafe.Read<Vector256<SByte>>(_dataTable.inArray2Ptr)
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunBasicScenario_Load()
        {
            var result = Avx.TestC(
                Avx.LoadVector256((SByte*)(_dataTable.inArray1Ptr)),
                Avx.LoadVector256((SByte*)(_dataTable.inArray2Ptr))
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunBasicScenario_LoadAligned()
        {
            var result = Avx.TestC(
                Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray1Ptr)),
                Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray2Ptr))
            );

            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, result);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            var method = typeof(Avx).GetMethod(nameof(Avx.TestC), new Type[] { typeof(Vector256<SByte>), typeof(Vector256<SByte>) });
            
            if (method != null)
            {
                var result = method.Invoke(null, new object[] {
                                        Unsafe.Read<Vector256<SByte>>(_dataTable.inArray1Ptr),
                                        Unsafe.Read<Vector256<SByte>>(_dataTable.inArray2Ptr)
                                     });

                ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
            }
        }

        public void RunReflectionScenario_Load()
        {
            var method = typeof(Avx).GetMethod(nameof(Avx.TestC), new Type[] { typeof(Vector256<SByte>), typeof(Vector256<SByte>) });
            
            if (method != null)
            {
                var result = method.Invoke(null, new object[] {
                                        Avx.LoadVector256((SByte*)(_dataTable.inArray1Ptr)),
                                        Avx.LoadVector256((SByte*)(_dataTable.inArray2Ptr))
                                     });

                ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
            }
        }

        public void RunReflectionScenario_LoadAligned()
        {
            var method = typeof(Avx).GetMethod(nameof(Avx.TestC), new Type[] { typeof(Vector256<SByte>), typeof(Vector256<SByte>) });
            
            if (method != null)
            {
                var result = method.Invoke(null, new object[] {
                                        Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray1Ptr)),
                                        Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray2Ptr))
                                     });

                ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, (bool)(result));
            }
        }

        public void RunClsVarScenario()
        {
            var result = Avx.TestC(
                _clsVar1,
                _clsVar2
            );

            ValidateResult(_clsVar1, _clsVar2, result);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var left = Unsafe.Read<Vector256<SByte>>(_dataTable.inArray1Ptr);
            var right = Unsafe.Read<Vector256<SByte>>(_dataTable.inArray2Ptr);
            var result = Avx.TestC(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclVarScenario_Load()
        {
            var left = Avx.LoadVector256((SByte*)(_dataTable.inArray1Ptr));
            var right = Avx.LoadVector256((SByte*)(_dataTable.inArray2Ptr));
            var result = Avx.TestC(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            var left = Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray1Ptr));
            var right = Avx.LoadAlignedVector256((SByte*)(_dataTable.inArray2Ptr));
            var result = Avx.TestC(left, right);

            ValidateResult(left, right, result);
        }

        public void RunLclFldScenario()
        {
            var test = new BooleanBinaryOpTest__TestCSByte();
            var result = Avx.TestC(test._fld1, test._fld2);

            ValidateResult(test._fld1, test._fld2, result);
        }

        public void RunFldScenario()
        {
            var result = Avx.TestC(_fld1, _fld2);

            ValidateResult(_fld1, _fld2, result);
        }

        public void RunUnsupportedScenario()
        {
            Succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                Succeeded = true;
            }
        }

        private void ValidateResult(Vector256<SByte> left, Vector256<SByte> right, bool result, [CallerMemberName] string method = "")
        {
            SByte[] inArray1 = new SByte[Op1ElementCount];
            SByte[] inArray2 = new SByte[Op2ElementCount];

            Unsafe.WriteUnaligned(ref Unsafe.As<SByte, byte>(ref inArray1[0]), left);
            Unsafe.WriteUnaligned(ref Unsafe.As<SByte, byte>(ref inArray2[0]), right);

            ValidateResult(inArray1, inArray2, result, method);
        }

        private void ValidateResult(void* left, void* right, bool result, [CallerMemberName] string method = "")
        {
            SByte[] inArray1 = new SByte[Op1ElementCount];
            SByte[] inArray2 = new SByte[Op2ElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<SByte, byte>(ref inArray1[0]), ref Unsafe.AsRef<byte>(left), (uint)Unsafe.SizeOf<Vector256<SByte>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<SByte, byte>(ref inArray2[0]), ref Unsafe.AsRef<byte>(right), (uint)Unsafe.SizeOf<Vector256<SByte>>());

            ValidateResult(inArray1, inArray2, result, method);
        }

        private void ValidateResult(SByte[] left, SByte[] right, bool result, [CallerMemberName] string method = "")
        {
            var expectedResult = true;

            for (var i = 0; i < Op1ElementCount; i++)
            {
                expectedResult &= ((~left[i] & right[i]) == 0);
            }

            if (expectedResult != result)
            {
                Succeeded = false;

                Console.WriteLine($"{nameof(Avx)}.{nameof(Avx.TestC)}<SByte>(Vector256<SByte>, Vector256<SByte>): {method} failed:");
                Console.WriteLine($"    left: ({string.Join(", ", left)})");
                Console.WriteLine($"   right: ({string.Join(", ", right)})");
                Console.WriteLine($"  result: ({string.Join(", ", result)})");
                Console.WriteLine();
            }
        }
    }
}
