using Altseed;

namespace Tutorial
{
    // クリア画面
    public class LevelCompletedNode : Node
    {
        // 画面遷移中かどうか
        private bool fading = false;

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // タイトル
            var titleText = new TextNode();
            // タイトルのフォントを設定
            titleText.Font = Resources.Font100;
            // タイトルの文字を設定
            titleText.Text = "Clear!";
            // タイトルの座標を設定
            titleText.Position = new Vector2F(349, 51);

            // タイトルを追加
            AddChildNode(titleText);

            // 画面下の案内
            var announce = new TextNode();
            // 案内のフォントを設定
            announce.Font = Resources.Font100;
            // 案内のテキストを設定
            announce.Text = "Press Z to go title";
            // 案内の拡大率を設定
            announce.Scale = new Vector2F(0.5f, 0.5f);
            // 案内の座標を設定
            announce.Position = new Vector2F(296, 575);

            //案内を追加
            AddChildNode(announce);
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 画面遷移中でなく，かつZキーが押された時に実行
            if (!fading && Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                // エンジンから自身を削除
                Engine.RemoveNode(this);

                // エンジンにタイトル画面を追加
                Engine.AddNode(new TitleNode());

                // 画面遷移中のフラグを立てる
                fading = true;
            }
        }
    }
}
