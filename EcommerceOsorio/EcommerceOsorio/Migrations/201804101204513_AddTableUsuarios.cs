namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableUsuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Cep = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
