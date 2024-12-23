using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSync.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founded = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumeLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeeker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeeker_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeeker_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTakingApplications = table.Column<bool>(type: "bit", nullable: false),
                    HasMultipleSpots = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerSkill",
                columns: table => new
                {
                    JobSeekersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerSkill", x => new { x.JobSeekersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_JobSeekerSkill_JobSeeker_JobSeekersId",
                        column: x => x.JobSeekersId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Benefit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => new { x.JobId, x.Benefit });
                    table.ForeignKey(
                        name: "FK_Benefits_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => new { x.JobId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_Bookmarks_JobSeeker_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookmarks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => new { x.JobId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobApplications_JobSeeker_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.JobsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_JobSkill_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("166ede4a-e984-4830-a28a-983ba0a5afe5"), null, "Employer", "EMPLOYER" },
                    { new Guid("77322953-952f-40c7-880e-200b5a495d70"), null, "Admin", "ADMIN" },
                    { new Guid("9c61ced3-1a34-4c2c-8980-5aef0356172c"), null, "JobSeeker", "JOBSEEKER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("07270609-faad-4cd8-953f-dd5002201839"), 0, "dcf2b723-51ef-4e35-a677-f0a9bc835ead", "leobachleda@hawaiiantel.net", false, false, null, "LEOBACHLEDA@HAWAIIANTEL.NET", "LEOBACHLEDA@HAWAIIANTEL.NET", "AQAAAAIAAYagAAAAEIrXAV3lMpDFmHntTHiPUZqXBYdEzCusNMhoCllBR6JInM2MldRIbXMFZ7OsEjJ5fA==", null, false, null, false, "leobachleda@hawaiiantel.net" },
                    { new Guid("09045647-6bcc-44a3-bc0f-06f15dab0611"), 0, "8ea94dc0-bdf4-4e0b-90c7-cba056988bea", "Kuhlmey.Criselda@earthdome.com", false, false, null, "KUHLMEY.CRISELDA@EARTHDOME.COM", "KUHLMEY.CRISELDA@EARTHDOME.COM", "AQAAAAIAAYagAAAAEL9N/6pIjLMRo8AABbh690cMwATkImSPs7yESQmfITfo14ntJF0+4Uri1fz802dy6w==", null, false, null, false, "Kuhlmey.Criselda@earthdome.com" },
                    { new Guid("0b3ca9c4-0b99-40de-b9db-e0e3c6c41769"), 0, "5c117382-20ac-4bca-be0b-bd6884977411", "izetta@mail2biker.com", false, false, null, "IZETTA@MAIL2BIKER.COM", "IZETTA@MAIL2BIKER.COM", "AQAAAAIAAYagAAAAEIBPI3TTjPzqdGVKWZds6oh7K/JuDy2+7S7TR+COsTG5brtE32ps/fdzsR2cliNpMQ==", null, false, null, false, "izetta@mail2biker.com" },
                    { new Guid("0b525566-35bd-4c0c-a76f-b8d7a3162174"), 0, "9d69cd97-49f0-435d-b65e-7337a913cba3", "Vicky.Dehner7@mail2colorado.com", false, false, null, "VICKY.DEHNER7@MAIL2COLORADO.COM", "VICKY.DEHNER7@MAIL2COLORADO.COM", "AQAAAAIAAYagAAAAEPrpw995rPu3Vf/wnKCmQ2QPj+2KEthBblehxve9NaRde+zHzdFKbD/8fHVJgXUTWA==", null, false, null, false, "Vicky.Dehner7@mail2colorado.com" },
                    { new Guid("0f1d7428-efd8-4891-87a8-4fb9158dad71"), 0, "51088764-3db5-436c-9137-9d8c20ee3764", "chet@windstream.net", false, false, null, "CHET@WINDSTREAM.NET", "CHET@WINDSTREAM.NET", "AQAAAAIAAYagAAAAEBaqH60zYL0wn6R8Csb1qKHRQCXAduKGY5+QqfK0XkHVWPpRseIASHYH9F3n4ctcIg==", null, false, null, false, "chet@windstream.net" },
                    { new Guid("1053b5e7-4521-4c06-b0a7-a02b6d333c4c"), 0, "54791460-6bd7-4678-9557-bcdd91d638ae", "mcguiremayme1@mail2register.com", false, false, null, "MCGUIREMAYME1@MAIL2REGISTER.COM", "MCGUIREMAYME1@MAIL2REGISTER.COM", "AQAAAAIAAYagAAAAEFMQpIR23vpViPGqsYCiGX4K3Vgw66sfUAfQw34JHfTHM1l5huEHRUhZGDVyFnR0XA==", null, false, null, false, "mcguiremayme1@mail2register.com" },
                    { new Guid("147c2d6b-f64f-4c07-9f6f-b385e32e5fad"), 0, "4071cc7c-a301-48b3-925b-c34f3fdddb4b", "Corbet.Glady@celtic.com", false, false, null, "CORBET.GLADY@CELTIC.COM", "CORBET.GLADY@CELTIC.COM", "AQAAAAIAAYagAAAAEMuhbOqX1Eqb65lwblKEt6xK5aMdL80PSKL+/JsaL/VPTatyVZDylSbaHbaEzsCMTQ==", null, false, null, false, "Corbet.Glady@celtic.com" },
                    { new Guid("15418835-1d59-428d-95eb-b66a051cf625"), 0, "8968349d-59f4-4c77-a44a-c066a1f1788e", "drozetamiko8@inmail.sk", false, false, null, "DROZETAMIKO8@INMAIL.SK", "DROZETAMIKO8@INMAIL.SK", "AQAAAAIAAYagAAAAEJfLphXM2zeIXY67APEgeDqsDJB7O6sVhlNF2HN6SjNUnadBnQ72DkT6ammCDGQ9Hw==", null, false, null, false, "drozetamiko8@inmail.sk" },
                    { new Guid("1668b07f-d9cb-46f4-98f6-ef58db4625bf"), 0, "c1ae5757-e42c-4fdf-8078-0e275e6ad576", "gemmaangelocci@directbox.com", false, false, null, "GEMMAANGELOCCI@DIRECTBOX.COM", "GEMMAANGELOCCI@DIRECTBOX.COM", "AQAAAAIAAYagAAAAEJ9sr9mQX/p/369NdH7useg2n8/ld3ZOjU5y3yFEnNKQAiOLWbyKElNMniNI39Uo1Q==", null, false, null, false, "gemmaangelocci@directbox.com" },
                    { new Guid("1a22c164-bf7f-4f93-80f9-7b14977214df"), 0, "b1e3817a-82d7-4af3-9acb-e205c41f8955", "Shanell.Scozzafava8@postpro.net", false, false, null, "SHANELL.SCOZZAFAVA8@POSTPRO.NET", "SHANELL.SCOZZAFAVA8@POSTPRO.NET", "AQAAAAIAAYagAAAAEJFHCTrS5AGilrLxY6REtTYhABUi2fKvkgwK4uJ5vMf156Drwc0FB/hzYRBaAg6bHA==", null, false, null, false, "Shanell.Scozzafava8@postpro.net" },
                    { new Guid("1d77285a-0724-4a09-aeeb-cac5d6a78d35"), 0, "7bbea5eb-0a30-4775-9fa4-204960813459", "villalpandoqiana@freenet.kg", false, false, null, "VILLALPANDOQIANA@FREENET.KG", "VILLALPANDOQIANA@FREENET.KG", "AQAAAAIAAYagAAAAEOUZqwQaQyDKTo8I5Cl0pfYfOkthIdMUt55FFjEWf+GLgMMZ74JoKsuKF7p8MLj7UA==", null, false, null, false, "villalpandoqiana@freenet.kg" },
                    { new Guid("1db86547-16b0-4642-b5dc-11b744601398"), 0, "933470d4-d84c-4032-aaab-5088903e3cf7", "Betry.Emelia@yogotemail.com", false, false, null, "BETRY.EMELIA@YOGOTEMAIL.COM", "BETRY.EMELIA@YOGOTEMAIL.COM", "AQAAAAIAAYagAAAAEFCSOVGjRZxHsvqJXMmEPQupXS+hyjPZA8cMJbRvMy321LF43T9cnJEpmjxSNgj9aA==", null, false, null, false, "Betry.Emelia@yogotemail.com" },
                    { new Guid("1eed8206-8772-42f3-ae58-5e185c00b7b5"), 0, "134a11fb-ee8d-43eb-b341-a884aa3549c2", "Daniell.Dundlow8@alibaba.com", false, false, null, "DANIELL.DUNDLOW8@ALIBABA.COM", "DANIELL.DUNDLOW8@ALIBABA.COM", "AQAAAAIAAYagAAAAEJdGeNwNByj4l+1nOH7aBmWTKAKf/RhMWeF0pKIH4KL3HDSUq4/VKOQlS0tP5DZsJw==", null, false, null, false, "Daniell.Dundlow8@alibaba.com" },
                    { new Guid("21fd3d5b-e860-4ea3-8dc5-3b21274be268"), 0, "7e2fefed-1454-42f5-a070-8d7cb8a977a7", "maricruz7@mail2worship.com", false, false, null, "MARICRUZ7@MAIL2WORSHIP.COM", "MARICRUZ7@MAIL2WORSHIP.COM", "AQAAAAIAAYagAAAAEJk15n9OckY+Xu3P6qdMlc6hA16Klj71lc1hGsmQ9rkmjWhanoQcxJ+sj7hZ60evOQ==", null, false, null, false, "maricruz7@mail2worship.com" },
                    { new Guid("25541e42-d5d4-48a7-af81-59c28277db7a"), 0, "5409fe0f-cf8e-4a1f-b650-d4f79fa0c88f", "doretheamormino@the-master.com", false, false, null, "DORETHEAMORMINO@THE-MASTER.COM", "DORETHEAMORMINO@THE-MASTER.COM", "AQAAAAIAAYagAAAAEBxOMex1qgNbbOBF88C0YD6IMdjVgNq9PWcK91aHntC5M1YenwfOWNJlS9sJIPwLkg==", null, false, null, false, "doretheamormino@the-master.com" },
                    { new Guid("25744c67-492d-45e2-afa4-9d6c7b3b8e4d"), 0, "9eb74378-b154-42fa-87fb-a1e7916ecf6e", "shaulkaren4@mail2winner.com", false, false, null, "SHAULKAREN4@MAIL2WINNER.COM", "SHAULKAREN4@MAIL2WINNER.COM", "AQAAAAIAAYagAAAAEPLjl6gcw0MPSLyEOhN8b3yp5fgctUF9mFmD8xrTSHdmVfqfAGAEv+UbqxhrKSlSgQ==", null, false, null, false, "shaulkaren4@mail2winner.com" },
                    { new Guid("28251510-2395-48e8-aeed-57222599f55c"), 0, "c48a11c9-7de6-4940-bbca-5d7baa394779", "Violante.Emilia1@mail2golfer.com", false, false, null, "VIOLANTE.EMILIA1@MAIL2GOLFER.COM", "VIOLANTE.EMILIA1@MAIL2GOLFER.COM", "AQAAAAIAAYagAAAAELp8LNzt9HwPL2+kGU9N7754DG9cmj9ogXlUxQceRMOdvWajNzHHip5LD6++bacZTw==", null, false, null, false, "Violante.Emilia1@mail2golfer.com" },
                    { new Guid("2bad91f5-5c65-4a30-882e-97c736a71660"), 0, "518784ad-fb81-40a5-9a31-5895fa8a0242", "diceconnie@mail2grace.com", false, false, null, "DICECONNIE@MAIL2GRACE.COM", "DICECONNIE@MAIL2GRACE.COM", "AQAAAAIAAYagAAAAEOciKzh/Sza2N/PtrHZp6EvB+0tB6MEJjxM5lgI/0Q8RplOCtOQw5eRWV8LzaysJWw==", null, false, null, false, "diceconnie@mail2grace.com" },
                    { new Guid("2de19ce4-070a-4fc8-9ac9-6de4be880eb0"), 0, "09897a48-89d3-4eb9-9c34-ce750d6af10f", "Jamar.Harold@compuserve.com", false, false, null, "JAMAR.HAROLD@COMPUSERVE.COM", "JAMAR.HAROLD@COMPUSERVE.COM", "AQAAAAIAAYagAAAAEOTHgIpTe6RRBhFeZRlJ1T6GyOksMFnjpYbz93PBF7cT+4eXFFT6GJrV7rpxqR/VAQ==", null, false, null, false, "Jamar.Harold@compuserve.com" },
                    { new Guid("2e8ca9c4-b870-4fc8-bcfe-8ac009d3c801"), 0, "fa09b8b3-f204-4761-b5ca-9e3b8d68b5f9", "adolfo2@will-hier-weg.de", false, false, null, "ADOLFO2@WILL-HIER-WEG.DE", "ADOLFO2@WILL-HIER-WEG.DE", "AQAAAAIAAYagAAAAEORtu+tzMOS8Nx9Mx09SWBI4TW22vTau2NLsgSy1/WI24Yvaa7OgeFFRwNr+aZmfXg==", null, false, null, false, "adolfo2@will-hier-weg.de" },
                    { new Guid("2ff0c9d3-b0e5-4b8b-b127-83eec8d4333b"), 0, "77a0ecfd-b723-4022-9738-d36aff38bbe5", "von5@tatanova.com", false, false, null, "VON5@TATANOVA.COM", "VON5@TATANOVA.COM", "AQAAAAIAAYagAAAAEBTjBi7nnKgixiZ7f8M5dCjPf44CZpqdcUcAIBCzw+JoEk7OB8WfuEby5gOjMSyyuQ==", null, false, null, false, "von5@tatanova.com" },
                    { new Guid("326c6b3e-f3cc-42fc-9c26-af8e407e3899"), 0, "1764f9d3-ad04-4124-a6fb-dec3196f21c1", "marylineversole@mail2frankfurt.com", false, false, null, "MARYLINEVERSOLE@MAIL2FRANKFURT.COM", "MARYLINEVERSOLE@MAIL2FRANKFURT.COM", "AQAAAAIAAYagAAAAENQlmBj0QukdV0VG30x6gf8iox/w+113E7SM8H0lmVA3WlJ3LrfHou0tgLlBI54KzQ==", null, false, null, false, "marylineversole@mail2frankfurt.com" },
                    { new Guid("33fd83af-349f-47e6-869b-7de408e26fe8"), 0, "a1ac98c3-83c4-4d4b-a84f-d639f18ad000", "lizabethsyon@cghost.s-a-d.de", false, false, null, "LIZABETHSYON@CGHOST.S-A-D.DE", "LIZABETHSYON@CGHOST.S-A-D.DE", "AQAAAAIAAYagAAAAEDL3vHM8jIn8kQ0J7Fjpj1mJwAoLw0OVkbnLBturypOR18zNy42BY5Rfuc2YVSWFyQ==", null, false, null, false, "lizabethsyon@cghost.s-a-d.de" },
                    { new Guid("3516fdbb-4600-434d-b897-e0a71b94877a"), 0, "a1badf82-11fe-42c1-a422-9d829d2ffeb3", "tommienobriga8@mail2virgo.com", false, false, null, "TOMMIENOBRIGA8@MAIL2VIRGO.COM", "TOMMIENOBRIGA8@MAIL2VIRGO.COM", "AQAAAAIAAYagAAAAEMZApxAYtoYvw8QBmvQow2cQjcfDuiufP4jpdAvflfI23/82/zGbeJlslcSOcGthqg==", null, false, null, false, "tommienobriga8@mail2virgo.com" },
                    { new Guid("356d1249-cf5c-4f06-8515-b8219520eb2d"), 0, "67169d25-3f7f-444b-a471-28e26f17f3e2", "rickbroaddus5@ptd.net", false, false, null, "RICKBROADDUS5@PTD.NET", "RICKBROADDUS5@PTD.NET", "AQAAAAIAAYagAAAAEGAVuOdsgl5K5yi8D9l6AMVC4EuF0oO/VdY3ldCNBIiV/JiqHxRBOn36MOcH2/plQg==", null, false, null, false, "rickbroaddus5@ptd.net" },
                    { new Guid("35bd4e81-35c1-4c94-8f77-b8e6dcabba88"), 0, "8ad523ba-5db8-480c-974d-d1f9ce6524fe", "josettesawdo1@technologist.com", false, false, null, "JOSETTESAWDO1@TECHNOLOGIST.COM", "JOSETTESAWDO1@TECHNOLOGIST.COM", "AQAAAAIAAYagAAAAELXqmD7fC/XiCGrSZK3PUSkRh29POzN5i+mPT1mU+ZESjuLb9wymIz63WE9andIv8A==", null, false, null, false, "josettesawdo1@technologist.com" },
                    { new Guid("362074c8-7ca2-4c80-b964-b335956cf55c"), 0, "affe108f-6a7a-4456-a252-952023a35ccd", "kristenkeeney2@malayalamtelevision.net", false, false, null, "KRISTENKEENEY2@MALAYALAMTELEVISION.NET", "KRISTENKEENEY2@MALAYALAMTELEVISION.NET", "AQAAAAIAAYagAAAAEBaYiczqtXGBkDlO6JoZT9RHcJ/r7va+Htk8C00UQPHQZXwYRiudN0SdIq3pwN1QWg==", null, false, null, false, "kristenkeeney2@malayalamtelevision.net" },
                    { new Guid("393eb359-3b33-44a6-9dc7-77e4aaabc671"), 0, "b72e9ec8-2aa4-4679-bd14-52a5065afaac", "Kimm.Elna@mail2filmfestival.com", false, false, null, "KIMM.ELNA@MAIL2FILMFESTIVAL.COM", "KIMM.ELNA@MAIL2FILMFESTIVAL.COM", "AQAAAAIAAYagAAAAEA72vr++cDn79HVJRP1UAQ0vGD6eNZvxhLzQ+SPzjgMXjMUtuE94EfdJM6Ozl+Uy9w==", null, false, null, false, "Kimm.Elna@mail2filmfestival.com" },
                    { new Guid("3f81db9a-95f1-4d2b-ab17-17c4bbd7f00e"), 0, "ab92c6d4-f1ab-45be-bccf-20b08839abb3", "toryhackner1@mail2abby.com", false, false, null, "TORYHACKNER1@MAIL2ABBY.COM", "TORYHACKNER1@MAIL2ABBY.COM", "AQAAAAIAAYagAAAAEOS/azxw7EWYIzNQAFLxMmby/kdX3Q6ve0YwrtdWO7HdaPlJ0xXawJMgM2kYyZOJWQ==", null, false, null, false, "toryhackner1@mail2abby.com" },
                    { new Guid("407f78b9-502d-4d3c-819d-5d0a409c53a2"), 0, "a93d43f7-1fbf-4da0-87d1-4b031fc9f2cc", "Yun.Jaffy@mailandftp.com", false, false, null, "YUN.JAFFY@MAILANDFTP.COM", "YUN.JAFFY@MAILANDFTP.COM", "AQAAAAIAAYagAAAAEKg+a9pAFG02Por+jYm5MpEBVxES4EPMJF6JGI6roZgo1m457J8Xl0CyTd1G9jK7Lw==", null, false, null, false, "Yun.Jaffy@mailandftp.com" },
                    { new Guid("4912ab76-d7f4-4039-94d9-f3063474ec7f"), 0, "063dd05a-5834-40ea-844b-a64332683b3f", "reneaucristen9@mail2classifieds.com", false, false, null, "RENEAUCRISTEN9@MAIL2CLASSIFIEDS.COM", "RENEAUCRISTEN9@MAIL2CLASSIFIEDS.COM", "AQAAAAIAAYagAAAAEG5dXt3vjX7Gc+YbHagA1wdSXpTGIx0jhuewf3RI9rZYnAPdPFbN4IdO6X+sIowcGg==", null, false, null, false, "reneaucristen9@mail2classifieds.com" },
                    { new Guid("4b5185d8-41ec-40ab-9ff2-12e3dd9f892b"), 0, "f3949a1e-bd5a-4248-88fe-9137242fa1a6", "Waibel.Gavin9@freewebemail.com", false, false, null, "WAIBEL.GAVIN9@FREEWEBEMAIL.COM", "WAIBEL.GAVIN9@FREEWEBEMAIL.COM", "AQAAAAIAAYagAAAAEGQDTcPpt1p/zO/CkC+1BRlmRwgzYL0PpVgV0CBsIncXUKxspMTH1I/dTCtKcwvbqQ==", null, false, null, false, "Waibel.Gavin9@freewebemail.com" },
                    { new Guid("4cd63ed6-655e-4eea-a4f8-e5f23226306b"), 0, "97da011a-a6b9-449c-b088-e019a2da55bc", "Brauer.Patria3@mail2emergency.com", false, false, null, "BRAUER.PATRIA3@MAIL2EMERGENCY.COM", "BRAUER.PATRIA3@MAIL2EMERGENCY.COM", "AQAAAAIAAYagAAAAEBPauyDeUK9ccA05wRiEnn08bMpfqai071RxsE/fxnDIeq0zPkuKSVkgYhp9H8hQ5w==", null, false, null, false, "Brauer.Patria3@mail2emergency.com" },
                    { new Guid("50a83e53-8a4c-4a62-b2ae-e255353be23e"), 0, "95d965e5-85e1-421d-8c7b-cd6e8e67f99b", "Cristen.Preisler2@infomail.es", false, false, null, "CRISTEN.PREISLER2@INFOMAIL.ES", "CRISTEN.PREISLER2@INFOMAIL.ES", "AQAAAAIAAYagAAAAEFmJcTR2U7pgzTrg2JQjQmX8AV6tcRKfh09hM9v+XYvDK4EEclUD+1C/KhBj0TqAXg==", null, false, null, false, "Cristen.Preisler2@infomail.es" },
                    { new Guid("50c35805-2225-46c9-8963-cf1398666f77"), 0, "20c7e5ac-5754-4096-9a03-c1e3c3a4642d", "hae4@oso.com", false, false, null, "HAE4@OSO.COM", "HAE4@OSO.COM", "AQAAAAIAAYagAAAAENpM+bj6MeAhPKBKaBW243/MDK0TgR379c9We0PqEXN3Gst+ZSwsI+TtGFdSzvuu9w==", null, false, null, false, "hae4@oso.com" },
                    { new Guid("52a932d7-c970-4dcd-9794-5231bd69055d"), 0, "6e453a2c-d98c-4c56-be0a-bb5c289b9a66", "idacherubini@mail2concert.com", false, false, null, "IDACHERUBINI@MAIL2CONCERT.COM", "IDACHERUBINI@MAIL2CONCERT.COM", "AQAAAAIAAYagAAAAEF5q542rjt6MMnVTGr5nb2K1fQQfbrVhQg45ApWRkpKLY6XddSFghYPI76Z3NeE85g==", null, false, null, false, "idacherubini@mail2concert.com" },
                    { new Guid("52fc3abb-7546-4eab-b958-ba4dc4c5bab7"), 0, "cf4be7e4-1251-4666-9448-45ea4739c4ed", "Porter.Ketelhut@imneverwrong.com", false, false, null, "PORTER.KETELHUT@IMNEVERWRONG.COM", "PORTER.KETELHUT@IMNEVERWRONG.COM", "AQAAAAIAAYagAAAAECe9zUAed533Lqn+V9jdIUtL+LUqwOrOTjjLIiOXCE/8sRUuhv9QUouk69dl0/dtfQ==", null, false, null, false, "Porter.Ketelhut@imneverwrong.com" },
                    { new Guid("553bbf2c-5581-4d8b-86be-162ec235d083"), 0, "36442992-2048-4374-a755-a86111d3d2d3", "Bronwyn.Bradd9@mail2persephone.com", false, false, null, "BRONWYN.BRADD9@MAIL2PERSEPHONE.COM", "BRONWYN.BRADD9@MAIL2PERSEPHONE.COM", "AQAAAAIAAYagAAAAELtYS9fawpzD2TWx9V5+M+Ks6q0v2IO4vIpUNjsPcsPFzDinpjqLsanObNi0oEVWLQ==", null, false, null, false, "Bronwyn.Bradd9@mail2persephone.com" },
                    { new Guid("590b8456-ce5f-4c5c-aadc-835f839b95ef"), 0, "b3c6fbe9-a9a9-49a0-a474-5bda765bdd87", "Earnest.Demaggio@mail2donald.com", false, false, null, "EARNEST.DEMAGGIO@MAIL2DONALD.COM", "EARNEST.DEMAGGIO@MAIL2DONALD.COM", "AQAAAAIAAYagAAAAEMSgtzJgXgbTYYQXZzfNa5M5SThJZ/XCLb0q/vyN+WNY2Adc7MwklX/O+MFiMQTATQ==", null, false, null, false, "Earnest.Demaggio@mail2donald.com" },
                    { new Guid("5a10a213-b7e0-42f8-ac3c-ffb38dfc3b10"), 0, "067a13c9-2455-495e-acb2-384527ccc6b5", "Taualii.Saundra5@mail2strong.com", false, false, null, "TAUALII.SAUNDRA5@MAIL2STRONG.COM", "TAUALII.SAUNDRA5@MAIL2STRONG.COM", "AQAAAAIAAYagAAAAEJPij3Bx0vhMBYPVIh4wA6nIJg5/jyEH2cR/OaNx5AElzcvQK+NJ+luQDHwFYJeVPQ==", null, false, null, false, "Taualii.Saundra5@mail2strong.com" },
                    { new Guid("5adf7c8c-4f3f-4677-9cc3-914ccef2474e"), 0, "37dc3033-0009-412a-ba31-93a1b349c105", "Latoria.Taggart6@trimix.cn", false, false, null, "LATORIA.TAGGART6@TRIMIX.CN", "LATORIA.TAGGART6@TRIMIX.CN", "AQAAAAIAAYagAAAAEEDVCKrrS4EpSG9eExQHi8xNVVJOaF4R3xi7lMzkiVfNL3fst9WGwvdzAaJos2ZGHA==", null, false, null, false, "Latoria.Taggart6@trimix.cn" },
                    { new Guid("5b5c4caa-f9d0-4c18-9ac8-5206e4a34f4c"), 0, "54475b9d-3ba7-4878-b773-3feb63743a50", "Schwager.Elane@boxemail.com", false, false, null, "SCHWAGER.ELANE@BOXEMAIL.COM", "SCHWAGER.ELANE@BOXEMAIL.COM", "AQAAAAIAAYagAAAAEP6l/x2XstpFqTTwHp7drWdiUXVVSF3YDeuMVD81U9OO2kDIZCnQgnq2dENdhO1WGw==", null, false, null, false, "Schwager.Elane@boxemail.com" },
                    { new Guid("5d7fcfdc-13fc-47ea-bf50-ef39a503d586"), 0, "ad7b4e0e-d004-413e-ba12-611e05d80af4", "Porietis.Kasi@earthdome.com", false, false, null, "PORIETIS.KASI@EARTHDOME.COM", "PORIETIS.KASI@EARTHDOME.COM", "AQAAAAIAAYagAAAAEPne3stvhgM8FrEQHCPQD3AdtKUpeblJa1xJ1iA/igLJl+jruQdsC6DIwLAqqX955Q==", null, false, null, false, "Porietis.Kasi@earthdome.com" },
                    { new Guid("6085fbb9-738a-44a9-bc12-ac9ef190c291"), 0, "6b0b0ef3-f8a7-44a4-9e73-c4d63ae0fd4b", "merylbreister3@seanet.com", false, false, null, "MERYLBREISTER3@SEANET.COM", "MERYLBREISTER3@SEANET.COM", "AQAAAAIAAYagAAAAEJvWdjj3GVdUF39XQ8iq5VeQxiaZowVtgMfJ3GvjVsFo54BOka52NhmSQOieU0rJJQ==", null, false, null, false, "merylbreister3@seanet.com" },
                    { new Guid("622e5ec7-5d61-4702-aa29-088b42a865b5"), 0, "e5739f17-6673-41fe-9afb-e6cc8c98bdd0", "ihdemadeleine4@fromoklahoma.com", false, false, null, "IHDEMADELEINE4@FROMOKLAHOMA.COM", "IHDEMADELEINE4@FROMOKLAHOMA.COM", "AQAAAAIAAYagAAAAEFqsTTvzBt9afTUVrBJIvu2UagrIIsCuQq8rFHyfunVo218Jd/xPd+f+tQM/HH4XkA==", null, false, null, false, "ihdemadeleine4@fromoklahoma.com" },
                    { new Guid("6589d2bd-4a01-4523-a038-fa6b666cf4bb"), 0, "f3354fdc-0e19-494f-b0db-96e8590ee11a", "mechellecaulkins@mail2jamie.com", false, false, null, "MECHELLECAULKINS@MAIL2JAMIE.COM", "MECHELLECAULKINS@MAIL2JAMIE.COM", "AQAAAAIAAYagAAAAED2Axgvc/3dSdt5bwIP7Qj2IeC/fqoB7LQKdmNDphhrfMQppXJzy3lM8HfFuwvZ9lg==", null, false, null, false, "mechellecaulkins@mail2jamie.com" },
                    { new Guid("67e1825d-b2c5-4d10-b961-56fc9bdcf775"), 0, "90f41348-de75-472f-8c64-2dd9938fcb0a", "Nadine.Ouellette@money.net", false, false, null, "NADINE.OUELLETTE@MONEY.NET", "NADINE.OUELLETTE@MONEY.NET", "AQAAAAIAAYagAAAAEOyu+8IimqoHU7oPguRCOyf25X4KYohNM3+ba7VBHpb7efUuk2S0Pc+Jn6OORiwcUw==", null, false, null, false, "Nadine.Ouellette@money.net" },
                    { new Guid("6f08a0f8-cb1f-4bef-b73c-76e015d42702"), 0, "2b3d0f54-07e6-4d84-a0f0-3762dce40012", "ozella1@coxinet.net", false, false, null, "OZELLA1@COXINET.NET", "OZELLA1@COXINET.NET", "AQAAAAIAAYagAAAAEF2aH+oSyeJsTiev864CKilV+5de0iEoOpnOW5hgR6bYp2pc+xTJpH+BUyWEnB9rbg==", null, false, null, false, "ozella1@coxinet.net" },
                    { new Guid("703204ae-474e-49fb-af92-b7d39b129317"), 0, "6b963ebf-49eb-4871-825c-c3cbd3a00f7b", "tonetteyasin4@bluehyppo.com", false, false, null, "TONETTEYASIN4@BLUEHYPPO.COM", "TONETTEYASIN4@BLUEHYPPO.COM", "AQAAAAIAAYagAAAAEMcRWv4GZ5WxMw7U2lUos/Mt8h/4pFQyvHuTVsp8fzsS2q/l8Lrm8pZjq2YaLBducg==", null, false, null, false, "tonetteyasin4@bluehyppo.com" },
                    { new Guid("753638e3-2999-474a-8546-74442b3dc2d6"), 0, "c82a4181-71d3-48d2-a2a2-d861b7b4068d", "Roy.Benac3@shinedyoureyes.com", false, false, null, "ROY.BENAC3@SHINEDYOUREYES.COM", "ROY.BENAC3@SHINEDYOUREYES.COM", "AQAAAAIAAYagAAAAEEhpEByxwvm/ilGs3xqM3SG/QUx6sSOXCPimQU0PkWcPyz0QobzSIR52ytCQVpTdrA==", null, false, null, false, "Roy.Benac3@shinedyoureyes.com" },
                    { new Guid("79e83b38-d743-4911-af5f-2c3b55fb8cad"), 0, "20410f8d-54e6-44af-aaf1-4f495e137d77", "herschelamore@1musicrow.com", false, false, null, "HERSCHELAMORE@1MUSICROW.COM", "HERSCHELAMORE@1MUSICROW.COM", "AQAAAAIAAYagAAAAEMuLcYtO/jVvAK/mUgvrcVCCRprX/SiKkB0mDegv7CgjFK3rKnSZ5S6dMTWF3lBEww==", null, false, null, false, "herschelamore@1musicrow.com" },
                    { new Guid("7a8ec500-3508-46f3-bcd7-d927549f5683"), 0, "1c4c3e05-f59c-4cdb-9608-72cb74d57cb0", "Kenneth.Haab3@mail2libra.com", false, false, null, "KENNETH.HAAB3@MAIL2LIBRA.COM", "KENNETH.HAAB3@MAIL2LIBRA.COM", "AQAAAAIAAYagAAAAEFgJ3Dk2DWpGEZgLKf/YFMGRsnFK3p9gsd6hjot2Xufhq4ZexauiEkylrO9mdQjmiA==", null, false, null, false, "Kenneth.Haab3@mail2libra.com" },
                    { new Guid("7f0ff3db-c2e3-4fbe-a990-fc961bd11056"), 0, "2998acf3-f05b-414d-9d52-e61c11afdac1", "authurpennie@our.st", false, false, null, "AUTHURPENNIE@OUR.ST", "AUTHURPENNIE@OUR.ST", "AQAAAAIAAYagAAAAEA7CLmyE47ghjAZ5LRsQNb4BFRtV3isv/SGNmr/KDhDy1zRynU1ajpdbGQSUmaATWA==", null, false, null, false, "authurpennie@our.st" },
                    { new Guid("870e3d2a-f489-46c5-b62a-a354045ede13"), 0, "7d10561c-df92-4f49-8e48-c38b03c7bf01", "nganwhitaker5@mail2fond.com", false, false, null, "NGANWHITAKER5@MAIL2FOND.COM", "NGANWHITAKER5@MAIL2FOND.COM", "AQAAAAIAAYagAAAAEFbO6wXZnQmnlagBiAH94SdK/oZQ/1Lx+f/B95QnjcFB+2WZY//TlVDrwwQr6aJ4gw==", null, false, null, false, "nganwhitaker5@mail2fond.com" },
                    { new Guid("8808c685-4356-45d9-947b-f8939a6a6913"), 0, "ff893656-8f43-4924-9f76-51fe2b8ea7ec", "Amorello.Caitlyn9@aim.com", false, false, null, "AMORELLO.CAITLYN9@AIM.COM", "AMORELLO.CAITLYN9@AIM.COM", "AQAAAAIAAYagAAAAEGcMAxR2UyNHjO+cgtEO240dCMIbgConmpDA0B01mz2cgzxfHk3PLIv15cnD0PrRwg==", null, false, null, false, "Amorello.Caitlyn9@aim.com" },
                    { new Guid("8939dc9f-e83b-4c0a-b53c-ce6e60fe9253"), 0, "b65d0554-5a01-4229-a40e-fe27ab199a72", "alta@1coolplace.com", false, false, null, "ALTA@1COOLPLACE.COM", "ALTA@1COOLPLACE.COM", "AQAAAAIAAYagAAAAEI1uF926PCayqAA9FCVTM3RDYSP0Cx8NXZpxg/3jYCQpJVCRXKE6bmVU4bEQItVFQA==", null, false, null, false, "alta@1coolplace.com" },
                    { new Guid("8d8a855e-94b7-4020-bedb-b8b653ab5b8e"), 0, "9f66acc8-68ec-4416-9c44-22ae7063751e", "delma@zipido.com", false, false, null, "DELMA@ZIPIDO.COM", "DELMA@ZIPIDO.COM", "AQAAAAIAAYagAAAAED7IHCwsM6eNqKMSBLIf4txD5raJcrtulMOb1OEcM/dOQmPwUwJxidv5EQfyWNRjuw==", null, false, null, false, "delma@zipido.com" },
                    { new Guid("8da87f6f-ab51-4e62-9420-d39f30e9ecd6"), 0, "c80b35d4-494d-4d3e-a2e8-5d8e45e1bf95", "gordisterrilyn@mail2infinity.com", false, false, null, "GORDISTERRILYN@MAIL2INFINITY.COM", "GORDISTERRILYN@MAIL2INFINITY.COM", "AQAAAAIAAYagAAAAEG89W7eZWDExBpYTj4g13B8WfU2nhBku0aXTWxjJhCfz7HSa7BKx0Kfh5BTC9GBV0g==", null, false, null, false, "gordisterrilyn@mail2infinity.com" },
                    { new Guid("8f752c16-8036-4c44-b23f-c0407fa54031"), 0, "89d6ba13-f9db-44f7-b748-0078c482f8fd", "rosemarie@mail2danny.com", false, false, null, "ROSEMARIE@MAIL2DANNY.COM", "ROSEMARIE@MAIL2DANNY.COM", "AQAAAAIAAYagAAAAEFGvfI+pISnNwX6T6Yva+1Y61n/+FlY4ojopjqwc+lrP9Z8lJHRAJXDdELXhhCzTGw==", null, false, null, false, "rosemarie@mail2danny.com" },
                    { new Guid("902c3cd9-d3c8-48e9-b709-a5d98007d61f"), 0, "a4c21142-7428-48cc-afd9-38d2cb9ba268", "Thammavong.Anya@mail2princess.com", false, false, null, "THAMMAVONG.ANYA@MAIL2PRINCESS.COM", "THAMMAVONG.ANYA@MAIL2PRINCESS.COM", "AQAAAAIAAYagAAAAED5jKf0Xy/Q50u3t3jZy7q4NWs34qwNmzhC9xBhBbA2yWgSRM/yZjQVGSxDB79FDzw==", null, false, null, false, "Thammavong.Anya@mail2princess.com" },
                    { new Guid("927c5f5b-4367-431b-8821-79bff5785595"), 0, "9f0d21b6-0ebb-42e3-8a6d-f83c70390f78", "Chanelle.Wraight1@movemail.com", false, false, null, "CHANELLE.WRAIGHT1@MOVEMAIL.COM", "CHANELLE.WRAIGHT1@MOVEMAIL.COM", "AQAAAAIAAYagAAAAENvUtpzTMxI8ypHwsYXTutim/x7xIy/iQXT96ube0ksC2OmuIntJA3hQkKdiUJoWOA==", null, false, null, false, "Chanelle.Wraight1@movemail.com" },
                    { new Guid("98d3e283-9ba6-431a-b023-f976c94fdd88"), 0, "1ac07233-e381-4338-b72e-d28d01a74279", "Kolwyck.Janette@mail2botswana.com", false, false, null, "KOLWYCK.JANETTE@MAIL2BOTSWANA.COM", "KOLWYCK.JANETTE@MAIL2BOTSWANA.COM", "AQAAAAIAAYagAAAAEC7BLhZOgrFkIvOK0AQwI3BWPqDdd4/mfvUKL6sxMXtVSmmDvSQhFIp0pr5x/otPbg==", null, false, null, false, "Kolwyck.Janette@mail2botswana.com" },
                    { new Guid("9978e71f-3c4c-456a-9afe-a9c4d8f0c755"), 0, "a1eaac5f-b7ff-43c5-b72c-b54289158ef8", "shemika@spray.se", false, false, null, "SHEMIKA@SPRAY.SE", "SHEMIKA@SPRAY.SE", "AQAAAAIAAYagAAAAEOyyHk0EWq0/gba5btCchVw2Wt0+KVs025Cow1KvDbBhWnNRfpx1OBn1pjtT9Rv08g==", null, false, null, false, "shemika@spray.se" },
                    { new Guid("9b1432ca-ec7a-4f4b-b029-41bb58ac748a"), 0, "e88211fd-cfe3-4a09-b94a-e682bb91fe64", "pennycorne5@writemeback.com", false, false, null, "PENNYCORNE5@WRITEMEBACK.COM", "PENNYCORNE5@WRITEMEBACK.COM", "AQAAAAIAAYagAAAAEEPZVbSAMLORxdlbHGI1R7bn8um/WLNq78o397MaTRk1ef/BLl4qtEDgbuVdAqRWfw==", null, false, null, false, "pennycorne5@writemeback.com" },
                    { new Guid("9b8d0fce-34bf-4172-8374-2fef5f6a7c85"), 0, "9fe3b2ed-1656-44e7-8783-003d58b0e09a", "Groos.Ailene3@yahoo.com.cn", false, false, null, "GROOS.AILENE3@YAHOO.COM.CN", "GROOS.AILENE3@YAHOO.COM.CN", "AQAAAAIAAYagAAAAEDeZVq3Nx+NCFmwMaFOgAk3Anw/Ijyg4w1EqLh8RWpEDn3aJSAi4UR1ksDt8u2EnCQ==", null, false, null, false, "Groos.Ailene3@yahoo.com.cn" },
                    { new Guid("a003f855-61a8-46b1-9e44-7231f479c773"), 0, "a21a8b48-168f-49a1-92d6-85a64e930da8", "gemmafahrenkrug@welsh-lady.com", false, false, null, "GEMMAFAHRENKRUG@WELSH-LADY.COM", "GEMMAFAHRENKRUG@WELSH-LADY.COM", "AQAAAAIAAYagAAAAEOFJLlXX/7wyjtKqlxyNpHE8GxRxfJvbI5+UrTnnAIa1C/wXE38c4lUdFqHEUmkeow==", null, false, null, false, "gemmafahrenkrug@welsh-lady.com" },
                    { new Guid("a5c679ac-5915-464c-87a7-64de3bb6fa8f"), 0, "e79e6da4-d804-4df6-bc70-a23b9659ab1d", "kandispelchat9@mail2la.com", false, false, null, "KANDISPELCHAT9@MAIL2LA.COM", "KANDISPELCHAT9@MAIL2LA.COM", "AQAAAAIAAYagAAAAEE/SEW4eO4yuqzK7mvnXOFh4ByTOExB8ZvG8cNCYIsZKFLYrMnT5ISbacDgotpy5Rw==", null, false, null, false, "kandispelchat9@mail2la.com" },
                    { new Guid("a65c0385-e7fe-490e-90c0-f01e2042fd3f"), 0, "ccaea929-c5d1-4365-87f3-44608c1a4b7e", "gena@mail2larry.com", false, false, null, "GENA@MAIL2LARRY.COM", "GENA@MAIL2LARRY.COM", "AQAAAAIAAYagAAAAEEgiN7Sk2xRrJBkAoxjpNuqGcCnyjSEHgQPL+a1QwEzvHCXQjH4Nf+An7+9gE7BV6g==", null, false, null, false, "gena@mail2larry.com" },
                    { new Guid("a77346f4-8b80-4b19-8186-f3f39e23b58d"), 0, "ef4ba221-bb4e-47a0-af12-808cb06e09ec", "Christi.Kerkvliet2@assamesemail.com", false, false, null, "CHRISTI.KERKVLIET2@ASSAMESEMAIL.COM", "CHRISTI.KERKVLIET2@ASSAMESEMAIL.COM", "AQAAAAIAAYagAAAAEBluyZf2UwHXxjzGmr+DSeSzqqTa9IZre2vpsoclAXTJdX4sb/cOX/0elu4Y3FPzBg==", null, false, null, false, "Christi.Kerkvliet2@assamesemail.com" },
                    { new Guid("a876e91d-111a-4953-9d51-25be0df094eb"), 0, "28c693c3-d488-4b24-b162-43c50f53f198", "vernicegalati@fastmailbox.net", false, false, null, "VERNICEGALATI@FASTMAILBOX.NET", "VERNICEGALATI@FASTMAILBOX.NET", "AQAAAAIAAYagAAAAEFxrZWb48MLdDxpj9kLQRHlFjBVAx8SzTFIhZix+QYd8IP94mg8tR7f9kyTT1JVokA==", null, false, null, false, "vernicegalati@fastmailbox.net" },
                    { new Guid("a909c01c-cc00-4ba0-9425-d2df0ad1074c"), 0, "1958b59e-1bbd-42bb-bfba-8f03f2e91891", "broughermarine@mp4.it", false, false, null, "BROUGHERMARINE@MP4.IT", "BROUGHERMARINE@MP4.IT", "AQAAAAIAAYagAAAAEKAU6AmxaENXhlk1wNG88WkxNMAEWG2ssAwaUZUCTTQfi+r/urr6jy/12LfBBy92gw==", null, false, null, false, "broughermarine@mp4.it" },
                    { new Guid("abde46d9-d4fd-47cd-86e8-ac7f59ebc2db"), 0, "8774d3c0-1cb1-4ffd-a127-3f20bf614fa2", "Ordas.Aliza@boardermail.com", false, false, null, "ORDAS.ALIZA@BOARDERMAIL.COM", "ORDAS.ALIZA@BOARDERMAIL.COM", "AQAAAAIAAYagAAAAEAxxrRTiJ+LJTujj4/wqk7zSPqSojWcTCWJBzrcmu8QcEq/5rV74fnhT5SoocpLaxA==", null, false, null, false, "Ordas.Aliza@boardermail.com" },
                    { new Guid("af141b8e-6296-446e-a87d-7383a70057df"), 0, "e5cf76d9-a196-40e1-bf20-c4f28ec35c75", "Hrna.Chanda@mail2libertarian.com", false, false, null, "HRNA.CHANDA@MAIL2LIBERTARIAN.COM", "HRNA.CHANDA@MAIL2LIBERTARIAN.COM", "AQAAAAIAAYagAAAAEEKBUhNsWfmW7HurTfLOpBWx7WMDJktN3sBlkrpni7Ciyk+sWFp82pd8F69YPPQLIw==", null, false, null, false, "Hrna.Chanda@mail2libertarian.com" },
                    { new Guid("b4abe570-cc41-4af0-b02a-3b6794ee124a"), 0, "3f37528f-897b-43f7-9be5-64177f0582db", "Burbidge.Annett3@list.ru", false, false, null, "BURBIDGE.ANNETT3@LIST.RU", "BURBIDGE.ANNETT3@LIST.RU", "AQAAAAIAAYagAAAAELLsgQO9z0vx1W1L6F0sFRHEKNt+DJN9kaNHYB67p/g0VpLSIM8p3KLPLBYT57enGQ==", null, false, null, false, "Burbidge.Annett3@list.ru" },
                    { new Guid("b6646379-cfb4-453d-8d91-a6e00479609f"), 0, "98dace24-da87-4c7e-b399-ccdb5585f639", "rosario@2bmail.co.uk", false, false, null, "ROSARIO@2BMAIL.CO.UK", "ROSARIO@2BMAIL.CO.UK", "AQAAAAIAAYagAAAAEF+RZnGBoguLYHFxT0jg5vuyOcG+/a+FDeiTt7IRW8wTBgHPy04ZX6PlY1y+NMjWIA==", null, false, null, false, "rosario@2bmail.co.uk" },
                    { new Guid("b7c750de-1526-43c5-8092-5e683aaa1af3"), 0, "49384f46-7fb0-4926-8b85-a853d076b6c4", "corydeangelo2@hot-shot.com", false, false, null, "CORYDEANGELO2@HOT-SHOT.COM", "CORYDEANGELO2@HOT-SHOT.COM", "AQAAAAIAAYagAAAAEKMmKfTkXGfxRLZjfI73KSXZb5mMH0h8MzypQvNbKCLAbqf7IQoMxfLqO1oQ2no0Eg==", null, false, null, false, "corydeangelo2@hot-shot.com" },
                    { new Guid("b9453821-52bb-4978-b6f2-5fbb1750dfd2"), 0, "07967a21-f73f-47ee-a814-086a2a26f9ec", "Wimberley.Charlie@nafe.com", false, false, null, "WIMBERLEY.CHARLIE@NAFE.COM", "WIMBERLEY.CHARLIE@NAFE.COM", "AQAAAAIAAYagAAAAEOjZKnu/jVZAFDGZeZyF9urhrCa2mgfgjPH5P3JUj/XMli0XVa4nBj7rdNX3f3fj3Q==", null, false, null, false, "Wimberley.Charlie@nafe.com" },
                    { new Guid("bdeab514-20fd-4cf6-b608-0741508f8050"), 0, "e0b424a3-8858-46dc-82d4-f6f8dedd47c6", "Wolfley.Nan3@mail2zack.com", false, false, null, "WOLFLEY.NAN3@MAIL2ZACK.COM", "WOLFLEY.NAN3@MAIL2ZACK.COM", "AQAAAAIAAYagAAAAEGsOMZs75DPKVEwoQf8PzwNx9SiB5MGwFkDmXuoYcTBH08rbjpjQpnC8ymoqRQfV8w==", null, false, null, false, "Wolfley.Nan3@mail2zack.com" },
                    { new Guid("c32e9dbf-ebf7-4cdc-ba3f-8089058b52dd"), 0, "a625135e-4627-4cf5-a6d6-ffe750d958bd", "daine@axoskate.com", false, false, null, "DAINE@AXOSKATE.COM", "DAINE@AXOSKATE.COM", "AQAAAAIAAYagAAAAEMBpduB8D22xrMEV05NgzSpwVMPMasKEC9AgDLH0/etzjwXtuHHxFCx9WDKQWBpEsA==", null, false, null, false, "daine@axoskate.com" },
                    { new Guid("c360cd44-214f-4671-9582-74a603c64d69"), 0, "54f2e4e3-a6a5-4c3c-a0ad-1ef3ed9d1847", "rufina2@mail2president.com", false, false, null, "RUFINA2@MAIL2PRESIDENT.COM", "RUFINA2@MAIL2PRESIDENT.COM", "AQAAAAIAAYagAAAAEAaig94OL9f1VpAO1L8ytTZRZSrChngZER3ukW4q6hUrKAOJ9seo/r/5/Md+aZfwOg==", null, false, null, false, "rufina2@mail2president.com" },
                    { new Guid("c468e314-02bd-4349-b534-100416f565f6"), 0, "18a41721-ce13-4997-8542-5fbf7e598dc0", "Sharita.Dorko@uk2net.com", false, false, null, "SHARITA.DORKO@UK2NET.COM", "SHARITA.DORKO@UK2NET.COM", "AQAAAAIAAYagAAAAENGDUVoP83mZX0alAEzYi8YQdarZd1WwNYw+hqWu6PxRB/uZAkkdk5W1JSo/qyj7Fw==", null, false, null, false, "Sharita.Dorko@uk2net.com" },
                    { new Guid("c7f18586-2a92-451b-8543-1fc96a7d7dd2"), 0, "06bb7d30-4cb8-48b3-97d8-aff82864ff7b", "Howryla.Mozell@theheadoffice.com", false, false, null, "HOWRYLA.MOZELL@THEHEADOFFICE.COM", "HOWRYLA.MOZELL@THEHEADOFFICE.COM", "AQAAAAIAAYagAAAAEP+NCciY0NLJN9TUdk2EttgeuYyFimdg8SCf5iMLECrTGxF2NmLGbHxnTGsf/aTKXA==", null, false, null, false, "Howryla.Mozell@theheadoffice.com" },
                    { new Guid("c81f4bfe-3fb4-47f4-83c8-63a10ca434ac"), 0, "c23dc037-c3f4-45db-a7b2-23a3bce479fa", "stanton8@eml.cc", false, false, null, "STANTON8@EML.CC", "STANTON8@EML.CC", "AQAAAAIAAYagAAAAEEjWFko2ZPSTXyIPfFvB/kVQHSsB2Hq/X7IgCfh1QkZsgqzhuNVv1pZ/0Daz0xoJ/w==", null, false, null, false, "stanton8@eml.cc" },
                    { new Guid("cb47c9ec-e4d3-4917-95cd-7a24360febe3"), 0, "578488d9-9c3a-45c3-b22f-f2f9501e370a", "Cofrancesco.Jolyn1@kellychen.com", false, false, null, "COFRANCESCO.JOLYN1@KELLYCHEN.COM", "COFRANCESCO.JOLYN1@KELLYCHEN.COM", "AQAAAAIAAYagAAAAENg6UqXBOQyk/Qh4b44xoV8DdsrnkevgFIXpOekriqqX4QrDNqCEuwM22Db6WK4eJQ==", null, false, null, false, "Cofrancesco.Jolyn1@kellychen.com" },
                    { new Guid("cd1cb521-56c4-417e-9b05-ae2a22d22099"), 0, "8302af10-9fe9-4f98-9f9f-cd7377285ac8", "Lill.Inger2@mail2trekkie.com", false, false, null, "LILL.INGER2@MAIL2TREKKIE.COM", "LILL.INGER2@MAIL2TREKKIE.COM", "AQAAAAIAAYagAAAAEG5WvRjqcYbZrgSIKO/sbviFpxZP2b+i9sDcQ0MgrfZcf1/3l1fkbr4AO2zOjyGVlQ==", null, false, null, false, "Lill.Inger2@mail2trekkie.com" },
                    { new Guid("ce4397d5-dafd-4242-98ed-cc0821c11d26"), 0, "870a76b1-a389-4229-8c4a-18772014b95b", "emmahuland6@sify.com", false, false, null, "EMMAHULAND6@SIFY.COM", "EMMAHULAND6@SIFY.COM", "AQAAAAIAAYagAAAAEIBRoFCijnAZuf23BQDR5oAYrAZtZwuWn6XXpjtJXdW0uCFxDQ2n5LofgRywNPnZLQ==", null, false, null, false, "emmahuland6@sify.com" },
                    { new Guid("cffdefda-be63-431d-97ee-30d039d185c3"), 0, "6f662e7f-30b0-45bb-af79-52e21e48f5b0", "Clarinda.Schwarts@ralib.com", false, false, null, "CLARINDA.SCHWARTS@RALIB.COM", "CLARINDA.SCHWARTS@RALIB.COM", "AQAAAAIAAYagAAAAENsmovScPgrNK0zJ8onAudFkRn9Wa8Zlu7NQhf57oTo4sr6xAMKNIkMfEpfctgjDnQ==", null, false, null, false, "Clarinda.Schwarts@ralib.com" },
                    { new Guid("d57328c4-6996-4edf-90cd-5e8009525d40"), 0, "07044de0-918c-460c-bad4-d24545351a01", "Hunnicutt.Leslee@zweb.in", false, false, null, "HUNNICUTT.LESLEE@ZWEB.IN", "HUNNICUTT.LESLEE@ZWEB.IN", "AQAAAAIAAYagAAAAENwzNoLh2Vsxcp91THOuuPDLUuHerioggoMMk6oV9ksX8o/6D4xXzm5DAObJNv3sfg==", null, false, null, false, "Hunnicutt.Leslee@zweb.in" },
                    { new Guid("d92dc5b7-9adf-470b-a7da-50d2008269e9"), 0, "e6f102ec-3450-4a32-99a9-9155d90da339", "barrie@ezcybersearch.com", false, false, null, "BARRIE@EZCYBERSEARCH.COM", "BARRIE@EZCYBERSEARCH.COM", "AQAAAAIAAYagAAAAEHnC9snkF1p1Kb5RHQTXdAX0i9yE/gpuqep3zi+C7nDqoU8EGbP/eVmot8rA0aKeRA==", null, false, null, false, "barrie@ezcybersearch.com" },
                    { new Guid("d9406416-b267-4571-becf-ff2fd36ecb9b"), 0, "638651f4-0f6d-41fa-92de-1f4024be84f1", "angelohafferkamp@gaybrighton.co.uk", false, false, null, "ANGELOHAFFERKAMP@GAYBRIGHTON.CO.UK", "ANGELOHAFFERKAMP@GAYBRIGHTON.CO.UK", "AQAAAAIAAYagAAAAEJWXWilu3eEzts7BSCQkEgekQ5acXqseEoxol7sMPyFdcnPZ52NK9ygbySKUMdGasQ==", null, false, null, false, "angelohafferkamp@gaybrighton.co.uk" },
                    { new Guid("dae950c0-cf18-44fb-985d-6a6bfacfd61e"), 0, "d17b7083-5426-4dd6-b2cd-25bf7fe0cf1d", "Floy.Schlensker@lover-boy.com", false, false, null, "FLOY.SCHLENSKER@LOVER-BOY.COM", "FLOY.SCHLENSKER@LOVER-BOY.COM", "AQAAAAIAAYagAAAAEBj2oFbodszfUeyCRXIQ5+0cONRdk+Dlw4n9gPxotcDdmS8Q4f6RhobL0YHSFTgxvw==", null, false, null, false, "Floy.Schlensker@lover-boy.com" },
                    { new Guid("dcbe67c2-3ae5-4c10-a4b4-4caf88d50778"), 0, "83f4c849-19d5-40f0-8e9c-9ad45685b7a6", "yontzkaitlin4@wahoye.com", false, false, null, "YONTZKAITLIN4@WAHOYE.COM", "YONTZKAITLIN4@WAHOYE.COM", "AQAAAAIAAYagAAAAECfRol1hINNuLpe6iKYvilvzECXFfQmUu2pxtqdOV0qzms6SHYSZsWXrEGQo9o/WZg==", null, false, null, false, "yontzkaitlin4@wahoye.com" },
                    { new Guid("de9784b8-0dea-4dc6-aaee-7f80604ec999"), 0, "cf89f744-8392-4af4-98c0-2534a022b513", "Jame.Teeter@catchamail.com", false, false, null, "JAME.TEETER@CATCHAMAIL.COM", "JAME.TEETER@CATCHAMAIL.COM", "AQAAAAIAAYagAAAAEGiM/2UvvqnIQ5tm9xI87tpIXCXspO7n3fJnCnEqv8fqDPs2vrpBO2aD8OZVYpiGQw==", null, false, null, false, "Jame.Teeter@catchamail.com" },
                    { new Guid("dfefdb80-1c4e-463f-ab2d-7d2e33f59964"), 0, "55cf8598-d3e0-4a03-8758-549533a3dea5", "mindihammerstein3@mail2panama.com", false, false, null, "MINDIHAMMERSTEIN3@MAIL2PANAMA.COM", "MINDIHAMMERSTEIN3@MAIL2PANAMA.COM", "AQAAAAIAAYagAAAAEHHIvJ3rPgm1+jmKcrBhBpKbEt1uwiDCotcpkkbEdJXQIMFu3gbBUDflRgGS4tQGXw==", null, false, null, false, "mindihammerstein3@mail2panama.com" },
                    { new Guid("e5bf0a3a-980e-43f3-9ecd-c1f30521ae33"), 0, "7ac5f06c-b62c-45f8-b130-ea16933efa78", "Rava.Bettina8@mail2mba.com", false, false, null, "RAVA.BETTINA8@MAIL2MBA.COM", "RAVA.BETTINA8@MAIL2MBA.COM", "AQAAAAIAAYagAAAAEImrWfiDMfEAIfnMrhxcrYOT83pxWPBr+l2jdbwxoQAkmnxDVIIoEHux2KKO/S6UYQ==", null, false, null, false, "Rava.Bettina8@mail2mba.com" },
                    { new Guid("e8aaadd5-89d4-4127-88fa-141fe4791886"), 0, "36b49062-7382-48f2-900c-9a824f279246", "brehonydave@feyenoorder.com", false, false, null, "BREHONYDAVE@FEYENOORDER.COM", "BREHONYDAVE@FEYENOORDER.COM", "AQAAAAIAAYagAAAAEBzVv41s399uKgRvzXiqfbrzSM8PyxRA3K5cugPcdoi8NNRCmwDo5cyEiUcbN/wBeA==", null, false, null, false, "brehonydave@feyenoorder.com" },
                    { new Guid("ea254921-c329-46e2-83b0-6be9dc08610a"), 0, "15d8f854-0ee0-457a-b802-56dfa742c9c1", "hawkinkarine@trmailbox.com", false, false, null, "HAWKINKARINE@TRMAILBOX.COM", "HAWKINKARINE@TRMAILBOX.COM", "AQAAAAIAAYagAAAAEI/2ELzNcf0Vl9IZQIvmzlwbEXpyPXMF9LpE1XMx272xCjv4w3N9ocCYaUBECos2Cw==", null, false, null, false, "hawkinkarine@trmailbox.com" },
                    { new Guid("f3615e2f-147e-421b-bb0a-e68ceabd78a2"), 0, "320ce925-9490-4d4f-9356-0a0c05a21967", "Barbara.Dame@skafan.com", false, false, null, "BARBARA.DAME@SKAFAN.COM", "BARBARA.DAME@SKAFAN.COM", "AQAAAAIAAYagAAAAED0YyfTe7lfyr+if4mojzVu2/WKMyIZZPFn1z11Vczm6imA0lJf72piyG7qmQlEXpw==", null, false, null, false, "Barbara.Dame@skafan.com" },
                    { new Guid("f5a12041-7994-4130-a9ca-c9f1cfd78595"), 0, "035b58d9-240d-4e4c-b129-649d8334991b", "shaquana@icrazy.com", false, false, null, "SHAQUANA@ICRAZY.COM", "SHAQUANA@ICRAZY.COM", "AQAAAAIAAYagAAAAEIYF4gBRZVCKtsVZGSfeZdjuruPlAILdzlC8Y7BuOwQpStppi8IT0/srTZSH4LE/Zw==", null, false, null, false, "shaquana@icrazy.com" },
                    { new Guid("fccf7326-0272-4cf1-a220-0699602b4b44"), 0, "fc57c5e0-680b-43ee-bf3d-80fe52587dd7", "brittney@srilankan.net", false, false, null, "BRITTNEY@SRILANKAN.NET", "BRITTNEY@SRILANKAN.NET", "AQAAAAIAAYagAAAAEDOUKpH2M4yk6P8qKEFmxTCmLDPdsj7HyCo7a3DLFPMRJ1lgGgHfN3crIi//kx/cYQ==", null, false, null, false, "brittney@srilankan.net" }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "Country", "Founded", "Industry", "Name", "Phone", "PhotoUrl", "SecondaryPhone", "UserId" },
                values: new object[,]
                {
                    { new Guid("0028013a-253b-421a-8c74-936d119b0738"), "Cocos (Keeling Islands)", new DateOnly(45, 12, 17), "Property-Casualty Insurers", "SpencerTrac", "734.620.1364 x2211", "https://picsum.photos/200/300", "", new Guid("ea254921-c329-46e2-83b0-6be9dc08610a") },
                    { new Guid("00e84dc4-48b5-416c-9f43-2423ac736c52"), "Portugal", new DateOnly(46, 7, 18), "Life Insurance", "TessHalgas", "764.502.4521 x36012", "https://picsum.photos/200/300", "", new Guid("2e8ca9c4-b870-4fc8-bcfe-8ac009d3c801") },
                    { new Guid("0197f749-cf3f-4e84-bca1-ea01d40440f7"), "Bouvet Island", new DateOnly(53, 12, 14), "Automotive Aftermarket", "DanieleRickenbacker", "815-177-0564 x70320", "https://picsum.photos/200/300", "", new Guid("52a932d7-c970-4dcd-9794-5231bd69055d") },
                    { new Guid("0239d02c-9a00-49e9-bd06-a8d079567e7c"), "Turks and Caicos Islands", new DateOnly(55, 4, 25), "Movies/Entertainment", "ElwandaMozick", "811.444.6876 x6333", "https://picsum.photos/200/300", "", new Guid("f3615e2f-147e-421b-bb0a-e68ceabd78a2") },
                    { new Guid("056f4fbf-3349-40c2-b63d-51d4633c98f9"), "Reunion", new DateOnly(28, 8, 18), "Radio And Television Broadcasting And Communications Equipment", "LouanneStrand", "434-408-5365", "https://picsum.photos/200/300", "", new Guid("50a83e53-8a4c-4a62-b2ae-e255353be23e") },
                    { new Guid("091ad5ab-926f-4153-ab2e-493a23a792f6"), "Swaziland", new DateOnly(55, 9, 21), "Clothing/Shoe/Accessory Stores", "KimberliHildner", "(687)323-5750", "https://picsum.photos/200/300", "", new Guid("98d3e283-9ba6-431a-b023-f976c94fdd88") },
                    { new Guid("0a457fb5-a216-4c28-9896-f9e688b031cb"), "Jamaica", new DateOnly(37, 11, 4), "Savings Institutions", "KathaleenPettett", "1-812-430-3128 x3366", "https://picsum.photos/200/300", "", new Guid("9b8d0fce-34bf-4172-8374-2fef5f6a7c85") },
                    { new Guid("0a8e5345-5c9a-48e6-87b1-3b43ed145a79"), "Dominican Republic", new DateOnly(70, 9, 30), "Package Goods/Cosmetics", "DannieIngemi", "1-334-510-8736", "https://picsum.photos/200/300", "", new Guid("7f0ff3db-c2e3-4fbe-a990-fc961bd11056") },
                    { new Guid("0a93a0ca-0cdc-46d2-896f-42c668495b02"), "Hong Kong", new DateOnly(26, 10, 24), "Specialty Chemicals", "CleoAirhart", "668.362.3187", "https://picsum.photos/200/300", "", new Guid("356d1249-cf5c-4f06-8515-b8219520eb2d") },
                    { new Guid("0aee24c7-c7cb-46fb-876f-f09735af3159"), "Russian Federation", new DateOnly(42, 3, 13), "Pollution Control Equipment", "LawannaSpena", "(817)313-2605", "https://picsum.photos/200/300", "", new Guid("50c35805-2225-46c9-8963-cf1398666f77") },
                    { new Guid("0edac3fa-4b53-4df3-b688-e68b823615e6"), "Andorra", new DateOnly(59, 5, 10), "Pollution Control Equipment", "TheressaHascup", "035.756.8372 x27445", "https://picsum.photos/200/300", "", new Guid("8939dc9f-e83b-4c0a-b53c-ce6e60fe9253") },
                    { new Guid("16178dff-567a-4da0-bbd8-7cf5a94dee1d"), "Cote D'Ivoire (Ivory Coast)", new DateOnly(72, 1, 14), "Television Services", "AmieeLarusso", "434.652.6474", "https://picsum.photos/200/300", "", new Guid("d57328c4-6996-4edf-90cd-5e8009525d40") },
                    { new Guid("19e34ee6-d4d4-4e89-8d2e-752a6feb773a"), "Tunisia", new DateOnly(66, 9, 17), "Semiconductors", "KeiraMessamore", "655-773-7226", "https://picsum.photos/200/300", "", new Guid("28251510-2395-48e8-aeed-57222599f55c") },
                    { new Guid("1ac1a6c7-33a6-4670-8f0e-3ef252abce76"), "Sweden", new DateOnly(53, 3, 12), "Building Materials", "AlexanderLitchmore", "260.854.8564 x13472", "https://picsum.photos/200/300", "", new Guid("902c3cd9-d3c8-48e9-b709-a5d98007d61f") },
                    { new Guid("1e64145e-02a9-4775-9e11-0723a1a0e214"), "India", new DateOnly(30, 2, 6), "Packaged Foods", "TadWytch", "(732)866-4525 x543", "https://picsum.photos/200/300", "", new Guid("abde46d9-d4fd-47cd-86e8-ac7f59ebc2db") },
                    { new Guid("26fec4fe-af44-442a-9903-073338aeca13"), "Norway", new DateOnly(65, 12, 5), "Business Services", "HildeHolgerson", "1-545-380-5757 x366", "https://picsum.photos/200/300", "", new Guid("15418835-1d59-428d-95eb-b66a051cf625") },
                    { new Guid("27acf4f6-29b4-4547-971c-c2410320f222"), "Vanuatu", new DateOnly(30, 12, 20), "Department/Specialty Retail Stores", "JoiKeedah", "(487)106-0073 x368", "https://picsum.photos/200/300", "", new Guid("2de19ce4-070a-4fc8-9ac9-6de4be880eb0") },
                    { new Guid("2b4d039d-94ff-4ea1-bc79-bfe5835ce252"), "Hong Kong", new DateOnly(46, 9, 5), "Property-Casualty Insurers", "RobbiCarello", "030-030-8868 x3312", "https://picsum.photos/200/300", "", new Guid("67e1825d-b2c5-4d10-b961-56fc9bdcf775") },
                    { new Guid("31bbd092-4bae-4a22-a50d-be84d534c3df"), "Benin", new DateOnly(74, 4, 25), "Television Services", "MitsukoBehrendt", "641-203-8660 x572", "https://picsum.photos/200/300", "", new Guid("f5a12041-7994-4130-a9ca-c9f1cfd78595") },
                    { new Guid("328fc453-1f86-46f2-9b5a-7dd4e19c4983"), "Gibraltar", new DateOnly(51, 2, 24), "Telecommunications Equipment", "TamieHargers", "(440)505-6553 x132", "https://picsum.photos/200/300", "", new Guid("6085fbb9-738a-44a9-bc12-ac9ef190c291") },
                    { new Guid("376f8f1c-db2e-4b64-8bba-0a58ed03255f"), "Ghana", new DateOnly(29, 10, 29), "Food Distributors", "AnnelleLev", "(816)226-4151 x0435", "https://picsum.photos/200/300", "", new Guid("1db86547-16b0-4642-b5dc-11b744601398") },
                    { new Guid("391c0ab8-2926-439a-9695-27d8e7225394"), "Liberia", new DateOnly(62, 7, 5), "Specialty Foods", "WyattAlvarran", "1-826-036-6354", "https://picsum.photos/200/300", "", new Guid("8808c685-4356-45d9-947b-f8939a6a6913") },
                    { new Guid("3ddf4ffe-8442-424d-a39f-83c284ece246"), "Sao Tome and Principe", new DateOnly(36, 1, 19), "Newspapers/Magazines", "DallasHolvey", "777-721-2355", "https://picsum.photos/200/300", "", new Guid("a5c679ac-5915-464c-87a7-64de3bb6fa8f") },
                    { new Guid("40f3e6c5-6a59-4ec3-a889-90ac3f09a239"), "Bangladesh", new DateOnly(29, 10, 31), "Life Insurance", "WillodeanParler", "636.335.0165", "https://picsum.photos/200/300", "", new Guid("25541e42-d5d4-48a7-af81-59c28277db7a") },
                    { new Guid("416c86db-9bbf-4ee8-b165-0ca7767e34a2"), "Trinidad and Tobago", new DateOnly(54, 4, 1), "Agricultural Chemicals", "IvoryWolter", "002-426-2704", "https://picsum.photos/200/300", "", new Guid("b7c750de-1526-43c5-8092-5e683aaa1af3") },
                    { new Guid("42237297-e4e8-400f-83f2-04871f6428df"), "Italy", new DateOnly(54, 12, 14), "Integrated oil Companies", "VinceNickerson", "236-782-3775 x7478", "https://picsum.photos/200/300", "", new Guid("a909c01c-cc00-4ba0-9425-d2df0ad1074c") },
                    { new Guid("489a380d-612d-4544-b97a-b9a00b26ce17"), "Antigua and Barbuda", new DateOnly(40, 8, 14), "Biotechnology: Biological Products (No Diagnostic Substances)", "HerbBjorseth", "(830)377-1423 x32268", "https://picsum.photos/200/300", "", new Guid("1eed8206-8772-42f3-ae58-5e185c00b7b5") },
                    { new Guid("496be307-9458-4cb7-97c9-388e88a1b348"), "Vanuatu", new DateOnly(66, 10, 19), "Restaurants", "KaterineRasinski", "652-488-0230 x2352", "https://picsum.photos/200/300", "", new Guid("6f08a0f8-cb1f-4bef-b73c-76e015d42702") },
                    { new Guid("4a311036-ef27-4ca8-8199-226bd77426ad"), "Mongolia", new DateOnly(35, 7, 17), "Pollution Control Equipment", "JerroldLivingood", "546-741-1454", "https://picsum.photos/200/300", "", new Guid("bdeab514-20fd-4cf6-b608-0741508f8050") },
                    { new Guid("4b125a22-2209-4db8-b751-65d7599a5797"), "Argentina", new DateOnly(67, 11, 23), "Marine Transportation", "DanikaBrooke", "611-607-8055", "https://picsum.photos/200/300", "", new Guid("d92dc5b7-9adf-470b-a7da-50d2008269e9") },
                    { new Guid("4c313726-199a-4b30-be5c-b8af5f4a928a"), "El Salvador", new DateOnly(43, 1, 21), "Specialty Chemicals", "RussellSandman", "628.327.7753 x15010", "https://picsum.photos/200/300", "", new Guid("8d8a855e-94b7-4020-bedb-b8b653ab5b8e") },
                    { new Guid("4e1fa878-39e1-47f0-a0bb-4141f9979cde"), "Oman", new DateOnly(64, 3, 17), "Food Chains", "ShanekaBarkett", "677-507-0167 x0672", "https://picsum.photos/200/300", "", new Guid("5b5c4caa-f9d0-4c18-9ac8-5206e4a34f4c") },
                    { new Guid("4e769dfd-5f79-4b99-9a70-688b53e4e28d"), "Andorra", new DateOnly(65, 8, 18), "Farming/Seeds/Milling", "LeslieSartor", "1-123-788-4166 x35501", "https://picsum.photos/200/300", "", new Guid("870e3d2a-f489-46c5-b62a-a354045ede13") },
                    { new Guid("54613efb-ec11-4a76-ac42-20f573d570dd"), "Maldives", new DateOnly(51, 7, 27), "Home Furnishings", "ShannaTease", "(700)276-7086", "https://picsum.photos/200/300", "", new Guid("a876e91d-111a-4953-9d51-25be0df094eb") },
                    { new Guid("550f1f31-e10d-440f-aba3-e93e92af2db0"), "Guatemala", new DateOnly(71, 1, 19), "Computer Manufacturing", "KylePaplow", "823.471.0287", "https://picsum.photos/200/300", "", new Guid("0f1d7428-efd8-4891-87a8-4fb9158dad71") },
                    { new Guid("5b32dc9e-cb50-4ccf-96f2-ee270c3e6e36"), "Papua New Guinea", new DateOnly(71, 11, 17), "Pollution Control Equipment", "KaleighRhone", "1-105-088-8105 x76863", "https://picsum.photos/200/300", "", new Guid("622e5ec7-5d61-4702-aa29-088b42a865b5") },
                    { new Guid("5c2dbccc-37e8-48c0-9c42-979ac00b2e51"), "Macedonia", new DateOnly(35, 6, 29), "Biotechnology: Biological Products (No Diagnostic Substances)", "TianaWeissinger", "256.368.0720 x5683", "https://picsum.photos/200/300", "", new Guid("d9406416-b267-4571-becf-ff2fd36ecb9b") },
                    { new Guid("60eb8d0c-6a11-4494-97c9-12e12e1b75d9"), "South Africa", new DateOnly(52, 11, 1), "Miscellaneous", "TamathaDegraaf", "735-161-4880 x505", "https://picsum.photos/200/300", "", new Guid("b6646379-cfb4-453d-8d91-a6e00479609f") },
                    { new Guid("657aa7bf-646d-4a39-bb17-e1a23e6fc8eb"), "Australia", new DateOnly(36, 6, 23), "Mining & Quarrying of Nonmetallic Minerals (No Fuels)", "GrettaRuzicka", "603.518.6823 x416", "https://picsum.photos/200/300", "", new Guid("a003f855-61a8-46b1-9e44-7231f479c773") },
                    { new Guid("65bacbe5-6737-45f1-829e-b0df55f4e5e9"), "Russian Federation", new DateOnly(46, 10, 27), "Computer Manufacturing", "DonyaErtzbischoff", "(480)665-2504 x03867", "https://picsum.photos/200/300", "", new Guid("5adf7c8c-4f3f-4677-9cc3-914ccef2474e") },
                    { new Guid("6f310d04-af8e-4996-bebc-534dddb3de11"), "Vanuatu", new DateOnly(65, 9, 1), "Shoe Manufacturing", "SachaBylsma", "(055)450-7370", "https://picsum.photos/200/300", "", new Guid("fccf7326-0272-4cf1-a220-0699602b4b44") },
                    { new Guid("6ffe764e-aa0a-48b0-91d3-4eb4c87bac21"), "Burkina Faso", new DateOnly(64, 10, 7), "Broadcasting", "TommieBusacker", "403.126.5703 x44140", "https://picsum.photos/200/300", "", new Guid("590b8456-ce5f-4c5c-aadc-835f839b95ef") },
                    { new Guid("7038c8a4-6da6-4b55-a543-9530f8a65f93"), "Burkina Faso", new DateOnly(55, 12, 18), "Marine Transportation", "ZenobiaBenward", "674.782.8323", "https://picsum.photos/200/300", "", new Guid("753638e3-2999-474a-8546-74442b3dc2d6") },
                    { new Guid("72f5a074-97d0-48b6-a36a-530ef43d7a81"), "Austria", new DateOnly(46, 8, 18), "Integrated oil Companies", "JohnieSemprini", "150.105.4051", "https://picsum.photos/200/300", "", new Guid("927c5f5b-4367-431b-8821-79bff5785595") },
                    { new Guid("762cf6f4-868b-4bed-b592-c2cef2cea047"), "Slovak Republic", new DateOnly(45, 5, 17), "Miscellaneous manufacturing industries", "CliffordBoadway", "1-547-801-7618 x6753", "https://picsum.photos/200/300", "", new Guid("8da87f6f-ab51-4e62-9420-d39f30e9ecd6") },
                    { new Guid("78214fab-3362-43a7-b240-0eaa6af9262f"), "France", new DateOnly(32, 2, 3), "Computer Software: Prepackaged Software", "MarthaBoulton", "1-405-802-2516 x220", "https://picsum.photos/200/300", "", new Guid("7a8ec500-3508-46f3-bcd7-d927549f5683") },
                    { new Guid("78e5807a-845b-47e7-86ad-349add80d67b"), "Equatorial Guinea", new DateOnly(63, 1, 21), "Publishing", "ManualGanas", "347-102-1338 x71244", "https://picsum.photos/200/300", "", new Guid("dae950c0-cf18-44fb-985d-6a6bfacfd61e") },
                    { new Guid("7a68e2bf-4e46-4dd4-820b-b2d2f65ec41a"), "Svalbard and Jan Mayen Islands", new DateOnly(33, 7, 4), "Computer Software: Programming, Data Processing", "AnjelicaSlimak", "706.802.0760 x645", "https://picsum.photos/200/300", "", new Guid("c32e9dbf-ebf7-4cdc-ba3f-8089058b52dd") },
                    { new Guid("7b65b6c3-f206-49a8-954d-c0dddc851188"), "Ireland", new DateOnly(36, 9, 1), "Hotels/Resorts", "DaneMaginn", "265.035.0366 x54142", "https://picsum.photos/200/300", "", new Guid("c468e314-02bd-4349-b534-100416f565f6") },
                    { new Guid("7e3680e0-7da9-44b5-a005-d90fe69e4d7d"), "Liberia", new DateOnly(69, 1, 8), "Diversified Electronic Products", "JaclynGertken", "1-428-584-3788 x18172", "https://picsum.photos/200/300", "", new Guid("de9784b8-0dea-4dc6-aaee-7f80604ec999") },
                    { new Guid("818605ee-3a9c-4212-b68d-484e7c94fcc8"), "Malawi", new DateOnly(43, 10, 18), "Other Specialty Stores", "MadelynSthilaire", "761-266-8787 x56170", "https://picsum.photos/200/300", "", new Guid("5d7fcfdc-13fc-47ea-bf50-ef39a503d586") },
                    { new Guid("81995799-acc6-4b7c-86ed-3f88328b2b31"), "Myanmar", new DateOnly(39, 1, 14), "Movies/Entertainment", "BreeHandelman", "(338)501-0162", "https://picsum.photos/200/300", "", new Guid("1053b5e7-4521-4c06-b0a7-a02b6d333c4c") },
                    { new Guid("823ae90a-815a-411c-92ac-1f7b53cd9f7f"), "Bangladesh", new DateOnly(28, 7, 20), "Consumer Electronics/Appliances", "EwaOsterland", "(017)788-7484", "https://picsum.photos/200/300", "", new Guid("c81f4bfe-3fb4-47f4-83c8-63a10ca434ac") },
                    { new Guid("84dc2973-934a-455f-94ff-a3a53ab98ab6"), "Switzerland", new DateOnly(69, 2, 15), "Automotive Aftermarket", "SoGastley", "1-878-488-1718", "https://picsum.photos/200/300", "", new Guid("e5bf0a3a-980e-43f3-9ecd-c1f30521ae33") },
                    { new Guid("84e9c665-a1f4-4b95-9ffd-51cc7d8b5675"), "Monaco", new DateOnly(25, 10, 25), "Publishing", "MagdaleneWalstad", "012.322.1374 x02164", "https://picsum.photos/200/300", "", new Guid("dfefdb80-1c4e-463f-ab2d-7d2e33f59964") },
                    { new Guid("850de5e7-a446-44f1-ac4a-d247e2f8fb36"), "Dominican Republic", new DateOnly(38, 3, 16), "Retail: Computer Software & Peripheral Equipment", "TrulaNipple", "(541)761-0142", "https://picsum.photos/200/300", "", new Guid("1668b07f-d9cb-46f4-98f6-ef58db4625bf") },
                    { new Guid("8613761b-686f-4081-834f-6b0bd78cfc2f"), "Guinea", new DateOnly(37, 12, 2), "Railroads", "EvelynnSchlesinger", "246-631-2283 x065", "https://picsum.photos/200/300", "", new Guid("33fd83af-349f-47e6-869b-7de408e26fe8") },
                    { new Guid("872b04d5-f2e7-47ad-978d-50d8eff1f6de"), "Germany", new DateOnly(36, 9, 7), "Other Transportation", "CrisEddy", "166.185.4374", "https://picsum.photos/200/300", "", new Guid("09045647-6bcc-44a3-bc0f-06f15dab0611") },
                    { new Guid("88be43d2-6666-4f33-ac03-d1de524dea22"), "Australia", new DateOnly(39, 7, 20), "Medical/Dental Instruments", "JaniGower", "353-006-2681 x548", "https://picsum.photos/200/300", "", new Guid("6589d2bd-4a01-4523-a038-fa6b666cf4bb") },
                    { new Guid("8c45688b-7032-413c-9003-45136dedda89"), "Tonga", new DateOnly(33, 5, 19), "Oilfield Services/Equipment", "ColleenRester", "474.827.6867", "https://picsum.photos/200/300", "", new Guid("3f81db9a-95f1-4d2b-ab17-17c4bbd7f00e") },
                    { new Guid("8d433efc-8cf8-4ca8-98af-3015bd3271af"), "Central African Republic", new DateOnly(35, 5, 8), "Pollution Control Equipment", "ColettaTopolski", "(272)776-0613 x1232", "https://picsum.photos/200/300", "", new Guid("dcbe67c2-3ae5-4c10-a4b4-4caf88d50778") },
                    { new Guid("8e697190-216b-4293-85bb-30fdaa70c5fb"), "Niue", new DateOnly(27, 2, 20), "Ophthalmic Goods", "DavidHanrahan", "047.607.8470 x61146", "https://picsum.photos/200/300", "", new Guid("1a22c164-bf7f-4f93-80f9-7b14977214df") },
                    { new Guid("91bf3618-b7e9-4f68-9cb5-4f77cbf7f04b"), "Afghanistan", new DateOnly(36, 7, 7), "Other Transportation", "KaylaSpizer", "(821)205-2860", "https://picsum.photos/200/300", "", new Guid("0b3ca9c4-0b99-40de-b9db-e0e3c6c41769") },
                    { new Guid("91c9bca3-a390-40f8-8d18-d5a51f64834c"), "Italy", new DateOnly(38, 11, 7), "Television Services", "TarenFil", "1-802-506-3313", "https://picsum.photos/200/300", "", new Guid("362074c8-7ca2-4c80-b964-b335956cf55c") },
                    { new Guid("93548399-b33c-4bd7-a6a7-d194e9140e8f"), "Mexico", new DateOnly(68, 7, 8), "EDP Services", "LuigiTaunton", "(553)187-2418", "https://picsum.photos/200/300", "", new Guid("c360cd44-214f-4671-9582-74a603c64d69") },
                    { new Guid("95ac766f-0a0a-411a-9b49-1d78845a3f3c"), "Mauritania", new DateOnly(60, 8, 8), "Oilfield Services/Equipment", "CoriGerwe", "042-411-1700", "https://picsum.photos/200/300", "", new Guid("e8aaadd5-89d4-4127-88fa-141fe4791886") },
                    { new Guid("97ce24b5-f771-46e2-9273-dc9efc657a0b"), "Swaziland", new DateOnly(43, 8, 31), "Major Pharmaceuticals", "DarleneCarrus", "1-840-045-7405", "https://picsum.photos/200/300", "", new Guid("1d77285a-0724-4a09-aeeb-cac5d6a78d35") },
                    { new Guid("9f9b36cf-1782-45a1-a773-da8663ed7098"), "Jamaica", new DateOnly(36, 9, 1), "Banks", "AlbertaSumption", "317.427.2538", "https://picsum.photos/200/300", "", new Guid("2bad91f5-5c65-4a30-882e-97c736a71660") },
                    { new Guid("a9ff80fc-7b55-4031-b325-3a944b374810"), "Belgium", new DateOnly(55, 9, 13), "Movies/Entertainment", "CourtneyRoden", "571.056.6233", "https://picsum.photos/200/300", "", new Guid("326c6b3e-f3cc-42fc-9c26-af8e407e3899") },
                    { new Guid("aa9243f6-c707-4c43-bb29-6f46398560fd"), "Latvia", new DateOnly(35, 10, 15), "Steel/Iron Ore", "EliseAirhart", "384.458.5750", "https://picsum.photos/200/300", "", new Guid("21fd3d5b-e860-4ea3-8dc5-3b21274be268") },
                    { new Guid("b092688c-1643-4578-a477-90b4be4425c5"), "Macedonia", new DateOnly(46, 4, 3), "Major Chemicals", "SeemaMatsubara", "177-283-3801 x4620", "https://picsum.photos/200/300", "", new Guid("9978e71f-3c4c-456a-9afe-a9c4d8f0c755") },
                    { new Guid("b125fa77-efc0-4944-b626-606189b8947a"), "Malta", new DateOnly(68, 8, 18), "Specialty Insurers", "JosephLaser", "1-125-726-6385", "https://picsum.photos/200/300", "", new Guid("52fc3abb-7546-4eab-b958-ba4dc4c5bab7") },
                    { new Guid("b1445bac-c0fc-4ba0-98de-4e129924ed58"), "Afghanistan", new DateOnly(41, 8, 10), "Electronic Components", "SharlaBraden", "(113)768-8840", "https://picsum.photos/200/300", "", new Guid("af141b8e-6296-446e-a87d-7383a70057df") },
                    { new Guid("b3b050eb-8936-4065-b4b6-76b0e3e68e5d"), "Albania", new DateOnly(33, 3, 13), "Banks", "TabithaAbes", "516-602-7501 x13733", "https://picsum.photos/200/300", "", new Guid("0b525566-35bd-4c0c-a76f-b8d7a3162174") },
                    { new Guid("c0c05eb3-1438-43e8-a27f-6d8a508be891"), "Liechtenstein", new DateOnly(68, 7, 26), "Home Furnishings", "SilvanaVaccarezza", "1-170-563-1356 x83537", "https://picsum.photos/200/300", "", new Guid("553bbf2c-5581-4d8b-86be-162ec235d083") },
                    { new Guid("c604c4c0-2ae9-4e1a-99bc-895d15c5259e"), "Suriname", new DateOnly(43, 1, 24), "Consumer Specialties", "IngeMokriski", "(801)326-5306 x172", "https://picsum.photos/200/300", "", new Guid("cd1cb521-56c4-417e-9b05-ae2a22d22099") },
                    { new Guid("c7c6b2db-4576-44b8-8ad5-0852cbfdfd55"), "Belarus", new DateOnly(64, 9, 7), "Telecommunications Equipment", "MarguriteStrizich", "1-746-332-5616 x48186", "https://picsum.photos/200/300", "", new Guid("147c2d6b-f64f-4c07-9f6f-b385e32e5fad") },
                    { new Guid("c8423539-31c0-4e70-b67b-ae09dad4eb08"), "Turkey", new DateOnly(47, 3, 21), "Major Chemicals", "JewellGude", "861-785-6652", "https://picsum.photos/200/300", "", new Guid("79e83b38-d743-4911-af5f-2c3b55fb8cad") },
                    { new Guid("caa96264-bf6b-4050-a4a6-74606eb288c6"), "Niger", new DateOnly(39, 8, 22), "Auto Manufacturing", "AmberDefrang", "(151)637-2708", "https://picsum.photos/200/300", "", new Guid("393eb359-3b33-44a6-9dc7-77e4aaabc671") },
                    { new Guid("cf43aaff-2f7e-41ff-82b4-e9a533d81b9c"), "Cyprus", new DateOnly(73, 5, 21), "Consumer Electronics/Appliances", "ChloeBagheri", "270.600.2765 x434", "https://picsum.photos/200/300", "", new Guid("9b1432ca-ec7a-4f4b-b029-41bb58ac748a") },
                    { new Guid("cf6648b2-a749-4c59-9433-807d8ccf91e1"), "Gambia", new DateOnly(44, 8, 21), "Medical Electronics", "GretchenMontanye", "(508)506-8571 x821", "https://picsum.photos/200/300", "", new Guid("5a10a213-b7e0-42f8-ac3c-ffb38dfc3b10") },
                    { new Guid("d357aefb-ca44-4ada-8eb1-699a2e9dfbb7"), "Macau", new DateOnly(70, 3, 8), "Finance: Consumer Services", "LeonaMakarewicz", "1-872-261-8603", "https://picsum.photos/200/300", "", new Guid("4912ab76-d7f4-4039-94d9-f3063474ec7f") },
                    { new Guid("d39bb9ae-f841-484c-922d-424b7451b84a"), "Virgin Islands (British)", new DateOnly(61, 7, 10), "Precision Instruments", "HueyGungor", "177-600-3512", "https://picsum.photos/200/300", "", new Guid("07270609-faad-4cd8-953f-dd5002201839") },
                    { new Guid("d540a19c-dce7-47fa-8d78-a629590797bb"), "Israel", new DateOnly(61, 12, 19), "Electrical Products", "MarcelinaMcquigg", "515-048-3382 x3801", "https://picsum.photos/200/300", "", new Guid("b9453821-52bb-4978-b6f2-5fbb1750dfd2") },
                    { new Guid("d8666952-5198-4d18-b7bf-b12e8f59770c"), "Syria", new DateOnly(57, 12, 28), "Beverages (Production/Distribution)", "NohemiFent", "1-776-665-0378 x384", "https://picsum.photos/200/300", "", new Guid("35bd4e81-35c1-4c94-8f77-b8e6dcabba88") },
                    { new Guid("d89f8df4-41af-46e9-89b1-c02e7350fc86"), "Kazakhstan", new DateOnly(49, 1, 14), "Biotechnology: Laboratory Analytical Instruments", "EnedinaMoreton", "1-010-887-6636", "https://picsum.photos/200/300", "", new Guid("407f78b9-502d-4d3c-819d-5d0a409c53a2") },
                    { new Guid("dd827676-b5ba-4be9-9827-39bc80f2a496"), "Western Sahara", new DateOnly(26, 12, 19), "Medical/Dental Instruments", "CarolannDejes", "271-700-0384 x5212", "https://picsum.photos/200/300", "", new Guid("cb47c9ec-e4d3-4917-95cd-7a24360febe3") },
                    { new Guid("df214f50-2a37-4cae-b745-c81b48e885c6"), "Anguilla", new DateOnly(30, 7, 31), "Power Generation", "AiTomasso", "812-713-5430", "https://picsum.photos/200/300", "", new Guid("4b5185d8-41ec-40ab-9ff2-12e3dd9f892b") },
                    { new Guid("df56cca2-71e8-4175-a62d-f5709a013347"), "Bermuda", new DateOnly(28, 2, 16), "Containers/Packaging", "SoledadAdrovel", "1-642-012-1062 x253", "https://picsum.photos/200/300", "", new Guid("a65c0385-e7fe-490e-90c0-f01e2042fd3f") },
                    { new Guid("dff578e6-6821-45b5-bf8a-d851dc651b4d"), "Martinique", new DateOnly(63, 10, 22), "Savings Institutions", "BurlBonucchi", "(042)482-5623", "https://picsum.photos/200/300", "", new Guid("25744c67-492d-45e2-afa4-9d6c7b3b8e4d") },
                    { new Guid("e9b1b83b-14c4-456f-a92c-98c362f63bb6"), "Gibraltar", new DateOnly(64, 7, 8), "Television Services", "SherikaMaragni", "1-372-430-3808 x71702", "https://picsum.photos/200/300", "", new Guid("cffdefda-be63-431d-97ee-30d039d185c3") },
                    { new Guid("eabc3cfa-74df-4438-8b81-a8ffe6153393"), "Portugal", new DateOnly(44, 9, 16), "Agricultural Chemicals", "DemetriceDin", "(645)154-2452", "https://picsum.photos/200/300", "", new Guid("703204ae-474e-49fb-af92-b7d39b129317") },
                    { new Guid("ecd5fd4b-60ca-4daa-b7b1-29524eeca26b"), "Czech Republic", new DateOnly(68, 2, 28), "Major Banks", "FeLedain", "285.736.2508 x42158", "https://picsum.photos/200/300", "", new Guid("3516fdbb-4600-434d-b897-e0a71b94877a") },
                    { new Guid("edebabc5-6554-4984-8203-a8ee96d1b164"), "Anguilla", new DateOnly(74, 1, 3), "Computer Communications Equipment", "ChristoperBlicker", "686.780.6755", "https://picsum.photos/200/300", "", new Guid("ce4397d5-dafd-4242-98ed-cc0821c11d26") },
                    { new Guid("ef937c41-7d42-40c4-a914-7722d5212a37"), "Indonesia", new DateOnly(42, 9, 6), "Diversified Electronic Products", "TrinityGome", "(522)635-6784 x3757", "https://picsum.photos/200/300", "", new Guid("8f752c16-8036-4c44-b23f-c0407fa54031") },
                    { new Guid("f0e2e7e6-46f5-4b74-9c2a-0d2f0da0b5c7"), "Sao Tome and Principe", new DateOnly(47, 9, 24), "Biotechnology: Laboratory Analytical Instruments", "RoxannaGraf", "782.583.6008 x27234", "https://picsum.photos/200/300", "", new Guid("4cd63ed6-655e-4eea-a4f8-e5f23226306b") },
                    { new Guid("f709356f-3d97-4072-9d3e-20c8be1df898"), "Japan", new DateOnly(38, 6, 14), "Motor Vehicles", "KatiWampol", "420-728-4635 x8763", "https://picsum.photos/200/300", "", new Guid("b4abe570-cc41-4af0-b02a-3b6794ee124a") },
                    { new Guid("fb387c71-80c4-4061-a997-612061e06d2b"), "Christmas Island", new DateOnly(38, 6, 1), "Retail: Computer Software & Peripheral Equipment", "ReyesGoeken", "(755)234-7613 x30354", "https://picsum.photos/200/300", "", new Guid("2ff0c9d3-b0e5-4b8b-b127-83eec8d4333b") },
                    { new Guid("fc8735ac-dc59-496b-b57b-e5bb3d640587"), "Barbados", new DateOnly(34, 6, 21), "Building Products", "WalterZiems", "(488)632-3413", "https://picsum.photos/200/300", "", new Guid("a77346f4-8b80-4b19-8186-f3f39e23b58d") },
                    { new Guid("fd651f97-6c32-45a6-8843-89225673d1b5"), "Laos", new DateOnly(45, 9, 15), "Oil & Gas Production", "VernonBritsch", "526.350.6057", "https://picsum.photos/200/300", "", new Guid("c7f18586-2a92-451b-8543-1fc96a7d7dd2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_JobSeekerId",
                table: "Bookmarks",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserId",
                table: "Employers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobSeekerId",
                table: "JobApplications",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AddressId",
                table: "Jobs",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeeker_AddressId",
                table: "JobSeeker",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeeker_UserId",
                table: "JobSeeker",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerSkill_SkillsId",
                table: "JobSeekerSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillsId",
                table: "JobSkill",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobSeekerSkill");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
