using Altseed;

namespace Tutorial
{
    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    public sealed class Player : CollidableObject
    {
        public override bool DoSurvey => false;

        public override float Radius { get; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public Player(Vector2F position) : base(position)
        {
            Texture = Texture2D.LoadStrict("Resources/Player.png");
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is Enemy || obj is EnemyBullet)
            {
                Parent.AddChildNode(new DeathEffect(Position));
                Parent.RemoveChildNode(this);
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
            const int maxX = 960;
            const int maxY = 720;
            var x = Position.X;
            var y = Position.Y;
            var halfSize = Texture.Size / 2;

            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) y -= 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) y += 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) x += 1.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) x -= 1.5f;

            x = MathHelper.Clamp(x, maxX - halfSize.X, halfSize.X);
            y = MathHelper.Clamp(y, maxY - halfSize.Y, halfSize.Y);

            Position = new Vector2F(x, y);
        }

        /// <summary>
        /// ショット
        /// </summary>
        private void Shot()
        {
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push) Parent.AddChildNode(new PlayerBullet(Position));
        }
    }
}
