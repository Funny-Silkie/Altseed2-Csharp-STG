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

        //static void Main(string[] args)
        //{
        //    Engine.Initialize("Tutorial", 960, 720, new Configuration());

        //    var list = new System.Collections.Generic.List<SpriteNode>();

        //    var player = new SpriteNode()
        //    {
        //        Texture = Resources.Texture_Player,
        //        Position = new Vector2F(100, 360)
        //    };
        //    player.CenterPosition = player.Texture.Size / 2;
        //    Engine.AddNode(player);

        //    while (Engine.DoEvents())
        //    {
        //        Engine.Update();

        //        if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) player.Position -= new Vector2F(0.0f, 2.5f);
        //        if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) player.Position += new Vector2F(0.0f, 2.5f);
        //        if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) player.Position += new Vector2F(2.5f, 0.0f);
        //        if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) player.Position -= new Vector2F(2.5f, 0.0f);

        //        if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
        //        {
        //            var bullet = new SpriteNode()
        //            {
        //                Texture = Resources.Texture_Bullet_Blue,
        //                Position = player.Position
        //            };
        //            bullet.CenterPosition = bullet.Texture.Size / 2;
        //            bullet.ZOrder--;

        //            Engine.AddNode(bullet);
        //            list.Add(bullet);
        //        }

        //        for (int i = 0; i < list.Count; i++) list[i].Position += new Vector2F(10.0f, 0.0f);

        //        if (Engine.Keyboard.GetKeyState(Keys.Escape) == ButtonState.Push) break;
        //    }

        //    Engine.Terminate();
        //}
    }
}
