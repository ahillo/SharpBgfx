using System;
using System.Runtime.InteropServices;

namespace SharpBgfx
{
    public struct Caps
    {
        public RendererType RendererType;
        public CapsFlags Supported;
        public CapsFlags Emulated;
        public ushort MaxTextureSize;
        public ushort MaxDrawCalls;
        public byte MaxFramebufferAttachements;
    }

    public struct TextureInfo
    {
        public TextureFormat Format;
        public int StorageSize;
        public short Width;
        public short Height;
        public short Depth;
        public byte MipCount;
        public byte BitsPerPixel;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct TransientIndexBuffer
    {
        public byte* data;
        uint size;
        //IndexBufferHandle handle;
        ushort handle;
        uint startIndex;


        public bool SetData<T>(T[] data, int start_index, int count) where T : struct
        {
            if (count > size)
                return false;

            int size_t = GetSize<T>();
            var num_bytes = size_t * count;

            IntPtr ptr = new IntPtr(this.data);
            WriteArray(ptr, data, start_index, num_bytes);// num_bytes);
            return true;
        }


        static int GetSize<T>()
        {
            return RewriteStubs.SizeOfInline<T>();
        }

        static void WriteArray<T>(IntPtr ptr, T[] data, int start_index, int num_bytes)
            where T : struct
        {
            RewriteStubs.WriteArray(ptr, data, start_index, num_bytes);
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public unsafe struct TransientVertexBuffer
    {
        public byte* data;
        uint size;
        uint startVertex;
        ushort stride;
        //VertexBufferHandle handle;
        ushort handle;
        ushort decl;


        public bool SetData<T>(T[] data, int start_index, int count) where T : struct
        {
            if (count > size)
                return false;

            int size_t = GetSize<T>();
            var num_bytes = size_t * count;

            IntPtr ptr = new IntPtr(this.data);
            WriteArray(ptr, data, start_index, num_bytes);
            return true;
        }


        static int GetSize<T>()
        {
            return RewriteStubs.SizeOfInline<T>();
        }

        static void WriteArray<T>(IntPtr ptr, T[] data, int start_index, int num_bytes)
            where T : struct
        {
            RewriteStubs.WriteArray(ptr, data, start_index, num_bytes);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct InstanceDataBuffer
    {
        byte* data;
        uint size;
        uint offset;
        ushort stride;
        ushort num;
        VertexBufferHandle handle;
    }

    public unsafe struct VertexDecl
    {
        const int MaxAttribCount = 15;

        public static readonly int SizeInBytes = Marshal.SizeOf(typeof(VertexDecl));

        public uint Hash;
        public ushort Stride;
        public fixed ushort Offset[MaxAttribCount];
        public fixed byte Attributes[MaxAttribCount];
    }

    unsafe struct GraphicsMemory
    {
        public byte* Data;
        public int Size;
    }
}
