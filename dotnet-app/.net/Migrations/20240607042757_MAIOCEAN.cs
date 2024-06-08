using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAIOCEAN.Migrations
{
    /// <inheritdoc />
    public partial class MAIOCEAN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MAIOCEAN_ESPECIES",
                columns: table => new
                {
                    IdEspecie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeEspecie = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ds_Especie = table.Column<string>(type: "varchar(155)", nullable: false),
                    StatusEspecie = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAIOCEAN_ESPECIES", x => x.IdEspecie);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAIOCEAN_ROBO",
                columns: table => new
                {
                    IdRobo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StatusRobo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmrSerie = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAIOCEAN_ROBO", x => x.IdRobo);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAIOCEAN_REGIAO",
                columns: table => new
                {
                    IdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeRegiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TempMedia = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    StatusRegiao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdRobo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoboIdRobo = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAIOCEAN_REGIAO", x => x.IdRegiao);
                    table.ForeignKey(
                        name: "FK_TB_MAIOCEAN_REGIAO_TB_MAIOCEAN_ROBO_RoboIdRobo",
                        column: x => x.RoboIdRobo,
                        principalTable: "TB_MAIOCEAN_ROBO",
                        principalColumn: "IdRobo");
                });

            migrationBuilder.CreateTable(
                name: "EspecieRegiao",
                columns: table => new
                {
                    EspecieIdEspecie = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieRegiao", x => new { x.EspecieIdEspecie, x.RegiaoIdRegiao });
                    table.ForeignKey(
                        name: "FK_EspecieRegiao_TB_MAIOCEAN_ESPECIES_EspecieIdEspecie",
                        column: x => x.EspecieIdEspecie,
                        principalTable: "TB_MAIOCEAN_ESPECIES",
                        principalColumn: "IdEspecie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecieRegiao_TB_MAIOCEAN_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "TB_MAIOCEAN_REGIAO",
                        principalColumn: "IdRegiao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_MAIOCEAN_IMAGEM",
                columns: table => new
                {
                    IdImagem = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_CAMINHO = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Profundidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    IdRobo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoboIdRobo = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAIOCEAN_IMAGEM", x => x.IdImagem);
                    table.ForeignKey(
                        name: "FK_TB_MAIOCEAN_IMAGEM_TB_MAIOCEAN_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "TB_MAIOCEAN_REGIAO",
                        principalColumn: "IdRegiao");
                    table.ForeignKey(
                        name: "FK_TB_MAIOCEAN_IMAGEM_TB_MAIOCEAN_ROBO_RoboIdRobo",
                        column: x => x.RoboIdRobo,
                        principalTable: "TB_MAIOCEAN_ROBO",
                        principalColumn: "IdRobo");
                });

            migrationBuilder.CreateTable(
                name: "TB_MAIOCEAN_TEMPERATURA",
                columns: table => new
                {
                    IdTemperatura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ValorTemperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataColeta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ProfundTemperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    LatitudeTemp = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    LongitudeTemp = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    IdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegiaoIdRegiao = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MAIOCEAN_TEMPERATURA", x => x.IdTemperatura);
                    table.ForeignKey(
                        name: "FK_TB_MAIOCEAN_TEMPERATURA_TB_MAIOCEAN_REGIAO_RegiaoIdRegiao",
                        column: x => x.RegiaoIdRegiao,
                        principalTable: "TB_MAIOCEAN_REGIAO",
                        principalColumn: "IdRegiao");
                });

            migrationBuilder.CreateTable(
                name: "RoboTemperatura",
                columns: table => new
                {
                    RoboIdRobo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TemperaturaIdTemperatura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoboTemperatura", x => new { x.RoboIdRobo, x.TemperaturaIdTemperatura });
                    table.ForeignKey(
                        name: "FK_RoboTemperatura_TB_MAIOCEAN_ROBO_RoboIdRobo",
                        column: x => x.RoboIdRobo,
                        principalTable: "TB_MAIOCEAN_ROBO",
                        principalColumn: "IdRobo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoboTemperatura_TB_MAIOCEAN_TEMPERATURA_TemperaturaIdTemperatura",
                        column: x => x.TemperaturaIdTemperatura,
                        principalTable: "TB_MAIOCEAN_TEMPERATURA",
                        principalColumn: "IdTemperatura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecieRegiao_RegiaoIdRegiao",
                table: "EspecieRegiao",
                column: "RegiaoIdRegiao");

            migrationBuilder.CreateIndex(
                name: "IX_RoboTemperatura_TemperaturaIdTemperatura",
                table: "RoboTemperatura",
                column: "TemperaturaIdTemperatura");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAIOCEAN_IMAGEM_RegiaoIdRegiao",
                table: "TB_MAIOCEAN_IMAGEM",
                column: "RegiaoIdRegiao");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAIOCEAN_IMAGEM_RoboIdRobo",
                table: "TB_MAIOCEAN_IMAGEM",
                column: "RoboIdRobo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAIOCEAN_REGIAO_RoboIdRobo",
                table: "TB_MAIOCEAN_REGIAO",
                column: "RoboIdRobo");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MAIOCEAN_TEMPERATURA_RegiaoIdRegiao",
                table: "TB_MAIOCEAN_TEMPERATURA",
                column: "RegiaoIdRegiao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecieRegiao");

            migrationBuilder.DropTable(
                name: "RoboTemperatura");

            migrationBuilder.DropTable(
                name: "TB_MAIOCEAN_IMAGEM");

            migrationBuilder.DropTable(
                name: "TB_MAIOCEAN_ESPECIES");

            migrationBuilder.DropTable(
                name: "TB_MAIOCEAN_TEMPERATURA");

            migrationBuilder.DropTable(
                name: "TB_MAIOCEAN_REGIAO");

            migrationBuilder.DropTable(
                name: "TB_MAIOCEAN_ROBO");
        }
    }
}
