using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GeraldFitzTheNPC.Projectiles;
using Microsoft.Xna.Framework;
using System;
using static Terraria.ModLoader.ModContent;
namespace GeraldFitzTheNPC.Items
{
	public class Mortar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mortar"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a small siege mortar");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 3;//Hold the mortor outwards
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = ProjectileType<MortarShell>();
			item.shootSpeed = 16f;
			//item.Ammo = 30;
			item.useAmmo = AmmoID.Rocket;
			item.holdStyle = 1;
		}
		/*public override bool CanUseItem(Player player) {
			return !player.isFlying;
		}*/
		
		public override void HoldStyle(Player player) {
			player.itemLocation += new Vector2(-32 * player.direction,-4);
			player.itemRotation += player.direction * (float) Math.PI/4;
        }
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack){
			
			//float projectile = DoPhysics(position.X,position.Y,Main.screenPosition.X,Main.screenPosition.Y,16f,9.8f);
			//Vector2 perturbedSpeed = new Vector2(16f * (float) Math.Cos(projectile), 16f * (float) Math.Sin(projectile));
			Vector2 perturbedSpeed = new Vector2(0,-500);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return true;
		}*/
		
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}*/
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int proj = Projectile.NewProjectile(position.X, position.Y, 0,-50, type, damage, knockBack, player.whoAmI);
			mod.Logger.Debug(Main.projectile[proj].ai);
			Main.projectile[proj].ai[1] = Main.screenPosition.X+Main.screenWidth/2;
			mod.Logger.Debug(Main.projectile[proj].ai);
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		/*
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(Main.screenPosition.X+Main.screenWidth/2, Main.screenPosition.Y+Main.screenHeight/2, 0, 0, type, damage, knockBack, player.whoAmI);
			return false; // return false because we don't want tmodloader to shoot projectile
		}*/
		
		/*
		public float DoPhysics(float x,float y,float tx,float ty,float v,float g) {
			float dx=Math.Abs(x-tx);
			float dy=Math.Abs(y-ty);
			float pa1=(float) Math.Atan(((v*v)-(float) Math.Sqrt((v*v*v*v)-(g*(g*(dx*dx)+2.0f*(dy)*v*v))))/(g*dx));
			return(pa1);
		}*/
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
			recipe.AddIngredient(ItemID.LeadBar, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
