using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WUI.Migrations
{
    public partial class kkdd233276 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PicturePath = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Birtday = table.Column<string>(type: "text", nullable: true),
                    RegistrationDay = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    MessageBody = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    ShipmentOptions = table.Column<string>(type: "varchar(32)", nullable: false),
                    State = table.Column<string>(type: "varchar(32)", nullable: false),
                    UserId1 = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<byte>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    PathToPhotoGallery = table.Column<string>(type: "text", nullable: true),
                    MainPhotoName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                    BasketsId = table.Column<int>(type: "integer", nullable: false),
                    SelectedGoodsId = table.Column<int>(type: "integer", nullable: false)
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
                    GoodId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
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
                values: new object[,]
                {
                    { 1553, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Movies", null },
                    { 1561, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Automotive", null },
                    { 1560, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Industrial", null },
                    { 1559, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Books", null },
                    { 1558, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Beauty", null },
                    { 1562, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tools", null },
                    { 1556, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Grocery", null },
                    { 1555, "The Football Is Good For Training And Recreational Purposes", "Tools", null },
                    { 1554, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Industrial", null },
                    { 1557, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Health", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birtday", "Name", "PhotoPath", "RegistrationDay" },
                values: new object[,]
                {
                    { 1223, "41379 Okuneva Drive, Lake Lizzie, Saint Pierre and Miquelon", "11/26/1993 21:47:29", "Osbaldo Bailey", null, "05/23/2021 06:34:10" },
                    { 1230, "350 Theodore Spur, South Deondreton, Mali", "04/25/1992 12:08:54", "Leonora Shanahan", null, "01/31/2021 21:59:04" },
                    { 1229, "37591 Walsh Groves, South Judge, Morocco", "12/15/1993 05:04:19", "Larissa Cremin", null, "10/10/2021 20:11:35" },
                    { 1228, "6179 Larue Shoals, Port Fredrick, Egypt", "03/07/1981 10:09:02", "Leilani Kemmer", null, "08/23/2021 19:50:05" },
                    { 1227, "5463 Damion Circles, Cleotown, Micronesia", "12/14/1986 18:56:55", "Kali Jenkins", null, "04/14/2021 17:55:24" },
                    { 1226, "12745 Santos Estates, Port Cordeliatown, Lao People's Democratic Republic", "03/12/1988 11:43:46", "Guido Cruickshank", null, "01/16/2021 06:19:21" },
                    { 1225, "041 Kristopher Flats, Lake Isobel, Algeria", "06/18/1992 22:18:19", "Petra Turner", null, "07/17/2021 23:04:41" },
                    { 1224, "026 Zboncak Causeway, East Ceasar, Senegal", "12/26/1989 23:13:39", "Scotty Jacobson", null, "05/26/2021 13:29:57" },
                    { 1222, "6782 Ledner Divide, Khalidbury, India", "07/18/1992 22:05:16", "Katlyn Streich", null, "08/30/2021 03:12:02" },
                    { 1217, "6361 Rafaela Vista, New Clark, Mongolia", "05/07/1986 07:04:25", "Jed Daugherty", null, "10/12/2021 17:40:13" },
                    { 1220, "608 Yundt Camp, Virginieside, Eritrea", "10/05/1997 12:01:43", "Mossie Mills", null, "02/03/2021 04:19:02" },
                    { 1219, "5364 Bogan Dale, South Schuyler, Estonia", "02/03/1981 00:45:11", "Keira Pagac", null, "01/12/2021 06:46:14" },
                    { 1218, "57710 Travis Trace, Lake Thaddeus, Italy", "02/18/2000 04:34:54", "Laila Kshlerin", null, "02/17/2021 07:17:50" },
                    { 1231, "5084 Christine Flat, Ernserview, Tokelau", "08/14/1985 22:05:47", "Ophelia Bradtke", null, "02/18/2021 22:28:26" },
                    { 1216, "964 Rusty Run, Kameronmouth, Monaco", "08/16/2000 18:18:32", "Jedidiah Harber", null, "10/08/2021 03:51:36" },
                    { 1215, "68454 Huel Parks, Port Gardner, Afghanistan", "07/07/1986 12:28:41", "Rashawn Predovic", null, "01/16/2021 18:43:04" },
                    { 1214, "7119 Braulio Rest, Lake Zachery, Mozambique", "01/23/1980 21:54:58", "Toney Douglas", null, "10/28/2021 09:36:16" },
                    { 1213, "4837 Brent Spring, Port Heathermouth, Svalbard & Jan Mayen Islands", "12/23/1991 09:13:25", "Rosario Boyle", null, "03/04/2021 12:15:00" },
                    { 1221, "985 Auer Track, North Herminioburgh, Denmark", "04/20/1997 13:51:39", "Elinore Cruickshank", null, "03/18/2021 06:27:21" },
                    { 1232, "6422 Elwyn Loaf, East Salma, Montserrat", "01/01/1994 13:38:01", "Saul Price", null, "06/08/2021 03:45:29" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "StoreId", "UserId" },
                values: new object[,]
                {
                    { 1250, 123, 1214 },
                    { 1245, 126, 1222 },
                    { 1249, 129, 1223 },
                    { 1248, 128, 1232 },
                    { 1251, 130, 1219 },
                    { 1244, 129, 1225 },
                    { 1247, 123, 1228 },
                    { 1243, 130, 1220 },
                    { 1246, 128, 1216 },
                    { 1252, 122, 1214 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "MessageBody", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 1418, "Facilis eum nisi aut rerum sit.\nEa incidunt sed et est perspiciatis autem magnam natus nobis.\nQuas consequatur odio magni consequatur et nemo.", 1229, 1228 },
                    { 1405, "Quod dolor et consequuntur non rerum consequuntur.\nAccusantium officiis iure error eos repellat eos minus amet.\nExercitationem exercitationem excepturi dicta fugit blanditiis ut at labore ut.", 1229, 1214 },
                    { 1398, "Voluptatem et commodi est sequi sed mollitia nulla.\nIure aut quibusdam neque perferendis voluptatem qui.\nUnde neque sed culpa saepe architecto magni omnis aperiam soluta.", 1214, 1229 },
                    { 1355, "Quidem explicabo enim sed commodi non sit assumenda id.\nQuis eum natus illo et sit nobis qui suscipit pariatur.\nIn ut perferendis dolor quisquam excepturi debitis quia.", 1229, 1215 },
                    { 1349, "Pariatur alias optio ut explicabo qui perspiciatis quis.\nEos aut non quis sunt libero repellendus.\nDolores eos ea assumenda asperiores tenetur id eveniet.", 1229, 1229 },
                    { 1345, "Non omnis quod.\nRepellat eos et.\nProvident id nisi qui qui est exercitationem.", 1223, 1229 },
                    { 1312, "Quia esse doloremque vitae.\nSimilique dolor velit id aut quas explicabo dignissimos fuga.\nAut distinctio esse voluptas fugiat provident ut earum qui.", 1229, 1229 },
                    { 1295, "Consectetur est in voluptas quaerat dolorum sed cupiditate.\nRepudiandae ut praesentium est voluptates illo deserunt nam et.\nImpedit iste magnam asperiores.", 1224, 1229 },
                    { 1283, "Expedita eius quia ratione voluptatum et qui.\nDelectus facere doloremque aut provident et.\nMinima repellendus mollitia blanditiis explicabo cupiditate aliquid.", 1222, 1229 },
                    { 1282, "Libero voluptatem aut.\nHic ipsam delectus ut.\nSed a cumque dignissimos perspiciatis enim tempora reprehenderit.", 1229, 1221 },
                    { 1279, "Tenetur ipsum eos.\nQuae rem quam.\nConsectetur deleniti aperiam quia.", 1214, 1229 },
                    { 1265, "Doloribus ducimus aspernatur dolores sit qui cum accusantium autem.\nOfficiis dolores accusamus possimus nulla voluptatem rerum sint commodi.\nOccaecati inventore nihil et consequuntur autem.", 1229, 1220 },
                    { 1511, "Asperiores fugit est suscipit dolorem quia omnis.\nLabore autem ab ut.\nQuam assumenda est enim error quasi tempore et.", 1214, 1228 },
                    { 1490, "Eum velit impedit doloremque est aliquam quaerat perferendis quod.\nNatus sit animi distinctio temporibus omnis accusantium.\nEt rerum repudiandae nobis iure.", 1228, 1228 },
                    { 1439, "Enim consequuntur eveniet.\nVoluptatem placeat blanditiis deserunt aperiam quia error ea.\nCupiditate in ut sed et repellat laboriosam.", 1229, 1215 },
                    { 1443, "Consequatur aut aut.\nAnimi consequuntur sit illum quia reprehenderit iusto.\nLabore enim pariatur numquam rerum reiciendis sit fugit dolor quisquam.", 1226, 1229 },
                    { 1450, "Qui nisi iusto ullam qui debitis ullam a.\nAutem voluptates voluptas aliquid amet sit doloremque quia dolores rerum.\nQuod aspernatur excepturi.", 1229, 1213 },
                    { 1465, "Error ad odio officia sit.\nDolorem quam facilis molestias pariatur id doloribus aut non.\nSoluta adipisci soluta praesentium et veritatis laudantium sit quis facilis.", 1229, 1222 },
                    { 1366, "At reiciendis dolores at quis.\nQuos qui sed quaerat.\nNihil vel nihil ipsa aspernatur sit ut.", 1230, 1217 },
                    { 1336, "Et possimus enim vero.\nSit minima explicabo.\nDolor sit sunt.", 1230, 1215 },
                    { 1317, "Et voluptatum est quis minus reprehenderit autem deserunt dolorem natus.\nDucimus similique reprehenderit excepturi praesentium non laborum consequuntur quibusdam.\nFugiat magnam voluptates quidem dicta ipsa voluptate.", 1230, 1227 },
                    { 1305, "Rerum voluptate numquam sed ut quis.\nBlanditiis magnam maiores.\nIn beatae dignissimos et voluptas.", 1223, 1230 },
                    { 1300, "Qui natus sed fugiat consequatur.\nDicta omnis commodi autem neque nemo.\nMinus perspiciatis minima possimus exercitationem optio sint totam at.", 1230, 1216 },
                    { 1298, "Vitae molestiae et rerum rerum voluptatem commodi eligendi.\nIure quia est et alias ab cupiditate nobis et dolores.\nOfficia non veritatis consequatur est.", 1227, 1230 },
                    { 1289, "Velit necessitatibus ea nam iure sunt itaque iusto totam.\nIn dicta dolores voluptate.\nVoluptates sit veniam est dignissimos eligendi unde molestiae cumque.", 1230, 1226 },
                    { 1272, "In quis tenetur.\nEa eligendi dignissimos et ipsa non repudiandae magnam voluptatem.\nEa quia ex qui.", 1214, 1230 },
                    { 1538, "Delectus sit quae.\nEum eos dolorum.\nOmnis delectus quia nihil quia saepe similique.", 1225, 1229 },
                    { 1525, "Earum non ad.\nProvident fugit ipsum aut excepturi quod.\nVoluptatem magni voluptatibus rem adipisci.", 1217, 1229 },
                    { 1513, "Explicabo et officia impedit accusantium quisquam in.\nDolor nesciunt eos et sint accusantium ut.\nEt in itaque.", 1217, 1229 },
                    { 1491, "Aliquam distinctio reprehenderit voluptatem est rem aut optio quam tenetur.\nProvident distinctio quia nam incidunt velit.\nEt illo inventore.", 1223, 1229 },
                    { 1335, "Aut at aut saepe quidem quam.\nLibero reiciendis repudiandae nihil doloribus debitis.\nEst deleniti voluptas autem corporis tempore sint cumque.", 1218, 1227 },
                    { 1471, "Iure totam blanditiis harum omnis veniam.\nAb molestiae et necessitatibus distinctio dicta debitis rem facilis dolores.\nQuae quo voluptates fugiat aut dolores omnis hic ad.", 1229, 1224 },
                    { 1466, "Omnis eaque molestiae eligendi et.\nModi magnam doloremque.\nQui earum architecto et excepturi dicta reiciendis similique.", 1223, 1229 },
                    { 1475, "Tempora molestias soluta impedit.\nCum numquam quod numquam voluptas adipisci in voluptatum odio.\nQui id quae molestiae et nihil facilis porro quia.", 1228, 1219 },
                    { 1392, "Voluptate aut est consequuntur.\nDeleniti qui qui vitae.\nQuo numquam quia mollitia non cum minima.", 1217, 1227 },
                    { 1467, "Velit sint temporibus quis.\nEt vel aut numquam quis voluptatem corporis qui.\nRem nihil repudiandae.", 1228, 1213 },
                    { 1460, "Blanditiis provident enim aut sint.\nLaudantium velit culpa perferendis nulla et facilis non est fugit.\nSed sed facilis quia quas nobis rem facere eligendi.", 1213, 1228 },
                    { 1280, "Adipisci quaerat aut.\nReiciendis velit aut.\nRecusandae consequuntur qui.", 1227, 1228 },
                    { 1268, "Ut a nihil sit.\nIpsum tempora necessitatibus debitis.\nDolores et ab maiores porro labore.", 1228, 1219 },
                    { 1259, "Sint et nemo aperiam.\nA fugit quis et doloremque perferendis accusamus in rerum.\nDolor quas voluptatem assumenda sint numquam sit.", 1214, 1228 },
                    { 1256, "Dolor ad ea itaque ad.\nAut enim consectetur accusantium dicta.\nSed porro molestiae tempore quo maxime eos officia accusantium.", 1217, 1228 },
                    { 1389, "Odio qui porro consequatur sint ex veniam nulla.\nIpsam commodi minus et voluptatem ut ut asperiores.\nId voluptatem eum nostrum soluta illo.", 1219, 1227 },
                    { 1543, "Cum ut corporis dolores deserunt.\nSit est at amet laboriosam.\nSit voluptas laboriosam ipsa aut nam.", 1227, 1227 },
                    { 1531, "Delectus iusto non libero alias ipsa quae.\nIusto nostrum est doloribus.\nRatione excepturi dicta aut rerum odio modi pariatur sunt nam.", 1225, 1227 },
                    { 1520, "Similique accusantium dolorum.\nEt cum sed ipsum rem nihil ducimus fugiat quae.\nPariatur dolore et accusamus sunt consequatur ipsam qui dolorem consequatur.", 1221, 1227 },
                    { 1516, "Mollitia quasi ipsa enim.\nAut amet ab et corporis.\nEst tenetur repellendus eius numquam est reiciendis odit quaerat aut.", 1219, 1227 },
                    { 1497, "Illum ut nobis atque.\nSimilique optio nulla iusto eligendi iure sed.\nEsse temporibus vel architecto.", 1227, 1219 },
                    { 1482, "Dolore nobis nam quibusdam delectus debitis.\nDolores numquam eaque dolor accusamus tenetur in ullam corrupti eos.\nQui consequatur iste quaerat cupiditate ipsum dicta.", 1215, 1227 },
                    { 1473, "Impedit vero laborum ea pariatur excepturi dicta similique iste.\nSapiente vero animi consequatur et aut.\nMagni ea quisquam laborum atque ut non.", 1222, 1227 },
                    { 1468, "Quidem est voluptatum ut sint omnis error hic.\nQui beatae dolorem qui.\nAliquid occaecati quidem.", 1213, 1227 },
                    { 1464, "Occaecati ut et et eligendi dolorum minus consequatur voluptas dolores.\nVoluptatem recusandae qui iste.\nEst et aut quo.", 1227, 1221 },
                    { 1459, "Sunt cupiditate reprehenderit quaerat maxime quos accusantium fugiat laboriosam et.\nReprehenderit ut nihil ea beatae.\nVero dolore dolorum quaerat et id est voluptas id.", 1220, 1227 },
                    { 1285, "Doloremque dignissimos quibusdam reprehenderit autem repellat nemo optio eos amet.\nQuia reiciendis soluta impedit ea magnam dolorem aliquam.\nConsequuntur suscipit qui et.", 1228, 1216 },
                    { 1461, "Quos qui eligendi voluptatibus laudantium aut provident veritatis.\nEt assumenda itaque nam quis nulla.\nDoloribus laborum qui quae in sapiente.", 1228, 1226 },
                    { 1287, "Possimus nulla exercitationem sint aliquam nobis repudiandae iste voluptas optio.\nRecusandae voluptatibus perferendis repellat sapiente aspernatur qui.\nQuia magni nisi.", 1213, 1228 },
                    { 1307, "Vel aut beatae necessitatibus qui ut et.\nVoluptatem ut asperiores minus aut quisquam.\nEaque qui amet qui magnam sunt assumenda cum praesentium ut.", 1223, 1228 },
                    { 1447, "Qui quos accusamus aut.\nMagnam non autem.\nSaepe voluptas culpa vitae repudiandae non officiis et minus.", 1228, 1219 },
                    { 1376, "Voluptas error maiores molestiae quaerat similique quod totam delectus.\nId ipsam totam tenetur eos velit dignissimos beatae.\nUt error vel et voluptatem perspiciatis corrupti consequatur aut.", 1230, 1222 },
                    { 1440, "Non voluptatum vitae cum odio et.\nEt neque cum omnis eos est quaerat rem illo placeat.\nProvident quae dicta.", 1228, 1216 },
                    { 1437, "Nam et enim amet voluptatem et officiis voluptate aut.\nQuas labore exercitationem dolores.\nQuis fugiat impedit in quia praesentium sint qui soluta voluptatem.", 1228, 1218 },
                    { 1408, "Qui omnis quia fuga velit fugiat.\nPerferendis eum eveniet porro aspernatur aut corporis sit ut repellat.\nFuga qui pariatur eaque aperiam sit tempore qui.", 1214, 1228 },
                    { 1406, "Maxime similique odio unde.\nQuaerat ut reiciendis rerum non aut quia ex quis.\nPraesentium deleniti esse qui earum nemo repellendus omnis illo.", 1220, 1228 },
                    { 1400, "Debitis qui quaerat doloribus ut asperiores sed occaecati.\nEt mollitia iusto fugiat natus eaque.\nIn voluptatem aut et sequi officiis.", 1218, 1228 },
                    { 1397, "Laboriosam tempora cumque assumenda beatae ipsam nulla cumque.\nAutem voluptas quidem non molestiae omnis inventore asperiores ut aut.\nEarum voluptatem sit minus illum.", 1219, 1228 },
                    { 1372, "Error hic culpa voluptatibus architecto omnis ab tenetur.\nMinus deserunt sed quidem nihil sit nesciunt est.\nReiciendis numquam earum quia possimus expedita impedit est.", 1228, 1221 },
                    { 1360, "Sed voluptate eum quas autem repellat excepturi aspernatur voluptas veniam.\nInventore ut voluptatem vel non sed commodi qui labore ipsa.\nQuaerat debitis illum perspiciatis id.", 1215, 1228 },
                    { 1331, "Fugit corrupti enim rerum quasi velit temporibus laborum.\nSed enim eos quia praesentium eum non voluptas consequatur dolores.\nVelit praesentium optio quod maiores praesentium deserunt quis.", 1223, 1228 },
                    { 1353, "Perferendis ut sit dolor id nihil blanditiis ut.\nCum doloribus dolore.\nDolorem dignissimos quisquam reiciendis ipsum.", 1227, 1214 },
                    { 1359, "Et similique suscipit aut.\nVoluptatem est dignissimos eum est sapiente qui velit.\nMinima sequi et expedita expedita omnis sit officia.", 1225, 1227 },
                    { 1319, "Qui ut rerum sint aut culpa.\nCorporis voluptate tempora.\nEt est aliquid ut est hic ea explicabo magnam.", 1219, 1228 },
                    { 1375, "Dolor odio rem qui nisi ut ea cupiditate consectetur.\nTemporibus est et.\nOfficia doloribus est dolor cumque perspiciatis non sunt numquam.", 1225, 1227 },
                    { 1292, "Voluptatem mollitia quis enim cumque est modi.\nVitae optio iste.\nVoluptatem est dicta autem exercitationem et animi sit nemo rerum.", 1217, 1228 },
                    { 1411, "Reprehenderit est quae accusamus repellat deleniti sapiente.\nEt dolorum qui dolorem labore.\nDolorem est officiis et numquam tempore non in vel.", 1230, 1217 },
                    { 1442, "Quidem impedit esse voluptatem consectetur.\nA fugiat et a.\nSit sit fugiat culpa voluptatibus nostrum ullam.", 1217, 1230 },
                    { 1421, "Deserunt aut eaque.\nAnimi vel reprehenderit iure.\nSint nesciunt culpa est vero dolorem ea consequuntur soluta cupiditate.", 1230, 1225 },
                    { 1318, "Placeat adipisci dolores autem.\nSit similique iste.\nVoluptas ad et ex.", 1217, 1232 },
                    { 1314, "At rem corporis sint enim sint ea at.\nQuidem cupiditate voluptate fugiat voluptas enim rerum numquam eligendi autem.\nNon maiores labore eum ullam ut.", 1232, 1214 },
                    { 1308, "Sit maiores facere maxime est asperiores fugit minus.\nDicta possimus sunt.\nTenetur amet omnis.", 1225, 1232 },
                    { 1294, "Voluptatum recusandae harum velit aut ut ipsam est.\nAccusantium adipisci sequi facilis ipsa eligendi.\nDignissimos hic in maxime quae.", 1227, 1232 },
                    { 1293, "Quas sed in sit reprehenderit.\nAut itaque eos reiciendis eaque similique.\nFacere voluptate rerum et dolorum minus consequatur dolorem.", 1232, 1232 },
                    { 1288, "Et mollitia reiciendis sed quis provident quae nulla corrupti.\nNesciunt ab vitae ullam molestiae soluta odio.\nDoloremque adipisci dolorum ea iste minima sequi et eius.", 1230, 1232 },
                    { 1257, "Eum dolore quis ea consectetur nemo culpa consequatur.\nMaiores assumenda exercitationem ut magni repudiandae quos dolorem fuga doloremque.\nAnimi ipsum minus quam.", 1232, 1213 },
                    { 1541, "Ut dolorum consequatur.\nAdipisci id amet sunt dolorem cumque laborum.\nMolestiae itaque aut ut.", 1231, 1214 },
                    { 1534, "Dolore provident ad sed nobis veniam repellat harum.\nOccaecati cum ipsum aut.\nRerum cumque provident vero et ut quis.", 1222, 1231 },
                    { 1501, "Alias at natus vel illum dolorem corporis numquam.\nAutem ipsa dolorum est aliquid.\nNihil dolorum modi delectus quam tempora quo.", 1216, 1231 },
                    { 1489, "Debitis ea sint molestias et et occaecati magnam consequatur velit.\nUt praesentium et dolore sequi et deleniti.\nDistinctio est numquam perferendis consequatur eos.", 1225, 1231 },
                    { 1479, "Blanditiis aut nisi odit libero maxime est ut accusamus.\nSoluta ut error quis saepe et libero sit quidem.\nFacilis asperiores numquam voluptatum nesciunt laboriosam qui mollitia.", 1216, 1231 },
                    { 1476, "Non omnis iusto atque odio quas repudiandae nisi.\nMaxime enim veniam ullam.\nDolorem fuga corporis natus esse libero voluptas deleniti.", 1231, 1226 },
                    { 1457, "Quia corrupti ipsum ratione ea omnis numquam.\nQui aut impedit et.\nMinima id repellendus quos sit sapiente nesciunt.", 1231, 1217 },
                    { 1454, "Quam accusantium non.\nNecessitatibus odio ad sed quis et.\nUt sed nulla nihil vero odio maxime impedit reprehenderit.", 1231, 1227 },
                    { 1340, "Reprehenderit omnis rem nihil labore.\nAssumenda architecto aut incidunt.\nUllam voluptatum sint minima quis et praesentium officia magnam qui.", 1232, 1227 },
                    { 1356, "Eum nisi voluptas impedit laudantium.\nEaque cumque dolore ut consequuntur ut soluta consequatur esse.\nVelit autem ut occaecati aut doloribus explicabo inventore consectetur aliquam.", 1232, 1223 },
                    { 1369, "Minus dolorum necessitatibus beatae atque soluta quia itaque.\nEa earum omnis necessitatibus id.\nEst explicabo quis et quia velit dicta ad non itaque.", 1223, 1232 },
                    { 1379, "Debitis dolores omnis voluptatem optio dolorem dignissimos sunt.\nFuga corporis architecto et vel.\nIpsa expedita enim velit alias esse omnis est repellendus consequatur.", 1223, 1232 },
                    { 1540, "Culpa in consequatur doloremque praesentium necessitatibus non explicabo.\nLaboriosam voluptatem commodi dolores sed.\nUt pariatur nesciunt sed est et quibusdam rerum.", 1232, 1222 },
                    { 1536, "Eveniet est totam.\nDolorem iste qui sint.\nQuisquam eos deserunt similique maiores.", 1224, 1232 },
                    { 1522, "Amet possimus qui voluptatem dolor ea.\nIpsum eos et aspernatur dolore est aliquam blanditiis rem.\nFuga ab omnis voluptatibus omnis repellendus.", 1232, 1222 },
                    { 1512, "Sunt enim ratione ipsam quia autem numquam aut.\nOmnis et quibusdam soluta.\nMolestias non ullam suscipit temporibus ipsum.", 1232, 1229 },
                    { 1509, "Numquam saepe iusto.\nOdio harum harum animi hic dolores est nulla soluta.\nQuia eveniet assumenda cupiditate corrupti nulla sint est natus est.", 1229, 1232 },
                    { 1502, "Cupiditate et officiis et.\nAb in dignissimos aut non officia officiis nesciunt.\nConsequatur inventore corporis.", 1217, 1232 },
                    { 1500, "Non eum ut occaecati dolorum omnis provident dignissimos et ut.\nQuia ea occaecati et tempora amet reiciendis ducimus consequuntur.\nUt expedita et.", 1220, 1232 },
                    { 1451, "Occaecati eaque exercitationem sit nam quasi natus enim voluptatibus vel.\nDoloremque qui architecto qui est ab a est rerum voluptatem.\nVoluptatem dolorem excepturi vel dicta temporibus itaque atque fugiat aut.", 1231, 1222 },
                    { 1499, "Temporibus provident nostrum.\nEst omnis natus et quis aut.\nEos officia et eos dolor placeat ut numquam nihil adipisci.", 1232, 1214 },
                    { 1486, "Incidunt animi et est id iure officia qui magni occaecati.\nEt fugiat reiciendis sapiente odit voluptas.\nFuga eum quaerat omnis qui.", 1229, 1232 },
                    { 1483, "Ducimus qui ullam tempora sit molestiae et dolor.\nOdit iusto id voluptate repudiandae officiis vero consequatur fugit.\nQuas sit non officia illo ut.", 1220, 1232 },
                    { 1430, "Quo id ullam.\nAutem sed non tempore laborum corrupti illum et qui.\nDolor ut et sint veritatis.", 1231, 1232 },
                    { 1424, "Aut expedita consequatur consequuntur blanditiis aperiam id et aliquid.\nNon atque enim.\nEt id numquam rerum saepe ab nulla.", 1216, 1232 },
                    { 1423, "Nisi qui perspiciatis doloribus voluptas debitis fugit iusto.\nIpsam magnam sed corporis et quidem labore dolor.\nPerspiciatis excepturi distinctio tempore recusandae tempore omnis laborum repellat.", 1222, 1232 },
                    { 1420, "Provident veniam et.\nSint autem nulla libero quis nisi soluta perferendis voluptatem quos.\nNemo tenetur alias impedit aliquid necessitatibus natus.", 1232, 1230 },
                    { 1419, "Ut ut quae odio vel.\nAutem perspiciatis quia autem ut et consequuntur.\nSed quia praesentium sequi facere quia.", 1232, 1220 },
                    { 1488, "Blanditiis perferendis tenetur exercitationem velit eos quam quaerat.\nEt ut quia.\nSequi placeat officia soluta nihil error neque voluptas ipsa corporis.", 1232, 1220 },
                    { 1417, "Odit tempora consectetur perferendis sit molestiae omnis assumenda.\nAdipisci inventore possimus assumenda distinctio cupiditate voluptas.\nUnde fugit sint eligendi inventore.", 1230, 1220 },
                    { 1441, "Porro est voluptatem eaque ullam qui dolores rerum iste.\nUt ipsum labore architecto perferendis cupiditate eaque sed.\nNobis id eum autem sunt est.", 1218, 1231 },
                    { 1426, "Aspernatur odit repudiandae.\nIncidunt esse veritatis repellendus dolorem id dolor.\nNumquam ea quia commodi.", 1220, 1231 },
                    { 1269, "Cumque officia ut ut et et ut sit et.\nDolor quis inventore sed voluptas molestias cupiditate nam fuga.\nVelit qui esse.", 1218, 1231 },
                    { 1267, "Nemo non maxime atque consequatur consequatur.\nQuis quae nemo molestiae iure.\nOmnis omnis sed hic laboriosam dolorem quod.", 1213, 1231 },
                    { 1261, "Quaerat dolores rerum.\nQui eveniet eos aut sunt asperiores sit qui vel.\nAut ipsum deserunt.", 1231, 1230 },
                    { 1260, "Vel temporibus occaecati.\nRecusandae qui quas culpa nisi excepturi aut nisi dicta.\nAtque delectus libero.", 1231, 1222 },
                    { 1546, "Placeat at quos.\nIpsum laboriosam error illum nemo.\nOfficiis qui rerum consequatur labore.", 1230, 1224 },
                    { 1533, "Rerum perferendis aut.\nNon officia quis quam et debitis assumenda harum sit.\nMolestias quaerat dolor nihil sequi esse officiis cumque velit.", 1230, 1220 },
                    { 1532, "Sed temporibus alias minus.\nUt sed amet minus.\nId reprehenderit qui et rerum qui ea.", 1225, 1230 },
                    { 1517, "Nisi et est sed sit quisquam ut.\nQuos eum veniam eveniet dolores porro.\nAb consectetur rerum iste quos voluptatem doloremque dolorum.", 1216, 1230 },
                    { 1515, "Odit dolorem in aut ut quia.\nAsperiores voluptatem vel.\nEa autem ut quisquam in velit reprehenderit perspiciatis consequatur consectetur.", 1214, 1230 },
                    { 1510, "Qui consequatur eveniet tempora inventore molestiae.\nQuis vel sit cumque pariatur error doloremque delectus et rem.\nExcepturi sunt minima sit deserunt.", 1230, 1226 },
                    { 1507, "Nostrum dolorem ut ea ipsam dolorem fugit.\nDeleniti eum libero corporis vel est molestias.\nNihil cupiditate soluta voluptatem qui distinctio.", 1230, 1215 },
                    { 1484, "Neque dolores impedit maiores deleniti voluptatem ab quasi quod tenetur.\nDoloremque omnis quia distinctio facere architecto dicta ea.\nIure nam aut aut animi saepe provident et.", 1230, 1219 },
                    { 1481, "Voluptas aliquid ab et quos et ea laborum iure velit.\nEveniet perspiciatis maiores.\nBeatae atque perferendis qui error.", 1230, 1224 },
                    { 1470, "Adipisci sunt ipsa maxime tenetur.\nDeserunt quia voluptatum exercitationem dolores quo magni esse debitis.\nNesciunt voluptates qui voluptas quaerat at rerum.", 1229, 1230 },
                    { 1275, "Tempore omnis libero et molestiae aperiam voluptas.\nEveniet quod magni.\nCorporis inventore rerum rerum nulla molestias est.", 1227, 1223 },
                    { 1270, "A est magni ut aut tempora.\nSunt quasi in optio eligendi et.\nAlias sequi nihil quae explicabo ipsum beatae ut veniam.", 1231, 1214 },
                    { 1276, "Ratione odit necessitatibus.\nDolore pariatur et dolorem ducimus rerum error amet.\nOptio quas aspernatur ipsum placeat eius sapiente occaecati est soluta.", 1227, 1231 },
                    { 1291, "Iusto et quidem itaque.\nQui aspernatur eos.\nCumque et molestiae illo labore totam placeat pariatur tempora magni.", 1231, 1223 },
                    { 1296, "Et eius culpa alias et libero.\nAut aut consectetur et doloribus.\nOmnis voluptates libero consequatur minus.", 1231, 1230 },
                    { 1415, "Et ratione adipisci atque officiis.\nPerspiciatis ab consequatur consequuntur ullam et exercitationem.\nSaepe facilis exercitationem debitis.", 1231, 1230 },
                    { 1402, "Ipsum eaque et veritatis laudantium atque nihil ut quia dolores.\nDolores vero cupiditate.\nQui amet assumenda aut atque velit facere non sed inventore.", 1215, 1231 },
                    { 1396, "Nesciunt dolor aut aut quo.\nDolore temporibus sit autem.\nEx tenetur et aspernatur.", 1214, 1231 },
                    { 1388, "Eius et dolor non et quibusdam veniam reiciendis velit.\nEaque ducimus excepturi.\nAut aut quis cupiditate reiciendis repudiandae odio ipsam pariatur.", 1225, 1231 },
                    { 1386, "Ad alias et corporis neque voluptas.\nPlaceat voluptas commodi quia.\nSit nesciunt incidunt itaque molestiae perspiciatis sapiente quisquam.", 1231, 1228 },
                    { 1378, "Rerum recusandae est vel.\nError rerum amet debitis rem est omnis molestiae recusandae.\nOfficiis dolor voluptatem et veritatis.", 1231, 1225 },
                    { 1373, "Sunt ut dolor eveniet eos voluptas eum alias et.\nUt doloribus est.\nCorrupti doloribus alias.", 1231, 1218 },
                    { 1432, "Earum amet doloribus iste quia ipsum et ut et.\nUllam tempora ut deserunt et soluta possimus quo delectus recusandae.\nUnde ipsa consequatur architecto quam nemo et odio rerum.", 1220, 1231 },
                    { 1368, "Asperiores et accusamus maiores harum.\nSint eveniet hic ad ut nihil.\nId ratione soluta ipsam voluptas asperiores mollitia assumenda quasi laborum.", 1231, 1213 },
                    { 1363, "Repellendus temporibus iste ea aut.\nQuisquam illum ea aut porro optio odit.\nCommodi eius dolores voluptas quibusdam aliquam.", 1224, 1231 },
                    { 1339, "Fuga esse et et vero quas.\nTempore ab esse eveniet aliquid a fugiat quisquam.\nOfficiis aut nulla.", 1231, 1227 },
                    { 1328, "Accusamus libero minus ex voluptas possimus veritatis et voluptas enim.\nNam vel voluptatem placeat eum eligendi sed autem aut.\nCulpa aspernatur a impedit aut possimus sed voluptatem autem.", 1231, 1219 },
                    { 1324, "Officiis sed quia labore ut sit veritatis impedit.\nSaepe cumque voluptatibus maiores quidem.\nConsequatur amet fugiat possimus quia id.", 1231, 1222 },
                    { 1323, "Aspernatur totam fugiat facere sint blanditiis est ut labore aut.\nCupiditate fugiat ea doloribus iusto dolor fugit et quam.\nNisi ut molestiae qui dolores nobis.", 1231, 1231 },
                    { 1321, "Eum autem nam sed repellat cum beatae sit maiores voluptas.\nIste tenetur quidem quasi repellat rerum sit quidem nisi.\nSaepe quibusdam similique est dolorem molestiae nesciunt debitis non dolores.", 1231, 1224 },
                    { 1315, "Deleniti repellendus ut.\nItaque dignissimos quasi dolorem non voluptate inventore sit.\nReprehenderit quasi dolorem blanditiis.", 1221, 1231 },
                    { 1365, "Sit vero fuga voluptas praesentium nulla qui praesentium perspiciatis in.\nOdit nisi quia iusto assumenda fugit est blanditiis.\nDucimus pariatur sapiente repellat minima vel.", 1231, 1218 },
                    { 1263, "Architecto quia ipsam quis dolore dolor et animi delectus et.\nDucimus placeat deleniti aut est voluptatem ducimus.\nPariatur sunt dolore.", 1227, 1216 },
                    { 1530, "Optio velit et assumenda consequatur a possimus est cumque consequatur.\nInventore in hic doloribus.\nVoluptas libero perspiciatis consequatur est neque fuga sint eaque incidunt.", 1226, 1221 },
                    { 1544, "Vel perspiciatis optio.\nAb deleniti voluptas accusamus minus.\nAtque maiores aut libero repellat deleniti.", 1232, 1214 },
                    { 1428, "Iste dolor eveniet.\nExercitationem labore culpa delectus eaque veritatis dolor quia ex similique.\nEligendi incidunt error aliquam ducimus quia sint earum exercitationem.", 1221, 1220 },
                    { 1422, "Harum fugiat pariatur et quia.\nEst fugit ut facilis.\nItaque molestiae quos consequatur sint nobis provident nostrum fuga ullam.", 1220, 1221 },
                    { 1410, "Dolores aliquid similique.\nQui temporibus tenetur nobis occaecati.\nEum id aut velit sit tempore accusantium.", 1221, 1213 },
                    { 1371, "Ut ea qui adipisci distinctio eos sit sit.\nQuae aut eveniet ipsa cum porro modi.\nSed soluta dolorem quod provident temporibus ipsum.", 1221, 1220 },
                    { 1351, "Libero rerum voluptatum recusandae.\nQuae a qui vero ea sapiente non iste est.\nAutem et quis et.", 1220, 1221 },
                    { 1333, "Et dignissimos et autem sunt.\nEst illum esse nisi aliquid impedit eum autem dolore quibusdam.\nExpedita qui unde ea inventore unde perferendis quis.", 1221, 1215 },
                    { 1304, "Quae modi saepe.\nSequi et occaecati non omnis mollitia et.\nNesciunt suscipit earum accusamus mollitia error.", 1221, 1220 },
                    { 1286, "Ut animi iste.\nDeserunt asperiores quidem.\nVel omnis eum similique minima fugit facere aut.", 1220, 1221 },
                    { 1545, "Aut adipisci quod sed praesentium distinctio sunt suscipit officia.\nVoluptatem architecto facilis maxime dolore.\nEst id et ut consequatur.", 1220, 1216 },
                    { 1480, "Minima ex quia sapiente aut et consequuntur velit corporis.\nNeque reiciendis voluptas repudiandae iusto adipisci delectus ut.\nQuo architecto enim voluptatum velit laudantium.", 1220, 1215 },
                    { 1414, "Quam dolor natus ut nulla accusamus sint deleniti expedita.\nAut ullam quo veritatis quidem error.\nEt saepe voluptates veritatis ex voluptatibus distinctio corporis qui porro.", 1213, 1220 },
                    { 1409, "Est rerum corporis beatae.\nMinima rerum praesentium deleniti quaerat eveniet.\nVoluptatibus eaque omnis consequatur autem aut eligendi incidunt.", 1220, 1219 },
                    { 1364, "Dignissimos porro molestiae.\nAd delectus odio aut.\nAut accusamus qui beatae commodi occaecati.", 1220, 1216 },
                    { 1344, "Enim dolorem quia quibusdam pariatur ut porro sit voluptas.\nAmet non vel id id omnis harum et delectus.\nVelit nulla qui.", 1220, 1219 },
                    { 1342, "Officia accusamus eum fugit est ducimus ullam eius.\nInventore molestiae voluptatem sed nam nihil nisi distinctio consequatur.\nCorrupti in quaerat.", 1217, 1220 },
                    { 1448, "Vero ut voluptas qui sapiente sint aut qui ullam facere.\nVel qui aperiam eveniet illo.\nRatione nulla voluptatibus id praesentium nam.", 1221, 1216 },
                    { 1338, "Nihil ex ipsum ut.\nVoluptas aut non impedit temporibus aspernatur sapiente incidunt et.\nMolestias incidunt repellat est voluptatem itaque expedita veniam nostrum.", 1220, 1219 },
                    { 1452, "Quaerat nam libero impedit voluptas.\nBeatae quia quis sed.\nEx officiis ullam.", 1221, 1220 },
                    { 1462, "Neque tenetur nulla quo aliquam modi.\nTempore impedit dicta accusamus voluptatem.\nSit facilis sequi illo nihil est voluptas nihil.", 1218, 1221 },
                    { 1352, "Laboriosam est deleniti dolorum voluptatibus veniam laudantium laborum quia dolores.\nQuo maxime repellat cum et et amet sit explicabo.\nSed et beatae illum dolore nostrum.", 1216, 1222 },
                    { 1329, "Praesentium molestiae quod ut.\nBeatae voluptas sed alias illo praesentium.\nModi distinctio officiis totam id officia qui sed recusandae.", 1222, 1213 },
                    { 1326, "Dolores iure hic at impedit.\nEt esse debitis et impedit dolor et nesciunt aliquid.\nQuia reprehenderit sunt velit in eum expedita.", 1220, 1222 },
                    { 1325, "Non possimus error et ea repellendus assumenda.\nVelit in ut id aliquid.\nQui aut quis rem aut quisquam quisquam.", 1219, 1222 },
                    { 1313, "Omnis ut porro suscipit voluptatibus nobis est exercitationem.\nTotam dignissimos quisquam aut quam alias veniam.\nUt et non nihil ut labore ut unde.", 1222, 1216 },
                    { 1303, "Eius incidunt quaerat.\nImpedit quo doloribus velit ratione architecto.\nIpsam voluptas et animi aut.", 1222, 1216 },
                    { 1301, "Veritatis sequi debitis.\nFacere et omnis quo eos consequatur officia.\nQuibusdam nam soluta voluptatem reiciendis eum.", 1220, 1222 },
                    { 1290, "Optio delectus quisquam.\nUt tenetur optio adipisci ut.\nQuam repudiandae suscipit maxime alias voluptas et et.", 1222, 1217 },
                    { 1278, "Nam ipsam illo molestiae sed vel voluptatem.\nVoluptas eum et earum corrupti praesentium sapiente quod commodi.\nQui quos in recusandae consequatur id recusandae rerum exercitationem.", 1221, 1222 },
                    { 1273, "At nemo ut sit deserunt.\nSunt nam ea illum odio odit quas deleniti et.\nIn repudiandae dolor et ut non non.", 1222, 1218 },
                    { 1271, "Ipsam velit omnis debitis ipsum quos suscipit.\nRem molestias rerum similique id.\nVoluptas atque laudantium consectetur vel fugiat possimus.", 1216, 1222 },
                    { 1524, "Velit harum aut vitae cumque maiores.\nAd dolorum reiciendis tempore molestiae.\nItaque quos quas sint deleniti reiciendis libero.", 1221, 1221 },
                    { 1518, "Rerum numquam fuga beatae enim.\nOfficiis excepturi delectus impedit autem maiores porro vitae.\nSunt velit sunt.", 1216, 1221 },
                    { 1503, "Ex voluptas omnis qui.\nEaque optio reiciendis possimus et dolorem accusamus quia.\nExercitationem molestiae et aliquid in quod laudantium.", 1221, 1215 },
                    { 1492, "Laboriosam non non sequi voluptates ratione.\nRerum dolores quod.\nMollitia fuga deserunt et dicta modi et et quo et.", 1221, 1213 },
                    { 1455, "Voluptatem eum voluptatem distinctio enim vitae eum minus.\nEst vitae ea quaerat est minima dignissimos inventore nihil.\nReprehenderit architecto recusandae molestiae quos ut qui repudiandae labore.", 1221, 1216 },
                    { 1316, "Mollitia sit at.\nIn qui et ut sint.\nEst ut aut maxime voluptate pariatur dolorum.", 1220, 1214 },
                    { 1277, "Autem quasi et harum autem est eos omnis harum error.\nQuo repellendus voluptatum mollitia qui exercitationem amet.\nFugit quia amet dolores maxime laboriosam aut quisquam omnis mollitia.", 1213, 1220 },
                    { 1255, "Occaecati nihil nulla perferendis libero hic.\nConsequuntur nisi unde similique ut et amet possimus quo.\nEius labore est ipsa enim eos atque dolorem ea consequatur.", 1220, 1217 },
                    { 1494, "Qui nesciunt fugiat fugiat sequi repellendus deserunt.\nNulla at corrupti dolor tempora officiis.\nVoluptatibus perferendis at voluptas commodi optio dolor aut.", 1214, 1217 },
                    { 1380, "Accusamus sit et enim ducimus consectetur.\nDolore repellat ullam earum sit iusto eum dolore eos.\nEos deleniti inventore exercitationem modi sapiente autem.", 1217, 1214 },
                    { 1350, "Neque quae esse rerum sequi commodi porro.\nNostrum perspiciatis dolore occaecati.\nQuis autem aut blanditiis iusto dolorum veritatis.", 1216, 1217 },
                    { 1334, "Et doloribus aliquid voluptatum veritatis sit eveniet atque.\nConsequatur voluptatibus numquam.\nAd consectetur corporis sunt et illum autem culpa necessitatibus.", 1217, 1214 },
                    { 1514, "Aut aut eum inventore perspiciatis autem officia accusantium dolor molestiae.\nEst illo sint provident nam amet reprehenderit facere ut aliquam.\nIllum ut doloribus et et tempora molestiae deserunt.", 1216, 1215 },
                    { 1445, "Cupiditate qui voluptas nisi voluptatem quibusdam iste saepe veniam non.\nSed aspernatur modi non consequatur.\nIpsa reprehenderit voluptatem ab soluta voluptatem.", 1215, 1216 },
                    { 1412, "Ut a ex et libero.\nDolores necessitatibus est voluptate nemo optio ea dolore dolorem expedita.\nEveniet odio distinctio.", 1216, 1214 },
                    { 1399, "Tenetur ut ut consequuntur unde et molestiae quasi atque aut.\nNon quos est accusamus dolor.\nNon rerum qui.", 1213, 1216 },
                    { 1343, "Nisi nulla natus libero.\nAsperiores a aut et.\nNemo quas sed voluptas voluptates est expedita quia explicabo.", 1216, 1214 },
                    { 1258, "Fuga necessitatibus fuga suscipit id veniam libero.\nAccusantium reiciendis est quia aut dignissimos vitae.\nOmnis hic magni magni impedit fugiat consequatur omnis in aut.", 1216, 1214 },
                    { 1385, "Eos dolorem quam rerum nulla aliquam.\nQuis quidem minima aut eum quasi voluptas tempore modi.\nAspernatur vero quia.", 1214, 1215 },
                    { 1539, "Corporis voluptate ad et.\nNecessitatibus eum sit ea.\nQui quos voluptatem amet qui quas non eaque officiis.", 1214, 1214 },
                    { 1458, "Eum beatae doloremque iure et molestias doloribus aut.\nPossimus suscipit expedita deleniti et possimus quos adipisci omnis.\nAb veniam autem perspiciatis.", 1214, 1213 },
                    { 1453, "At veritatis consequatur error quisquam consequuntur qui.\nMaiores assumenda suscipit dolores reiciendis.\nSoluta nihil quisquam totam accusantium eum dolore assumenda cum architecto.", 1213, 1214 },
                    { 1361, "Sit et incidunt eos.\nRepudiandae nemo earum aut laborum qui.\nOfficiis vel ipsam aspernatur qui suscipit.", 1214, 1214 },
                    { 1548, "Quia voluptas vel officiis nihil et nobis consequatur expedita.\nLibero iure ipsam velit vel perferendis dolore.\nAutem doloremque est accusamus quos veniam voluptas.", 1217, 1216 },
                    { 1302, "Est dignissimos dolorem et omnis veniam voluptatum aliquid dolorem.\nDicta eum dolorem nemo et quia recusandae est commodi laborum.\nNobis molestiae tenetur at a et perferendis.", 1215, 1218 },
                    { 1330, "Omnis est accusamus repellat non quas reprehenderit.\nEum cupiditate sint necessitatibus consequatur.\nNumquam consequuntur hic odio.", 1218, 1216 },
                    { 1370, "Id molestiae illum saepe odio.\nOptio ullam aut officiis temporibus eos dolores aperiam ut quod.\nVoluptas debitis aliquam dolorum ipsa reiciendis labore voluptates.", 1213, 1218 },
                    { 1254, "Quis quidem voluptatem ipsa quas.\nCommodi autem est at voluptas vero aut voluptas.\nAut ut repellat sunt et non dolorum nihil sapiente voluptatem.", 1218, 1220 },
                    { 1456, "Accusamus aut autem veritatis distinctio et omnis.\nAperiam ut saepe ut assumenda qui dignissimos dolorem vitae neque.\nEt est ea sit sunt.", 1213, 1219 },
                    { 1438, "Necessitatibus qui id sequi sed autem et.\nQuia beatae quia rem facilis vel labore.\nLaborum sequi eius.", 1219, 1215 },
                    { 1395, "Vitae minima expedita nisi.\nOccaecati alias sit quia beatae odit.\nLaudantium cupiditate blanditiis eum.", 1216, 1219 },
                    { 1391, "Quo nam voluptatum aut.\nError totam autem aut ullam voluptas.\nAutem blanditiis minima officia ut ab vero.", 1219, 1218 },
                    { 1362, "Tempora consequatur et et molestiae ratione.\nNobis fugiat quaerat et ipsa sequi tenetur.\nDolorem omnis eveniet totam.", 1219, 1218 },
                    { 1348, "Nisi alias numquam facere asperiores veritatis error labore.\nSaepe nisi odit magni distinctio reiciendis aut similique sapiente et.\nSed dolor tenetur et.", 1219, 1215 },
                    { 1262, "Excepturi nostrum incidunt autem ea.\nQuam illo veniam unde perspiciatis veniam unde consequatur voluptas.\nVoluptas libero minima aperiam et quos consequatur aliquid.", 1227, 1221 },
                    { 1341, "Est ipsam eius est voluptate dolor necessitatibus ut.\nEx accusantium debitis doloremque voluptatem voluptatem.\nEt reiciendis provident nam blanditiis expedita.", 1219, 1214 },
                    { 1264, "Ratione nobis iusto sit quis debitis velit eligendi officiis nisi.\nUt dolor ullam aut non quia et est enim modi.\nIste veritatis assumenda voluptatibus ut consequuntur et.", 1219, 1218 },
                    { 1253, "Et totam libero dolorem quia velit.\nDolore consequuntur voluptas nam deserunt architecto rerum molestiae reiciendis ducimus.\nVoluptatem beatae numquam non ipsa voluptatem ea deleniti.", 1219, 1217 },
                    { 1529, "Voluptatem eveniet voluptas ut quia voluptates quod blanditiis aut.\nExpedita est placeat sunt.\nSint eius ipsum ipsa iure numquam possimus non sit.", 1215, 1218 },
                    { 1495, "Ut et laudantium.\nPossimus eum et beatae qui qui.\nFacilis minus ducimus.", 1218, 1215 },
                    { 1431, "Quidem consequatur quae.\nNesciunt natus animi adipisci.\nIure doloribus earum tempore.", 1218, 1218 },
                    { 1394, "Magnam quo culpa veniam.\nExpedita modi est voluptatem occaecati molestiae aut veritatis.\nCommodi explicabo ipsa eos at.", 1218, 1217 },
                    { 1377, "Repellat omnis ut voluptatem.\nUt voluptatem illum eius voluptates mollitia debitis necessitatibus iure.\nImpedit maxime ea fugit est dolores.", 1214, 1218 },
                    { 1266, "Quasi dolorem atque sint aut voluptatibus qui velit est placeat.\nQuia placeat saepe totam expedita quam consectetur.\nDolores facere sit.", 1219, 1218 },
                    { 1387, "Harum molestias aut repellendus qui cum quis repudiandae distinctio.\nVel ratione earum esse hic et occaecati voluptate provident est.\nEveniet quasi corrupti et illum nesciunt.", 1222, 1220 },
                    { 1374, "Quis aspernatur sint iusto unde dolor et adipisci.\nAd iure minima ratione eos beatae voluptas vel corporis et.\nHarum nesciunt fuga dolorum harum modi eius aliquam ut nam.", 1222, 1213 },
                    { 1425, "Veritatis tempore quia accusamus odio voluptatem aut quia minima voluptates.\nDeserunt fugiat quia nisi id.\nNeque dolores qui maiores quia in voluptas et.", 1221, 1222 },
                    { 1390, "Porro autem et numquam et necessitatibus et ea necessitatibus voluptatem.\nIste nobis neque nam beatae corrupti.\nIste voluptates dolorem similique eveniet voluptatem reprehenderit voluptatibus.", 1225, 1223 },
                    { 1383, "Recusandae nostrum similique aut.\nMolestias inventore id et sunt veniam soluta voluptatem soluta.\nModi aut aperiam excepturi accusantium ullam odit accusamus fuga.", 1222, 1225 },
                    { 1357, "Corporis est tempora et non alias numquam nostrum.\nAccusamus vel unde harum animi ex qui repellat.\nEst nemo deserunt soluta sit.", 1225, 1219 },
                    { 1309, "A vitae aut.\nMagnam recusandae ad eaque.\nQuia et perspiciatis sequi necessitatibus numquam ad.", 1220, 1225 },
                    { 1274, "Ad temporibus est voluptatum quia mollitia.\nDolor perspiciatis veritatis esse molestiae consequatur necessitatibus.\nDoloribus soluta quo voluptatum qui.", 1224, 1225 },
                    { 1550, "Quia quis numquam vitae laboriosam enim explicabo perspiciatis rerum harum.\nMinus labore reprehenderit eligendi blanditiis omnis.\nOmnis iste debitis modi quasi voluptate sit in quaerat ut.", 1224, 1221 },
                    { 1527, "Nesciunt qui consequatur nesciunt amet exercitationem cum commodi.\nDucimus quis voluptatem omnis ut beatae distinctio.\nReiciendis expedita deserunt velit magnam impedit unde inventore reiciendis.", 1224, 1221 },
                    { 1485, "At illo vel perferendis suscipit.\nDucimus aliquam ratione et et sed.\nEt ut est veritatis accusamus fugiat.", 1217, 1224 },
                    { 1469, "Velit qui vel ut quia rerum recusandae.\nIpsa distinctio et qui aut sunt.\nUnde ipsa magnam at fugit recusandae eos.", 1224, 1219 },
                    { 1444, "Quas et aut consequatur et aliquid.\nIn amet et.\nProvident sint deserunt explicabo et sit et similique.", 1224, 1214 },
                    { 1436, "Ducimus saepe nesciunt dolorem odio reprehenderit ut.\nSuscipit occaecati repellendus numquam voluptatem fugit.\nSint quidem porro in ratione quo.", 1224, 1218 },
                    { 1416, "Aut blanditiis eos optio.\nAdipisci eveniet libero.\nVoluptatem expedita sed.", 1220, 1224 },
                    { 1393, "Iure ut porro ea aperiam.\nEt minus quos.\nOdio harum recusandae occaecati aliquam quas sequi ad esse doloribus.", 1216, 1224 },
                    { 1384, "Est aspernatur occaecati totam qui laborum iste aut.\nQuia repellendus dolor suscipit dolore ea distinctio.\nDolorum cumque enim omnis consequatur et est.", 1224, 1215 },
                    { 1381, "Aspernatur corrupti doloribus blanditiis quidem.\nAut eius nisi possimus aperiam et tempore ut rerum ipsa.\nVoluptas qui similique aperiam non.", 1223, 1224 },
                    { 1401, "Quaerat animi recusandae facere corporis ipsam.\nSoluta dolorum ea voluptatibus.\nOfficiis adipisci architecto commodi corrupti.", 1221, 1225 },
                    { 1404, "Eum esse consequatur nostrum a debitis.\nQuas eum inventore.\nUt incidunt omnis velit voluptatem deleniti minima debitis consequuntur minima.", 1222, 1225 },
                    { 1433, "Aspernatur sunt debitis ut.\nSint laudantium et architecto et labore voluptatem autem.\nDeserunt deleniti nemo amet sapiente rerum praesentium repellat reprehenderit.", 1218, 1225 },
                    { 1434, "Repellendus et quasi non aut ullam.\nVitae dolore sit.\nEsse accusantium quibusdam.", 1225, 1215 },
                    { 1526, "Qui blanditiis ipsum incidunt dolorum eum.\nEt praesentium nihil.\nOmnis dolorum consectetur sint doloremque officiis.", 1215, 1226 },
                    { 1521, "Hic quo alias.\nDolorem repellendus dolores.\nExercitationem praesentium quaerat quam vel et eum pariatur veniam inventore.", 1226, 1226 },
                    { 1505, "Omnis natus est vitae fuga tenetur omnis eligendi.\nDolor suscipit hic facilis aut in dolores sit.\nMolestias praesentium ipsam ut id laborum.", 1220, 1226 },
                    { 1498, "Id in dolorem et excepturi esse reiciendis harum nihil et.\nQuia maiores maxime eius illum aut dicta atque dolore maiores.\nTenetur voluptate enim.", 1225, 1226 },
                    { 1493, "Aut nobis enim.\nEt deleniti necessitatibus incidunt ut.\nConsequatur sed rerum a temporibus ad non animi eaque sint.", 1226, 1222 },
                    { 1446, "Molestiae corrupti nesciunt explicabo excepturi qui.\nNatus vel architecto quae blanditiis.\nDolore sit exercitationem.", 1221, 1226 },
                    { 1429, "Vel eaque commodi ducimus nostrum ex.\nMaiores excepturi sint eligendi distinctio id iure sint incidunt qui.\nVoluptatem in velit eius voluptatum voluptas magnam odit.", 1221, 1226 },
                    { 1413, "Exercitationem quibusdam odit voluptatem.\nAsperiores illum ut hic.\nOptio earum consequatur itaque adipisci tenetur voluptatem aperiam.", 1217, 1222 },
                    { 1427, "Eaque ut nostrum esse soluta a reiciendis delectus rerum.\nAut odio quos possimus assumenda.\nIpsum repellat illum.", 1226, 1218 },
                    { 1367, "Magnam fugiat vel sed occaecati.\nEveniet fuga quae facilis.\nDebitis quia est quam non magnam illo.", 1215, 1226 },
                    { 1354, "Et neque aut dolores modi ratione in.\nMinus asperiores ea voluptates et sed et illum delectus.\nAut reiciendis et quia et odit.", 1222, 1226 },
                    { 1311, "Eum quas consequatur esse a.\nNon et ut animi velit rerum.\nPariatur a quis voluptas sed ut saepe delectus.", 1225, 1226 },
                    { 1306, "Amet et numquam id quos et velit.\nEveniet harum alias velit quas ut dolorum aspernatur vel cum.\nEt unde iusto.", 1215, 1226 },
                    { 1528, "Hic mollitia assumenda aspernatur eum nemo est.\nAut quae quia sequi possimus nisi.\nEos eos non.", 1214, 1225 },
                    { 1496, "Ut praesentium dolor error in quia dolorum voluptatem et dignissimos.\nVoluptates eaque ex eligendi sunt eaque vel nobis.\nIure aspernatur expedita enim voluptatem quam in repudiandae consequatur sed.", 1223, 1225 },
                    { 1474, "Accusamus eum laboriosam neque voluptas minima consequuntur similique quidem.\nVoluptatibus dicta reiciendis at et quo.\nPossimus doloribus ratione quia nisi quasi et soluta.", 1213, 1225 },
                    { 1407, "Eos tempore nihil qui.\nTempore minus rerum.\nQuam ducimus dicta rem numquam asperiores velit commodi voluptate voluptas.", 1214, 1226 },
                    { 1346, "Voluptatem consectetur iure nemo doloribus aut in.\nQuis autem officia.\nEt atque aliquam aut voluptatem tenetur.", 1222, 1224 },
                    { 1347, "Voluptas consequuntur qui quasi alias non ut et et.\nEst ex et occaecati ut expedita et est.\nVoluptatum ut corrupti molestiae aut et corporis eos.", 1218, 1224 },
                    { 1332, "Odio omnis molestiae distinctio nesciunt iste.\nPraesentium explicabo id.\nDignissimos quia est facere eum nobis eum repudiandae.", 1224, 1218 },
                    { 1337, "Et unde accusamus commodi voluptas ipsam numquam ut ipsum saepe.\nExplicabo voluptate officia et sit est itaque et quo.\nNon consequatur recusandae eveniet qui eveniet dolor totam.", 1220, 1224 },
                    { 1358, "Reprehenderit magnam nihil occaecati quia provident qui.\nRerum cumque eveniet.\nPlaceat consequatur sed et voluptatum et sequi ut ipsum reprehenderit.", 1222, 1223 },
                    { 1297, "Sed saepe aut vitae et dolorum pariatur.\nEarum optio sed in.\nOptio ut rerum temporibus exercitationem officiis dicta necessitatibus ut.", 1217, 1223 },
                    { 1284, "Omnis dolor id possimus quaerat ut omnis rerum minima quam.\nEarum sapiente minus quae minus cupiditate.\nEt molestias pariatur.", 1214, 1223 },
                    { 1281, "Et occaecati suscipit minus et molestiae.\nEt voluptate velit corrupti voluptatem adipisci animi sint praesentium modi.\nQuasi atque quod fuga.", 1222, 1223 },
                    { 1552, "Aperiam quae maiores ullam aut ut omnis perferendis.\nQuis corrupti vel nam.\nMaxime voluptate dicta quod accusamus placeat ducimus adipisci.", 1218, 1222 },
                    { 1403, "Aut cumque nam hic sint molestias exercitationem eius voluptatibus.\nQuis qui est veniam voluptatum consequuntur aliquid corrupti iusto.\nNumquam soluta quia quisquam qui.", 1223, 1216 },
                    { 1551, "Aut quae dolores voluptatibus est porro soluta neque sit.\nDolorem reprehenderit sunt sequi est.\nVoluptas dolorum cumque.", 1222, 1216 },
                    { 1542, "Expedita est dolore voluptas dolor consectetur.\nAd ut incidunt repellendus est rerum vitae dignissimos.\nDeserunt est quibusdam qui quam dolor molestiae autem aperiam id.", 1220, 1222 },
                    { 1523, "Qui corrupti unde aut.\nIpsum eligendi tempore voluptas tenetur omnis saepe facilis vel id.\nIusto voluptas nesciunt quia assumenda laborum quis vel et.", 1222, 1220 },
                    { 1519, "Aut nisi illo.\nRepellat quia impedit.\nIpsam aperiam enim aperiam consequatur beatae voluptatem.", 1219, 1222 },
                    { 1506, "Aut reprehenderit accusamus.\nEum totam eius veniam eveniet voluptatum.\nId ut nesciunt vero velit soluta ut sint rerum quam.", 1215, 1222 },
                    { 1477, "Ut voluptates molestias culpa temporibus molestias ab ut.\nEst voluptatibus dolor.\nFacere quasi error aspernatur minus quo sit omnis consequuntur.", 1219, 1222 },
                    { 1472, "Recusandae corrupti earum voluptatum qui.\nPorro nulla maxime.\nVoluptas vitae quos vel.", 1213, 1222 },
                    { 1549, "Harum esse consectetur reiciendis.\nVoluptas et id praesentium quis suscipit est fuga molestias nostrum.\nIpsam nesciunt accusantium quia.", 1213, 1222 },
                    { 1435, "Et aut aut optio sunt porro tenetur magni.\nDistinctio voluptatem soluta aspernatur dolor id.\nDolore magni animi quibusdam unde expedita itaque incidunt.", 1214, 1223 },
                    { 1382, "Culpa amet quia est inventore architecto quo rerum accusamus maxime.\nConsequatur nulla corporis explicabo praesentium neque et vel officia.\nConsequatur sunt et dolor.", 1216, 1223 },
                    { 1463, "Architecto omnis beatae quaerat quod consequuntur provident quod molestiae.\nUllam non nobis modi quia non corrupti.\nTenetur velit aut dolore nisi.", 1217, 1223 },
                    { 1327, "Placeat ut et id et quae ea ullam velit ut.\nSint animi mollitia expedita illum qui optio rerum eaque.\nNumquam sed minima animi.", 1213, 1224 },
                    { 1322, "Fugit ut rerum et.\nPraesentium incidunt ut rem sit tempora maxime labore provident voluptatem.\nMaxime natus sint sunt.", 1221, 1224 },
                    { 1320, "Magni commodi illo rerum doloremque corporis.\nSaepe eos nemo soluta praesentium quia ipsa ullam adipisci.\nExplicabo consectetur iure saepe.", 1224, 1214 },
                    { 1310, "Ipsa consequatur est amet sint.\nEt minus voluptatem dolorum culpa.\nQuo reiciendis reiciendis.", 1224, 1219 },
                    { 1299, "Voluptatem harum harum doloremque beatae voluptate provident adipisci.\nNemo inventore iusto.\nImpedit voluptates enim in.", 1221, 1224 },
                    { 1449, "Perspiciatis aut autem hic error sequi aliquid sit ut hic.\nEst ab sit.\nEt et qui et velit harum debitis.", 1222, 1223 },
                    { 1537, "Inventore sint quas dolorem mollitia sed.\nIste repellat libero ipsam.\nMaiores eveniet voluptate aut perspiciatis.", 1223, 1214 },
                    { 1547, "Dolor sed impedit consequatur.\nEt omnis autem nemo officiis hic vel voluptatibus perspiciatis.\nDolorum temporibus id ipsum assumenda.", 1232, 1224 },
                    { 1535, "Omnis cumque modi deleniti qui amet animi ipsum.\nNon nisi facere qui sed.\nCorrupti quidem iure fuga.", 1220, 1223 },
                    { 1508, "Qui illo ut earum quas nihil.\nProvident quis velit distinctio error vel delectus quasi ea.\nAliquam qui quos iste mollitia.", 1218, 1223 },
                    { 1504, "Earum fugiat praesentium sed a commodi molestiae impedit omnis.\nEos nobis totam.\nTempora eligendi aliquid mollitia est.", 1223, 1216 },
                    { 1487, "Magnam dolorem rem ab porro voluptatem molestias.\nQui non sint facilis expedita veritatis libero esse minus veniam.\nRepellendus mollitia quis voluptas tenetur perspiciatis voluptatum.", 1220, 1223 },
                    { 1478, "Esse laborum dolore.\nEt ab ad dolores.\nUt deserunt ea omnis laboriosam labore modi eum aliquam.", 1223, 1217 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Description", "IsActive", "Name", "OwnerId", "Rating" },
                values: new object[,]
                {
                    { 128, "2597 Hartmann Island, North Alessandraton, Jordan", "facilis", false, "aspernatur", 1216, (byte)0 },
                    { 122, "396 Faustino Springs, South Ashlee, Cocos (Keeling) Islands", "Dolor aut dolorum beatae. Assumenda eveniet quia. Aut neque porro voluptatum minima maxime omnis nam vitae.", false, "occaecati", 1216, (byte)0 },
                    { 130, "486 Scotty Lights, South Lemuel, Morocco", "odio", false, "placeat", 1223, (byte)0 },
                    { 121, "33124 Rau Port, New Catherine, Czech Republic", "Iure vero et provident repellendus debitis voluptas alias a voluptatibus.", false, "minima", 1229, (byte)0 },
                    { 125, "90075 Goyette Ville, Lake Jermaineburgh, Yemen", "Laborum dolor debitis aut et.\nQuis voluptatem voluptatem enim.", false, "ut", 1228, (byte)0 },
                    { 124, "5651 Ritchie Shoal, Kemmerborough, Namibia", "sed", false, "optio", 1228, (byte)0 },
                    { 123, "38697 Smith Springs, Moenstad, Qatar", "Et aliquam architecto inventore est.\nUt est tempore dignissimos autem est.\nQuam odit voluptate illo possimus molestiae voluptatem dolor.\nQuo rerum minima aliquam quae.\nIste eos placeat et pariatur quam omnis dolorem ducimus explicabo.\nOfficiis velit tempora aut et qui aut ut.", false, "ut", 1228, (byte)0 },
                    { 127, "14591 McLaughlin Plains, North Lillianmouth, Andorra", "Quidem dolor sunt debitis illo eligendi. Non quod ea tenetur dolorem hic laborum. Saepe asperiores quam repellat et commodi vel. Occaecati sed est perferendis.", false, "doloremque", 1217, (byte)0 },
                    { 129, "8018 Sanford Pine, Ambermouth, Gibraltar", "Possimus eum explicabo quos officia.\nDoloremque reiciendis incidunt numquam aut.\nAd commodi dicta officiis sit sed.\nError sint non aut accusantium veniam.", false, "quaerat", 1221, (byte)0 },
                    { 126, "0642 Maryjane Forges, Terrellchester, Albania", "Harum quas dignissimos rerum qui eligendi molestiae repudiandae. Expedita reprehenderit et asperiores rerum rerum omnis excepturi earum vel. Cum aut voluptatem reiciendis consequatur tempore sed quae. Consectetur explicabo et possimus deserunt nobis vel eum eveniet.", false, "ut", 1222, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CategoryId", "Description", "MainPhotoName", "Name", "PathToPhotoGallery", "Price", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1570, 1557, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "Tasty Plastic Ball", null, 7282L, 0, 122 },
                    { 1564, 1561, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Awesome Frozen Soap", null, 1951L, 0, 126 },
                    { 1569, 1557, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "Sleek Cotton Chips", null, 1819L, 0, 130 },
                    { 1567, 1562, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "Licensed Fresh Computer", null, 1387L, 0, 124 },
                    { 1568, 1562, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "Unbranded Metal Cheese", null, 2229L, 0, 124 },
                    { 1563, 1556, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Practical Fresh Ball", null, 921L, 0, 125 },
                    { 1565, 1558, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Rustic Plastic Towels", null, 2470L, 0, 125 },
                    { 1566, 1555, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "Unbranded Granite Gloves", null, 6805L, 0, 125 },
                    { 1571, 1553, "The Football Is Good For Training And Recreational Purposes", null, "Fantastic Frozen Chips", null, 240L, 0, 125 },
                    { 1572, 1556, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "Rustic Granite Mouse", null, 8824L, 0, 121 }
                });

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
