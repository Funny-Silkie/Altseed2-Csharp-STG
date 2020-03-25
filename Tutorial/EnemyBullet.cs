using Altseed;

namespace Tutorial
{
    public sealed class EnemyBullet : Bullet
    {
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        /// <param name="velocity">速度</param>
        public EnemyBullet(Vector2F position, Vector2F velocity) : base(position, velocity)
        {
            
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is Player) Parent?.RemoveChildNode(this);
        }
    }
}
