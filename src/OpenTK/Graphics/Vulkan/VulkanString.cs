using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Graphics.Vulkan
{
    public unsafe class VulkanString : IDisposable
    {
        private GCHandle _handle;
        private uint _numBytes;

        public byte* StringPtr => (byte*)_handle.AddrOfPinnedObject().ToPointer();

        public VulkanString(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            byte[] text = Encoding.UTF8.GetBytes(s);
            _handle = GCHandle.Alloc(text, GCHandleType.Pinned);
            _numBytes = (uint)text.Length;
        }

        public void SetText(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            _handle.Free();
            byte[] text = Encoding.UTF8.GetBytes(s);
            _handle = GCHandle.Alloc(text, GCHandleType.Pinned);
            _numBytes = (uint)text.Length;
        }

        private string GetString()
        {
            return Encoding.UTF8.GetString(StringPtr, (int)_numBytes);
        }

        public void Dispose()
        {
            _handle.Free();
        }

        public static implicit operator byte* (VulkanString utf8String) => utf8String.StringPtr;
        public static implicit operator IntPtr (VulkanString utf8String) => new IntPtr(utf8String.StringPtr);
        public static implicit operator VulkanString(string s) => new VulkanString(s);
        public static implicit operator string(VulkanString utf8String) => utf8String.GetString();
    }
}