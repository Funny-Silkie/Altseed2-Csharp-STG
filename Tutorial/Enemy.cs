using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 敵の抽象クラス
    /// </summary>
    public abstract class Enemy : CollidableObject
    {
        public sealed override bool DoSurvey => true;
        public abstract int Score { get; }
        
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        protected Enemy(Vector2F position) : base(position)
        {

        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is PlayerBullet)
            {
                ((MainNode)Parent.Parent).Score += Score;
                Parent.AddChildNode(new DeathEffect(Position));
                Parent.RemoveChildNode(this);
            }
        }
    }
}
