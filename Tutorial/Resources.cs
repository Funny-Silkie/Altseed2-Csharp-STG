using Altseed;

namespace Tutorial
{
    /// <summary>
    /// リソースを置いておくクラス
    /// </summary>
    public static class Resources
    {
        #region Fonts
        public static Font Font30 { get; } = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 30);
        public static Font Font100 { get; } = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 100);
        #endregion
        #region Sounds
        public static Sound Sound_BGM { get; }
        public static Sound Sound_EnemyShot { get; }
        public static Sound Sound_Explosion { get; }
        public static Sound Sound_PlayerShot { get; }
        #endregion
        #region Textures
        public static Texture2D Texture_Background { get; } = Texture2D.LoadStrict("Resources/Background.png");
        public static Texture2D Texture_Bullet_Blue { get; } = Texture2D.LoadStrict("Resources/Bullet_Blue.png");
        public static Texture2D Texture_Bullet_Red { get; } = Texture2D.LoadStrict("Resources/Bullet_Red.png");
        public static Texture2D Texture_Explosion { get; } = Texture2D.LoadStrict("Resources/Explosion.png");
        public static Texture2D Texture_Meteor { get; } = Texture2D.LoadStrict("Resources/Meteor.png");
        public static Texture2D Texture_image { get; } = Texture2D.LoadStrict("Resources/image.png");
        public static Texture2D Texture_Player { get; } = Texture2D.LoadStrict("Resources/Player.png");
        public static Texture2D Texture_UFO { get; } = Texture2D.LoadStrict("Resources/UFO.png");
        #endregion
    }
}
