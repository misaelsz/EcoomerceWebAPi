namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Endereco = c.String(),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendaId);
            
            AddColumn("dbo.ItensVenda", "Venda_VendaId", c => c.Int());
            CreateIndex("dbo.ItensVenda", "Venda_VendaId");
            AddForeignKey("dbo.ItensVenda", "Venda_VendaId", "dbo.Vendas", "VendaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensVenda", "Venda_VendaId", "dbo.Vendas");
            DropIndex("dbo.ItensVenda", new[] { "Venda_VendaId" });
            DropColumn("dbo.ItensVenda", "Venda_VendaId");
            DropTable("dbo.Vendas");
        }
    }
}
