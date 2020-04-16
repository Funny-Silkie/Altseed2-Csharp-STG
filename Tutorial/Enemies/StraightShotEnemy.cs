using Altseed;
using System;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// まっすぐな弾を発射する敵
    /// </summary>
    public class StraightShotEnemy : Enemy
    {
        private int count = 0;

        protected override int Score => 20;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="player">プレイヤーへの参照</param>
        /// <param name="position">座標</param>
        public StraightShotEnemy(Player player, Vector2F position) : base(player, position)
        {
            Texture = Texture_UFO;
            CenterPosition = Texture.Size / 2;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnUpdate()
        {
            if (count % 150 == 0) Shot((Player.Position - Position).Normal * 5);
            
            Position -= new Vector2F(MathF.Sin(MathHelper.DegreeToRadian(count)) * 3.0f, 0);

            base.OnUpdate();
            count++;
        }
    }
}
