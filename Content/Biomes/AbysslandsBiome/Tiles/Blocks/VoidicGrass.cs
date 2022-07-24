using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Plants.VoidGrass;
namespace CelestialMod.Content.Biomes.AbysslandsBiome.Tiles.Blocks
{
    public class VoidicGrass : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMerge[ModContent.TileType<VoidicGrass>()][ModContent.TileType<CelestialRemnantsTempleTile>()] = true;
			Main.tileMerge[ModContent.TileType<VoidicGrass>()][ModContent.TileType<VoidicStone>()] = true;
			Main.tileMerge[ModContent.TileType<VoidicGrass>()][ModContent.TileType<VoidicMud>()] = true;


			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(0, 191, 255));
			ItemDrop = ItemType<Content.Biomes.AbysslandsBiome.Items.Placeable.VoidicGrassBlock>();
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

		public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
		{
			TileObject toBePlaced;
			if (!TileObject.CanPlace(x, y, type, style, direction, out toBePlaced, false))
			{
				return false;
			}
			toBePlaced.random = random;
			if (TileObject.Place(toBePlaced) && !mute)
			{
				WorldGen.SquareTileFrame(x, y, true);
				//   Main.PlaySound(0, x * 16, y * 16, 1, 1f, 0f);
			}
			return false;
		}
		public override void RandomUpdate(int i, int j)
		{
			if (Main.tile[i, j].HasTile && Main.rand.NextBool(10))
			{
				switch (Main.rand.Next(7))
				{

					case 1:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA1>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA1>(), 0, 0, -1, -1);
						break;

					case 2:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA2>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA2>(), 0, 0, -1, -1);
						break;
					case 3:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA3>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA3>(), 0, 0, -1, -1);
						break;
					case 4:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA4>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA4>(), 0, 0, -1, -1);
						break;
					case 5:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA5>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA5>(), 0, 0, -1, -1);
						break;
					case 6:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA6>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA6>(), 0, 0, -1, -1);
						break;
					default:
						VoidicGrass.PlaceObject(i, j - 1, ModContent.TileType<VoidGrassA7>());
						NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<VoidGrassA7>(), 0, 0, -1, -1);
						break;

				}

			}


		}
	}
}



