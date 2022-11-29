using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneV4.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProgramDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tuition = table.Column<double>(type: "float", nullable: false),
                    TopicID = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseProgram",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgram", x => new { x.CourseID, x.ProgramID });
                    table.ForeignKey(
                        name: "FK_CourseProgram_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgram_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Programs",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramID", "ProgramDescription", "ProgramType" },
                values: new object[,]
                {
                    { 1, "This is an in-person course led by an instructor. Our classroom ratios are 5:1. Classes meet once a week.", "Group Learning" },
                    { 2, "The curriculum of our Academic Accelerators empowers students where their weak points are. Students enrolled in this program meet with an instructor once a week at our campus.", "1-On-1" },
                    { 3, "This is a virtual course led by an instructor over Zoom. Upon enrollment, Science Lab provides all the necessary materials to succeed in this program. Classes meet once a week.", "Virtual Course" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicID", "Name" },
                values: new object[,]
                {
                    { "biol", "Biology" },
                    { "chem", "Chemistry" },
                    { "cs", "Compuer Science" },
                    { "math", "Mathematics" },
                    { "phys", "Physics" },
                    { "psych", "Psychology" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseDescription", "CourseName", "TopicID", "Tuition" },
                values: new object[,]
                {
                    { 101, "Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.", "Let's Get Reactive: Chemistry Foundations", "chem", 229.0 },
                    { 102, "Get ready to have some fun as you learn everything it takes to plan, design, and program your own 2D and 3D games. This class uses Unity's C# language to teach core game development skills. The projects you create will be brought to life with animation, sound effects, and music. In the final few weeks of this course, students will create an original game for class showcase day!", "Game Designer: Program Your Own Game", "cs", 229.0 },
                    { 103, "A step up from our introductory web development course, Web Masters is all about learning how to take static HTML files to the web! We will review HTML and CSS, continue into JavaScript, and dive into server-side scripting with PHP. By the end of this course, you'll have hands-on experience creating complete websites such as blogs, and portfolios, or even a simple eCommerce site.", "Web Masters: Advanced Web Development", "cs", 229.0 },
                    { 104, "Who am I? This is a question humans have been trying to answer since the dawn of time. In this course, students will build upon their knowledge of psychology, learning about theories, methods, and research around personality testing. In addition, we'll cover how we can use our understanding of personality and personality disorders in everyday situations.", "Advanced Psychology: Understanding You", "psych", 229.0 },
                    { 105, "Robotics is one of the more exciting and dynamic fields of engineering, with students have a blast building things and seeing them come to life. This course will give students a chance to learn the fundamentals of robotics and engineering through exciting, hands-on activities using Lego and VEX Robotics. Students will cover topics such as circuitry, hardware and software development, simple machines, Python programming, and more!", "Robotics: Build a Robot from Scratch", "cs", 229.0 },
                    { 201, "Python is a fast, easy and versatile language that can be used for everything from data science to game development. Students will learn how to make computer program using loops, conditionals and variables, with examples in Python libraries like Numpy and Pandas. Students will also learn the basics of application development such as GUIs, database creation and testing.", "Sssstrengthen Your Ssskills in Python", "cs", 199.0 },
                    { 202, "Master the principles and theories of aerospace science with these hands-on projects. Students build a model space shuttle, design and test airfoils that allow an object to fly, and create 3D models of rockets and spacecraft. Along the way, they will apply orbital mechanics concepts to build an accurate depiction of a rocket launch or a satellite in orbit.", "It's Not Rocket Science: Aerospace Fundamentals", "phys", 199.0 },
                    { 203, "Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.", "Let's Get Reactive: Chemistry Foundations", "chem", 199.0 },
                    { 301, "A one-on-one course focused on Algebra.", "Academic Accelerator: Algebra", "math", 149.0 },
                    { 302, "A one-on-one course focused on Physics.", "Academic Accelerator: Physics", "phys", 149.0 },
                    { 303, "A one-on-one course focused on Biology.", "Academic Accelerator: Biology", "biol", 149.0 }
                });

            migrationBuilder.InsertData(
                table: "CourseProgram",
                columns: new[] { "CourseID", "ProgramID" },
                values: new object[,]
                {
                    { 101, 1 },
                    { 102, 1 },
                    { 103, 1 },
                    { 104, 1 },
                    { 105, 1 },
                    { 201, 2 },
                    { 202, 2 },
                    { 203, 2 },
                    { 301, 3 },
                    { 302, 3 },
                    { 303, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgram_ProgramID",
                table: "CourseProgram",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicID",
                table: "Courses",
                column: "TopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProgram");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
