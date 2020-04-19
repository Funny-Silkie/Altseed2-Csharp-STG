using Altseed;

namespace Tutorial
{
    // 隕石
    public class Meteor : Enemy
    {
        // フレーム毎の移動速度
        private Vector2F velocity;

        // HP
        private int HP = 3;

        // コンストラクタ
        public Meteor(Player player, Vector2F position, Vector2F velocity) : base(player, position)
        {
            // 速度の設定
            this.velocity = velocity;

            // テクスチャの設定
            Texture = Texture2D.LoadStrict("Resources/Meteor.png");

            // 中心座標の設定
            CenterPosition = Texture.Size / 2;

            // 半径の設定
            collider.Radius = Texture.Size.X / 2;

            // スコアの設定
            score = 1;
        }

        // 毎フレーム実行
        protected override void OnUpdate()
        {
            // 座標を速度分加算
            Position += velocity;

            // EnemyクラスのOnUpdate呼び出し
            base.OnUpdate();
        }

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突したのが自機弾だったら
            if (obj is PlayerBullet)
            {
                // HPを1減らす
                HP--;

                // HPが0になったらEnemyクラスのOnCollisionを呼び出して削除
                if (HP == 0)
                {
                    base.OnCollision(obj);
                }
            }
        }
    }
}
