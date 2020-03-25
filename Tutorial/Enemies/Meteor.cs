using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// 隕石
    /// </summary>
    public class Meteor : Enemy
    {
        private Vector2F velocity;

        private int HP = 3;
        public override int Score => 1;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="player">プレイヤーへの参照</param>
        /// <param name="position">座標</param>
        /// <param name="velocity">速度</param>
        public Meteor(Player player, Vector2F position, Vector2F velocity) : base(player, position)
        {
            this.velocity = velocity;
            Texture = Texture_Meteor;
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnUpdate()
        {
            Position += velocity;
            base.OnUpdate();
            RemoveMyselfIfOutOfWindow();
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is PlayerBullet)
            {
                HP--;
                if (HP <= 0) base.OnCollision(obj);
            }
        }
    }
}
