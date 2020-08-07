using Altseed2;

namespace Tutorial
{
    // 自機弾
    public class PlayerBullet : Bullet
    {
        // コンストラクタ
        public PlayerBullet(MainNode mainNode, Vector2F position) : base(mainNode, position, new Vector2F(10f, 0.0f))
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

            // 半径を設定
            collider.Radius = Texture.Size.X / 2;
        }

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象が敵だったら自身を削除
            if (obj is Enemy)
            {
                Parent?.RemoveChildNode(this);
            }
        }
    }
}
