using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GeraldFitzTheNPC.Projectiles;
using Microsoft.Xna.Framework;
using System;
using static Terraria.ModLoader.ModContent;
namespace GeraldFitzTheNPC.Items
{
	public class UltimateCannonade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ultimate Mortar Cannon"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a large weapon with nine barrells");
		}

		public override void SetDefaults() 
		{
			item.damage = 5;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 5;
			item.useAnimation = 20;
			item.useStyle = 3;//Hold the mortor outwards
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 30000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileType<MortarProjectile>();
			item.shootSpeed = 16f;
			//item.Ammo = 30;
			item.useAmmo = ItemType<MortarShell>();
			item.holdStyle = 1;
		}
		/*public override bool CanUseItem(Player player) {
			return !player.isFlying;
		}*/
		public override void HoldItem(Player player){
			player.AddBuff(BuffType<Buffs.DeployedDebuff>(),3);
		}
		public override void HoldStyle(Player player) {
			player.itemLocation += new Vector2(-32 * player.direction,8);
			player.itemRotation += player.direction * (float) Math.PI/4;
        }
		public override void UseStyle(Player player) {
			player.itemLocation += new Vector2(0,8);
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
			int proj = Projectile.NewProjectile(position.X, position.Y, 0,-250, type, damage, knockBack, player.whoAmI);
			Main.projectile[proj].ai[1] = Main.MouseWorld.X;
			
			
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
			recipe.AddIngredient(ItemType<Cannonade>(),1);
			recipe.AddIngredient(ItemID.ClayBlock, 30);
			recipe.AddIngredient(ItemID.LeadBar, 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Cannonade>(),1);
			recipe.AddIngredient(ItemID.ClayBlock, 30);
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			

		}
	}
}
