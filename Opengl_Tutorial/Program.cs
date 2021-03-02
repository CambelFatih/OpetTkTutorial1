using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opengl_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(600, 600);
            game gm=new game(window);
        }
    }
}
