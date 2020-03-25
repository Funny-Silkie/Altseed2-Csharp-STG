using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 弾のクラス
    /// </summary>
    public abstract class Bullet : CollidableObject
    {
        public sealed override bool DoSurvey => false;

        /// <summary>
        /// 移動距離
        /// </summary>
        private readonly Vector2F velocity;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        /// <param name="velocity">速度</param>
        public Bullet(MainNode stage, Vector2F position, Vector2F velocity) : base(stage, position)
        {
            this.velocity = velocity;
            ZOrder--;
        }

        protected override void OnUpdate()
        {
            Position += velocity;
            base.OnUpdate();
            RemoveMyselfIfOutOfWindow();
        }
    }
}
