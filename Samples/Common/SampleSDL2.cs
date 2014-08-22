using System;
using System.Threading;
using SharpBgfx;
using SDL2;
using System.Runtime.InteropServices;


namespace Common {
    public class SampleSDL2
    {
        EventQueue eventQueue = new EventQueue();

        public int WindowWidth {
            get;
            private set;
        }

        public int WindowHeight {
            get;
            private set;
        }

        public SampleSDL2 (string name, int windowWidth, int windowHeight) {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

			SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

			var m_window = SDL.SDL_CreateWindow("bgfx"
							, SDL.SDL_WINDOWPOS_UNDEFINED
							, SDL.SDL_WINDOWPOS_UNDEFINED
							, windowWidth
							, windowHeight
							, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
							);

			var s_userEventStart = SDL.SDL_RegisterEvents(3);

            SDL.SDL_SysWMinfo m_window_info = new SDL.SDL_SysWMinfo();
            SDL.SDL_GetWindowWMInfo(m_window, ref m_window_info);
            Bgfx.SetWindowHandle(m_window_info.info.win.window);
        }

        public void Run (Action<SampleSDL2> renderThread) {
            var thread = new Thread(() => renderThread(this));
            thread.Start();

            while (true)
            {   
                SDL.SDL_Event evt;
                SDL.SDL_WaitEvent(out evt);

                if (evt.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    eventQueue.Post(new Event(EventType.Exit));
                    break;
                }
            }

            thread.Join();
        }

        public bool ProcessEvents (ResetFlags resetFlags) 
        {
            Event ev;
            bool resizeRequired = false;

            while ((ev = eventQueue.Poll()) != null) {
                switch (ev.Type) {
                    case EventType.Exit:
                        return false;

                    case EventType.Size:
                        var size = (SizeEvent)ev;
                        WindowWidth = size.Width;
                        WindowHeight = size.Height;
                        resizeRequired = true;
                        break;
                }
            }

            if (resizeRequired)
                Bgfx.Reset(WindowWidth, WindowHeight, resetFlags);

            return true;
        }
    }
}
