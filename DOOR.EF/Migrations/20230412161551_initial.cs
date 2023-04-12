using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOOR.EF.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UD_JBEANS");

            migrationBuilder.CreateSequence(
                name: "COURSE_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.CreateSequence(
                name: "INSTRUCTOR_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.CreateSequence(
                name: "ORA_TRANSLATE_MSG_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.CreateSequence(
                name: "SECTION_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.CreateSequence(
                name: "STUDENT_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.CreateTable(
                name: "ORA_TRANSLATE_MSG",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    ORA_TRANSLATE_MSG_ID = table.Column<string>(type: "VARCHAR2(38)", unicode: false, maxLength: 38, nullable: true, defaultValueSql: "sys_guid()"),
                    ORA_CONSTRAINT_NAME = table.Column<string>(type: "VARCHAR2(128)", unicode: false, maxLength: 128, nullable: true),
                    ORA_ERROR_MESSAGE = table.Column<string>(type: "VARCHAR2(200)", unicode: false, maxLength: 200, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(38)", unicode: false, maxLength: 38, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(38)", unicode: false, maxLength: 38, nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SCHOOL_NAME = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SCHOOL_PK", x => x.SCHOOL_ID);
                });

            migrationBuilder.CreateTable(
                name: "ZIPCODE",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    ZIP = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: true),
                    STATE = table.Column<string>(type: "CHAR(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ZIP_PK", x => x.ZIP);
                });

            migrationBuilder.CreateTable(
                name: "COURSE",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    COURSE_NO = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    COST = table.Column<decimal>(type: "NUMBER(9,2)", nullable: true),
                    PREREQUISITE = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    PREREQUISITE_SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COURSE_PK", x => new { x.COURSE_NO, x.SCHOOL_ID });
                    table.ForeignKey(
                        name: "COURSE_FK1",
                        columns: x => new { x.PREREQUISITE, x.PREREQUISITE_SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "COURSE",
                        principalColumns: new[] { "COURSE_NO", "SCHOOL_ID" });
                    table.ForeignKey(
                        name: "COURSE_FK2",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "GRADE_CONVERSION",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    LETTER_GRADE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    GRADE_POINT = table.Column<decimal>(type: "NUMBER(3,2)", nullable: false),
                    MAX_GRADE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    MIN_GRADE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GRADE_CONVERSION_PK", x => new { x.SCHOOL_ID, x.LETTER_GRADE });
                    table.ForeignKey(
                        name: "GRADE_CONVERSION_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "GRADE_TYPE",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    GRADE_TYPE_CODE = table.Column<string>(type: "CHAR(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GRADE_TYPE_PK", x => new { x.SCHOOL_ID, x.GRADE_TYPE_CODE });
                    table.ForeignKey(
                        name: "GRADE_TYPE_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    STUDENT_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SALUTATION = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: true),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: true),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    ZIP = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR2(15)", unicode: false, maxLength: 15, nullable: true),
                    EMPLOYER = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    REGISTRATION_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("STUDENT_PK", x => new { x.STUDENT_ID, x.SCHOOL_ID });
                    table.ForeignKey(
                        name: "STUDENT_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "INSTRUCTOR",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    INSTRUCTOR_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SALUTATION = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: true),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR2(15)", unicode: false, maxLength: 15, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSTRUCTOR_PK", x => new { x.SCHOOL_ID, x.INSTRUCTOR_ID });
                    table.ForeignKey(
                        name: "INSTRUCTOR_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "INSTRUCTOR_FK2",
                        column: x => x.ZIP,
                        principalSchema: "UD_JBEANS",
                        principalTable: "ZIPCODE",
                        principalColumn: "ZIP");
                });

            migrationBuilder.CreateTable(
                name: "SECTION",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SECTION_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    COURSE_NO = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SECTION_NO = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    START_DATE_TIME = table.Column<DateTime>(type: "DATE", nullable: true),
                    LOCATION = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    INSTRUCTOR_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    CAPACITY = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SECTION_PK", x => new { x.SECTION_ID, x.SCHOOL_ID });
                    table.ForeignKey(
                        name: "SECTION_FK1",
                        columns: x => new { x.COURSE_NO, x.SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "COURSE",
                        principalColumns: new[] { "COURSE_NO", "SCHOOL_ID" });
                    table.ForeignKey(
                        name: "SECTION_FK2",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "SECTION_FK3",
                        columns: x => new { x.SCHOOL_ID, x.INSTRUCTOR_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "INSTRUCTOR",
                        principalColumns: new[] { "SCHOOL_ID", "INSTRUCTOR_ID" });
                });

            migrationBuilder.CreateTable(
                name: "ENROLLMENT",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    STUDENT_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SECTION_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    ENROLL_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    FINAL_GRADE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ENROLLMENT_PK", x => new { x.SECTION_ID, x.STUDENT_ID, x.SCHOOL_ID });
                    table.ForeignKey(
                        name: "ENROLLMENT_FK1",
                        columns: x => new { x.SECTION_ID, x.SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "SECTION",
                        principalColumns: new[] { "SECTION_ID", "SCHOOL_ID" });
                    table.ForeignKey(
                        name: "ENROLLMENT_FK2",
                        columns: x => new { x.STUDENT_ID, x.SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "STUDENT",
                        principalColumns: new[] { "STUDENT_ID", "SCHOOL_ID" });
                    table.ForeignKey(
                        name: "ENROLLMENT_FK3",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                });

            migrationBuilder.CreateTable(
                name: "GRADE_TYPE_WEIGHT",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SECTION_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    GRADE_TYPE_CODE = table.Column<string>(type: "CHAR(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    NUMBER_PER_SECTION = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    PERCENT_OF_FINAL_GRADE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    DROP_LOWEST = table.Column<bool>(type: "NUMBER(1)", precision: 1, nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GRADE_TYPE_WEIGHT_PK", x => new { x.SCHOOL_ID, x.SECTION_ID, x.GRADE_TYPE_CODE });
                    table.ForeignKey(
                        name: "GRADE_TYPE_WEIGHT_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "GRADE_TYPE_WEIGHT_FK2",
                        columns: x => new { x.SCHOOL_ID, x.GRADE_TYPE_CODE },
                        principalSchema: "UD_JBEANS",
                        principalTable: "GRADE_TYPE",
                        principalColumns: new[] { "SCHOOL_ID", "GRADE_TYPE_CODE" });
                    table.ForeignKey(
                        name: "GRADE_TYPE_WEIGHT_FK3",
                        columns: x => new { x.SECTION_ID, x.SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "SECTION",
                        principalColumns: new[] { "SECTION_ID", "SCHOOL_ID" });
                });

            migrationBuilder.CreateTable(
                name: "GRADE",
                schema: "UD_JBEANS",
                columns: table => new
                {
                    SCHOOL_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    STUDENT_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    SECTION_ID = table.Column<int>(type: "NUMBER(8)", precision: 8, nullable: false),
                    GRADE_TYPE_CODE = table.Column<string>(type: "CHAR(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    GRADE_CODE_OCCURRENCE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    NUMERIC_GRADE = table.Column<decimal>(type: "NUMBER(5,2)", nullable: false),
                    COMMENTS = table.Column<string>(type: "CLOB", nullable: true),
                    CREATED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    MODIFIED_BY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GRADE_PK", x => new { x.SCHOOL_ID, x.STUDENT_ID, x.SECTION_ID, x.GRADE_TYPE_CODE, x.GRADE_CODE_OCCURRENCE });
                    table.ForeignKey(
                        name: "GRADE_FK1",
                        column: x => x.SCHOOL_ID,
                        principalSchema: "UD_JBEANS",
                        principalTable: "SCHOOL",
                        principalColumn: "SCHOOL_ID");
                    table.ForeignKey(
                        name: "GRADE_FK2",
                        columns: x => new { x.SECTION_ID, x.STUDENT_ID, x.SCHOOL_ID },
                        principalSchema: "UD_JBEANS",
                        principalTable: "ENROLLMENT",
                        principalColumns: new[] { "SECTION_ID", "STUDENT_ID", "SCHOOL_ID" });
                    table.ForeignKey(
                        name: "GRADE_FK3",
                        columns: x => new { x.SCHOOL_ID, x.SECTION_ID, x.GRADE_TYPE_CODE },
                        principalSchema: "UD_JBEANS",
                        principalTable: "GRADE_TYPE_WEIGHT",
                        principalColumns: new[] { "SCHOOL_ID", "SECTION_ID", "GRADE_TYPE_CODE" });
                });

            migrationBuilder.CreateIndex(
                name: "CRSE_CRSE_FK_I",
                schema: "UD_JBEANS",
                table: "COURSE",
                column: "PREREQUISITE");

            migrationBuilder.CreateIndex(
                name: "CRSE_PK",
                schema: "UD_JBEANS",
                table: "COURSE",
                column: "COURSE_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_PREREQUISITE_PREREQUISITE_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "COURSE",
                columns: new[] { "PREREQUISITE", "PREREQUISITE_SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "COURSE",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "ENR_PK",
                schema: "UD_JBEANS",
                table: "ENROLLMENT",
                columns: new[] { "STUDENT_ID", "SECTION_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ENR_SECT_FK_I",
                schema: "UD_JBEANS",
                table: "ENROLLMENT",
                column: "SECTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ENROLLMENT_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "ENROLLMENT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ENROLLMENT_SECTION_ID_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "ENROLLMENT",
                columns: new[] { "SECTION_ID", "SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_ENROLLMENT_STUDENT_ID_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "ENROLLMENT",
                columns: new[] { "STUDENT_ID", "SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_GRADE_SCHOOL_ID_SECTION_ID_GRADE_TYPE_CODE",
                schema: "UD_JBEANS",
                table: "GRADE",
                columns: new[] { "SCHOOL_ID", "SECTION_ID", "GRADE_TYPE_CODE" });

            migrationBuilder.CreateIndex(
                name: "IX_GRADE_SECTION_ID_STUDENT_ID_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "GRADE",
                columns: new[] { "SECTION_ID", "STUDENT_ID", "SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_GRADE_TYPE_WEIGHT_SCHOOL_ID_GRADE_TYPE_CODE",
                schema: "UD_JBEANS",
                table: "GRADE_TYPE_WEIGHT",
                columns: new[] { "SCHOOL_ID", "GRADE_TYPE_CODE" });

            migrationBuilder.CreateIndex(
                name: "IX_GRADE_TYPE_WEIGHT_SECTION_ID_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "GRADE_TYPE_WEIGHT",
                columns: new[] { "SECTION_ID", "SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_INSTRUCTOR_ZIP",
                schema: "UD_JBEANS",
                table: "INSTRUCTOR",
                column: "ZIP");

            migrationBuilder.CreateIndex(
                name: "IX_SECTION_COURSE_NO_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "SECTION",
                columns: new[] { "COURSE_NO", "SCHOOL_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_SECTION_SCHOOL_ID_INSTRUCTOR_ID",
                schema: "UD_JBEANS",
                table: "SECTION",
                columns: new[] { "SCHOOL_ID", "INSTRUCTOR_ID" });

            migrationBuilder.CreateIndex(
                name: "SECT_CRSE_FK_I",
                schema: "UD_JBEANS",
                table: "SECTION",
                column: "COURSE_NO");

            migrationBuilder.CreateIndex(
                name: "SECT_INST_FK_I",
                schema: "UD_JBEANS",
                table: "SECTION",
                column: "INSTRUCTOR_ID");

            migrationBuilder.CreateIndex(
                name: "SECT_PK",
                schema: "UD_JBEANS",
                table: "SECTION",
                column: "SECTION_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SECT_SECT2_UK",
                schema: "UD_JBEANS",
                table: "SECTION",
                columns: new[] { "SECTION_NO", "COURSE_NO" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_SCHOOL_ID",
                schema: "UD_JBEANS",
                table: "STUDENT",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "STU_PK",
                schema: "UD_JBEANS",
                table: "STUDENT",
                column: "STUDENT_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "STU_ZIP_FK_I",
                schema: "UD_JBEANS",
                table: "STUDENT",
                column: "ZIP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRADE",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "GRADE_CONVERSION",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "ORA_TRANSLATE_MSG",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "ENROLLMENT",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "GRADE_TYPE_WEIGHT",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "STUDENT",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "GRADE_TYPE",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "SECTION",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "COURSE",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "INSTRUCTOR",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "SCHOOL",
                schema: "UD_JBEANS");

            migrationBuilder.DropTable(
                name: "ZIPCODE",
                schema: "UD_JBEANS");

            migrationBuilder.DropSequence(
                name: "COURSE_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.DropSequence(
                name: "INSTRUCTOR_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.DropSequence(
                name: "ORA_TRANSLATE_MSG_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.DropSequence(
                name: "SECTION_SEQ",
                schema: "UD_JBEANS");

            migrationBuilder.DropSequence(
                name: "STUDENT_SEQ",
                schema: "UD_JBEANS");
        }
    }
}
