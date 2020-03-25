using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// デバッグ用
    /// </summary>
    public sealed class StayEnemy : Enemy
    {
        public override int Score => 0;
        public StayEnemy(Player player, Vector2F position) : base(player, position)
        {
            Texture = Texture_UFO;
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            
        }
    }
}
