using GeraldFitzTheNPC;
using GeraldFitzTheNPC.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace GeraldFitzTheNPC.Items
{
	public class MortarShell : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shell for Mortar and Artillery Weapons");
		}

		public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0.0f;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = ItemRarityID.Yellow;
			item.shoot = ProjectileType<MortarProjectile>();
			item.ammo = item.type; // The first item in an ammo class sets the AmmoID to it's type
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.RocketI,50);
			recipe.AddIngredient(ItemID.ExplosivePowder,100);
			recipe.AddIngredient(ItemID.IronBar,10);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.RocketI,50);
			recipe.AddIngredient(ItemID.ExplosivePowder,100);
			recipe.AddIngredient(ItemID.LeadBar,10);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}

}