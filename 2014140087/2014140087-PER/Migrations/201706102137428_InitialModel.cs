namespace _2014140087_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        ATMId = c.Int(nullable: false, identity: true),
                        DescripcionATM = c.String(),
                        RanuraDepositoId = c.Int(nullable: false),
                        TecladoId = c.Int(nullable: false),
                        DispensadorEfectivoId = c.Int(nullable: false),
                        PantallaId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                        BasedeDatosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ATMId)
                .ForeignKey("dbo.Retiro", t => t.RetiroId, cascadeDelete: true)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.Base de Datos",
                c => new
                    {
                        BasedeDatosId = c.Int(nullable: false),
                        AutentificarCuenta = c.Boolean(nullable: false),
                        ObtenerSaldoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ObtenerSaldoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debitar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acreditar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasedeDatosId)
                .ForeignKey("dbo.Retiro", t => t.RetiroId, cascadeDelete: true)
                .ForeignKey("dbo.ATM", t => t.BasedeDatosId)
                .Index(t => t.BasedeDatosId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        Pin = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.Int(nullable: false),
                        BasedeDatos_BasedeDatosId = c.Int(),
                    })
                .PrimaryKey(t => t.Pin)
                .ForeignKey("dbo.Base de Datos", t => t.BasedeDatos_BasedeDatosId)
                .Index(t => t.BasedeDatos_BasedeDatosId);
            
            CreateTable(
                "dbo.Retiro",
                c => new
                    {
                        RetiroId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RetiroId);
            
            CreateTable(
                "dbo.DispensadorEfectivo",
                c => new
                    {
                        DispensadorEfectivoId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DispensadorEfectivoId)
                .ForeignKey("dbo.Retiro", t => t.RetiroId, cascadeDelete: true)
                .ForeignKey("dbo.ATM", t => t.DispensadorEfectivoId)
                .Index(t => t.DispensadorEfectivoId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.Pantalla",
                c => new
                    {
                        PantallaId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PantallaId)
                .ForeignKey("dbo.Retiro", t => t.RetiroId, cascadeDelete: true)
                .ForeignKey("dbo.ATM", t => t.PantallaId)
                .Index(t => t.PantallaId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.Ranura",
                c => new
                    {
                        RanuraDepositoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RanuraDepositoId)
                .ForeignKey("dbo.ATM", t => t.RanuraDepositoId)
                .Index(t => t.RanuraDepositoId);
            
            CreateTable(
                "dbo.Teclado",
                c => new
                    {
                        TecladoId = c.Int(nullable: false),
                        ATMId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TecladoId)
                .ForeignKey("dbo.Retiro", t => t.RetiroId, cascadeDelete: true)
                .ForeignKey("dbo.ATM", t => t.TecladoId)
                .Index(t => t.TecladoId)
                .Index(t => t.RetiroId);
            
            CreateTable(
                "dbo.CuentaRetiros",
                c => new
                    {
                        CuentaId = c.Int(nullable: false),
                        RetiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CuentaId, t.RetiroId })
                .ForeignKey("dbo.Retiro", t => t.CuentaId, cascadeDelete: true)
                .ForeignKey("dbo.Cuenta", t => t.RetiroId, cascadeDelete: true)
                .Index(t => t.CuentaId)
                .Index(t => t.RetiroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teclado", "TecladoId", "dbo.ATM");
            DropForeignKey("dbo.Teclado", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.ATM", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Ranura", "RanuraDepositoId", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "PantallaId", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.DispensadorEfectivo", "DispensadorEfectivoId", "dbo.ATM");
            DropForeignKey("dbo.DispensadorEfectivo", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Base de Datos", "BasedeDatosId", "dbo.ATM");
            DropForeignKey("dbo.Base de Datos", "RetiroId", "dbo.Retiro");
            DropForeignKey("dbo.Cuenta", "BasedeDatos_BasedeDatosId", "dbo.Base de Datos");
            DropForeignKey("dbo.CuentaRetiros", "RetiroId", "dbo.Cuenta");
            DropForeignKey("dbo.CuentaRetiros", "CuentaId", "dbo.Retiro");
            DropIndex("dbo.CuentaRetiros", new[] { "RetiroId" });
            DropIndex("dbo.CuentaRetiros", new[] { "CuentaId" });
            DropIndex("dbo.Teclado", new[] { "RetiroId" });
            DropIndex("dbo.Teclado", new[] { "TecladoId" });
            DropIndex("dbo.Ranura", new[] { "RanuraDepositoId" });
            DropIndex("dbo.Pantalla", new[] { "RetiroId" });
            DropIndex("dbo.Pantalla", new[] { "PantallaId" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "RetiroId" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "DispensadorEfectivoId" });
            DropIndex("dbo.Cuenta", new[] { "BasedeDatos_BasedeDatosId" });
            DropIndex("dbo.Base de Datos", new[] { "RetiroId" });
            DropIndex("dbo.Base de Datos", new[] { "BasedeDatosId" });
            DropIndex("dbo.ATM", new[] { "RetiroId" });
            DropTable("dbo.CuentaRetiros");
            DropTable("dbo.Teclado");
            DropTable("dbo.Ranura");
            DropTable("dbo.Pantalla");
            DropTable("dbo.DispensadorEfectivo");
            DropTable("dbo.Retiro");
            DropTable("dbo.Cuenta");
            DropTable("dbo.Base de Datos");
            DropTable("dbo.ATM");
        }
    }
}
