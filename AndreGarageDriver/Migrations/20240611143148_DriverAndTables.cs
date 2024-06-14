using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreGarageDriver.Migrations
{
    public partial class DriverAndTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Adress",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Adress", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Bank",
            //    columns: table => new
            //    {
            //        CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FoundingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bank", x => x.CNPJ);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Boleto",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Number = table.Column<int>(type: "int", nullable: false),
            //        DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Boleto", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Car",
            //    columns: table => new
            //    {
            //        Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ModelYear = table.Column<int>(type: "int", nullable: false),
            //        FabricationYear = table.Column<int>(type: "int", nullable: false),
            //        Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Car", x => x.Plate);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Card",
            //    columns: table => new
            //    {
            //        CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Card", x => x.CardNumber);
            //    });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "PixType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PixType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Position",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Position", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Person",
            //    columns: table => new
            //    {
            //        Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AdressId = table.Column<int>(type: "int", nullable: true),
            //        Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Person", x => x.Document);
            //        table.ForeignKey(
            //            name: "FK_Person_Adress_AdressId",
            //            column: x => x.AdressId,
            //            principalTable: "Adress",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "CNH",
                columns: table => new
                {
                    Cnh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNH", x => x.Cnh);
                    table.ForeignKey(
                        name: "FK_CNH_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateTable(
            //    name: "Pix",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TypeId = table.Column<int>(type: "int", nullable: false),
            //        Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Pix", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Pix_PixType_TypeId",
            //            column: x => x.TypeId,
            //            principalTable: "PixType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Client",
            //    columns: table => new
            //    {
            //        Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Income = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Client", x => x.Document);
            //        table.ForeignKey(
            //            name: "FK_Client_Person_Document",
            //            column: x => x.Document,
            //            principalTable: "Person",
            //            principalColumn: "Document");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PositionId = table.Column<int>(type: "int", nullable: false),
            //        ComissionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Comission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.Document);
            //        table.ForeignKey(
            //            name: "FK_Employee_Person_Document",
            //            column: x => x.Document,
            //            principalTable: "Person",
            //            principalColumn: "Document");
            //        table.ForeignKey(
            //            name: "FK_Employee_Position_PositionId",
            //            column: x => x.PositionId,
            //            principalTable: "Position",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cnh = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Document);
                    table.ForeignKey(
                        name: "FK_Driver_CNH_Cnh",
                        column: x => x.Cnh,
                        principalTable: "CNH",
                        principalColumn: "Cnh");
                    table.ForeignKey(
                        name: "FK_Driver_Person_Document",
                        column: x => x.Document,
                        principalTable: "Person",
                        principalColumn: "Document");
                });

            //migrationBuilder.CreateTable(
            //    name: "Payment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        BoletoId = table.Column<int>(type: "int", nullable: true),
            //        PixId = table.Column<int>(type: "int", nullable: true),
            //        PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payment", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Payment_Boleto_BoletoId",
            //            column: x => x.BoletoId,
            //            principalTable: "Boleto",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Payment_Card_CardNumber",
            //            column: x => x.CardNumber,
            //            principalTable: "Card",
            //            principalColumn: "CardNumber");
            //        table.ForeignKey(
            //            name: "FK_Payment_Pix_PixId",
            //            column: x => x.PixId,
            //            principalTable: "Pix",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "Dependant",
                columns: table => new
                {
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientDocument = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependant", x => x.Document);
                    table.ForeignKey(
                        name: "FK_Dependant_Client_ClientDocument",
                        column: x => x.ClientDocument,
                        principalTable: "Client",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependant_Person_Document",
                        column: x => x.Document,
                        principalTable: "Person",
                        principalColumn: "Document");
                });

            migrationBuilder.CreateTable(
                name: "Pendency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PendencyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientDocument = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pendency_Client_ClientDocument",
                        column: x => x.ClientDocument,
                        principalTable: "Client",
                        principalColumn: "Document");
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Franchise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DriverDocument = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_Insurance_Client_ClientDocument",
                        column: x => x.ClientDocument,
                        principalTable: "Client",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Insurance_Driver_DriverDocument",
                        column: x => x.DriverDocument,
                        principalTable: "Driver",
                        principalColumn: "Document");
                });

            //migrationBuilder.CreateTable(
            //    name: "Sale",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SaleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        EmployeeDocument = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ClientDocument = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        PaymentId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sale", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Sale_Car_CarPlate",
            //            column: x => x.CarPlate,
            //            principalTable: "Car",
            //            principalColumn: "Plate");
            //        table.ForeignKey(
            //            name: "FK_Sale_Client_ClientDocument",
            //            column: x => x.ClientDocument,
            //            principalTable: "Client",
            //            principalColumn: "Document");
            //        table.ForeignKey(
            //            name: "FK_Sale_Employee_EmployeeDocument",
            //            column: x => x.EmployeeDocument,
            //            principalTable: "Employee",
            //            principalColumn: "Document");
            //        table.ForeignKey(
            //            name: "FK_Sale_Payment_PaymentId",
            //            column: x => x.PaymentId,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Financing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    FinancingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankCNPJ = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financing_Bank_BankCNPJ",
                        column: x => x.BankCNPJ,
                        principalTable: "Bank",
                        principalColumn: "CNPJ");
                    table.ForeignKey(
                        name: "FK_Financing_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CNH_CategoryId",
                table: "CNH",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependant_ClientDocument",
                table: "Dependant",
                column: "ClientDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Cnh",
                table: "Driver",
                column: "Cnh");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_PositionId",
            //    table: "Employee",
            //    column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_BankCNPJ",
                table: "Financing",
                column: "BankCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_SaleId",
                table: "Financing",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_CarPlate",
                table: "Insurance",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_ClientDocument",
                table: "Insurance",
                column: "ClientDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_DriverDocument",
                table: "Insurance",
                column: "DriverDocument");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_BoletoId",
            //    table: "Payment",
            //    column: "BoletoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_CardNumber",
            //    table: "Payment",
            //    column: "CardNumber");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_PixId",
            //    table: "Payment",
            //    column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_Pendency_ClientDocument",
                table: "Pendency",
                column: "ClientDocument");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Person_AdressId",
            //    table: "Person",
            //    column: "AdressId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Pix_TypeId",
            //    table: "Pix",
            //    column: "TypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sale_CarPlate",
            //    table: "Sale",
            //    column: "CarPlate");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sale_ClientDocument",
            //    table: "Sale",
            //    column: "ClientDocument");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sale_EmployeeDocument",
            //    table: "Sale",
            //    column: "EmployeeDocument");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sale_PaymentId",
            //    table: "Sale",
            //    column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependant");

            migrationBuilder.DropTable(
                name: "Financing");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "Pendency");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "CNH");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "PixType");
        }
    }
}
