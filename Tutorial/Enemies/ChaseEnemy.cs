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
        protected override int Score => 10;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            Texture = Texture_UFO;
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
            this.speed = speed;
        }

        protected override void OnUpdate()
        {
            var vector = Player.Position - Position;
            Position += vector.Normal * speed;
            base.OnUpdate();
        }
    }
}
