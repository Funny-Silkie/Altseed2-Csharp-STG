using Altseed;

namespace Tutorial
{
    /// <summary>
    /// ステージの表示など
    /// </summary>
    public class MainNode : Node
    {
        private readonly Node characterNode = new Node();
        private readonly Player player = new Player(default);
        private readonly Node uiNode = new Node();

        /// <summary>
        /// ステージの初期化
        /// </summary>
        private void InitAllStage()
        {

        }

        protected override void OnAdded()
        {
            AddChildNode(characterNode);
            AddChildNode(uiNode);

            characterNode.AddChildNode(player);

            InitAllStage();
        }
    }
}
