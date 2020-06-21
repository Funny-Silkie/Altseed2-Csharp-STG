using Altseed2;

namespace Tutorial
{
    // 敵の弾のクラス
    public class EnemyBullet : Bullet
    {
        // コンストラクタ
        public EnemyBullet(MainNode mainNode, Vector2F position, Vector2F velocity) : base(mainNode, position, velocity)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Red.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // 半径を設定
            collider.Radius = Texture.Size.X / 2;
        }

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象がプレイヤーだったらBulletのOnCollisionを実行して削除
            if (obj is Player)
            {
                Parent?.RemoveChildNode(this);
            }
        }
    }
}
