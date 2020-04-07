using System.Collections.Generic;
using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 衝突可能なオブジェクト(円形)
    /// </summary>
    public abstract class CollidableObject : SpriteNode
    {
        /// <summary>
        /// オブジェクトのコレクションを取得する
        /// </summary>
        public static HashSet<CollidableObject> Objects { get; } = new HashSet<CollidableObject>(10);

        /// <summary>
        /// <see cref="OnUpdate"/>内で衝突判定を調査するかどうかを取得する
        /// </summary>
        public abstract bool DoSurvey { get; }
        /// <summary>
        /// 衝突半径を取得する
        /// </summary>
        public float Radius { get; protected set; }

        /// <summary>
        /// 所属するステージを取得する
        /// </summary>
        public MainNode Stage { get; }

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary
        /// <param name="position">座標</param>
        protected CollidableObject(MainNode stage, Vector2F position)
        {
            Stage = stage;
            Position = position;
        }

        protected override void OnAdded() => Objects.Add(this);

        protected override void OnRemoved() => Objects.Remove(this);

        protected override void OnUpdate()
        {
            if (DoSurvey) Survey();
        }

        /// <summary>
        /// <see cref="OnCollision(CollidableObject)"/>の制御
        /// </summary>
        /// <param name="obj"></param>
        private void CollideWith(CollidableObject obj)
        {
            if (obj == null) return;
            if (!obj.DoSurvey) obj.OnCollision(this);
            OnCollision(obj);
        }

        /// <summary>
        /// 2オブジェクト間の衝突判定
        /// </summary>
        /// <param name="o1">衝突を調べるオブジェクト</param>
        /// <param name="o2">衝突を調べるオブジェクト</param>
        /// <returns><paramref name="o1"/>と<paramref name="o2"/>が衝突していたらtrue，それ以外でfalse</returns>
        private static bool IsCollide(CollidableObject o1, CollidableObject o2) => (o1.Position - o2.Position).Length <= o1.Radius + o2.Radius;

        /// <summary>
        /// 衝突時に実行
        /// </summary>
        /// <param name="obj">衝突したオブジェクト</param>
        protected abstract void OnCollision(CollidableObject obj); 

        /// <summary>
        /// 画面外で消去
        /// </summary>
        protected void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X || Position.Y < -halfSize.Y || Position.X > Engine.WindowSize.X + halfSize.X || Position.Y > Engine.WindowSize.Y + halfSize.Y) Parent?.RemoveChildNode(this);
        }

        /// <summary>
        /// 衝突判定を調査する
        /// </summary>
        private void Survey()
        {
            foreach (var obj in Objects)
                if (IsCollide(this, obj))
                    CollideWith(obj);
        }
    }
}
