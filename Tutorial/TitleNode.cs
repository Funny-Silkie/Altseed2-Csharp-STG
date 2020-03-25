using Altseed;

namespace Tutorial
{
    /// <summary>
    /// タイトル
    /// </summary>
    public class TitleNode : Node
    {
        protected override void OnAdded()
        {
            var titleText = new TextNode()
            {
                Font = Resources.Font100,
                Text = "Tutorial STG"
            };
            var size1 = titleText.Font.CalcTextureSize(titleText.Text, WritingDirection.Horizontal, true);
            titleText.Position = new Vector2F(480, 100) - size1 / 2;

            var announce = new TextNode()
            {
                Font = Resources.Font100,
                Text = "Press Z to start",
                Scale = new Vector2F(0.5f, 0.5f)
            };
            var size2 = announce.Font.CalcTextureSize(announce.Text, WritingDirection.Horizontal, true) * announce.Scale;
            announce.Position = new Vector2F(480, 600) - size2 / 2;

            AddChildNode(titleText);
            AddChildNode(announce);
        }

        protected override void OnUpdate()
        {
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                Engine.RemoveNode(this);
                Engine.AddNode(new MainNode());
            }
        }
    }
}
