using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 敵の抽象クラス
    /// </summary>
    public abstract class Enemy : CollidableObject
    {
        public sealed override bool DoSurvey => true;
        public abstract int Score { get; }

        /// <summary>
        /// プレイヤーへの参照を取得する
        /// </summary>
        protected Player Player { get; }
        
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        protected Enemy(Player player, Vector2F position) : base(player.Stage, position)
        {
            Player = player;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is PlayerBullet)
            {
                Stage.Score += Score;
                Parent.AddChildNode(new DeathEffect(Position));
                Parent.RemoveChildNode(this);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            RemoveMyselfIfOutOfWindow();
        }

        /// <summary>
        /// 弾を撃つ
        /// </summary>
        /// <param name="velocity">弾速</param>
        protected void Shot(Vector2F velocity) => Parent.AddChildNode(new EnemyBullet(Stage, Position, velocity));
    }
}
