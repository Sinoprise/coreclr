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
        private static void ShiftRightArithmeticInt1616()
        {
            var test = new SimpleUnaryOpTest__ShiftRightArithmeticInt1616();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Sse2.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Sse2.IsSupported)
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

                if (Sse2.IsSupported)
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

    public sealed unsafe class SimpleUnaryOpTest__ShiftRightArithmeticInt1616
    {
        private static readonly int LargestVectorSize = 16;

        private static readonly int Op1ElementCount = Unsafe.SizeOf<Vector128<Int16>>() / sizeof(Int16);
        private static readonly int RetElementCount = Unsafe.SizeOf<Vector128<Int16>>() / sizeof(Int16);

        private static Int16[] _data = new Int16[Op1ElementCount];

        private static Vector128<Int16> _clsVar;

        private Vector128<Int16> _fld;

        private SimpleUnaryOpTest__DataTable<Int16, Int16> _dataTable;

        static SimpleUnaryOpTest__ShiftRightArithmeticInt1616()
        {
            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (short)(random.Next(0, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Int16>, byte>(ref _clsVar), ref Unsafe.As<Int16, byte>(ref _data[0]), (uint)Unsafe.SizeOf<Vector128<Int16>>());
        }

        public SimpleUnaryOpTest__ShiftRightArithmeticInt1616()
        {
            Succeeded = true;

            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (short)(random.Next(0, short.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Int16>, byte>(ref _fld), ref Unsafe.As<Int16, byte>(ref _data[0]), (uint)Unsafe.SizeOf<Vector128<Int16>>());

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (short)(random.Next(0, short.MaxValue)); }
            _dataTable = new SimpleUnaryOpTest__DataTable<Int16, Int16>(_data, new Int16[RetElementCount], LargestVectorSize);
        }

        public bool IsSupported => Sse2.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            var result = Sse2.ShiftRightArithmetic(
                Unsafe.Read<Vector128<Int16>>(_dataTable.inArrayPtr),
                16
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_Load()
        {
            var result = Sse2.ShiftRightArithmetic(
                Sse2.LoadVector128((Int16*)(_dataTable.inArrayPtr)),
                16
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_LoadAligned()
        {
            var result = Sse2.ShiftRightArithmetic(
                Sse2.LoadAlignedVector128((Int16*)(_dataTable.inArrayPtr)),
                16
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            var result = typeof(Sse2).GetMethod(nameof(Sse2.ShiftRightArithmetic), new Type[] { typeof(Vector128<Int16>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Unsafe.Read<Vector128<Int16>>(_dataTable.inArrayPtr),
                                        (byte)16
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Int16>)(result));
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_Load()
        {
            var result = typeof(Sse2).GetMethod(nameof(Sse2.ShiftRightArithmetic), new Type[] { typeof(Vector128<Int16>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Sse2.LoadVector128((Int16*)(_dataTable.inArrayPtr)),
                                        (byte)16
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Int16>)(result));
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_LoadAligned()
        {
            var result = typeof(Sse2).GetMethod(nameof(Sse2.ShiftRightArithmetic), new Type[] { typeof(Vector128<Int16>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Sse2.LoadAlignedVector128((Int16*)(_dataTable.inArrayPtr)),
                                        (byte)16
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Int16>)(result));
            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunClsVarScenario()
        {
            var result = Sse2.ShiftRightArithmetic(
                _clsVar,
                16
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_clsVar, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var firstOp = Unsafe.Read<Vector128<Int16>>(_dataTable.inArrayPtr);
            var result = Sse2.ShiftRightArithmetic(firstOp, 16);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_Load()
        {
            var firstOp = Sse2.LoadVector128((Int16*)(_dataTable.inArrayPtr));
            var result = Sse2.ShiftRightArithmetic(firstOp, 16);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            var firstOp = Sse2.LoadAlignedVector128((Int16*)(_dataTable.inArrayPtr));
            var result = Sse2.ShiftRightArithmetic(firstOp, 16);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, _dataTable.outArrayPtr);
        }

        public void RunLclFldScenario()
        {
            var test = new SimpleUnaryOpTest__ShiftRightArithmeticInt1616();
            var result = Sse2.ShiftRightArithmetic(test._fld, 16);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(test._fld, _dataTable.outArrayPtr);
        }

        public void RunFldScenario()
        {
            var result = Sse2.ShiftRightArithmetic(_fld, 16);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_fld, _dataTable.outArrayPtr);
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

        private void ValidateResult(Vector128<Int16> firstOp, void* result, [CallerMemberName] string method = "")
        {
            Int16[] inArray = new Int16[Op1ElementCount];
            Int16[] outArray = new Int16[RetElementCount];

            Unsafe.WriteUnaligned(ref Unsafe.As<Int16, byte>(ref inArray[0]), firstOp);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<Int16>>());

            ValidateResult(inArray, outArray, method);
        }

        private void ValidateResult(void* firstOp, void* result, [CallerMemberName] string method = "")
        {
            Int16[] inArray = new Int16[Op1ElementCount];
            Int16[] outArray = new Int16[RetElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref inArray[0]), ref Unsafe.AsRef<byte>(firstOp), (uint)Unsafe.SizeOf<Vector128<Int16>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Int16, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<Int16>>());

            ValidateResult(inArray, outArray, method);
        }

        private void ValidateResult(Int16[] firstOp, Int16[] result, [CallerMemberName] string method = "")
        {
            if ((short)(firstOp[0] >> 15) != result[0])
            {
                Succeeded = false;
            }
            else
            {
                for (var i = 1; i < RetElementCount; i++)
                {
                    if ((short)(firstOp[i] >> 15) != result[i])
                    {
                        Succeeded = false;
                        break;
                    }
                }
            }

            if (!Succeeded)
            {
                Console.WriteLine($"{nameof(Sse2)}.{nameof(Sse2.ShiftRightArithmetic)}<Int16>(Vector128<Int16><9>): {method} failed:");
                Console.WriteLine($"  firstOp: ({string.Join(", ", firstOp)})");
                Console.WriteLine($"   result: ({string.Join(", ", result)})");
                Console.WriteLine();
            }
        }
    }
}
