using Altseed;

namespace Tutorial
{
    public abstract class Bullet : CollidableObject
    {
        public sealed override bool DoSurvey => false;

        public sealed override float Radius { get; }

        /// <summary>
        /// 速度を取得魔取得または設定する
        /// </summary>
        public Vector2F Velocity { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        /// <param name="velocity">速度</param>
        public Bullet(Vector2F position, Vector2F velocity) : base(position)
        {
            Texture = Texture2D.LoadStrict("Resources/Bullet.png");
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
            Velocity = velocity;
            ZOrder--;
        }

        protected override void OnUpdate()
        {
            Position += Velocity;
            base.OnUpdate();
            RemoveMyselfIfOutOfWindow();
        }
    }
}
