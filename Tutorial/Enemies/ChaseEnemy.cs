using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    // 追跡型敵
    public class ChaseEnemy : Enemy
    {
        // 移動速度
        private float speed;

        // コンストラクタ
        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            // テクスチャを設定
            Texture = Texture_UFO;

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // 半径を設定
            collider.Radius = Texture.Size.X / 2;

            // 移動速度を設定
            this.speed = speed;

            // 自身が倒された時に加算されるスコアを設定
            score = 10;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // プレイヤーへのベクトルを取得
            var vector = player.Position - Position;

            // ベクトルの長さを調整
            vector.Length = speed;

            // ベクトル分座標を動かす
            Position += vector;

            // EnemyのOnUpdateを実行
            base.OnUpdate();
        }
    }
}
