using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.ID;
using CelestialMod;
using CelestialMod.Content.WorldGeneration.MainMenu;

namespace CelestialMod.Content.ModMenuAssets
{
	public class CelestialModMenu : ModMenu
	{
		//private const string menuAssetPath = "CelestialMod/Assets/Textures/Menu"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

		

		
		public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("CelestialMod/Content/ModMenuAssets/Logo");

		//public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampleSun");

		//public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampliumMoon");

		public override int Music => MusicLoader.GetMusicSlot("CelestialMod/Content/ModMenuAssets/MenuMusic");

		public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<EmptyBgStyle>();
		public override string DisplayName => "Celestial Style";

		public override void OnSelected()
		{
			//SoundStyle CelestialTheme = new SoundStyle("CelestialMod/Content/ModMenuAssets/MenuMusic");
			//SoundEngine.PlaySound(CelestialTheme);
		}

		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
		{
			Texture2D Background1 = ModContent.Request<Texture2D>("CelestialMod/Content/WorldGeneration/Backgrounds/MenuBackground").Value;
			spriteBatch.Draw(Background1, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.White);
			drawColor = Color.White;



			return true;

		}



	}
}
