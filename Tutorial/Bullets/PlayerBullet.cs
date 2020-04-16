using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    // 自機弾
    public class PlayerBullet : Bullet
    {
        // フレーム毎の移動距離
        private static Vector2F velocity = new Vector2F(10f, 0.0f);

        // コンストラクタ
        public PlayerBullet(MainNode mainNode, Vector2F position) : base(mainNode, position, velocity)
        {
            // テクスチャを設定
            Texture = Texture_Bullet_Blue;

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

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
