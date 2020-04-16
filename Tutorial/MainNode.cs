using Altseed;
using System.Collections.Generic;

namespace Tutorial
{
    /// <summary>
    /// ステージの表示など
    /// </summary>
    public class MainNode : Node
    {
        private int? bgmID = null;
        private int count = 0;
        private const int waves = 3;
        private int wave = 1;
        private readonly Queue<Enemy>[] enemies = new Queue<Enemy>[waves];
        private readonly Node characterNode = new Node();
        private Player player;
        private readonly Node uiNode = new Node();
        private TextNode scoreNode;
        private TextNode waveNode;
        private bool fading = false;

        /// <summary>
        /// スコアを取得または設定する
        /// </summary>
        public int score;

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

            //InitBGM();
        }

        protected override void OnRemoved()
        {
            CollidableObject.objects.Clear();
        }

        /// <summary>
        /// BGM初期化
        /// </summary>
        private void InitBGM()
        {
            Resources.Sound_BGM.IsLoopingMode = true;
            bgmID = Engine.Sound.Play(Resources.Sound_BGM);
        }

        /// <summary>
        /// ウェーブの初期化
        /// </summary>
        private void InitAllWave()
        {
            for (int i = 0; i < enemies.Length; i++) enemies[i] = new Queue<Enemy>();

            InitWave1();
            InitWave2();
            InitWave3();
        }

        /// <summary>
        /// ウェーブ1の初期化
        /// </summary>
        private void InitWave1()
        {
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 620)));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 620)));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(300, 620)));
        }

        /// <summary>
        /// ウェーブ2の初期化
        /// </summary>
        private void InitWave2()
        {
            enemies[1].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.5f));
            enemies[1].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.5f));

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(100, 100)));
            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(100, 620)));

            var random = new System.Random();

            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(400, 320)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(400, 400)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
        }

        /// <summary>
        /// ウェーブ3の初期化
        /// </summary>
        private void InitWave3()
        {
            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 100)));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(100, 100), 3.0f));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(100, 620), 3.0f));
            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 360), 3));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 560), 3));

            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(910, 50)));
            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(910, 670)));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(100, 360), 5));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(860, 360), 5));

            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 3.0f));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 3.0f));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 200), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 520), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 200), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 520), 7));
        }

        protected override void OnUpdate()
        {
            scoreNode.Text = $"Score : {score}";
            waveNode.Text = $"Wave : {wave}";

            Summon();

            count++;
        }

        /// <summary>
        /// ゲームオーバー画面に遷移
        /// </summary>
        public void ToGameOver()
        {
            //if (!bgmID.HasValue) Engine.Sound.FadeOut(bgmID.Value, 3.0f);
            if (fading) return;
            Engine.RemoveNode(this);
            Engine.AddNode(new GameOverNode());
            fading = true;
        }

        /// <summary>
        /// 敵召還関連
        /// </summary>
        private void Summon()
        {
            if (count % 100 == 0)
            {
                if (enemies[wave - 1].Count > 0) characterNode.AddChildNode(enemies[wave - 1].Dequeue());
                else
                {
                    count = 0;
                    wave++;
                    if (wave > waves && !fading)
                    {
                        //if (bgmID.HasValue) Engine.Sound.FadeOut(bgmID.Value, 3.0f);
                        Engine.RemoveNode(this);
                        Engine.AddNode(new LevelCompletedNode());
                        fading = true;
                    }
                }
            }
        }
    }
}
