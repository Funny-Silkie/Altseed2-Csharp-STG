using Altseed;

namespace Tutorial
{
    /// <summary>
    /// タイトル
    /// </summary>
    public class TitleNode : Node
    {
        private bool fading = false;

        protected override void OnRegistered()
        {
            var titleText = new TextNode()
            {
                Font = Resources.Font100,
                Text = "Tutorial STG"
            };
            var size1 = titleText.Font.CalcTextureSize(titleText.Text, WritingDirection.Horizontal, true);
            titleText.Position = new Vector2F(Engine.WindowSize.X / 2, 100) - size1 / 2;

            var announce = new TextNode()
            {
                Font = Resources.Font100,
                Text = "Press Z to start",
                Scale = new Vector2F(0.5f, 0.5f)
            };
            var size2 = announce.Font.CalcTextureSize(announce.Text, WritingDirection.Horizontal, true) * announce.Scale;
            announce.Position = new Vector2F(Engine.WindowSize.X / 2, 600) - size2 / 2;

            var backTexture = new SpriteNode()
            {
                Texture = Resources.Texture_image,
                ZOrder = -1
            };

            AddChildNode(titleText);
            AddChildNode(announce);
            AddChildNode(backTexture);
        }

        protected override void OnUpdate()
        {
            if (!fading && Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                Engine.RemoveNode(this);
                Engine.AddNode(new MainNode());
                fading = true;
            }
        }
    }
}
