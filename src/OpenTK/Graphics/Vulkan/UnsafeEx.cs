using System;
using System.Runtime.CompilerServices;

namespace OpenTK.Graphics.Vulkan
{
    public static unsafe class UnsafeEx
    {
        public static IntPtr AsIntPtr<T>(ref T obj)
        {
            return new IntPtr(Unsafe.AsPointer(ref obj));
        }
    }
}
