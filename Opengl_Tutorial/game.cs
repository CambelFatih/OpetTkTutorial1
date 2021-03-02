using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace Opengl_Tutorial
{
    public class game
    {
        double theta = 0.0;
        GameWindow window;
        public game(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
            window.Load += Window_Load;
            window.Resize += Window_Resize;
            window.RenderFrame += Window_RenderFrame;
            window.Run(1.0 / 60.0);
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 matrix = Matrix4.Perspective(45.0f,window.Width/window.Height,1.0f,100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit|ClearBufferMask.DepthBufferBit);

            GL.Translate(0.0, 0.0,-45.0);

            GL.Rotate(theta, 1.0, 0.0, 0.0);//ÖNEMLİ
            GL.Rotate(theta, 0.0, 1.0, 0.0);

            GL.Begin(BeginMode.Quads);

            //front
            GL.Color3(1.0, 0.0, 0.0);//1.0,0,0
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            //back
            GL.Color3(0.0,1.0, 0.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            //top1
            GL.Color3(0.0, 1.0,0.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            //bottom
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            //right
            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            //left
            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);


            GL.End(); 
            window.SwapBuffers();
            theta += 1.0;
            if (theta > 360)
                theta -= 360;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f,0.0f,0.0f,0.0f);
            GL.Enable(EnableCap.DepthTest);//sonradan yazdık
        }
    }
}
