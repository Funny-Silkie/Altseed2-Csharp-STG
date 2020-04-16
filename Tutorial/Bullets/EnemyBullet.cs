using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    public class EnemyBullet : Bullet
    {
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        /// <param name="velocity">速度</param>
        public EnemyBullet(MainNode stage, Vector2F position, Vector2F velocity) : base(stage, position, velocity)
        {
            Texture = Texture_Bullet_Red;
            CenterPosition = Texture.Size / 2;
            collider.Radius = Texture.Size.X / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is Player) Parent?.RemoveChildNode(this);
        }
    }
}
