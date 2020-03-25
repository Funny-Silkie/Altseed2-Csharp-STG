using Altseed;

namespace Tutorial
{
    /// <summary>
    /// リソースを置いておくクラス
    /// </summary>
    public static class Resources
    {
        #region Fonts
        public static Font Font { get; } = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 30);
        #endregion
        #region Textures
        public static Texture2D Texture_Bullet_Blue { get; } = Texture2D.LoadStrict("Resources/Bullet_Blue.png");
        public static Texture2D Texture_Bullet_Red { get; } = Texture2D.LoadStrict("Resources/Bullet_Red.png");
        public static Texture2D Texture_Explosion { get; } = Texture2D.LoadStrict("Resources/Explosion.png");
        public static Texture2D Texture_Meteor { get; } = Texture2D.LoadStrict("Resources/Meteor.png");
        public static Texture2D Texture_Player { get; } = Texture2D.LoadStrict("Resources/Player.png");
        public static Texture2D Texture_UFO { get; } = Texture2D.LoadStrict("Resources/UFO.png");
        #endregion
    }
}
