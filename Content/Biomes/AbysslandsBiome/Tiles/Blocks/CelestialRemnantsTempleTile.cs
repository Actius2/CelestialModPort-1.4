using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks
{
    public class CelestialRemnantsTempleTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMerge[ModContent.TileType<CelestialRemnantsTempleTile>()][ModContent.TileType<VoidicGrass>()] = true;
			Main.tileMerge[ModContent.TileType<CelestialRemnantsTempleTile>()][ModContent.TileType<VoidicStone>()] = true;
			Main.tileMerge[ModContent.TileType<CelestialRemnantsTempleTile>()][ModContent.TileType<VoidicMud>()] = true;


			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(0, 191, 255));
			ItemDrop = ItemType<Content.Biomes.AbysslandsBiome.Items.Placeable.CelestialRemnantsTempleTileBlock>();
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

			Texture2D Glowmask2 = ModContent.Request<Texture2D>("CelestialMod/Content/Glowmasks/TempleTile_Glow").Value;
			int height = tile.TileFrameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(Glowmask2, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
	}
}



