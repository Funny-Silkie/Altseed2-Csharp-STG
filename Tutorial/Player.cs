using Altseed;

namespace Tutorial
{
    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    public sealed class Player : CollidableObject
    {
        public override bool DoSurvey { get; } = false;

        public override float Radius { get; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        public Player()
        {
            Texture = Texture2D.LoadStrict("Resources/Player.png");
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            
        }

        protected override void OnUpdate()
        {
            Move();
            base.OnUpdate();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            const int maxX = 960;
            const int maxY = 720;
            var x = Position.X;
            var y = Position.Y;
            var size = Texture.Size;

            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Push) y -= 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Push) y += 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Push) x += 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Push) x -= 1.5f;

            x = MathHelper.Clamp(x, maxX - size.X / 2, size.X / 2);
            y = MathHelper.Clamp(y, maxY - size.Y / 2, size.Y / 2);

            Position = new Vector2F(x, y);
        }
    }
}
