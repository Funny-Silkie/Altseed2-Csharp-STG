using Altseed;
using static Tutorial.Resources;

namespace Tutorial
{
    /// <summary>
    /// 死亡時エフェクト
    /// </summary>
    public class DeathEffect : SpriteNode
    {
        private int count = 0;

        /// <summary>
        /// 新しいインスタンスを生成する
        /// </summary>
        /// <param name="position">座標</param>
        public DeathEffect(Vector2F position)
        {
            Position = position;
            Texture = Texture_Explosion;
            CenterPosition = new Vector2F(32f, 32f);
            ZOrder++;
            Src = new RectF(default, new Vector2F(Texture.Size.X / 9, Texture.Size.Y));
        }

        protected override void OnUpdate()
        {
            var size = new Vector2F(Texture.Size.X / 9, Texture.Size.Y);
            var pos = new Vector2F(size.X * (count / 2 % 9), size.Y);
            Src = new RectF(pos, size);

            count++;

            if (count >= 18) Parent?.RemoveChildNode(this);
        }
    }
}
