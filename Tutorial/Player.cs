using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// プレイヤーのクラス
    /// </summary>
    public class Player : CollidableObject
    {
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public Player(MainNode stage, Vector2F position) : base(stage, position)
        {
            doSurvey = true;
            Texture = Texture_Player;
            CenterPosition = Texture.Size / 2;
            collider.Radius = Texture.Size.Y / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is Enemy || obj is EnemyBullet)
            {
                //Engine.Sound.Play(Sound_Explosion)
                Parent.RemoveChildNode(this);
                stage.ToGameOver();
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

            x = MathHelper.Clamp(x, Engine.WindowSize.X - halfSize.X, halfSize.X);
            y = MathHelper.Clamp(y, Engine.WindowSize.Y - halfSize.Y, halfSize.Y);

            Position = new Vector2F(x, y);
        }

        /// <summary>
        /// ショット
        /// </summary>
        private void Shot()
        {
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push) Parent.AddChildNode(new PlayerBullet(stage, Position + CenterPosition));
            //Engine.Sound.Play(Sound_PlayerShot);
        }
    }
}
