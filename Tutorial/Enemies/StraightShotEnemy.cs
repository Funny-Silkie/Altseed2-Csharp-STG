using Altseed;
using System;
using static Tutorial.Resources;

namespace Tutorial
{
    // まっすぐな弾を発射する敵
    public class StraightShotEnemy : Enemy
    {
        // カウンタ
        private int count = 0;

        // コンストラクタ
        public StraightShotEnemy(Player player, Vector2F position) : base(player, position)
        {
            // テクスチャを設定
            Texture = Texture_UFO;

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // 半径を設定
            collider.Radius = Texture.Size.X / 2;

            // 倒された時に加算されるスコアを設定
            score = 20;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // カウントが150の倍数で実行
            if (count % 150 == 0)
            {
                // プレイヤーに対するベクトルを取得
                var velocity = player.Position - Position;
                // ベクトルの長さを調整(弾速になる)
                velocity.Length = 5;

                // 弾を追加
                Shot(velocity);
            }

            // 座標を設定
            Position -= new Vector2F(MathF.Sin(MathHelper.DegreeToRadian(count)) * 3.0f, 0);

            // EnemyのOnUpdateを実行
            base.OnUpdate();

            // カウントを進める
            count++;
        }
    }
}
