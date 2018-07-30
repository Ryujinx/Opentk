namespace OpenTK.Graphics.Vulkan
{
    public struct VulkanVersion
    {
        private readonly uint value;

        public VulkanVersion(uint major, uint minor, uint patch)
        {
            value = major << 22 | minor << 12 | patch;
        }

        public uint Major => value >> 22;

        public uint Minor => (value >> 12) & 0x3ff;

        public uint Patch => (value >> 22) & 0xfff;

        public static implicit operator uint(VulkanVersion version)
        {
            return version.value;
        }
    }
}