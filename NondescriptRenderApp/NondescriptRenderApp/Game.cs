using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace NondescriptRenderApp
{
    public class Game : GameWindow
    {

        //A basic triangle as vertices
        float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };

        Shader shader;

        //OpenGL doesn't use traditional objects, instead integer pointer to "objects"
        int VertexBufferObject;

        //Instantiating a new game window, TODO: move to either xaml or winform control for render output
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }


        //Frame update OpenGL
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }

        //First load for OpenGL
        protected override void OnLoad(EventArgs e)
        {
            shader = new Shader("shader.vert", "shader.frag");

            //OpenGL doesn't use traditional objects, instead integer pointer to "objects"
            //Creating a new buffer for vertex data on gpu (Vertex Buffer Object: VBO)
            VertexBufferObject = GL.GenBuffer();

            //Bind buffer to our OpenGL context, all buffer calls on this buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            //Setup buffer size and usage hint, TODO: Check if this needs to be changed to dynamic
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            //Sets background color to be used for future clear frame calls
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Define vertex attributes
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            shader.Use();

            someOpenGLFunctionThatDrawsOurTriangle();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            //Dispose of our shader
            shader.Dispose();

            //Bind buffer to 0, should prevent anything from interacting with buffer since object ref is null
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //Free up our gMemory
            GL.DeleteBuffer(VertexBufferObject);

            base.OnUnload(e);
        }
    }
}
