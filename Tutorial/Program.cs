using Altseed;
using System;

namespace Tutorial
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("Tutorial", 960, 720);

            while (Engine.DoEvents())
            {
                if (!Engine.Update()) break;
            }

            Engine.Terminate();
        }
    }
}
