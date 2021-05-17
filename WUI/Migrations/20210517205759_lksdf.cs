using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WUI.Migrations
{
    public partial class lksdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PicturePath = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Birtday = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationDay = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false),
                    MessageBody = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: true),
                    MessageTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShipmentOptions = table.Column<int>(type: "varchar(32)", nullable: false),
                    State = table.Column<int>(type: "varchar(32)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<byte>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBaskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    PathToPhotoGallery = table.Column<string>(type: "TEXT", nullable: true),
                    MainPhotoName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<uint>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goods_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodUserBasket",
                columns: table => new
                {
                    BasketsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedGoodsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodUserBasket", x => new { x.BasketsId, x.SelectedGoodsId });
                    table.ForeignKey(
                        name: "FK_GoodUserBasket_Goods_SelectedGoodsId",
                        column: x => x.SelectedGoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodUserBasket_UserBaskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "UserBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderGood",
                columns: table => new
                {
                    GoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGood", x => new { x.GoodId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderGood_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderGood_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1553, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Grocery", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1561, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Outdoors", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1560, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Electronics", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1559, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Automotive", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1558, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Clothing", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1562, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Grocery", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1556, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Kids", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1555, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Tools", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1554, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Games", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PicturePath" },
                values: new object[] { 1557, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Sports", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1223, "7242 Wisozk Island, Itzelmouth, Iceland", "07/05/1989 22:58:48", "Otto Boehm", null, "03/20/2021 06:19:39" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1230, "262 Augustine Corners, New Wava, Mauritius", "04/16/1985 19:54:34", "Leonora Thiel", null, "06/21/2021 07:47:52" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1229, "74700 Gregg Village, Collinshaven, Dominican Republic", "09/15/1989 14:22:35", "Brandt Tremblay", null, "02/13/2021 01:18:59" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1228, "356 Boehm Village, Armandobury, Sao Tome and Principe", "10/17/1995 08:36:04", "Saul Douglas", null, "04/21/2021 00:20:13" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1227, "81733 Kevon Extensions, South Arleneside, Gabon", "10/11/1986 01:48:32", "Theresa Wilderman", null, "08/21/2021 12:29:36" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1226, "1303 Wilderman Curve, Lake Kayfort, Australia", "09/12/1997 00:40:56", "Seth McLaughlin", null, "10/22/2021 14:05:41" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1225, "67428 Jammie Burg, New Lorenzo, Kiribati", "11/27/1982 20:06:44", "Keyshawn Paucek", null, "04/16/2021 09:51:03" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1224, "45896 Wava Hills, Erdmanview, Zambia", "10/12/1993 03:00:29", "Joelle Lubowitz", null, "07/01/2021 13:51:06" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1222, "839 Effertz Ranch, North Deliaberg, Somalia", "10/28/1986 12:55:21", "Harley Stanton", null, "06/28/2021 21:55:17" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1217, "5060 Caroline Mill, Dorcasberg, Thailand", "12/15/1995 07:07:19", "Michale Lueilwitz", null, "01/12/2021 17:59:38" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1220, "952 Stracke Mount, Port Della, Kuwait", "05/18/1997 06:10:28", "Davin Denesik", null, "01/06/2021 15:06:36" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1219, "108 Gutkowski Pike, North Nicolaville, Mongolia", "11/17/1993 10:04:11", "Omari Hills", null, "05/26/2021 03:16:51" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1218, "4891 Blaise Harbors, Olinville, Cuba", "05/11/1989 18:03:58", "Ashly Dooley", null, "07/29/2021 01:16:46" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1231, "45008 Lueilwitz Squares, Henryfort, Kenya", "11/03/1992 10:51:28", "Diego Torphy", null, "07/14/2021 15:27:12" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1216, "27044 Bogisich Loop, South Theo, Liberia", "06/13/1985 05:09:42", "Jon Terry", null, "11/05/2021 19:29:03" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1215, "3692 Emard Underpass, Lake Melynastad, Belarus", "07/18/1993 07:13:16", "Marty Gleichner", null, "10/23/2021 07:09:24" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1214, "27738 Champlin Motorway, South Jacinthe, Wallis and Futuna", "04/22/1990 18:08:12", "Jesus Tillman", null, "04/24/2021 17:46:08" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1213, "19708 Deven Centers, West Zula, Burundi", "04/03/1998 13:09:28", "Emmett Marvin", null, "05/25/2021 09:20:27" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1221, "142 Abshire Rue, North Flavio, Brazil", "10/03/1995 09:48:49", "Kelvin Toy", null, "11/10/2021 13:58:54" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[] { 1232, "87737 Jerde Expressway, Krajcikfort, Dominica", "05/22/1985 06:56:14", "Erick Kihn", null, "05/15/2021 11:02:17" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1248, 121, 1224 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1251, 123, 1215 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1244, 127, 1216 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1245, 125, 1229 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1243, 123, 1218 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1249, 130, 1227 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1246, 122, 1217 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1250, 121, 1230 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1247, 126, 1221 });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[] { 1252, 124, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1386, "Tempore voluptas vitae nihil asperiores perspiciatis quas.\nQuia voluptatem perferendis quis voluptatem itaque nisi in similique eveniet.\nEt laudantium sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1380, "Aperiam quidem iusto neque molestiae autem fugit aut eveniet veritatis.\nEnim dolor non quia.\nDicta porro mollitia adipisci consequatur eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1377, "Et eos sit qui voluptatibus sunt doloremque sit dolore nulla.\nVoluptate a eaque eos.\nOfficiis suscipit modi vel explicabo iusto minus modi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1353, "Unde minus quia et quam.\nHarum tempore quidem.\nDeleniti ea voluptas unde mollitia quia est iure.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1336, "Vitae aut deserunt minus ut excepturi cupiditate.\nVoluptas rem voluptate minima odit ad.\nQuam provident velit sed natus doloribus nihil autem suscipit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1335, "In et occaecati repellendus.\nHarum vero tempore reiciendis natus velit placeat.\nCommodi tenetur magnam est ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1519, "Qui non deserunt aliquam itaque at.\nArchitecto eligendi modi.\nMolestiae totam provident non voluptate et a incidunt id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1313, "Modi recusandae laudantium.\nPossimus voluptatem tempore vel reprehenderit quam dolore.\nEst quisquam deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1397, "A omnis et omnis aut.\nPariatur pariatur provident qui.\nEt et ut sunt sed officia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1299, "Qui dolor blanditiis enim voluptate iusto qui amet consequuntur eaque.\nIpsam et ut et voluptatibus necessitatibus nihil nam.\nReiciendis recusandae quos facilis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1279, "Facere qui fuga in eaque adipisci ut dolore tempore.\nDoloribus magnam sequi laborum exercitationem officiis voluptatem assumenda.\nSint modi suscipit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1545, "Consequatur nihil delectus reprehenderit adipisci et quia recusandae eius architecto.\nConsequatur voluptatem tenetur.\nAliquam suscipit architecto in rerum sequi non nemo exercitationem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1517, "Temporibus beatae rerum cupiditate ipsum et.\nTotam consectetur aut eum delectus.\nDolor quod dolor ratione quidem aut nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1331, "Suscipit ipsam sed aut dolor velit.\nOmnis error hic ullam.\nTenetur voluptatum atque beatae necessitatibus deleniti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1404, "Esse vel a.\nVoluptatem repellendus ratione.\nQuia incidunt ut non beatae nisi praesentium praesentium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1455, "Exercitationem tenetur est quo et eos ea repellat sapiente saepe.\nRecusandae cupiditate omnis qui.\nQuibusdam vel optio est velit et velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1438, "Est neque sed inventore aut nihil sint placeat tempora.\nUllam cum et pariatur eius repellat incidunt non reiciendis.\nLabore magni facere ad quos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1309, "Tenetur et debitis minus.\nSunt eum nobis ullam rerum suscipit qui.\nAliquam velit dolores natus ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1307, "Ut sunt repudiandae assumenda soluta.\nIllum et placeat quidem.\nDolorem quam voluptatem sint eaque commodi dignissimos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1288, "Molestias et voluptatum ut velit dolor et.\nAut ut quis.\nVoluptates iusto ut rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1272, "Repudiandae modi perspiciatis qui possimus unde qui molestiae.\nNesciunt voluptatem voluptas sit odio voluptatem libero velit earum.\nEum error culpa voluptate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1269, "Omnis qui velit repudiandae.\nAssumenda et reiciendis qui sed error eligendi dolorum.\nAut autem maxime.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1546, "Ullam sint qui neque enim.\nError facere hic omnis sunt fuga assumenda dignissimos.\nDolorum exercitationem est exercitationem sed quia corporis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1427, "Quasi consequatur tempore voluptatem enim quidem aut quos.\nEt exercitationem et tempora modi deserunt fugiat maiores inventore saepe.\nRecusandae harum in blanditiis consequatur veritatis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1510, "Sed dolores sunt ea sit ducimus odio impedit neque.\nIn consequatur atque vitae error accusamus et sequi.\nModi ea quo numquam facilis fuga dolor sunt voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1488, "Et aut est.\nVero rerum illum quia corrupti laudantium.\nPossimus saepe omnis distinctio sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1480, "Distinctio aperiam eos placeat.\nDolores ipsa consequuntur et quasi.\nVoluptas voluptatem error.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1474, "Optio enim aut quia ipsum voluptates quod ea nisi.\nAb molestiae modi.\nLaborum nulla numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1470, "Quo voluptatem incidunt est placeat minima voluptatem.\nLibero rerum recusandae id sit possimus eligendi.\nQui deserunt reiciendis optio aliquam autem praesentium alias quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1496, "Quasi cumque nobis nam voluptatem ducimus aut.\nIusto blanditiis quia ratione sunt.\nDicta nemo neque ad reiciendis ut pariatur error quasi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1441, "Est maxime consequatur maiores.\nVoluptatem eveniet atque facere quis.\nDolore earum quidem assumenda ipsam autem ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1500, "Hic est praesentium omnis voluptate.\nLaboriosam qui consequatur vel ipsa consequatur voluptatem aliquid rem quia.\nEnim alias necessitatibus dolore amet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1481, "Quasi eos dolor sit corrupti modi dolor doloribus.\nDoloremque necessitatibus vero.\nEst optio suscipit labore corporis ut deserunt tempore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1460, "Et enim qui ipsum.\nInventore eveniet omnis ut porro.\nTotam facere inventore impedit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1471, "Maxime fugit expedita porro eius voluptatem minus nam dicta et.\nNon corrupti dolores sapiente ut architecto aut.\nEt fuga omnis nostrum ullam velit ratione voluptatem sint aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1478, "Eaque amet ipsam fugiat itaque maiores qui non facere numquam.\nSunt voluptatem exercitationem ut.\nNemo quod est autem pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1465, "Ducimus minus facilis pariatur est eveniet corporis repellat.\nEa et ratione omnis sit quia occaecati dolor placeat nostrum.\nAut vero delectus sunt quis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1456, "Voluptas illum ratione fugit aliquid.\nUt alias minima modi non est.\nFuga eius aut debitis neque magni dolores temporibus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1437, "Earum ut voluptatem facere corporis recusandae aut fuga debitis repellendus.\nId quaerat ut quasi enim reiciendis rerum quisquam dignissimos.\nProvident eligendi consequuntur consectetur possimus quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1430, "Voluptate nihil rem.\nUnde fugit ratione consequatur est quidem officia.\nUnde et modi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1420, "Aut distinctio quo ipsa velit quo dolor nihil.\nQuia itaque dolorem eum quasi consequuntur praesentium omnis.\nAd ratione molestias commodi provident facere.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1412, "Minus eum nemo distinctio nisi similique possimus qui ut ipsa.\nVoluptas molestias illum iste ut voluptatem est.\nVoluptatem voluptas sint similique tempora omnis est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1401, "Nobis minus nihil voluptas.\nEos impedit voluptatem et ut vitae repudiandae architecto cupiditate.\nConsectetur eos id qui numquam aspernatur officia aut id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1395, "Voluptatum sint itaque ut.\nAt facilis iusto nobis quaerat iusto molestias amet sit.\nVoluptatem neque illo pariatur rerum optio quasi sed odio ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1394, "Numquam quis nemo voluptas consequatur rerum.\nVoluptatem ut cupiditate praesentium voluptas.\nId labore totam nesciunt vel et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1393, "Voluptate dolorem et error quo ipsum eveniet in et.\nDoloribus ut alias odit.\nLabore deserunt culpa sed qui asperiores omnis cupiditate commodi aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1387, "Magni earum maxime consequatur.\nUt quia voluptatum et culpa iste velit omnis.\nQuo ipsam mollitia quaerat non hic dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1381, "Enim dignissimos neque culpa ipsum totam.\nBlanditiis aspernatur velit nulla enim sit.\nCorrupti illum quia sint illum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1378, "Recusandae rerum omnis aut dolor dolores.\nOdit recusandae vero repellat esse voluptatem debitis distinctio.\nAmet iusto doloribus aut consequuntur recusandae pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1373, "Ut rerum consectetur in magnam quia officiis.\nReprehenderit inventore quasi sint sint earum autem eaque aut.\nPraesentium nemo fugiat dicta porro et expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1482, "Dignissimos nesciunt aut.\nOmnis sapiente aliquam ex quisquam numquam et.\nHarum quo quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1485, "Tenetur voluptas mollitia laboriosam unde consequuntur voluptas.\nDolores laboriosam qui cumque aut cum magni.\nQuaerat nesciunt voluptatem quod quia impedit ipsa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1494, "Sunt fugiat aut rerum rem eligendi vero ullam necessitatibus earum.\nEt qui quidem labore quis maiores.\nNobis ad animi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1495, "Iste dolorem non.\nVoluptatem et explicabo ut autem quaerat dolor.\nMagnam nam a aut labore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1325, "Et rerum explicabo ut doloremque excepturi dolores autem.\nQuia ut dicta nulla quo impedit et voluptate consequatur qui.\nPlaceat eius dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1429, "Id eius ipsam quia excepturi ut.\nEligendi quae asperiores veritatis quibusdam adipisci reiciendis et.\nFuga commodi aliquam aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1367, "Sunt repellendus ut nostrum.\nAperiam ea expedita dolore recusandae enim et omnis.\nAmet dolores qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1360, "Occaecati cumque nemo excepturi esse.\nSoluta quos ducimus ex ut aut.\nCorporis consequuntur deserunt et aut cupiditate fugit voluptatem sint.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1345, "Provident quam ipsum enim dolor nulla nam maxime laboriosam.\nQui qui labore.\nFacilis corrupti explicabo quasi et quia excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1320, "Illum libero ipsum.\nHarum blanditiis sed porro et animi iste dolores sequi voluptatem.\nDolor accusamus sit ab corrupti.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1302, "Et voluptates dolores.\nAd sint officia aspernatur nemo saepe voluptatibus ea omnis.\nCorporis nihil cumque sint veritatis qui nulla temporibus sit optio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1477, "Et sequi possimus sunt.\nEt est aut aliquid eos quam fugit error dolore odit.\nMolestiae nisi aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1285, "Ut quia eum expedita et vitae repellendus voluptatem.\nNon nesciunt recusandae omnis et ut necessitatibus aut provident.\nSint vel adipisci non.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1257, "Tempora voluptas est ducimus quibusdam occaecati.\nMolestias eligendi ea rerum placeat asperiores veritatis magni cumque.\nVelit quo omnis dolorum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1253, "Aut explicabo perspiciatis eveniet rerum corporis voluptatum ratione aperiam vitae.\nAt nemo quaerat.\nNon et ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1551, "Mollitia nemo dolorem saepe possimus error quo fuga veritatis sapiente.\nExercitationem earum sapiente tempore aliquam et odit enim.\nVoluptatem asperiores atque omnis consectetur nemo facilis laboriosam quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1550, "Est cumque voluptas dolore qui dolorem sed.\nEt dolorem vitae fuga quibusdam accusamus eaque.\nQuos delectus adipisci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1531, "Nam delectus voluptate et ut in ipsa.\nQuam id velit perspiciatis ipsa nemo esse dicta et.\nReiciendis dolorem quo voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1528, "Minus voluptatem repellat dolores eius reprehenderit sunt omnis.\nEum placeat tenetur nesciunt.\nUt inventore similique sunt ipsum ex eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1518, "Quo inventore quidem quo.\nAnimi incidunt officiis tempora omnis aliquam quasi exercitationem totam eius.\nUt dolores id et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1267, "Ut et dolor vitae aspernatur voluptatem.\nVoluptas animi delectus corrupti mollitia delectus aut expedita dolor.\nAut sunt ut molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1329, "Cum dicta occaecati ab voluptatem aliquam voluptatibus quia magni.\nQuia praesentium voluptatum sed sit.\nQuia nemo omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1348, "Sed consectetur nam dolorum iste rerum expedita.\nAssumenda voluptas aut et pariatur.\nReprehenderit in reprehenderit odio assumenda neque ex numquam cum repellat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1343, "Totam non quis unde delectus.\nSed sint deleniti debitis commodi aut ex praesentium.\nProvident maiores nam aut soluta laborum est accusamus ut sequi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1310, "Ut mollitia sint amet eos natus.\nQuia mollitia similique molestiae.\nModi rem porro dignissimos voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1303, "Recusandae ad nulla ullam aut dolorem consequatur consequatur ut non.\nQuidem ipsa quia eveniet.\nQui reprehenderit rerum nihil ea similique.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1297, "Ea hic libero nihil omnis nostrum porro.\nNisi ex et aut sed rerum eveniet aperiam aspernatur quia.\nRepudiandae eum dicta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1291, "Qui quasi repellat sint a aperiam.\nSaepe quis sit consequatur placeat enim.\nReprehenderit aut iure mollitia est nostrum et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1287, "Id labore praesentium voluptatem consequatur ipsa ad sit quis.\nMinus odio nemo adipisci soluta mollitia.\nOdit et neque consequuntur illo est aliquid soluta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1277, "Facere ut sed a.\nTotam molestias consequuntur omnis voluptatem.\nQuis cumque est dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1273, "Repellendus laudantium repellat fugiat enim commodi facere aut.\nAccusantium aperiam voluptas laboriosam ea ad.\nError officiis dolore.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1540, "Voluptas ut omnis voluptate temporibus.\nTemporibus sit aliquam optio culpa nihil et eum vel nostrum.\nEa dicta quod facilis et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1536, "Quia dolorum quia.\nAut hic aut iure.\nEos tempore saepe pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1526, "Ducimus optio fuga laborum unde molestiae sit.\nHarum et error itaque voluptates autem excepturi ea sint.\nIn non quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1511, "Odit expedita et.\nExercitationem numquam nostrum quidem.\nReiciendis exercitationem ut error modi asperiores consequatur commodi velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1502, "Eaque unde molestiae numquam beatae error rerum officia pariatur.\nConsectetur nihil tempora magni est aliquam modi tempore.\nOmnis neque alias sit tenetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1501, "Consectetur qui omnis cumque eius delectus reprehenderit dolorum.\nQuia laboriosam iusto accusantium sunt sit mollitia totam voluptatem facilis.\nTempore officia error a voluptatem magni voluptatem ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1491, "Accusantium tenetur expedita nostrum reiciendis voluptatem vel ut ullam odit.\nVoluptatem doloremque quos possimus quisquam cupiditate asperiores.\nHarum dignissimos corrupti reprehenderit in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1464, "Omnis corporis labore sed quis culpa cupiditate qui.\nNon eligendi atque assumenda.\nPossimus qui similique est consequatur consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1314, "In distinctio cum dolorem voluptas repellat cupiditate.\nOccaecati ipsum sunt ipsum consequatur et repudiandae.\nSed beatae assumenda consequatur rerum tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1359, "Temporibus in molestiae aut eaque recusandae.\nLaboriosam quos laborum possimus sequi nulla.\nId in quam sed alias qui harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1363, "Velit iusto enim ut.\nVoluptatem culpa blanditiis alias assumenda ex ipsum.\nUt blanditiis iusto incidunt esse nobis omnis recusandae rerum consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1372, "Quae omnis itaque labore minus eos quisquam culpa modi dolore.\nSit in consequuntur.\nVeritatis quisquam odio distinctio id aut eveniet autem nulla.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1534, "Porro accusantium excepturi harum consectetur neque.\nReiciendis error facere et dolorum.\nEt dolor reiciendis dolor aut omnis est placeat dolorem quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1530, "Nulla culpa laboriosam vel et vitae delectus in molestiae.\nRerum assumenda aliquid ex alias doloribus quo nisi repudiandae tempora.\nQui voluptatem eius ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1512, "Exercitationem est esse commodi sint ducimus dolor ut.\nTempore autem ipsam ut exercitationem.\nVero repudiandae ut expedita molestias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1492, "Nostrum corrupti dolor quis cum eligendi.\nLaborum sed dolore eum.\nIllo quod quas voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1489, "Quo reiciendis sit necessitatibus est consectetur id perspiciatis.\nSunt nihil at quia magni eum.\nFacilis aut natus facere pariatur consequatur voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1487, "Sapiente ex et et explicabo a est officiis perspiciatis et.\nA est autem et tempora nulla veritatis delectus quibusdam.\nQuam vero libero explicabo et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1483, "Quaerat aut voluptatem enim accusamus ullam enim molestias beatae.\nDolor necessitatibus quasi repudiandae iure.\nRerum sit numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1447, "Vitae et cumque voluptas molestiae cumque laborum saepe aut.\nLibero impedit ea modi id cum labore autem.\nConsectetur ut quas quasi blanditiis voluptatem et ut alias quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1479, "Omnis molestiae qui voluptate delectus consequatur minus quam.\nAut sed sunt omnis vitae error dolorum.\nQui odit quia tenetur doloribus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1232 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1473, "Impedit sequi impedit ea alias vero quam ipsa.\nDeserunt aut sunt ullam voluptatem itaque.\nDicta in exercitationem at veritatis mollitia ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1442, "Nesciunt et explicabo nisi.\nQuos et numquam autem dolorum voluptas.\nDolores debitis est et aperiam illum expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1426, "Rerum nostrum beatae quia vel sequi aspernatur dolorum iusto.\nCumque neque non architecto.\nMollitia quod totam et accusamus voluptates dicta vitae dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1425, "Autem velit et et autem adipisci impedit esse dolore.\nVoluptatem numquam ut sed possimus illo.\nAut ducimus asperiores velit voluptatum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1421, "Qui delectus cupiditate ratione rerum recusandae ea optio ipsam ut.\nMinus ut qui alias.\nDeserunt sint ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1403, "Laborum dolorum sed autem.\nExplicabo et aspernatur et.\nAut ad aliquid neque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1388, "Voluptas sint quod omnis ea ipsa laboriosam et molestiae.\nEt id possimus aut totam magnam eligendi.\nVoluptates ea repellendus neque consequatur ipsam velit corporis et architecto.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1475, "Inventore quis dolores iste qui.\nError consequuntur in aut amet.\nLibero magni nesciunt aut labore quia quam aspernatur eum earum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1435, "In possimus numquam cum amet soluta omnis labore a eum.\nEt blanditiis asperiores exercitationem porro quia magnam deleniti dolorem ducimus.\nDolor ad voluptas neque molestiae magnam corporis pariatur quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1428, "Non qui ullam aut molestiae accusantium et voluptas vel.\nNon consequuntur qui voluptates delectus ducimus.\nRerum est ipsam aliquam aspernatur odio recusandae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1422, "Odit veritatis eligendi nisi in eius occaecati.\nSapiente non et et.\nQuod velit aut exercitationem incidunt voluptatibus autem vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1476, "Distinctio ex modi et eius eum.\nVero atque illum voluptas.\nMagnam voluptatum necessitatibus ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1229 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1472, "Modi suscipit repellendus iste incidunt eius eum et voluptatem doloremque.\nPorro repellat ab quia omnis fugiat tempora non aperiam.\nFuga commodi ut qui ex occaecati architecto inventore vel vero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1469, "Ducimus molestiae ipsam officia nisi non consequatur accusantium harum.\nConsequatur voluptate sunt.\nVoluptatem et officiis saepe.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1450, "Animi est odio excepturi officia.\nEligendi deleniti recusandae consectetur dolores.\nIpsam velit ea sunt ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1448, "Dolore et sit aliquid voluptas consectetur rerum et velit cupiditate.\nEt nihil et aspernatur labore optio doloremque velit cupiditate.\nExcepturi earum culpa asperiores et et molestias minus est aliquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1433, "Deserunt odio reiciendis ut placeat.\nVoluptatem dolorem vitae soluta pariatur autem nam magnam.\nModi voluptates voluptatibus sed expedita expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1229, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1432, "Neque id delectus occaecati tempore ea.\nDoloremque blanditiis molestias sint omnis.\nCulpa sit et ea amet suscipit quibusdam nam velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1497, "Eaque voluptatem aspernatur debitis aperiam dolorem ipsa ut alias vero.\nEos voluptatem officiis omnis quod totam.\nRecusandae harum voluptatem odio culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1418, "Ea ut dicta.\nVelit dolorem sint est aspernatur architecto.\nUt ut ab numquam quia dolore est illum dolore ad.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1406, "Dolorem eum omnis illum omnis sit aspernatur quisquam accusantium rerum.\nMinus voluptatem et eos.\nOmnis libero eaque a expedita harum sint rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1391, "Mollitia delectus maxime quis veniam et hic.\nVel ipsam autem quia quo qui repellat ut voluptatem.\nEt assumenda voluptas sequi culpa cum officiis qui sit consequuntur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1382, "Modi impedit aut cumque.\nIncidunt veritatis asperiores asperiores iure nobis placeat expedita ut.\nModi est deserunt nihil vero soluta et ad dolores ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1376, "Perspiciatis qui voluptate omnis aut dolorum sequi.\nSed quibusdam ipsa qui qui aut et doloribus.\nAperiam natus qui quo neque quibusdam occaecati repellat consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1354, "Cupiditate aut dicta deserunt unde excepturi ut necessitatibus culpa molestiae.\nEveniet sit perspiciatis aut aliquid quam laboriosam magnam.\nEnim accusantium perferendis qui ut error dolore quae iste.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1352, "Iure sed odio corporis dolor assumenda eum amet et.\nUllam sunt nihil iste pariatur possimus nemo quam.\nNam maxime ullam rerum saepe autem rerum debitis dolore omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1357, "Aliquam et nihil.\nNostrum voluptatem omnis dolorem cumque non non.\nTemporibus saepe minima deserunt ducimus eaque dolore quo ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1415, "Laboriosam dolor sit atque repellendus qui minima consequatur.\nNecessitatibus quia quas explicabo explicabo magni dolore voluptatibus.\nQuas eum consequatur in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1339, "Voluptas molestiae aut error.\nNecessitatibus quos atque sit vitae incidunt quibusdam dolores nihil.\nPerspiciatis quis quia et temporibus occaecati aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1504, "Cum est ipsam.\nEaque commodi aut et qui maxime quas.\nVelit est excepturi fuga et eum aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1508, "Asperiores quia quos consequatur aut facilis.\nEveniet iusto ut fuga architecto.\nNon velit rerum tenetur ut quos ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1411, "Vel sint mollitia tempore harum molestias ex.\nConsectetur aut sapiente tenetur dignissimos laborum assumenda.\nAutem cum autem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1409, "Et laborum pariatur itaque quas.\nConsequatur praesentium rerum et.\nQui expedita repudiandae corrupti rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1400, "Eius numquam molestias sed earum pariatur necessitatibus reprehenderit officia.\nQuisquam sunt ullam dolor eaque ad accusantium deleniti iusto.\nVoluptates repellendus esse facere tempora.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1390, "Neque aut molestiae.\nAspernatur quia ut iusto porro voluptatum error.\nAut et est sunt magni dolorem impedit sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1371, "Dignissimos est eum dolores maiores aut autem.\nEarum asperiores enim dolore omnis distinctio tenetur quaerat ab qui.\nAut sapiente ut dolor rerum aspernatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1361, "Quisquam quisquam et doloribus cum facere sit voluptate dolorem culpa.\nEt hic et explicabo recusandae.\nNihil quos optio est qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1351, "Temporibus et et quia ratione id qui deserunt ut.\nEa vel dignissimos laudantium sint reiciendis sed et rerum.\nDebitis ut ratione ducimus nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1507, "Quis facilis labore deleniti eos aut similique ea.\nSunt voluptatibus ut.\nEt est quidem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1228, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1330, "Dolores quae error quasi consequatur.\nVeniam ut voluptas illum eaque omnis eos.\nIllum occaecati est dolorem numquam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1266, "Quo est non sint.\nQuo earum sapiente in.\nCupiditate quis et molestiae sit accusantium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1231 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1263, "Commodi in doloremque occaecati iste sed.\nVoluptas consectetur ipsum vel quod quia molestiae voluptatum dolores aliquam.\nIusto tempore sed et voluptas sed id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1549, "Et quaerat sed corrupti tempora eum necessitatibus deserunt distinctio alias.\nFuga recusandae sint vel ipsum nesciunt similique.\nMaiores dolor soluta nihil repudiandae nihil.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1533, "Itaque voluptatem nemo qui rerum.\nUt cumque et saepe mollitia omnis et labore.\nEt nostrum molestiae qui qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1523, "Dolore et doloremque accusantium accusantium nisi dolor similique aperiam.\nNatus a voluptatem quia fugiat dolorum ullam repellendus natus.\nConsectetur sequi in vitae reiciendis vero quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1230 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1521, "Perspiciatis facere expedita quis dicta accusamus.\nDolor atque enim commodi illum ratione earum aut voluptate.\nRerum eligendi blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1516, "Aut maxime ea qui nulla.\nAsperiores sed sint odio.\nNemo suscipit eaque vitae quos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1230, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1282, "Consequatur autem nostrum sit maiores.\nDoloremque porro consectetur eius odit dignissimos repudiandae.\nSit cumque at ratione voluptas voluptates a mollitia ea qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1322, "Eius temporibus consectetur aut ut sed voluptas qui.\nEsse aut ea omnis illum.\nQuod reiciendis porro explicabo eos sapiente qui rerum corrupti illo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1301, "Et doloremque hic dolores delectus.\nPraesentium nostrum vel impedit ut repudiandae sapiente quibusdam repellat dolor.\nQuis nostrum aliquam eum accusamus possimus odit fugiat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1535, "Ullam at odio animi rem.\nNihil qui officia nihil consequuntur.\nImpedit sed in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1509, "Eligendi et ad quam alias.\nEius fuga alias.\nDucimus voluptas dolores quibusdam quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1462, "Sit nostrum perferendis ipsum ut nemo officiis sit.\nOptio reiciendis delectus dolorem omnis quia iure.\nEt aut culpa ipsum in expedita labore accusamus asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1452, "Doloribus voluptate fugit qui rerum numquam.\nNecessitatibus excepturi odit autem facere.\nVeniam dolorum vitae impedit quasi laudantium placeat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1449, "Laudantium id necessitatibus eum fugiat ab et porro asperiores.\nQuisquam voluptatem placeat est qui qui.\nId voluptatum cum et minus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1417, "Aut recusandae quasi autem amet ut earum eveniet.\nIllo non consequatur.\nEum quidem eum qui ut omnis earum inventore et voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1392, "Incidunt atque ut fugiat animi ex aut.\nNon assumenda distinctio amet nisi dicta exercitationem itaque ea dolores.\nEst ratione aliquid et aut dignissimos iure quasi et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1362, "Modi placeat dolore illo repellat animi.\nQuia sint eligendi cum dolore quas assumenda id rerum.\nDeserunt quisquam temporibus sapiente aut a et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1341, "Veritatis laborum aperiam.\nConsequatur harum expedita.\nDolorem voluptatem omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1327, "Recusandae voluptatem reprehenderit vel et cum doloremque et consectetur.\nVel voluptatem quod laudantium aliquid.\nDolor sit magni et dolores pariatur et laboriosam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1304, "Explicabo qui et magni necessitatibus et voluptas veniam eaque expedita.\nPraesentium deserunt quia ut sit est in non in.\nSit amet hic ipsam velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1298, "Similique ea aut.\nNeque autem ut est voluptatum.\nIure excepturi sint repellendus sint expedita.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1284, "Ratione atque voluptas hic et fugiat.\nUt nihil quas facere.\nMinima nam atque est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1259, "Dignissimos tenetur facilis quo saepe labore.\nLaborum sed unde laboriosam qui maiores atque rerum consequatur.\nFacilis et repellat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1538, "Tempore dicta autem quasi maxime soluta nihil beatae dolores.\nAspernatur et dicta ut temporibus voluptas aut optio.\nQuia sapiente id placeat quae dolorem adipisci enim harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1520, "Ducimus enim molestiae dignissimos architecto consectetur alias voluptas.\nEt culpa voluptates sit.\nNisi exercitationem sit sequi nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1541, "Eos reiciendis placeat.\nCum voluptatem cum laborum et consequuntur.\nVero sit magni maiores quia sunt eos aperiam quam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1383, "Aut quia et aut occaecati.\nModi blanditiis voluptatum.\nQuo quia reprehenderit odit esse praesentium.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1261, "At adipisci rerum nemo voluptates error.\nDolore consequuntur voluptas dicta dolores aliquid maxime consequuntur accusamus sequi.\nVelit consequuntur quis exercitationem qui necessitatibus dolores ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1326, "Atque quasi amet et earum.\nUt eum ea sapiente est modi officiis consectetur et ut.\nSequi et sint expedita omnis eos voluptatem molestias.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1315, "Consequatur dignissimos delectus totam quia animi vero atque.\nQuam temporibus iure in.\nLaudantium doloremque nesciunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1365, "Qui sit dolores labore minima non et.\nTempore quia ea magni.\nQuia a deleniti ipsum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1344, "Officiis asperiores repellendus nostrum odit sit hic.\nSaepe rerum consequatur magnam.\nRecusandae ea quis ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1337, "Quibusdam fuga quidem et voluptatibus.\nUt dolores et molestiae.\nIncidunt sed sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1312, "Aut incidunt natus cumque vel voluptate.\nSunt repellendus eligendi ab labore saepe.\nVel nam nobis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1283, "Velit aut voluptatem hic in earum neque et.\nEaque consequatur autem dolorem magni numquam ea velit.\nOfficiis modi officia fuga dolorum nesciunt voluptatem labore aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1276, "Qui beatae sequi.\nEveniet sit autem est id molestias qui voluptatem veniam.\nTempora omnis temporibus voluptate eveniet repellat maxime quibusdam rerum nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1255, "Nihil consequuntur unde vel doloremque ex nihil reiciendis harum voluptate.\nId non corrupti corrupti officia voluptatem provident sed omnis.\nQuaerat sit doloremque hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1552, "Nulla assumenda aut.\nVitae non et.\nImpedit veniam aut quia tenetur et molestiae beatae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1532, "Placeat fuga sed iste quia.\nVoluptates et blanditiis voluptates praesentium sunt facilis nihil tenetur ipsam.\nSunt aut qui consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1514, "Et qui voluptatem molestiae facilis.\nDucimus non ut corrupti neque nostrum consequatur aliquid molestiae ut.\nVoluptatem voluptatem et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1454, "Sapiente maxime tenetur in quia nihil dignissimos sed atque culpa.\nQuo illo nisi.\nIpsam in aut ut autem officia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1436, "Aliquam aperiam placeat ab itaque quas non est.\nUllam maxime harum eaque id quos.\nQuae et numquam assumenda.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1407, "Iusto sequi alias est placeat itaque beatae totam illum.\nAutem voluptas quia nostrum eum quam itaque quis veniam.\nQuisquam cumque dolore quos magnam dolorem voluptas incidunt provident ipsam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1369, "Quia dolorem quaerat ipsam autem laborum laborum.\nRepellat nam quo libero temporibus.\nAliquam reiciendis quia in.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1311, "Quod eius omnis et.\nRepudiandae fuga est.\nVoluptas esse aliquam ut fugiat ab totam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1374, "Ratione possimus sunt illum maiores veniam sit quidem doloremque.\nAutem eveniet nihil quaerat molestiae consequatur est molestiae quod.\nQui eos doloribus nemo sapiente odio quod qui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1370, "Qui neque corporis illo maxime.\nMagni quis eaque.\nIllo doloremque est iusto ut inventore nesciunt nulla molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1347, "Deserunt nostrum sint.\nVel quod officia ad.\nOmnis dolorem blanditiis sint ea voluptatibus nihil possimus sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1499, "Mollitia quod dignissimos labore quasi doloremque eveniet in.\nTempora itaque illo eum praesentium assumenda.\nVoluptates repudiandae et cupiditate voluptate harum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1434, "Architecto repellendus reprehenderit.\nEum temporibus sapiente est quia sit vitae.\nConsequatur magni impedit officiis quos qui repellendus eveniet ipsum accusamus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1431, "Numquam et qui sed voluptas blanditiis laboriosam amet molestiae vel.\nEarum odio quo ipsum non et repellendus.\nVoluptatem ratione culpa.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1398, "Ea deserunt quia occaecati non dolore aliquam.\nQui similique deserunt incidunt sint odit ea nihil voluptate quas.\nVeniam dolorem sit vel.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1389, "Ullam hic debitis.\nQui nesciunt natus quasi velit labore.\nCorrupti labore quisquam ut iste quos temporibus ad quaerat ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1364, "Dolorum ducimus magnam autem vel officiis.\nIure eum id et autem architecto modi molestiae ipsam id.\nDolore quam quod.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1338, "Temporibus totam neque.\nQui fugiat fugit.\nEt officiis laborum autem dicta quaerat quisquam vel eius.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1324, "Id pariatur dolor.\nEt nihil inventore minima harum voluptatum.\nAlias et corrupti nulla consequuntur sint voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1281, "Sed atque eos.\nDistinctio provident voluptas eum ea dolor neque.\nOmnis esse et voluptatem eos atque facilis voluptatem aut dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1264, "Amet nobis quia id.\nQui repellat et quam fugit ut omnis perferendis.\nIpsa laborum qui dicta accusantium adipisci vitae voluptatum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1544, "Natus et occaecati delectus illum sunt est.\nQuo consequatur rerum distinctio eos nesciunt.\nCulpa doloremque eaque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1368, "Deleniti ullam laborum explicabo ipsam rem.\nEaque sint rerum sed odit natus et quis.\nCommodi est sed nisi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1306, "Quidem architecto quia exercitationem illum eligendi quos voluptas asperiores.\nExercitationem rerum sit quia laudantium laudantium veritatis.\nIure quibusdam est molestiae perferendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1278, "Quod molestiae sunt blanditiis voluptatum.\nConsectetur magnam unde veniam temporibus consectetur pariatur est illum.\nDolorum quaerat dolorum omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1445, "Excepturi maxime excepturi distinctio.\nQuidem sequi eius.\nPlaceat voluptates consequatur voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1308, "Voluptatem facere sit blanditiis nihil repellendus quia illo impedit veritatis.\nNihil sint est ea pariatur tempora aut.\nEt in blanditiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1334, "Illo suscipit eius rerum magnam.\nLaborum itaque voluptatem doloribus fugiat quam distinctio nobis ex.\nOmnis aut expedita placeat debitis quis eos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1375, "Quia quod inventore quisquam harum delectus aliquam non.\nPossimus id consequatur a maxime error id in.\nImpedit enim minus suscipit porro dicta quis assumenda.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1416, "Quaerat officia veniam reiciendis consequatur inventore.\nSed voluptatem sequi architecto laboriosam distinctio ut inventore.\nAut dolorem adipisci impedit incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1340, "Quia quo libero sit quam ut animi laboriosam beatae dolore.\nEa animi nemo aliquam laboriosam.\nRerum perspiciatis rerum vel debitis eum porro quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1294, "Id tenetur sed eligendi tenetur officiis molestiae.\nMagni reiciendis ut quis.\nEligendi voluptates aperiam libero maxime explicabo quae libero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1289, "Odit distinctio tenetur officiis necessitatibus.\nAssumenda est unde harum aut culpa natus voluptatem nobis dolorem.\nReiciendis iure doloremque consequuntur consequuntur libero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1286, "Ut nisi tenetur tempore magnam error.\nExpedita quia sit voluptas.\nEt accusamus fugiat sunt corporis laboriosam unde sunt asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1539, "Voluptas consequatur molestias unde maiores blanditiis quisquam.\nDeserunt et officiis asperiores odit qui.\nRepellat adipisci est non deserunt nesciunt neque quae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1527, "Inventore corporis quae ut at rem commodi.\nDebitis laboriosam quis nisi alias.\nMolestiae modi quas illo doloribus aut non vero esse libero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1525, "Et sunt nostrum hic quae ipsum modi aut a.\nIpsa et quos aut et cupiditate eos fuga.\nEst quibusdam quia quae voluptatem explicabo sunt consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1414, "Blanditiis omnis illum vel.\nRerum minus non.\nVoluptas magni repudiandae minima.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1505, "Quaerat adipisci minus quia odit rem.\nEt doloribus quo numquam iste consequatur.\nAtque voluptas voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1396, "Quia et tempore.\nRepudiandae veritatis consequatur.\nUt et sed in autem aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1333, "Minima minus quibusdam magni accusantium doloremque saepe quam.\nOccaecati numquam similique consectetur delectus modi nam at.\nVoluptas ut consequuntur dolores sequi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1317, "Incidunt nobis adipisci ut consequuntur aspernatur aut.\nCorporis reiciendis temporibus mollitia incidunt omnis deleniti enim nulla quibusdam.\nDistinctio velit tempore nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1292, "Accusantium beatae blanditiis rerum totam non voluptate et earum explicabo.\nSint esse consequuntur sunt corrupti rerum aspernatur aut nihil.\nVoluptatum nisi quas odit omnis aut sed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1543, "Sed omnis sint.\nEst corporis necessitatibus voluptatem sed deserunt.\nCum recusandae esse a qui ex et at velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1453, "Repellat aspernatur veritatis fugit blanditiis fugiat ipsum cum deleniti ex.\nIpsam et dolores sit tempora excepturi qui.\nExcepturi consequuntur similique labore cumque.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1424, "Et dolorum nemo non eveniet autem unde qui aut corporis.\nQuo dolore consectetur consequuntur.\nVelit magnam debitis aut id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1444, "Architecto et et enim.\nRerum voluptatem unde aspernatur deserunt.\nVoluptas est vero quo neque nisi cumque non iure pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1419, "Aliquam voluptatem distinctio magni in.\nEt non non architecto et nihil vel porro at nihil.\nUt qui error voluptas odit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1385, "Dolores placeat magnam aut.\nLaudantium in eum illum molestias totam.\nDelectus quas voluptatibus non non ut corrupti rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1463, "Doloribus debitis id possimus voluptatum nostrum iste.\nEt nihil dignissimos saepe ea enim aut sed eius unde.\nVero facere eum voluptatibus et omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1321, "Reprehenderit sed cumque quo modi.\nUt id mollitia.\nUt omnis voluptatem sunt iure eveniet repudiandae consectetur repellendus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1293, "Consequatur reiciendis ipsa corrupti debitis in at molestiae ea laborum.\nConsequatur dolor assumenda officiis iste quaerat accusantium.\nVoluptate in incidunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1274, "Consectetur delectus consequatur non et et quasi suscipit illum.\nVitae vitae omnis cum non sit nulla.\nSunt non quae nostrum harum iusto id omnis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1256, "Aperiam rerum esse quisquam id.\nAliquid quis placeat totam.\nOfficia unde itaque voluptatem sed dolores sunt expedita dolor aperiam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1254, "Ratione dolorem inventore velit.\nVeniam earum earum aliquam sint.\nCupiditate minima nemo qui ut occaecati ipsam vel hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1529, "Quasi labore quas quia velit rerum.\nPossimus sed illum et aut aut.\nEt tenetur voluptates voluptas sit voluptas possimus aut eum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1323, "Eos ullam repudiandae ipsam iste.\nEveniet voluptates cupiditate fugit doloremque at aut et.\nAt aut sint ipsam similique delectus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1524, "Porro recusandae totam quia occaecati.\nPossimus cum architecto repellendus quod.\nAut omnis maiores voluptate ab tempora qui maiores pariatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1484, "Omnis sed dolores provident.\nEst nihil ea magni nesciunt harum voluptates saepe est.\nQuia quis impedit et enim aut asperiores in fugiat ratione.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1468, "Quia itaque consectetur molestias.\nMolestiae in aut dolore rerum.\nCorporis quis maiores unde.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1217 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1466, "Quasi est consequatur dicta architecto expedita autem iure est.\nSint molestiae earum non porro consequuntur nulla voluptatem.\nQuidem et dolorem doloremque autem quaerat velit quidem officia voluptas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1457, "Culpa non eum velit sed.\nFacere id dolores dolor sit perspiciatis pariatur pariatur.\nOmnis doloremque cupiditate dolores tempora cum consectetur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1443, "Quos non voluptatem at qui ad nostrum provident ut voluptatibus.\nUt provident rerum quo facilis ut non doloremque ut.\nPlaceat cumque distinctio aut omnis quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1214 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1440, "Voluptatem error qui ab voluptatem amet.\nVoluptatibus doloribus facilis eos facere error autem doloremque.\nEst voluptates perferendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1522, "Fuga ut inventore cupiditate nam numquam qui sint et eos.\nAssumenda quia temporibus cumque aut magni et iusto qui enim.\nConsequatur sed in quis est voluptatem et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1328, "Impedit recusandae molestiae qui et unde sed ducimus.\nSunt officiis nihil adipisci nesciunt.\nQuo blanditiis est deserunt dolor adipisci nihil qui vitae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1346, "Vero eos atque soluta voluptatem.\nIllum molestias facere et et blanditiis dolorem.\nExcepturi voluptatem sint quia et officiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1350, "Sapiente id quia cupiditate et explicabo quod.\nDignissimos eum nostrum ratione qui et libero incidunt iure.\nDistinctio minima veritatis occaecati.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1296, "Quae temporibus suscipit sit dolorum suscipit quia.\nMinus corrupti nostrum ullam rerum sunt.\nCorporis rem labore commodi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1295, "Eius porro molestias aliquam.\nNatus in officia cumque itaque.\nDolorum ipsam id ea.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1290, "Recusandae aliquam est sint eos numquam nostrum perspiciatis dolor.\nOmnis non qui esse facilis provident occaecati vel asperiores reprehenderit.\nVoluptatibus tempora laborum inventore dolores placeat commodi dolores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1227, 1222 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1265, "Aliquam accusamus quo consequatur.\nDolor quia consequatur nihil eos quas.\nRerum alias molestiae non ut quo eos dolore tempore distinctio.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1227 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1548, "Nobis praesentium optio.\nAsperiores deserunt consequuntur.\nConsequuntur ab possimus officiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1547, "Amet laborum consequatur debitis qui tempore quidem vel excepturi voluptates.\nQui voluptates quisquam.\nBlanditiis sed et nihil omnis ducimus aut dignissimos.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1537, "Et quos ut sapiente minima odio adipisci et eaque voluptatum.\nQuod ullam modi architecto fugiat temporibus voluptatem enim nisi.\nConsequuntur quod quos autem dicta dolorem natus illo optio vero.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1498, "Quibusdam qui distinctio quas et perspiciatis consequatur et velit dolor.\nIste nihil et odit at.\nIncidunt dolorem ullam perferendis odit nobis aut aspernatur minus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1461, "Velit aspernatur dolor aspernatur ratione dolorum nulla itaque.\nExpedita placeat voluptas perspiciatis.\nConsequatur sint amet porro tempora sit eos quia modi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1459, "Doloremque fuga ex laudantium ut.\nSed est iure.\nPossimus assumenda tempora earum porro natus molestiae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1458, "Enim id eaque ipsa quia laudantium.\nEum repellendus sed qui.\nNihil laudantium animi totam voluptas rem quas.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1214, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1439, "Error unde consequatur enim aperiam alias aspernatur et sed sed.\nConsequatur qui tempora velit.\nRatione et nam nulla et adipisci cupiditate repudiandae dolorem veniam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1221 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1408, "Tempora distinctio similique accusantium minima.\nAutem quasi nesciunt voluptatem pariatur dolor.\nEt libero eum non in excepturi nesciunt sint quasi id.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1379, "Quia debitis asperiores consequuntur sapiente itaque enim.\nAspernatur ducimus atque maxime ut enim veniam recusandae.\nVel debitis et sed itaque iusto eum unde temporibus rem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1226, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1356, "Ut ab voluptatibus.\nDolores suscipit voluptatem illo inventore.\nNam occaecati aliquid incidunt culpa totam nihil optio corrupti ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1226 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1423, "Eaque quam molestias enim itaque fugiat in quae.\nPariatur vero praesentium blanditiis ullam ea amet quia.\nItaque labore corrupti sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1399, "In consequatur unde eos temporibus officiis expedita.\nNon commodi et eum accusantium omnis sapiente.\nIn delectus vero dolor rerum reprehenderit eos et consequuntur vitae.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1446, "Fuga quam molestiae odio nisi sed aspernatur nulla hic.\nEsse quam perspiciatis tenetur quis rerum vel esse.\nError quis commodi et praesentium iusto nihil est ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1358, "Id eligendi qui sit ea.\nCupiditate eum eius sit.\nVoluptatem architecto placeat qui minus ullam qui delectus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1402, "Iusto quibusdam possimus saepe labore voluptas distinctio impedit at.\nDebitis illum odio.\nNecessitatibus ex possimus qui occaecati et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1366, "Consectetur iusto laboriosam praesentium fugiat dolorum minima optio.\nConsequatur et autem earum quo et quibusdam autem omnis aut.\nOdit aspernatur quia accusamus qui quibusdam odit qui nesciunt.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1355, "Non ex accusantium fuga sed voluptas officiis perspiciatis.\nDolor inventore corporis.\nMolestias enim alias dolorum ut enim ab necessitatibus aut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1349, "Sed dolor voluptatem libero ea distinctio ea inventore aspernatur aliquam.\nQui aspernatur recusandae delectus vitae perferendis quisquam.\nQuasi rem deserunt voluptatem commodi voluptas sed sed aliquam voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1332, "Nemo nihil optio nisi expedita adipisci.\nQui mollitia est harum unde est quo magnam.\nReprehenderit voluptas accusamus voluptatem et aliquam dicta voluptatum blanditiis voluptate.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1305, "Voluptatum commodi earum dignissimos eum.\nEst quia labore perferendis velit et ex consequatur.\nArchitecto perferendis incidunt numquam est occaecati quibusdam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1219 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1300, "Sit reprehenderit consequuntur quaerat accusantium rerum ea.\nUt fugit magni.\nFugiat voluptatem consectetur nulla sunt minus et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1280, "Iste omnis accusantium labore quas fuga.\nNecessitatibus voluptatem qui.\nAt minima voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1219, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1405, "Quia quae non laborum modi.\nQuidem est molestiae consectetur ut consectetur iure omnis ducimus dolorem.\nSit aut aliquid quo ut quae et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1275, "Provident impedit at.\nAut enim aperiam voluptatem aut.\nEst ut inventore non ducimus nobis aliquam rerum mollitia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1270, "Aperiam sed dolore error repellat odio tempora.\nEius eaque reiciendis quidem voluptas praesentium.\nEst est nemo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1268, "Occaecati ea facilis.\nTemporibus consequatur modi sint ut esse quasi ut sed.\nFugit et ipsam hic nisi asperiores dicta.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1260, "Incidunt impedit id rerum.\nQuisquam eaque incidunt nihil.\nAut recusandae voluptates.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1515, "Odit atque ullam facilis fugit necessitatibus.\nRepellat fugit non itaque error aliquid et dolores voluptatibus voluptatem.\nQuidem ipsam commodi ad occaecati.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1215 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1513, "Et itaque et nihil.\nAut est similique quis pariatur iusto consequatur ab.\nEt autem voluptas excepturi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1213, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1506, "Iusto quis beatae non mollitia.\nUt perspiciatis rem asperiores nam quisquam.\nQuaerat reprehenderit quia et eum quaerat quas sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1493, "Sit magni nemo et dolores.\nArchitecto ut qui.\nError beatae corporis iste minus dicta velit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1486, "Magnam dolor sapiente ullam eum voluptas et quia ducimus quis.\nNostrum commodi assumenda quia ipsam eaque rerum.\nUt totam sed eos hic.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1271, "Explicabo tenetur esse alias quam.\nUt aut unde.\nExcepturi quidem aut voluptatem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1218 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1384, "Qui accusamus ut consectetur modi quasi aperiam voluptatum.\nIusto ut quibusdam iure consequuntur est.\nOfficiis a quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1221, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1410, "Ipsam ut a expedita ea quia.\nSequi non repellendus sequi molestiae distinctio sint molestiae.\nSit modi modi vel rerum quia ducimus.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1220, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1451, "Nulla dolores saepe nobis consequatur corporis est laborum assumenda.\nQui maxime qui accusantium ut ea asperiores quia ea.\nAccusantium tempore illum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1223 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1342, "Esse praesentium sit amet est ut.\nDucimus rerum dolorem consequatur expedita sed.\nBlanditiis tenetur nesciunt reiciendis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1225, 1216 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1319, "Possimus a nobis autem natus vel mollitia doloribus.\nQuia non consequatur reprehenderit et.\nEnim ullam porro rerum qui atque facere maiores rerum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1216, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1318, "Est ad et voluptates voluptatum voluptatem quis non inventore.\nVero commodi ipsa consectetur quo quam aut.\nDolor in eligendi quo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1413, "Assumenda consequuntur laboriosam a itaque amet.\nCommodi ut neque repellendus.\nQuae aut et laboriosam id odit hic dolores magnam.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1213 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1316, "Eius illo mollitia dolorem quis.\nEa amet quia similique ipsum molestiae laborum.\nVoluptatum iste iste.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1223, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1262, "Unde minus similique culpa ut et et soluta voluptatibus suscipit.\nAut ea qui qui harum ut aut a.\nIncidunt dolor velit eum ut quia iste laborum asperiores consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1222, 1225 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1542, "Non accusamus voluptates facilis maxime adipisci eligendi cum laudantium.\nSit non voluptates eaque iste.\nVel ut consequatur voluptatem aliquam natus et.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1232, 1228 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1503, "Vel dicta est ipsa soluta et commodi ullam necessitatibus.\nOfficiis aliquam aperiam.\nEt quibusdam beatae deleniti dolorem suscipit dolorem.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1218, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1490, "Ipsa ex rerum velit totam odit deserunt explicabo.\nQuasi et quia fugit quia quia ea voluptatem.\nDolor laborum non fuga et voluptatem sit explicabo.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1220 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1467, "Id iusto non quis unde quo quasi odit reprehenderit itaque.\nQuae eum commodi ut et qui voluptas et ut.\nCupiditate fuga ut expedita et eum nam sit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1224, 1224 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "MessageTime", "RecipientId", "SenderId" },
                values: new object[] { 1258, "Odit non sed vel.\nRerum nemo corporis explicabo asperiores dolores voluptas blanditiis ut.\nIncidunt est ea saepe consectetur asperiores.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1217, 1225 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 122, "7504 Kay Fort, South Alvinaside, Western Sahara", "Aliquid rem qui pariatur. Aut perferendis ut. Dolor ab sed assumenda debitis aut non cumque a. Recusandae asperiores sit eum voluptatem est rerum. Facilis molestias consequatur ut et blanditiis libero eum cum.", false, "voluptates", 1231, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 124, "1037 Jenkins Fall, South Cade, Norway", "quae", false, "iusto", 1225, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 125, "587 Smith Ramp, Charlesport, Gabon", "Libero est provident dolores aperiam. Quisquam eveniet et est deserunt sunt. Autem ut est ut ut ut praesentium.", false, "aut", 1219, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 128, "733 Stokes Radial, Schowalterton, Somalia", "Harum unde ducimus et voluptatem qui et.\nEveniet repellat autem deserunt est cum nesciunt non quo.\nProvident debitis consequatur quaerat nobis quia enim.\nOfficiis autem sapiente nesciunt quo et omnis reiciendis hic.", false, "iusto", 1219, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 129, "08815 Judd Via, Ledaburgh, Guadeloupe", "Distinctio omnis autem.", false, "eos", 1219, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 126, "4950 Schuppe Plains, Donnyland, Kyrgyz Republic", "In quia illo accusantium exercitationem aut vitae. Magnam quam dignissimos similique quis voluptate. Libero numquam ut. Et soluta numquam aut incidunt itaque inventore nam at. Blanditiis eveniet voluptas eaque soluta et dolor voluptate architecto.", false, "accusantium", 1228, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 121, "2027 Steve Islands, West Aarontown, Poland", "Dolorum omnis iure.\nOdit temporibus architecto fugit quibusdam labore similique veritatis voluptatem.\nVoluptatum perferendis amet quae.\nMinima et necessitatibus cumque commodi delectus sunt.\nNemo sit maxime sed quibusdam sit voluptatem.", false, "rerum", 1228, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 123, "059 Emma Mews, Ebbaborough, Macao", "accusantium", false, "ut", 1227, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 130, "72587 Klein Square, Minnieville, Singapore", "Ex beatae incidunt eum.", false, "et", 1215, (byte)0 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[] { 127, "3266 Donnelly Canyon, Stephanialand, Bosnia and Herzegovina", "Et qui sunt ut.\nTempora laborum quibusdam occaecati sed provident.\nVoluptates enim voluptatem eos voluptatem ab nobis.\nEst soluta amet perspiciatis temporibus.\nQuia numquam omnis.\nEius provident vel ipsam sed qui voluptatibus autem laboriosam.", false, "sequi", 1228, (byte)0 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1565, 1553, "The Football Is Good For Training And Recreational Purposes", "4b2e3e59-945a-d1a7-9c15-922b2dfb4f2b", "Small Plastic Salad", null, 5295u, (ushort)0, 130 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1571, 1560, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "74d3fccf-aedc-b677-a363-9269fc75eca4", "Refined Frozen Soap", null, 9698u, (ushort)5, 127 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1570, 1561, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "dbac5da3-039d-1fc8-1dc0-c4436d94da49", "Handmade Concrete Car", null, 3398u, (ushort)5, 127 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1564, 1556, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "ddaaf806-463e-cb5f-8c31-45f36beeb551", "Generic Metal Bike", null, 5025u, (ushort)2, 121 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1563, 1559, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "984356ee-d823-8dd8-712e-873cba56655b", "Handcrafted Wooden Pizza", null, 6771u, (ushort)1, 121 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1581, 1556, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "4faec3dc-a7d3-20db-d4a9-d7dbfe96365d", "Gorgeous Fresh Pants", null, 1919u, (ushort)0, 123 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1579, 1554, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "8e982597-0e06-04e7-f5d5-717aebbe8cd6", "Refined Cotton Keyboard", null, 682u, (ushort)3, 123 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1578, 1561, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "f1dfd973-83d8-a6d7-b606-37ebf590144f", "Licensed Plastic Pants", null, 903u, (ushort)5, 123 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1582, 1556, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "33aa2856-3081-1dd1-c720-740ae911fbc0", "Sleek Soft Pizza", null, 6328u, (ushort)2, 124 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1573, 1554, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "0ded2c0e-183b-45fe-b52c-d0d4e2ab66a9", "Awesome Frozen Cheese", null, 7812u, (ushort)5, 124 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1567, 1561, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "86cfbbd8-05e9-e7e6-4e07-20435c4b9b80", "Incredible Plastic Computer", null, 4350u, (ushort)0, 124 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1580, 1562, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "510f2bb7-97cd-cf61-689d-59b3ea489fa7", "Fantastic Plastic Computer", null, 5654u, (ushort)4, 129 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1568, 1555, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "9cffb84c-991a-a1ca-f370-847a4c638264", "Rustic Frozen Shoes", null, 5593u, (ushort)4, 129 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1572, 1553, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "cccc07a4-fa4f-539e-0029-0ca02f53436e", "Handcrafted Granite Pizza", null, 3374u, (ushort)5, 128 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1569, 1557, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "352bd7d7-a9c7-8950-a813-3a310649cdb5", "Generic Wooden Mouse", null, 1475u, (ushort)6, 128 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1566, 1561, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "5c38162b-1c36-6cea-69b3-8300171370f7", "Tasty Wooden Hat", null, 7507u, (ushort)1, 128 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1576, 1560, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "a2a98127-715f-6975-1a5e-cef3f8e12a41", "Sleek Rubber Computer", null, 867u, (ushort)7, 125 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1574, 1558, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "76fca6d7-3dea-32a4-ba21-be220d9117e7", "Gorgeous Rubber Gloves", null, 1921u, (ushort)2, 125 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1575, 1557, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "c344f6a8-7908-c241-b7f4-35951b885b77", "Refined Rubber Chips", null, 7352u, (ushort)9, 127 });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[] { 1577, 1558, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "e57c746b-cb54-64b0-5a11-9b86d09e6346", "Intelligent Cotton Chicken", null, 6440u, (ushort)2, 127 });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StoreId",
                table: "Goods",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodUserBasket_SelectedGoodsId",
                table: "GoodUserBasket",
                column: "SelectedGoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId1",
                table: "Order",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderGood_OrderId",
                table: "OrderGood",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OwnerId",
                table: "Stores",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_UserId",
                table: "UserBaskets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodUserBasket");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrderGood");

            migrationBuilder.DropTable(
                name: "UserBaskets");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
