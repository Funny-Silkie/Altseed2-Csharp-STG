using Altseed;
using System;

namespace Tutorial
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("Tutorial", 960, 720, new Configuration());

            Engine.AddNode(new TitleNode());

            while (Engine.DoEvents())
            {
                Engine.Update();
                if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;
            }

            Engine.Terminate();
        }
    }
}
