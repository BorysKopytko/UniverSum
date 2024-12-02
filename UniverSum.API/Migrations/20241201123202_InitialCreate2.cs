using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniverSum.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonTimeSpans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonNumber = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTimeSpans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    IsUniversity = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationLevels_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    IsUniversity = table.Column<bool>(type: "bit", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Links_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Links_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialities_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecurringLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekMode = table.Column<int>(type: "int", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    LessonType = table.Column<int>(type: "int", nullable: false),
                    LessonTimeSpanId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringLessons_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecurringLessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecurringLessons_LessonTimeSpans_LessonTimeSpanId",
                        column: x => x.LessonTimeSpanId,
                        principalTable: "LessonTimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversationProfile",
                columns: table => new
                {
                    ConversationsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationProfile", x => new { x.ConversationsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ConversationProfile_Conversations_ConversationsId",
                        column: x => x.ConversationsId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConversationProfile_Profiles_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile", x => new { x.CoursesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_CourseProfile_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProfile_Profiles_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkProfile",
                columns: table => new
                {
                    FavoriteLinksId = table.Column<int>(type: "int", nullable: false),
                    FavoriteProfilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkProfile", x => new { x.FavoriteLinksId, x.FavoriteProfilesId });
                    table.ForeignKey(
                        name: "FK_LinkProfile_Links_FavoriteLinksId",
                        column: x => x.FavoriteLinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkProfile_Profiles_FavoriteProfilesId",
                        column: x => x.FavoriteProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    MaxMark = table.Column<short>(type: "smallint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Profiles_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialityCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialityCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialityCourses_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRecurringLesson",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "int", nullable: false),
                    RecurringLessonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRecurringLesson", x => new { x.MembersId, x.RecurringLessonsId });
                    table.ForeignKey(
                        name: "FK_ProfileRecurringLesson_Profiles_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileRecurringLesson_RecurringLessons_RecurringLessonsId",
                        column: x => x.RecurringLessonsId,
                        principalTable: "RecurringLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurringLessonId = table.Column<int>(type: "int", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualLessons_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualLessons_RecurringLessons_RecurringLessonId",
                        column: x => x.RecurringLessonId,
                        principalTable: "RecurringLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualLessons_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Profiles_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityCourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_SpecialityCourses_SpecialityCourseId",
                        column: x => x.SpecialityCourseId,
                        principalTable: "SpecialityCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndividualLessonId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_IndividualLessons_IndividualLessonId",
                        column: x => x.IndividualLessonId,
                        principalTable: "IndividualLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupProfile",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProfile", x => new { x.GroupsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GroupProfile_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupProfile_Profiles_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "Id", "CourseId", "FacultyId", "IsUniversity", "Title" },
                values: new object[] { 3, null, null, true, "Студентський уряд" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ConversationId", "Description", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Курс розроблено таким чином, щоб надати учасникам знання принципів\r\nзахисту інформації, як необхідного інструменту для побудови захищених\r\nсистем. Тому у курсі представлено програмно-технічні методи захисту\r\nінформації як основу захищеної системи. Основну частину курсу займає\r\nрозгляд практичних і теоретичних аспектів захисту конфіденційності\r\nінформації, а також її цілісності та автентичності.", "Технології захист інформації", 0 },
                    { 2, null, "Фокус уваги курсу спрямовано на вивчення сучасної реалізації Pharo\r\nкласичної об’єктної системи програмування Smalltalk. Курс пов'язаний з\r\nдисциплінами \"Програмування\", \"Програмна інженерія\", \"Алгоритми і\r\nструктури даних\", \"Програмування та підтримка веб-застосувань\".", "(ДВ 3) ООС Pharo", 1 },
                    { 3, null, "Курс “Паралельні та розподілені обчислення” присвячено проектуванню\r\nта розробці відмовостійких та масштабованих систем, що піддаються\r\nвисоким навантаженням. Розглянуто практичні підходи до ефективного\r\nрозпаралелення обчислювально складних задач.\r\nОсновна увага зосереджується на розробці архітектури та практичних\r\nаспектах побудови розподілених систем за використання сучасних засобів\r\nта технологій. Викладення матеріалу здійснюється за допомогою сучасних\r\nтермінів та понять з галузі інформаційних технологій.", "(ДВ 2) Паралельні обчислення", 1 },
                    { 4, null, "Курс спрямований на розвиток і вдосконалення компетенції спілкуватися\r\nукраїнською мовою у майбутній професійній сфері; формувати навички\r\nкультури мовлення (усні і писемні) з урахуванням особливостей найбільш\r\nдоречного функціонального стилю мовлення та відповідно до норм сучасної\r\nукраїнської літературної мови. Теоретичні знання і практичні навички\r\nреалізації сучасних мовних норм (зокрема лексичних, граматичних,\r\nстилістичних, орфоепічних) у професійній сфері (передусім стосується\r\nнаукового, офіційно-ділового стилів) сприяють формуванню комунікативної\r\nповедінки фахівця, зокрема успішній комунікації та досягненні мети\r\nспілкування.", "Українська мова (за професійним спрямуванням)", 0 },
                    { 5, null, "Цей курс охоплює такі розділи дослідження операцій: Моделі керування\r\nзапасами (МКЗ), Транспортна задача. Задачі дискретного програмування .\r\nЗадачі багатокритеріальної оптимізації. МГМ розв’язування екстремальних\r\nкомбінаторних задач. Моделі ЗУР в умовах невизначеності. Моделі ЗУР в\r\nумовах конфлікту. Антагоністичні ігри. Ситуації рівноваги Неша, елементи\r\nтеорії систем масового обслуговування. ", "(ДВ 1) Дослідження операцій", 1 },
                    { 6, null, "У курсі філософії головна увага зосереджена на вузлових інтелектуальних пунктах розвитку філософського знання у контексті\r\nєвропейської і світової цивілізації. Українська філософська думка органічно вплетена в контекст практично всіх тем.\r\nЛогіка викладу матеріалу спрямована на перетворення засвоюваного студентами філософського знання у складник їх внутрішньої\r\nкультури і основи для критичного мислення, на виформування лінії поведінки у напрямку пошуку вищих вартостей – Істини, Добра, Краси\r\nНавчальним планом передбачено читання лекцій, проведення семінарських занять, написання розвиваючих тестових завдань по темах\r\nдвох головних змістових частин, на які розбитий курс.\r\n", "Філософія", 0 },
                    { 7, null, "Фокус уваги курсу спрямовано на вивчення засад декларативного програмування. Засоби та методи написання програм у логічному стилі проілюстровано мовою Пролог, засоби та методи функційного програмування – з\r\nвикористанням Лісп і Пайтон. Курс пов'язаний з дисциплінами \"Програмування\", \"Теорія алгоритмів\", \"Алгоритми і структури даних\".\r\n", "Логічне та функціональне програмування", 0 },
                    { 8, null, "Фокус уваги курсу спрямовано на вивчення засад декларативного програмування. Засоби та методи написання програм у логічному стилі проілюстровано мовою Пролог, засоби та методи функційного програмування – з\r\nвикористанням Лісп і Пайтон. Курс пов'язаний з дисциплінами \"Програмування\", \"Теорія алгоритмів\", \"Алгоритми і структури даних\".\r\n", "Логічне та функціональне програмування", 0 },
                    { 9, null, "Дисципліна знайомить студентів з сучасними підходами до мікро –мезо та –\r\nмакромоделювання процесів еволюції і самоорганізації у складних\r\nдинамічних нелінійних нерівноважних матеріальних, суспільних та\r\nінформаційних системах.\r\n", "Моделювання еволюційних систем", 0 }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Прикладної математики та інформатики" },
                    { 2, "Механіко-математичний" },
                    { 3, "Електроніки та комп'ютерних технологій" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "StreamId", "Title" },
                values: new object[,]
                {
                    { 4, null, "(ДВ 3) ООС Pharo 2024" },
                    { 5, null, "(ДВ 2) Паралельні обчислення 2024" },
                    { 6, null, "(ДВ 1) Дослідження операцій 2024" }
                });

            migrationBuilder.InsertData(
                table: "LessonTimeSpans",
                columns: new[] { "Id", "EndTime", "LessonNumber", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 9, 50, 0, 0, DateTimeKind.Unspecified), (short)1, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), (short)2, new DateTime(1, 1, 1, 10, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 13, 10, 0, 0, DateTimeKind.Unspecified), (short)3, new DateTime(1, 1, 1, 11, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 14, 50, 0, 0, DateTimeKind.Unspecified), (short)4, new DateTime(1, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 16, 25, 0, 0, DateTimeKind.Unspecified), (short)5, new DateTime(1, 1, 1, 15, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), (short)6, new DateTime(1, 1, 1, 16, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), (short)7, new DateTime(1, 1, 1, 18, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), (short)8, new DateTime(1, 1, 1, 19, 40, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "ContentId", "CourseId", "FacultyId", "FileType", "IsUniversity", "LogoPath", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, null, "Сайт університету", "https://lnu.edu.ua/" },
                    { 2, null, null, null, null, true, null, "Сайт студентського уряду", "http://studentgovernment.lnu.edu.ua/" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Головний корпус" },
                    { 2, "вул. Чорновола, буд. 61" },
                    { 3, "вул. Менцинського, буд. 8" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "IdentityId", "LastName", "MiddleName", "Position", "Role" },
                values: new object[,]
                {
                    { 1, null, "student1@example.com", "Петро", null, "Петренко", "Петрович", null, 2 },
                    { 15, null, "default@example.com", "Віталій", null, "Горлач", "Михайлович", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "PlaceId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "439" },
                    { 2, 1, "261" },
                    { 3, 1, "112" },
                    { 4, 1, "365" },
                    { 5, 1, "116" },
                    { 6, 1, "367" },
                    { 7, 1, "366" }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "CourseId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Основні види та джерела атак на інформацію" },
                    { 2, 1, "Методології захисту інформації" },
                    { 3, 1, "Шкідливе програмне забезпечення та захист від нього" },
                    { 4, 1, "Елементарна криптографія" },
                    { 5, 1, "Блокові шифри" },
                    { 6, 1, "Сучасні алгоритми блокового шифрування I" },
                    { 7, 1, "Сучасні алгоритми блокового шифрування II" },
                    { 8, 1, "Потокові шифри" },
                    { 9, 1, "Елементи теорії чисел" },
                    { 10, 1, "Криптосистеми з відкритим ключем" }
                });

            migrationBuilder.InsertData(
                table: "ConversationProfile",
                columns: new[] { "ConversationsId", "MembersId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "Id", "CourseId", "FacultyId", "IsUniversity", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, false, null },
                    { 2, null, 1, false, "Деканат" }
                });

            migrationBuilder.InsertData(
                table: "CourseProfile",
                columns: new[] { "CoursesId", "MembersId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Програмування" },
                    { 2, 1, "Кібербезпеки" },
                    { 3, 1, "Інформаційний систем" },
                    { 4, 1, "Дискретного аналізу та інтелектуальних систем" }
                });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "FacultyId", "Type" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "GroupProfile",
                columns: new[] { "GroupsId", "StudentsId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "LinkProfile",
                columns: new[] { "FavoriteLinksId", "FavoriteProfilesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "ContentId", "CourseId", "FacultyId", "FileType", "IsUniversity", "LogoPath", "Title", "Url" },
                values: new object[,]
                {
                    { 3, null, null, 1, null, false, null, "Сайт факультету", "https://ami.lnu.edu.ua/" },
                    { 4, null, null, 1, null, false, null, "Сайт програми Кібербезпека", "https://cybersecurity.lnu.edu.ua/" }
                });

            migrationBuilder.InsertData(
                table: "ConversationProfile",
                columns: new[] { "ConversationsId", "MembersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "ContentId", "CourseId", "FacultyId", "FileType", "IsUniversity", "LogoPath", "Title", "Url" },
                values: new object[,]
                {
                    { 5, 1, null, null, null, false, null, "Презентація до розділу 1", "https://example.com/" },
                    { 6, 1, null, null, null, false, null, "Teams-нарада", "https://example.com/" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "IdentityId", "LastName", "MiddleName", "Position", "Role" },
                values: new object[,]
                {
                    { 2, 3, "default@example.com", "Ірина", null, "Бернакевич", "Євстахіївна", 1, 1 },
                    { 3, 1, "default@example.com", "Сергій", null, "Ярошко", "Адамович", 1, 1 },
                    { 4, 3, "default@example.com", "Оксана", null, "Ярошко", "Сергіївна", 2, 1 },
                    { 5, 3, "default@example.com", "Георгій", null, "Шинкаренко", "Андрійович", 0, 1 },
                    { 6, 3, "default@example.com", "Михайло", null, "Яджак", "Степанович", 0, 1 },
                    { 7, 1, "default@example.com", "Андріана", null, "Чучвара", "Петрівна", 1, 1 },
                    { 8, 4, "default@example.com", "Роман", null, "Олійник", "Миколайович", 1, 1 },
                    { 9, 4, "default@example.com", "Наталія", null, "Коркуна", "Михайлівна", 2, 1 },
                    { 10, 3, "default@example.com", "Олександр", null, "Вовк", "Дмитрович", 1, 1 },
                    { 11, 1, "default@example.com", "Валерій", null, "Джунь", "Володимирович", 1, 1 },
                    { 12, 1, "default@example.com", "Наталія", null, "Івасько", "Михайлівна", 1, 1 },
                    { 13, 1, "default@example.com", "Роман", null, "Селіверстов", "Григорович", 1, 1 },
                    { 14, 1, "default@example.com", "Володимир", null, "Вовк", "Дмитрович", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecurringLessons",
                columns: new[] { "Id", "ClassroomId", "CourseId", "EndDate", "LessonTimeSpanId", "LessonType", "StartDate", "WeekDay", "WeekMode" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { 2, 2, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { 3, 3, 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { 4, 3, 4, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, 1, 5, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 6, 1, 6, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 7, 4, 5, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 8, 5, 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 9, 6, 6, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 10, 6, 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 11, 7, 7, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 12, 1, 9, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 13, 1, 9, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "EducationLevelId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "122 Комп'ютерні науки" },
                    { 2, 1, "125 Кібербезпека" },
                    { 3, 1, "113 Прикладна математика" }
                });

            migrationBuilder.InsertData(
                table: "CourseProfile",
                columns: new[] { "CoursesId", "MembersId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "IndividualLessons",
                columns: new[] { "Id", "ContentId", "Date", "RecurringLessonId", "TaskId" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, null, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 4, null, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 6, null, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null },
                    { 7, null, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null },
                    { 8, null, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ConversationId", "IndividualLessonId", "SenderId", "SendingDateTime", "TaskId", "Text" },
                values: new object[] { 3, 2, null, 3, new DateTime(2024, 5, 1, 15, 39, 15, 0, DateTimeKind.Unspecified), null, "Кінцевий термін слухання повторних курсів 8 травня 2024 року. З 10 до 13 травня 2024 року будуть відбуватися здачі іспитів, заліків, диференційованих заліків та комп'ютерних проектів по повторних курсах згідно розкладу кафедр викладачів." });

            migrationBuilder.InsertData(
                table: "ProfileRecurringLesson",
                columns: new[] { "MembersId", "RecurringLessonsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "SpecialityCourses",
                columns: new[] { "Id", "SpecialityId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "2" },
                    { 2, 1, "3" },
                    { 3, 1, "4" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CourseId", "CreatorId", "EndDateTime", "MaxMark", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, 1, 0, "Лабораторна робота №1" },
                    { 2, 2, 2, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)25, 2, 1, "Підготувати презентацію" },
                    { 3, 3, 2, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)30, 0, 1, "Лабораторна робота №3" },
                    { 4, 4, 2, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)10, 0, 2, "Практична робота №4" },
                    { 5, 5, 2, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)15, 2, 2, " №4" },
                    { 6, 1, 2, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20, 1, 2, "Підготувати доповідь на тему Політика безпеки та її структура" }
                });

            migrationBuilder.InsertData(
                table: "IndividualLessons",
                columns: new[] { "Id", "ContentId", "Date", "RecurringLessonId", "TaskId" },
                values: new object[] { 1, 1, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ConversationId", "IndividualLessonId", "SenderId", "SendingDateTime", "TaskId", "Text" },
                values: new object[] { 1, 1, null, 2, new DateTime(2024, 12, 7, 10, 45, 0, 0, DateTimeKind.Unspecified), 6, "Чудова робота, але наступного разу коректніше форматуйте текст." });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "Mark", "StudentId", "TaskId" },
                values: new object[] { 1, (short)19, 1, 6 });

            migrationBuilder.InsertData(
                table: "Streams",
                columns: new[] { "Id", "SpecialityCourseId", "Title" },
                values: new object[,]
                {
                    { 1, 3, "1" },
                    { 2, 3, "2" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "StreamId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ПМІ-41" },
                    { 2, 1, "ПМІ-42" },
                    { 3, 1, "ПМІ-43" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ConversationId", "IndividualLessonId", "SenderId", "SendingDateTime", "TaskId", "Text" },
                values: new object[] { 2, 1, 1, 1, new DateTime(2024, 12, 1, 9, 56, 10, 0, DateTimeKind.Unspecified), null, "Можна, будь ласка, перенести дане заняття на інший день?" });

            migrationBuilder.InsertData(
                table: "GroupProfile",
                columns: new[] { "GroupsId", "StudentsId" },
                values: new object[] { 1, 1 });

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
                name: "IX_Classrooms_PlaceId",
                table: "Classrooms",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CourseId",
                table: "Contents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationProfile_MembersId",
                table: "ConversationProfile",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_CourseId",
                table: "Conversations",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_FacultyId",
                table: "Conversations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile_MembersId",
                table: "CourseProfile",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_FacultyId",
                table: "EducationLevels",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProfile_StudentsId",
                table: "GroupProfile",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StreamId",
                table: "Groups",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLessons_ContentId",
                table: "IndividualLessons",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLessons_RecurringLessonId",
                table: "IndividualLessons",
                column: "RecurringLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualLessons_TaskId",
                table: "IndividualLessons",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkProfile_FavoriteProfilesId",
                table: "LinkProfile",
                column: "FavoriteProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ContentId",
                table: "Links",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_CourseId",
                table: "Links",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FacultyId",
                table: "Links",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IndividualLessonId",
                table: "Messages",
                column: "IndividualLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TaskId",
                table: "Messages",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRecurringLesson_RecurringLessonsId",
                table: "ProfileRecurringLesson",
                column: "RecurringLessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DepartmentId",
                table: "Profiles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringLessons_ClassroomId",
                table: "RecurringLessons",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringLessons_CourseId",
                table: "RecurringLessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringLessons_LessonTimeSpanId",
                table: "RecurringLessons",
                column: "LessonTimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TaskId",
                table: "Results",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_EducationLevelId",
                table: "Specialities",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityCourses_SpecialityId",
                table: "SpecialityCourses",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_SpecialityCourseId",
                table: "Streams",
                column: "SpecialityCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CourseId",
                table: "Tasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");
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
                name: "ConversationProfile");

            migrationBuilder.DropTable(
                name: "CourseProfile");

            migrationBuilder.DropTable(
                name: "GroupProfile");

            migrationBuilder.DropTable(
                name: "LinkProfile");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProfileRecurringLesson");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "IndividualLessons");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "RecurringLessons");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "SpecialityCourses");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "LessonTimeSpans");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
