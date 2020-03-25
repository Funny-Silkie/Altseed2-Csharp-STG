using Altseed;

namespace Tutorial
{
    /// <summary>
    /// 死亡時エフェクト
    /// </summary>
    public sealed class DeathEffect : SpriteNode
    {
        private int count = 0;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public DeathEffect(Vector2F position)
        {
            Position = position;
            Texture = Texture2D.LoadStrict("Resources/DeathEffect.png");
            Scale = new Vector2F(0.25f, 0.25f);
            CenterPosition = new Vector2F(16f, 16f);
            ZOrder++;
            Src = new RectF(default, Texture.Size / 4);
        }

        protected override void OnUpdate()
        {
            var size = Texture.Size / 4;
            var pos = new Vector2F(size.X * (count % 4), size.Y * (count / 4));
            Src = new RectF(pos, size);

            count++;

            if (count >= 16) Parent?.RemoveChildNode(this);
        }
    }
}
