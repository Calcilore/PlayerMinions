using Microsoft.Xna.Framework;
using PlayerMinion.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlayerMinion.Items {
	public class MinionsCurse : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("SummonersCurse"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Use this item to give yourself the minions curse\n" +
				"This allows you to use teleport to your master at any time\n" +
				"Enemies will not target you\n" +
				"And you cannot take damage");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 0;
			item.rare = ItemRarityID.Green;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.Meowmere, 0);
			item.autoReuse = false;
		}

		public override bool UseItem(Player player) {

			MinionPlayer mp = player.GetModPlayer<MinionPlayer>();

			if (mp.IsMinion) { // if 
				player.AddBuff(ModContent.BuffType<CurseBuff>(), 18000);
				return true;
			}
			
			foreach (var ps in Main.player) { 
				if (ps.whoAmI == player.whoAmI || Vector2.Distance(ps.position, Main.MouseWorld) > 30) continue;
				
				Main.NewText($"New Master: {ps.name}", Color.Green);
				
				mp.MasterName = ps.name;
				player.AddBuff(ModContent.BuffType<CurseBuff>(), 18000);
				return true;
			}
			
			Main.NewText("You need to click on the player you will serve", Color.Red);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}