namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderedProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ShoppingCartProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.FavouriteProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderedProducts", new[] { "Order_Id" });
            DropIndex("dbo.OrderedProducts", new[] { "Product_Id" });
            DropIndex("dbo.ShoppingCartProducts", new[] { "Product_Id" });
            RenameColumn(table: "dbo.FavouriteProducts", name: "appUser_Id", newName: "userId");
            RenameColumn(table: "dbo.FavouriteProducts", name: "Product_Id", newName: "productId");
            RenameColumn(table: "dbo.Orders", name: "appUser_Id", newName: "userId");
            RenameColumn(table: "dbo.OrderedProducts", name: "Order_Id", newName: "orderId");
            RenameColumn(table: "dbo.OrderedProducts", name: "Product_Id", newName: "productId");
            RenameColumn(table: "dbo.ShoppingCartProducts", name: "ShoppingCart_Id", newName: "shoppingCartId");
            RenameColumn(table: "dbo.ShoppingCartProducts", name: "Product_Id", newName: "productId");
            RenameIndex(table: "dbo.FavouriteProducts", name: "IX_appUser_Id", newName: "IX_userId");
            RenameIndex(table: "dbo.Orders", name: "IX_appUser_Id", newName: "IX_userId");
            RenameIndex(table: "dbo.ShoppingCartProducts", name: "IX_ShoppingCart_Id", newName: "IX_shoppingCartId");
            AlterColumn("dbo.FavouriteProducts", "productId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderedProducts", "orderId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderedProducts", "productId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShoppingCartProducts", "productId", c => c.Int(nullable: false));
            CreateIndex("dbo.FavouriteProducts", "productId");
            CreateIndex("dbo.OrderedProducts", "productId");
            CreateIndex("dbo.OrderedProducts", "orderId");
            CreateIndex("dbo.ShoppingCartProducts", "productId");
            AddForeignKey("dbo.FavouriteProducts", "productId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderedProducts", "orderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderedProducts", "productId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingCartProducts", "productId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "orderId", "dbo.Orders");
            DropForeignKey("dbo.FavouriteProducts", "productId", "dbo.Products");
            DropIndex("dbo.ShoppingCartProducts", new[] { "productId" });
            DropIndex("dbo.OrderedProducts", new[] { "orderId" });
            DropIndex("dbo.OrderedProducts", new[] { "productId" });
            DropIndex("dbo.FavouriteProducts", new[] { "productId" });
            AlterColumn("dbo.ShoppingCartProducts", "productId", c => c.Int());
            AlterColumn("dbo.OrderedProducts", "productId", c => c.Int());
            AlterColumn("dbo.OrderedProducts", "orderId", c => c.Int());
            AlterColumn("dbo.FavouriteProducts", "productId", c => c.Int());
            RenameIndex(table: "dbo.ShoppingCartProducts", name: "IX_shoppingCartId", newName: "IX_ShoppingCart_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_userId", newName: "IX_appUser_Id");
            RenameIndex(table: "dbo.FavouriteProducts", name: "IX_userId", newName: "IX_appUser_Id");
            RenameColumn(table: "dbo.ShoppingCartProducts", name: "productId", newName: "Product_Id");
            RenameColumn(table: "dbo.ShoppingCartProducts", name: "shoppingCartId", newName: "ShoppingCart_Id");
            RenameColumn(table: "dbo.OrderedProducts", name: "productId", newName: "Product_Id");
            RenameColumn(table: "dbo.OrderedProducts", name: "orderId", newName: "Order_Id");
            RenameColumn(table: "dbo.Orders", name: "userId", newName: "appUser_Id");
            RenameColumn(table: "dbo.FavouriteProducts", name: "productId", newName: "Product_Id");
            RenameColumn(table: "dbo.FavouriteProducts", name: "userId", newName: "appUser_Id");
            CreateIndex("dbo.ShoppingCartProducts", "Product_Id");
            CreateIndex("dbo.OrderedProducts", "Product_Id");
            CreateIndex("dbo.OrderedProducts", "Order_Id");
            CreateIndex("dbo.FavouriteProducts", "Product_Id");
            AddForeignKey("dbo.ShoppingCartProducts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderedProducts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderedProducts", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.FavouriteProducts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
