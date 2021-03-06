﻿using Altseed2;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        // BGMのID
        private int? bgmID = null;

        // カウンタ
        private int count = 0;

        // ウェーブの個数
        private const int waves = 3;

        // 現在ウェーブ
        private int wave = 1;

        // 敵を格納するキュー
        private Queue<Enemy>[] enemies = new Queue<Enemy>[waves];

        // キャラクターを表示するノード
        private Node characterNode = new Node();
        
        // プレイヤーの参照
        private Player player;

        // スコアを表示するノード
        private TextNode scoreNode;

        // 現在ウェーブを表示するノード
        private TextNode waveNode;

        // 他画面へ遷移しているかどうか
        private bool fading = false;

        // スコア
        public int score;

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // キャラクターノードを追加
            AddChildNode(characterNode);

            // UIを表示するノード
            var uiNode = new Node();

            // UIノードを追加
            AddChildNode(uiNode);

            // 背景に使用するテクスチャ
            var backTexture = new SpriteNode();
            // 背景のテクスチャを読み込む
            backTexture.Texture = Texture2D.LoadStrict("Resources/Background.png");
            // 表示位置を奥に設定
            backTexture.ZOrder = -100;

            // 背景テクスチャを追加
            AddChildNode(backTexture);

            // プレイヤーを設定
            player = new Player(this, new Vector2F(100, 360));

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);

            // スコアを表示するノードを設定
            scoreNode = new TextNode();
            // スコア表示に使うフォントを読み込む
            scoreNode.Font = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 30);
            // スコア表示の位置を設定
            scoreNode.Position = new Vector2F();

            // UIノードにスコア表示ノードを追加
            uiNode.AddChildNode(scoreNode);

            // 現在ウェーブを表示するノードを設定
            waveNode = new TextNode();
            // ウェーブ表示に使うフォントを読み込む
            waveNode.Font = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 30);
            // ウェーブ表示の座標を設定
            waveNode.Position = new Vector2F(200, 0);

            // ウェーブ表示ノードを追加
            uiNode.AddChildNode(waveNode);

            // 全てのウェーブを初期化する
            InitAllWave();

            // BGMを初期化する
            InitBGM();
        }

        // エンジンから削除されたときに実行
        protected override void OnRemoved()
        {
            // 衝突判定を全てリセット
            CollidableObject.objects.Clear();
        }

        // BGMを初期化
        private void InitBGM()
        {
            // BGMを読み込む
            var bgm = Sound.LoadStrict("Resources/BGM.wav", false);

            // BGMをループするように設定
            bgm.IsLoopingMode = true;

            // ループ開始位置を設定
            bgm.LoopStartingPoint = 11.33f;

            // ループ終了位置を設定
            bgm.LoopEndPoint = 33.93f;

            // BGMのプレイ開始
            bgmID = Engine.Sound.Play(bgm);
        }

        // 全ウェーブの初期化
        private void InitAllWave()
        {
            // 各キューの初期化
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Queue<Enemy>();
            }

            // ウェーブ1を初期化
            InitWave1();
            // ウェーブ2を初期化
            InitWave2();
            // ウェーブ3を初期化
            InitWave3();
        }

        // ウェーブ1の初期化
        private void InitWave1()
        {
            // enemies[0].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 360), 2.0f));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));
            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 560), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));

            enemies[0].Enqueue(new ChaseEnemy(player, new Vector2F(700, 160), 2.0f));

            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 100)));
            enemies[0].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));
        }

        // ウェーブ2の初期化
        private void InitWave2()
        {
            // enemies[1].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


            enemies[1].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.5f));
            enemies[1].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.5f));

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(500, 100)));
            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(500, 620)));

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

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(700, 320)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));

            enemies[1].Enqueue(new StraightShotEnemy(player, new Vector2F(700, 400)));
            enemies[1].Enqueue(new Meteor(player, new Vector2F(910, random.Next(50, Engine.WindowSize.Y - 50)), new Vector2F(-4.0f, 0.0f)));
        }

        // ウェーブ3の初期化
        private void InitWave3()
        {
            // enemies[2].Enqueue～でウェーブ1に敵を追加
            // 追加した順番に敵が出現する


            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 100)));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(100, 100), 2.0f));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(100, 620), 2.0f));
            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(600, 620)));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 160), 3));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 360), 3));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(400, 560), 3));

            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(910, 50)));
            enemies[2].Enqueue(new StraightShotEnemy(player, new Vector2F(910, 670)));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(100, 360), 5));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(860, 360), 5));

            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.0f));
            enemies[2].Enqueue(new ChaseEnemy(player, new Vector2F(500, 360), 2.0f));

            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 200), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 520), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 200), 7));
            enemies[2].Enqueue(new RadialShotEnemy(player, new Vector2F(600, 520), 7));
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // スコア表示の更新
            scoreNode.Text = "Score : " + score;

            // 現在ウェーブ表示の更新
            waveNode.Text = "Wave : " + wave;

            // ステージの更新
            UpdateStage();

            // カウントを進める
            count++;
        }

        // ゲームオーバー画面に遷移
        public void ToGameOver()
        {
            // BGMをフェードアウト
            if (bgmID.HasValue)
            {
                Engine.Sound.FadeOut(bgmID.Value, 1.0f);

                // BGMが止まったのでIDをnullに
                bgmID = null;
            }

            // 画面遷移中でないなら遷移処理を実行
            if (!fading)
            {
                // 自身をエンジンから削除
                Engine.RemoveNode(this);

                // エンジンにゲームオーバー画面を追加
                Engine.AddNode(new GameOverNode());

                // 遷移中フラグを縦立てる
                fading = true;
            }
        }

        // 敵召還関連
        private void UpdateStage()
        {
            // カウントが100の倍数だったら
            if (count % 100 == 0)
            {
                // 敵が残っていたら画面に追加
                if (enemies[wave - 1].Count > 0)
                {
                    characterNode.AddChildNode(enemies[wave - 1].Dequeue());
                }
                else
                {
                    // カウントをリセット
                    count = 0;

                    //ウェーブを次に進める
                    wave++;

                    // もし最終ウェーブが終わっていて，かつ画面遷移中でなければ実行
                    if (wave > waves && !fading)
                    {
                        // BGMをフェードアウト
                        if (bgmID.HasValue)
                        {
                            Engine.Sound.FadeOut(bgmID.Value, 1.0f);

                            // BGMが止まったのでIDをnullに
                            bgmID = null;
                        }

                        // エンジンから自身を削除
                        Engine.RemoveNode(this);

                        // クリア画面をエンジンに追加
                        Engine.AddNode(new LevelCompletedNode());

                        // 画面遷移中フラグを立てる
                        fading = true;
                    }
                }
            }
        }
    }
}
