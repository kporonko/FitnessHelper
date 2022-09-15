using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicalSetEfficiency",
                columns: table => new
                {
                    EfficiencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cardio = table.Column<int>(type: "int", nullable: false),
                    Legs = table.Column<int>(type: "int", nullable: false),
                    Arms = table.Column<int>(type: "int", nullable: false),
                    Back = table.Column<int>(type: "int", nullable: false),
                    Chest = table.Column<int>(type: "int", nullable: false),
                    Abs = table.Column<int>(type: "int", nullable: false),
                    BasicalSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicalSetEfficiency", x => x.EfficiencyId);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    UrlImage = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    UrlVideo = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Muscle",
                columns: table => new
                {
                    MuscleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    UrlImage = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    PartOfBody = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscle", x => x.MuscleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BasicalSetOfExercises",
                columns: table => new
                {
                    BasicalSetId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicalSetOfExercises", x => x.BasicalSetId);
                    table.ForeignKey(
                        name: "FK_BasicalSetOfExercises_BasicalSetEfficiency_BasicalSetId",
                        column: x => x.BasicalSetId,
                        principalTable: "BasicalSetEfficiency",
                        principalColumn: "EfficiencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    MuscleId = table.Column<int>(type: "int", nullable: false),
                    IsTarget = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Muscle_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "Muscle",
                        principalColumn: "MuscleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetOfExercises",
                columns: table => new
                {
                    UserSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetOfExercises", x => x.UserSetId);
                    table.ForeignKey(
                        name: "FK_UserSetOfExercises_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicalSetExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicalSetId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicalSetExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicalSetExercise_BasicalSetOfExercises_BasicalSetId",
                        column: x => x.BasicalSetId,
                        principalTable: "BasicalSetOfExercises",
                        principalColumn: "BasicalSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicalSetExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicalSetTraining",
                columns: table => new
                {
                    BasicalTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    BasicalSetId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicalSetTraining", x => x.BasicalTrainingId);
                    table.ForeignKey(
                        name: "FK_BasicalSetTraining_BasicalSetOfExercises_BasicalSetId",
                        column: x => x.BasicalSetId,
                        principalTable: "BasicalSetOfExercises",
                        principalColumn: "BasicalSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicalSetTraining_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSetId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSetExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSetExercise_UserSetOfExercises_UserSetId",
                        column: x => x.UserSetId,
                        principalTable: "UserSetOfExercises",
                        principalColumn: "UserSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetTraining",
                columns: table => new
                {
                    UserTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    UserSetId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetTraining", x => x.UserTrainingId);
                    table.ForeignKey(
                        name: "FK_UserSetTraining_UserSetOfExercises_UserSetId",
                        column: x => x.UserSetId,
                        principalTable: "UserSetOfExercises",
                        principalColumn: "UserSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicalSetExercise_BasicalSetId",
                table: "BasicalSetExercise",
                column: "BasicalSetId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicalSetExercise_ExerciseId",
                table: "BasicalSetExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicalSetTraining_BasicalSetId",
                table: "BasicalSetTraining",
                column: "BasicalSetId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicalSetTraining_UserId",
                table: "BasicalSetTraining",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_ExerciseId",
                table: "ExerciseMuscles",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_MuscleId",
                table: "ExerciseMuscles",
                column: "MuscleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetExercise_ExerciseId",
                table: "UserSetExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetExercise_UserSetId",
                table: "UserSetExercise",
                column: "UserSetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetOfExercises_UserId",
                table: "UserSetOfExercises",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetTraining_UserSetId",
                table: "UserSetTraining",
                column: "UserSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicalSetExercise");

            migrationBuilder.DropTable(
                name: "BasicalSetTraining");

            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "UserSetExercise");

            migrationBuilder.DropTable(
                name: "UserSetTraining");

            migrationBuilder.DropTable(
                name: "BasicalSetOfExercises");

            migrationBuilder.DropTable(
                name: "Muscle");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "UserSetOfExercises");

            migrationBuilder.DropTable(
                name: "BasicalSetEfficiency");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
