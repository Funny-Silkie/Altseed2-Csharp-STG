using Altseed;

namespace Tutorial
{
    // 自機弾
    public class PlayerBullet : Bullet
    {
        // フレーム毎の移動距離
        private static Vector2F velocity = new Vector2F(10f, 0.0f);

        // コンストラクタ
        public PlayerBullet(Vector2F position) : base(position, velocity)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;
        }
    }
}
