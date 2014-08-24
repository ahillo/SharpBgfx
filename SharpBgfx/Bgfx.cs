using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpBgfx {
    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Bgfx {
        const string DllName = "bgfx.dll";

        [DllImport(DllName, EntryPoint = "bgfx_get_renderer_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern RendererType GetCurrentRenderer ();

        [DllImport(DllName, EntryPoint = "bgfx_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Init (RendererType rendererType, IntPtr p, IntPtr d);

        [DllImport(DllName, EntryPoint = "bgfx_shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown ();

        [DllImport(DllName, EntryPoint = "bgfx_reset", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Reset (int width, int height, ResetFlags flags);

        [DllImport(DllName, EntryPoint = "bgfx_set_debug", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDebugFlags (DebugFlags flags);

        [DllImport(DllName, EntryPoint = "bgfx_set_marker", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDebugMarker (string marker);

        [DllImport(DllName, EntryPoint = "bgfx_dbg_text_clear", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DebugTextClear (byte color, bool smallText);

        [DllImport(DllName, EntryPoint = "bgfx_dbg_text_printf", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DebugTextWrite (ushort x, ushort y, byte color, string text);

        [DllImport(DllName, EntryPoint = "bgfx_frame", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Frame ();

        [DllImport(DllName, EntryPoint = "bgfx_get_caps", CallingConvention = CallingConvention.Cdecl)]
        public static extern Caps* GetCaps ();

        [DllImport(DllName, EntryPoint = "bgfx_win_set_hwnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowHandle (IntPtr hwnd);

        [DllImport(DllName, EntryPoint = "bgfx_vertex_decl_begin", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VertexDeclBegin (ref VertexDecl decl, RendererType renderer);

        [DllImport(DllName, EntryPoint = "bgfx_vertex_decl_add", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VertexDeclAdd (ref VertexDecl decl, VertexAttribute attribute, byte count, VertexAttributeType type, bool normalized, bool asInt);

        [DllImport(DllName, EntryPoint = "bgfx_vertex_decl_skip", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VertexDeclSkip (ref VertexDecl decl, byte count);

        [DllImport(DllName, EntryPoint = "bgfx_vertex_decl_end", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VertexDeclEnd (ref VertexDecl decl);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewName (byte id, string name);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_rect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewRect (byte id, ushort x, ushort y, ushort width, ushort height);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_rect_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewRectMask (int viewMask, ushort x, ushort y, ushort width, ushort height);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_scissor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewScissor (byte id, ushort x, ushort y, ushort width, ushort height);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_scissor_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewScissorMask (int viewMask, ushort x, ushort y, ushort width, ushort height);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_clear", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewClear (byte id, ClearFlags flags, int rgba, float depth, byte stencil);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_clear_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewClearMask (int viewMask, ClearFlags flags, int rgba, float depth, byte stencil);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_seq", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewSequential (byte id, bool enabled);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_seq_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewSequentialMask (int viewMask, bool enabled);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_transform", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewTransform (byte id, float* view, float* proj);

        [DllImport(DllName, EntryPoint = "bgfx_set_view_transform_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetViewTransformMask (int viewMask, float* view, float* proj);

        [DllImport(DllName, EntryPoint = "bgfx_set_transform", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTransform (float* matrix, ushort count);

        [DllImport(DllName, EntryPoint = "bgfx_set_stencil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetStencil (StencilFlags frontFace, StencilFlags backFace);

        [DllImport(DllName, EntryPoint = "bgfx_submit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Submit (byte id, int depth = 0);

        [DllImport(DllName, EntryPoint = "bgfx_submit_mask", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SubmitMask (int viewMask, int depth);

        [DllImport(DllName, EntryPoint = "bgfx_discard", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Discard ();

        [DllImport(DllName, EntryPoint = "bgfx_save_screen_shot", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveScreenShot (string filePath);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyIndexBuffer (IndexBufferHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyVertexBuffer (VertexBufferHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_shader", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyShader (ShaderHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_create_program", CallingConvention = CallingConvention.Cdecl)]
        public static extern ProgramHandle CreateProgram (ShaderHandle vertexShader, ShaderHandle fragmentShader, bool destroyShaders);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_program", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyProgram (ProgramHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_set_program", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetProgram (ProgramHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_set_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetIndexBuffer (IndexBufferHandle handle, int firstIndex, int count);

        [DllImport(DllName, EntryPoint = "bgfx_set_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVertexBuffer (VertexBufferHandle handle, int startVertex, int count);
        
        [DllImport(DllName, EntryPoint = "bgfx_set_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRenderState (RenderState state, uint rgba);

        [DllImport(DllName, EntryPoint = "bgfx_create_uniform", CallingConvention = CallingConvention.Cdecl)]
        public static extern UniformHandle CreateUniform (string name, UniformType type, ushort arraySize = 1);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_uniform", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyUniform (UniformHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_set_uniform", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUniform (UniformHandle handle, void* value, ushort arraySize = 1);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_texture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyTexture (TextureHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_set_texture", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTexture(byte stage, UniformHandle sampler, TextureHandle handle, uint flags);

        //[DllImport(DllName, EntryPoint = "bgfx_set_texture_from_frame_buffer", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void SetTextureFromFrameBuffer(byte stage, UniformHandle sampler, FrameBufferHandle handle, byte attachment, uint flags);

        [DllImport(DllName, EntryPoint = "bgfx_create_texture_2d", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TextureHandle CreateTexture2D_Internal(ushort width, ushort height, byte numMips, TextureFormat format, TextureFlags flags, GraphicsMemory* memory);

        //===============================================================================================================

        #region transient buffers

        public static void AllocTransientIndexBuffer(ref TransientIndexBuffer buffer, uint size)
        {
            AllocTransientIndexBuffer_(ref buffer, size);
        }

        public static void AllocTransientVertexBuffer(ref TransientVertexBuffer buffer, uint size, ref VertexDecl decl)
        {
            AllocTransientVertexBuffer_(ref buffer, size, ref decl);
        }
        
        [DllImport(DllName, EntryPoint = "bgfx_alloc_transient_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void AllocTransientIndexBuffer_(ref TransientIndexBuffer buffer, uint size);
        
        [DllImport(DllName, EntryPoint = "bgfx_alloc_transient_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AllocTransientVertexBuffer_(ref TransientVertexBuffer buffer, uint size, ref VertexDecl decl);
        
        [DllImport(DllName, EntryPoint = "bgfx_set_transient_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTransientIndexBuffer(ref TransientIndexBuffer tib, uint firstIndex, uint numIndices);

        [DllImport(DllName, EntryPoint = "bgfx_set_transient_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTransientVertexBuffer(ref TransientVertexBuffer tvb, uint startVertex, uint numVertices);
    
        // TODO: destroy
        #endregion

        #region instance data buffers

        [DllImport(DllName, EntryPoint = "bgfx_set_instance_data_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstanceDataBuffer(ref InstanceDataBuffer idb, ushort num);

        // TOTO: create, update

        #endregion

        #region dynamic buffers

        public static IndexBufferHandle CreateDynamicIndexBuffer(MemoryBuffer memory)
        {
            return CreateDynamicIndexBuffer(memory.Native);
        }

        public static void UpdateDynamicIndexBuffer(IndexBufferHandle handle, MemoryBuffer memory)
        {
            UpdateDynamicIndexBuffer(handle, memory.Native);
        }

        public static VertexBufferHandle CreateDynamicVertexBuffer(MemoryBuffer memory, VertexDecl decl)
        {
            return CreateDynamicVertexBuffer(memory.Native, ref decl);
        }

        public static void UpdateDynamicVertexBuffer(VertexBufferHandle handle, MemoryBuffer memory)
        {
            UpdateDynamicVertexBuffer(handle, memory.Native);
        }


        [DllImport(DllName, EntryPoint = "bgfx_create_dynamic_index_buffer_mem", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IndexBufferHandle CreateDynamicIndexBuffer(GraphicsMemory* memory);

        [DllImport(DllName, EntryPoint = "bgfx_update_dynamic_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UpdateDynamicIndexBuffer(IndexBufferHandle handle, GraphicsMemory* memory);

        [DllImport(DllName, EntryPoint = "bgfx_destroy_dynamic_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyDynamicIndexBuffer(IndexBufferHandle handle);

        [DllImport(DllName, EntryPoint = "bgfx_create_dynamic_vertex_buffer_mem", CallingConvention = CallingConvention.Cdecl)]
        internal static extern VertexBufferHandle CreateDynamicVertexBuffer(GraphicsMemory* memory, ref VertexDecl decl);

        [DllImport(DllName, EntryPoint = "bgfx_update_dynamic_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UpdateDynamicVertexBuffer(VertexBufferHandle handle, GraphicsMemory* memory);

        #endregion

        // **** wrapper methods for convenience ****

        public static string GetRendererName (RendererType rendererType) {
            return new string(GetRendererNameInternal(rendererType));
        }

        public static RendererType[] GetSupportedRenderers () {
            var types = new RendererType[Enum.GetValues(typeof(RendererType)).Length];
            var count = GetSupportedRenderers(types);

            return types.Take(count).ToArray();
        }

        public static IndexBufferHandle CreateIndexBuffer (MemoryBuffer memory) {
            return CreateIndexBuffer(memory.Native);
        }

        public static VertexBufferHandle CreateVertexBuffer (MemoryBuffer memory, VertexDecl decl) {
            return CreateVertexBuffer(memory.Native, ref decl);
        }

        public static ShaderHandle CreateShader (MemoryBuffer memory) {
            return CreateShader(memory.Native);
        }

        public static TextureHandle CreateTexture(MemoryBuffer memory, TextureFlags flags, byte skip) {
            TextureInfo info;
            return CreateTexture(memory.Native, flags, skip, out info);
        }

        public static TextureHandle CreateTexture2D(ushort width, ushort height, byte numMips, TextureFormat format, TextureFlags flags, MemoryBuffer memory)
        {
            return CreateTexture2D_Internal(width, height, numMips, format, flags, memory.Native);
        }

        // **** methods below are internal, since they're exposed by a wrapper to make them more convenient for .NET callers ****

        [DllImport(DllName, EntryPoint = "bgfx_alloc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern GraphicsMemory* Alloc (int size);

        [DllImport(DllName, EntryPoint = "bgfx_copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern GraphicsMemory* Copy(IntPtr data, int size);

        [DllImport(DllName, EntryPoint = "bgfx_get_renderer_name", CallingConvention = CallingConvention.Cdecl)]
        static extern sbyte* GetRendererNameInternal (RendererType rendererType);

        [DllImport(DllName, EntryPoint = "bgfx_get_supported_renderers", CallingConvention = CallingConvention.Cdecl)]
        static extern byte GetSupportedRenderers (RendererType[] types);

        [DllImport(DllName, EntryPoint = "bgfx_create_index_buffer", CallingConvention = CallingConvention.Cdecl)]
        static extern IndexBufferHandle CreateIndexBuffer (GraphicsMemory* memory);

        [DllImport(DllName, EntryPoint = "bgfx_create_vertex_buffer", CallingConvention = CallingConvention.Cdecl)]
        static extern VertexBufferHandle CreateVertexBuffer (GraphicsMemory* memory, ref VertexDecl decl);

        [DllImport(DllName, EntryPoint = "bgfx_create_shader", CallingConvention = CallingConvention.Cdecl)]
        static extern ShaderHandle CreateShader (GraphicsMemory* memory);

        [DllImport(DllName, EntryPoint = "bgfx_calc_texture_size", CallingConvention = CallingConvention.Cdecl)]
        static extern void CalcTextureSize (ref TextureInfo info, ushort width, ushort height, ushort depth, byte mipCount, TextureFormat format);

        [DllImport(DllName, EntryPoint = "bgfx_create_texture", CallingConvention = CallingConvention.Cdecl)]
        static extern TextureHandle CreateTexture (GraphicsMemory* memory, TextureFlags flags, byte skip, out TextureInfo info);
    }
}
