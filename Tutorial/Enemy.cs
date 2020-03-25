using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 敵の抽象クラス
    /// </summary>
    public abstract class Enemy : CollidableObject
    {
        public override bool DoSurvey => true;
        
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
                Parent.AddChildNode(new DeathEffect(Position));
                Parent.RemoveChildNode(this);
            }
        }
    }
}
