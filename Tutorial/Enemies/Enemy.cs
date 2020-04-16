using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 敵の抽象クラス
    /// </summary>
    public abstract class Enemy : CollidableObject
    {
        protected int score;

        /// <summary>
        /// プレイヤーへの参照を取得する
        /// </summary>
        protected Player player;
        
        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        protected Enemy(Player player, Vector2F position) : base(player.stage, position)
        {
            doSurvey = true;
            this.player = player;
        }

        protected override void OnCollision(CollidableObject obj)
        {
            if (obj is PlayerBullet)
            {
                stage.score += score;
                Parent.AddChildNode(new DeathEffect(Position));
                Parent.RemoveChildNode(this);
                //Engine.Sound.Play(Sound_Explosion);
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
        protected void Shot(Vector2F velocity)
        {
            Parent.AddChildNode(new EnemyBullet(stage, Position, velocity));
            //Engine.Sound.Play(Sound_EnemyShot);
        }
    }
}
