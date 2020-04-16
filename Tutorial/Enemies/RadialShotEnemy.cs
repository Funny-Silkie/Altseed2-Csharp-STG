using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// 放射ショットの敵
    /// </summary>
    public class RadialShotEnemy : Enemy
    {
        private int count = 0;
        private int shotAmount;
        private Vector2F velocity;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="player">プレイヤーへの参照</param>
        /// <param name="position">座標</param>
        /// <param name="shotAmount">ショットの個数</param>
        public RadialShotEnemy(Player player, Vector2F position, int shotAmount) : base(player, position)
        {
            this.shotAmount = shotAmount;
            Texture = Texture_UFO;
            CenterPosition = Texture.Size / 2;
            collider.Radius = Texture.Size.X / 2;
            score = 30;
        }

        protected override void OnUpdate()
        {
            if (count % 250 == 0)
            {
                var half = shotAmount / 2;
                for (int i = 0; i < shotAmount; i++)
                {
                    var vector = (player.Position - Position).Normal * 7.0f;
                    vector.Degree += 30 * (i - half);
                    Shot(vector);
                }
            }

            if (count % 100 < 50)
            {
                if (count % 100 == 0) velocity = (player.Position - Position).Normal * 3.0f;
                
                Position += velocity;
            }

            base.OnUpdate();

            count++;
        }
    }
}
