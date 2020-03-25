using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    public sealed class Player : CollidableObject
    {
        public override bool DoSurvey => false;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public Player(Vector2F position) : base(position)
        {
            Texture = Texture_Player;
            Init();
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
            if (Engine.Keyboard.GetKeyState(Keys.D) == ButtonState.Push) Parent.AddChildNode(new DeathEffect(new Vector2F(480, 360)));
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

            if (Engine.Keyboard.GetKeyState(Keys.Up) == ButtonState.Hold) y -= 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Down) == ButtonState.Hold) y += 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Right) == ButtonState.Hold) x += 2.5f;
            if (Engine.Keyboard.GetKeyState(Keys.Left) == ButtonState.Hold) x -= 2.5f;

            //x = MathHelper.Clamp(x, maxX - halfSize.X, halfSize.X);
            x = MathHelper.Clamp(x, maxX, 0);
            //y = MathHelper.Clamp(y, maxY - halfSize.Y, halfSize.Y);
            y = MathHelper.Clamp(y, maxY, 0);

            Position = new Vector2F(x, y);
        }

        /// <summary>
        /// ショット
        /// </summary>
        private void Shot()
        {
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push) Parent.AddChildNode(new PlayerBullet(Position + CenterPosition));
        }
    }
}
