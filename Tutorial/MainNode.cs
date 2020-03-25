using Altseed;
using System.Collections.Generic;

namespace Tutorial
{
    /// <summary>
    /// ステージの表示など
    /// </summary>
    public class MainNode : Node
    {
        private int count = 0;
        const int waves = 1;
        private int wave = 1;
        private readonly Queue<Enemy>[] enemies = new Queue<Enemy>[waves];
        private readonly Node characterNode = new Node();
        private Player player;
        private readonly Node uiNode = new Node();
        private TextNode scoreNode;
        private TextNode waveNode;

        /// <summary>
        /// スコアを取得または設定する
        /// </summary>
        public int Score { get; set; }

        protected override void OnAdded()
        {
            AddChildNode(characterNode);
            AddChildNode(uiNode);
            var backTexture = new SpriteNode()
            {
                Texture = Resources.Texture_Background,
                ZOrder = -100
            };
            AddChildNode(backTexture);

            player = new Player(this, new Vector2F(100, 360));
            characterNode.AddChildNode(player);

            scoreNode = new TextNode()
            {
                Font = Resources.Font30,
                Text = "Score : 0"
            };
            uiNode.AddChildNode(scoreNode);

            waveNode = new TextNode()
            {
                Font = Resources.Font30,
                Text = "Wave : 1",
                Position = new Vector2F(200, 0)
            };
            uiNode.AddChildNode(waveNode);

            InitAllWave();

            //AddChildNode(new StayEnemy(new Vector2F(500, 500)));
            AddChildNode(new StraightShotEnemy(player, new Vector2F(600, 360)));
        }

        /// <summary>
        /// ウェーブの初期化
        /// </summary>
        private void InitAllWave()
        {
            for (int i = 0; i < enemies.Length; i++) enemies[i] = new Queue<Enemy>();

            InitWave1();
        }

        /// <summary>
        /// ウェーブ1の初期化
        /// </summary>
        private void InitWave1()
        {
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 300)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 420)));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(600, 300), 3.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(600, 420), 3.0f));
        }

        protected override void OnUpdate()
        {
            scoreNode.Text = $"Score : {Score}";
            waveNode.Text = $"Wave : {wave}";

            //Summon();

            count++;
        }

        /// <summary>
        /// 敵召還関連
        /// </summary>
        private void Summon()
        {
            if (count % 300 == 0)
            {
                if (enemies[wave - 1].Count > 0) characterNode.AddChildNode(enemies[wave - 1].Dequeue());
                else
                {
                    count = 0;
                    wave++;
                }
            }
        }
    }
}
