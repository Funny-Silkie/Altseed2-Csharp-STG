using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    public sealed class Player : CollidableObject
    {
        public override bool DoSurvey => true;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public Player(MainNode stage, Vector2F position) : base(stage, position)
        {
            Texture = Texture_Player;
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.Y / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is Enemy || obj is EnemyBullet)
            {
                Parent.RemoveChildNode(this);
                Engine.RemoveNode(Stage);
                Engine.AddNode(new GameOverNode());
            }
        }

        protected override void OnUpdate()
        {
            Move();
            Shot();
            base.OnUpdate();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            var x = Position.X;
            var y = Position.Y;
            var halfSize = Texture.Size / 2;

            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) y -= 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) y += 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) x += 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) x -= 2.5f;

            //x = MathHelper.Clamp(x, Engine.WindowSize.X - halfSize.X, halfSize.X);
            x = MathHelper.Clamp(x, Engine.WindowSize.X, 0);
            //y = MathHelper.Clamp(y, Engine.WindowSize.Y - halfSize.Y, halfSize.Y);
            y = MathHelper.Clamp(y, Engine.WindowSize.Y, 0);

            Position = new Vector2F(x, y);
        }

        /// <summary>
        /// ショット
        /// </summary>
        private void Shot()
        {
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push) Parent.AddChildNode(new PlayerBullet(Stage, Position + CenterPosition));
            //if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Hold)
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Parent.AddChildNode(new PlayerBullet(Position + CenterPosition + new Vector2F(0, i * 10)));
            //        Parent.AddChildNode(new PlayerBullet(Position + CenterPosition + new Vector2F(0, -i * 10)));
            //    }
        }
    }
}
