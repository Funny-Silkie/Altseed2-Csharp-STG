using Altseed;

namespace Tutorial
{
    // 弾のクラス
    public class Bullet : CollidableObject
    {
        // フレーム毎に進む距離
        private Vector2F velocity;

        // コンストラクタ
        public Bullet(MainNode mainNpde, Vector2F position, Vector2F velocity) : base(mainNpde, position)
        {
            // 衝突判定を行わないように設定
            doSurvey = false;

            // 弾速を設定
            this.velocity = velocity;

            // 表示位置をプレイヤーや敵より奥に設定
            ZOrder--;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 座標を速度分進める
            Position += velocity;

            // CollidableObjectのOnUpdateを呼び出す
            base.OnUpdate();

            // 画面外に出たら自身を削除
            RemoveMyselfIfOutOfWindow();
        }
    }
}
