namespace E_Commerence.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminInfo",
                c => new
                    {
                        AdminInfoId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        AdminName = c.String(nullable: false, maxLength: 100),
                        AdminPw = c.String(nullable: false, maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdminInfoId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        IsPaid = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        CartProductsId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Cart_CartId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CartProductsId)
                .ForeignKey("dbo.Carts", t => t.Cart_CartId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Cart_CartId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductPrice = c.Double(nullable: false),
                        ProductDesc = c.String(maxLength: 500),
                        ProductStock = c.Int(nullable: false),
                        ProductImage = c.String(),
                        Discount = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ProductCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.ProductCategory_CategoryId)
                .Index(t => t.ProductCategory_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Position = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(nullable: false),
                        UserPassword = c.String(nullable: false, maxLength: 20),
                        UserAdress = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrdderId = c.Int(nullable: false, identity: true),
                        OrdderAmount = c.Double(nullable: false),
                        OrderAdress = c.String(nullable: false, maxLength: 500),
                        OrderMail = c.String(nullable: false),
                        OrderShipName = c.String(),
                        isOrderShipped = c.String(),
                        UserName = c.String(nullable: false, maxLength: 100),
                        UserTel = c.String(),
                        OrderDetail = c.String(maxLength: 250),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Cart_CartId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrdderId)
                .ForeignKey("dbo.Carts", t => t.Cart_CartId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Cart_CartId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        SliderTitle = c.String(),
                        SliderDesc = c.String(),
                        Position = c.Int(nullable: false),
                        SliderImageUrl = c.String(),
                        SliderUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Order", "Cart_CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.CartProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategory_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CartProducts", "Cart_CartId", "dbo.Carts");
            DropIndex("dbo.Order", new[] { "User_UserId" });
            DropIndex("dbo.Order", new[] { "Cart_CartId" });
            DropIndex("dbo.Products", new[] { "ProductCategory_CategoryId" });
            DropIndex("dbo.CartProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.CartProducts", new[] { "Cart_CartId" });
            DropIndex("dbo.Carts", new[] { "user_UserId" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Order");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartProducts");
            DropTable("dbo.Carts");
            DropTable("dbo.AdminInfo");
        }
    }
}
