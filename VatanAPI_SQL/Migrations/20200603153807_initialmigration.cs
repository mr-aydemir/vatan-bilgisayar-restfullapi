using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VatanAPI.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Marka = table.Column<byte>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    PreviousCost = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    NumberInStock = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: false),
                    KargoFiyatı = table.Column<double>(nullable: false),
                    ToplamSiparisSayisi = table.Column<int>(nullable: false),
                    Tag = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    SepetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    SepeteKonulmaTarihi = table.Column<DateTime>(nullable: false),
                    Adet = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.SepetId);
                    table.ForeignKey(
                        name: "FK_Sepet_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiparisTarihi = table.Column<DateTime>(nullable: false),
                    Adet = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK_Siparis_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 100, "Telefon" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 101, "Bilgisayar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 102, "Bilgisayar Parçaları" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 103, "Kamera" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 104, "TV & Ev Elektroniği" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 105, "Ofis" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 106, "Aksesuar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 107, "Oyun & Hobi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 108, "Ev Aletleri" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 109, "Spor & Outdoor" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "aydemir@gmail.com", "Aydemir", "Emre", "1234", "AydemirEmre" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "akdeniz@gmail.com", "Akdeniz", "Yusuf", "4567", "AkdenizYusuf" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 100, 101, 5049.0, "HP 15 - DA1021NT CORE İ5 8265U 1.6GHZ - 8GB - 256GB SSD - 15.6-MX110 2GB-W10 NOTEBOOK", 0.0, (byte)8, "5QS63EA", 15, 4837.0, (byte)1, 0, "https://www.vatanbilgisayar.com/hp-15-da1021nt-core-i5-8265u-1-6ghz-8gb-256gb-ssd-15-6-mx110-2gb-w10-notebook.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 118, 101, 11697.0, "DELL G317 CORE İ7 8750H 2.2GHZ-16GB -2TB+256 SSD-GTX1060 6GB-17.3'W10", 0.0, (byte)6, "G317-FB75D256W162C", 12, 11000.0, (byte)2, 1, "https://www.vatanbilgisayar.com/dell-g317-core-i7-8750h-2-2ghz-16gb-2tb-256-ssd-gtx1060-6gb-17-3-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 117, 101, 2299.0, "HOMETECH ALFA 300i INTEL CORE İ3 5005U 2GHZ-4GB-128GB SSD-14''INT-W10", 0.0, (byte)9, "31.8029", 35, 2500.0, (byte)3, 1, "https://www.vatanbilgisayar.com/hometech-alfa-300i-intel-core-i3-5005u-2ghz-4gb-128gb-ssd-14-int-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 116, 101, 9686.0, "DELL G315 CORE İ7 9750H 2.6GHZ-16GB -1TB+256 SSD-GTX1650 4GB-15.6'W10", 0.0, (byte)6, "G315-4B75D256W161C", 8, 9686.0, (byte)3, 0, "https://www.vatanbilgisayar.com/dell-g315-core-i7-9750h-2-6ghz-16gb-1tb-256-ssd-gtx1650-4gb-15-6-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 115, 101, 5799.0, "ACER SWIFT 3 AMD RYZEN 7 3700U 2.3GHZ-8GB-256GB SSD-14' - RX540 2GB - W10", 0.0, (byte)4, "SF314-41G-R1WG", 50, 5700.0, (byte)3, 0, "https://www.vatanbilgisayar.com/acer-swift-3-amd-ryzen-7-3700u-2-3ghz-8gb-256gb-ssd-14-rx540-2gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 114, 101, 4949.0, "HP 15-DA1065NT CORE İ5 8265U 1.6GHZ-4GB-128GB SSD-15.6' - MX110 2GB - W10 NOTEBOOK", 0.0, (byte)8, "6TC05EA", 50, 4725.0, (byte)2, 0, "https://www.vatanbilgisayar.com/hp-15-da1065nt-core-i5-8265u-1-6ghz-4gb-128gb-ssd-15-6-mx110-2gb-w10-notebook.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 113, 101, 5599.0, "HP 15-DA1116NT CORE İ5 8265U 1.6GHZ-8GB-1TB+128GB SSD-15.6' - MX110 2GB - W10", 0.0, (byte)8, "9QH75EA", 35, 5300.0, (byte)2, 0, "https://www.vatanbilgisayar.com/hp-15-da1116nt-core-i5-8265u-1-6ghz-8gb-1tb-128gb-ssd-15-6-mx110-2gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 112, 101, 12499.0, "HP SPECTRE X360 13-AW0001NT CORE İ7 1065G7 1.3GHZ-16GB-512GB SSD-13.3' - INT - W10", 0.0, (byte)8, "7WA87EA", 8, 14299.0, (byte)3, 0, "https://www.vatanbilgisayar.com/hp-spectre-x360-13-aw0001nt-core-i7-1065g7-1-3ghz-16gb-512gb-ssd-13-3-int-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 111, 101, 10028.0, "ASUS G531GT CORE İ7 9750H 2.6GHZ-16GB-512GB SSD-15.6''-GTX1650 4GB-W10", 0.0, (byte)2, "G531GT-AL178T-Gaming", 2, 10050.0, (byte)2, 0, "https://www.vatanbilgisayar.com/asus-g531gt-core-i7-9750h-2-6ghz-16gb-512gb-ssd-15-6-gtx1650-4gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 119, 101, 9686.0, "DELL G315 CORE İ7 9750H 2.6GHZ-16GB -1TB+256 SSD-GTX1650 4GB-15.6'W10", 0.0, (byte)6, "G315-4B75D256W161C", 18, 9700.0, (byte)3, 0, "https://www.vatanbilgisayar.com/dell-g315-core-i7-9750h-2-6ghz-16gb-1tb-256-ssd-gtx1650-4gb-15-6-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 110, 101, 5049.0, "HP 15-DA1021NT CORE İ5 8265U 1.6GHZ-8GB-256GB SSD-15.6' - MX110 2GB - W10 NOTEBOOK", 0.0, (byte)8, "5QS63EA", 11, 5500.0, (byte)1, 0, "https://www.vatanbilgisayar.com/hp-15-da1021nt-core-i5-8265u-1-6ghz-8gb-256gb-ssd-15-6-mx110-2gb-w10-notebook.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 108, 101, 6299.0, "ACER NITRO 5 CORE İ5 8300H 2.3GHZ-8GB-1TB+128GB SSD-15.6' - GTX1050 3GB - W10", 0.0, (byte)4, "AN515-54-56UW", 12, 6700.0, (byte)3, 0, "https://www.vatanbilgisayar.com/acer-nitro-5-core-i5-8300h-2-3ghz-8gb-1tb-128gb-ssd-15-6-gtx1050-3gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 107, 101, 10399.0, "ACER NITRO 5 CORE İ7 9750H 2.6GHZ-16GB-1TB+128GB SSD-15.6' - GTX1660TI 6GB - W10", 0.0, (byte)4, "AN515-54-74XH", 5, 11000.0, (byte)2, 0, "https://www.vatanbilgisayar.com/acer-nitro-5-core-i7-9750h-2-6ghz-16gb-1tb-128gb-ssd-15-6-gtx1660ti-6gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 106, 101, 2299.0, "ACER ASPIRE 3 CELERON N4000 1.1GHZ-4GB RAM-128GB SSD-15.6' - INT - W10 NOTEBOOK", 0.0, (byte)4, "A315-34-C7LB", 35, 2500.0, (byte)1, 0, "https://www.vatanbilgisayar.com/acer-aspire-3-celeron-n4000-1-1ghz-4gb-ram-128gb-ssd-15-6-int-w10-notebook.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 105, 101, 21499.0, "MACBOOK PRO TOUCH BAR CORE İ9 2.3GHZ-16GB-1TB SSD-RETINA 16' - 4GB - SILVER", 0.0, (byte)5, "MVVM2TU/A", 3, 21800.0, (byte)2, 0, "https://www.vatanbilgisayar.com/macbook-pro-touch-bar-core-i9-2-3ghz-16gb-1tb-ssd-retina-16-4gb-silver.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 104, 101, 4599.0, "ACER ASPIRE 3 CORE İ5 10210U 1.6GHZ-8GB-256GB SSD-15.6' - MX230 2GB - W10 NOTEBOOK", 0.0, (byte)4, "A315-55G-57HC", 15, 5000.0, (byte)2, 0, "https://www.vatanbilgisayar.com/acer-aspire-3-core-i5-10210u-1-6ghz-8gb-256gb-ssd-15-6-mx230-2gb-w10-notebook.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 103, 101, 4813.0, "ASUS X509FB CORE İ5 8265U 1.6GHZ-8GB RAM-256GB SSD-15.6' - MX110 2GB - W10", 0.0, (byte)6, "X509FB-BR073T", 8, 5000.0, (byte)3, 0, "https://www.vatanbilgisayar.com/asus-x509fb-core-i5-8265u-1-6ghz-8gb-ram-256gb-ssd-15-6-mx110-2gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 102, 101, 4599.0, "HUAWEI MATEBOOK D 15 AMD RYZEN 5 3500U 2.1GHZ-8GB-256GB SSD-15.6' - AMD - W10", 0.0, (byte)7, "53010TTJ", 10, 4395.0, (byte)1, 0, "https://www.vatanbilgisayar.com/huawei-matebook-d-15-amd-ryzen-5-3500u-2-1ghz-8gb-512gbssd-15-6-amd-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 101, 101, 6899.0, "LENOVO IDEAPAD S540 CORE İ5 10210U 1.6GHZ-8GB RAM-256GB SSD-15.6''-MX250 2GB-W10", 0.0, (byte)1, "81ND009TTX", 9, 6593.0, (byte)3, 0, "https://www.vatanbilgisayar.com/lenovo-ideapad-s540-core-i5-10210u-1-6ghz-8gb-ram-256gb-ssd-15-6-mx250-2gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 109, 101, 8999.0, "ACER NITRO 5 CORE İ7 9750H 2.6GHZ-16GB-1TB+256GB SSD-15.6' - GTX1650 4GB - W10", 0.0, (byte)4, "AN515-54-78JD", 12, 9105.0, (byte)2, 0, "https://www.vatanbilgisayar.com/acer-nitro-5-core-i7-9750h-2-6ghz-16gb-1tb-256gb-ssd-15-6-gtx1650-4gb-w10.html" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Info", "KargoFiyatı", "Marka", "Name", "NumberInStock", "PreviousCost", "Tag", "ToplamSiparisSayisi", "Url" },
                values: new object[] { 120, 101, 4599.0, "HUAWEI MATEBOOK D 15 AMD RYZEN 5 3500U 2.1GHZ-8GB-256GB SSD-15.6' - AMD - W10", 0.0, (byte)7, "53010TTJ", 35, 4680.0, (byte)3, 0, "https://www.vatanbilgisayar.com/huawei-matebook-d-15-amd-ryzen-5-3500u-2-1ghz-8gb-512gbssd-15-6-amd-w10.html" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 100, "TeoriV2-106687_large.jpg", 100, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106687_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 118, "v2-92892_large.jpg", 118, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/v2-92892_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 117, "TeoriV2-104680-3_large.jpg", 117, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HOMETECH/thumb/TeoriV2-104680-3_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 116, "TeoriV2-104849_large.jpg", 116, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/TeoriV2-104849_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 115, "TeoriV2-106421_large.jpg", 115, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-106421_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 114, "TeoriV2-106470_large.jpg", 114, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106470_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 113, "TeoriV2-106571_large.jpg", 113, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106571_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 119, "TeoriV2-104849_large.jpg", 119, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/TeoriV2-104849_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 111, "TeoriV2-106598_large.jpg", 111, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ASUS/thumb/TeoriV2-106598_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 110, "TeoriV2-106687_large.jpg", 110, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106687_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 112, "TeoriV2-106595_large.jpg", 112, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106595_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 108, "TeoriV2-105819-5_large.jpg", 108, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105819-5_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 107, "TeoriV2-105818-5_large.jpg", 107, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105818-5_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 106, "TeoriV2-105813_large.jpg", 106, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105813_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 105, "TeoriV2-105271-4_large.jpg", 105, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/APPLE/thumb/TeoriV2-105271-4_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 104, "TeoriV2-106597_large.jpg", 104, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-106597_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 103, "TeoriV2-105445-7_large.jpg", 103, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ASUS/thumb/TeoriV2-105445-7_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 102, "TeoriV2-106613_large.jpg", 102, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HUAWEI/thumb/TeoriV2-106613_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 101, "TeoriV2-97788_large.jpg", 101, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/LENOVO/thumb/TeoriV2-97788_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 109, "TeoriV2-105816-5_large.jpg", 109, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105816-5_large.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "ProductId", "Url" },
                values: new object[] { 120, "TeoriV2-106613_large.jpg", 120, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HUAWEI/thumb/TeoriV2-106613_large.jpg" });

            migrationBuilder.InsertData(
                table: "Sepet",
                columns: new[] { "SepetId", "Adet", "ProductID", "SepeteKonulmaTarihi", "UserId" },
                values: new object[] { 1, 1, 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Sepet",
                columns: new[] { "SepetId", "Adet", "ProductID", "SepeteKonulmaTarihi", "UserId" },
                values: new object[] { 2, 1, 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Siparis",
                columns: new[] { "SiparisId", "Adet", "ProductID", "SiparisTarihi", "UserId" },
                values: new object[] { 1, 1, 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Siparis",
                columns: new[] { "SiparisId", "Adet", "ProductID", "SiparisTarihi", "UserId" },
                values: new object[] { 2, 1, 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_ProductID",
                table: "Sepet",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_UserId",
                table: "Sepet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_ProductID",
                table: "Siparis",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_UserId",
                table: "Siparis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
