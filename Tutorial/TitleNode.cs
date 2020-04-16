using Altseed;

namespace Tutorial
{
    // タイトル画面
    public class TitleNode : Node
    {
        // 画面が遷移中かどうか
        private bool fading = false;

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // タイトル
            var titleText = new TextNode();
            // タイトルのフォントを設定
            titleText.Font = Resources.Font100;
            // タイトルの文字を設定
            titleText.Text = "Tutorial STG";
            // タイトルの座標を設定
            titleText.Position = new Vector2F(207, 51);

            // タイトルを追加
            AddChildNode(titleText);

            // 画面下に表示される案内
            var announce = new TextNode();
            // 案内のフォントを設定
            announce.Font = Resources.Font100;
            // 案内の文字を設定
            announce.Text = "Press Z to start";
            // 案内の拡大率を設定
            announce.Scale = new Vector2F(0.5f, 0.5f);
            // 案内の座標を設定
            announce.Position = new Vector2F(320, 575);
            
            // 案内を追加
            AddChildNode(announce);

            // 背景のテクスチャ
            var backTexture = new SpriteNode();
            // 背景のテクスチャを設定
            backTexture.Texture = Resources.Texture_image;
            // 背景の表示位置を奥に設定
            backTexture.ZOrder = -1;

            // 背景を追加
            AddChildNode(backTexture);
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 画面が遷移中でなく，Zキーが押された時に実行
            if (!fading && Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
                // エンジンから自身を削除
                Engine.RemoveNode(this);

                // エンジンにメイン画面を追加
                Engine.AddNode(new MainNode());

                // 画面遷移中のフラグを立てる
                fading = true;
            }
        }
    }
}
