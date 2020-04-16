using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// 追跡型敵
    /// </summary>
    public sealed class ChaseEnemy : Enemy
    {
        private readonly float speed;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            Texture = Texture_UFO;
            CenterPosition = Texture.Size / 2;
            collider.Radius = Texture.Size.X / 2;
            this.speed = speed;
            score = 10;
        }

        protected override void OnUpdate()
        {
            var vector = player.Position - Position;
            Position += vector.Normal * speed;
            base.OnUpdate();
        }
    }
}
