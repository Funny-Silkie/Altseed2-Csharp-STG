using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// まっすぐな弾を発射する敵
    /// </summary>
    public class StraightShotEnemy : Enemy
    {
        private int count = 0;

        public override int Score => 20;

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
            if (count > 250)
            {
                Shot((Player.Position - Position).Normal * 5);
                count = 0;
            }

            base.OnUpdate();
            count++;
        }
    }
}
