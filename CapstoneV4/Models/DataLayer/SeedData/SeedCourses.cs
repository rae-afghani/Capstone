using CapstoneV4.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapstoneV4.Models.DataLayer.SeedData
{
    public class SeedCourses : IEntityTypeConfiguration<Courses>

    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasData(
                new Courses { CourseID = 101, CourseName = "Let's Get Reactive: Chemistry Foundations", CourseDescription = "Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.", TopicID = "chem", Tuition = 229.00 },


                new Courses { CourseID = 102, CourseName = "Game Designer: Program Your Own Game", CourseDescription = "Get ready to have some fun as you learn everything it takes to plan, design, and program your own 2D and 3D games. This class uses Unity's C# language to teach core game development skills. The projects you create will be brought to life with animation, sound effects, and music. In the final few weeks of this course, students will create an original game for class showcase day!", TopicID = "cs", Tuition = 229.00 },


                new Courses { CourseID = 103, CourseName = "Web Masters: Advanced Web Development", CourseDescription = "A step up from our introductory web development course, Web Masters is all about learning how to take static HTML files to the web! We will review HTML and CSS, continue into JavaScript, and dive into server-side scripting with PHP. By the end of this course, you'll have hands-on experience creating complete websites such as blogs, and portfolios, or even a simple eCommerce site.", TopicID = "cs", Tuition = 229.00 },


                new Courses { CourseID = 104, CourseName = "Advanced Psychology: Understanding You", CourseDescription = "Who am I? This is a question humans have been trying to answer since the dawn of time. In this course, students will build upon their knowledge of psychology, learning about theories, methods, and research around personality testing. In addition, we'll cover how we can use our understanding of personality and personality disorders in everyday situations.", TopicID = "psych", Tuition = 229.00 },


                new Courses { CourseID = 105, CourseName = "Robotics: Build a Robot from Scratch", CourseDescription = "Robotics is one of the more exciting and dynamic fields of engineering, with students have a blast building things and seeing them come to life. This course will give students a chance to learn the fundamentals of robotics and engineering through exciting, hands-on activities using Lego and VEX Robotics. Students will cover topics such as circuitry, hardware and software development, simple machines, Python programming, and more!", TopicID = "cs", Tuition = 229.00 },




                new Courses { CourseID = 201, CourseName = "Sssstrengthen Your Ssskills in Python", CourseDescription = "Python is a fast, easy and versatile language that can be used for everything from data science to game development. Students will learn how to make computer program using loops, conditionals and variables, with examples in Python libraries like Numpy and Pandas. Students will also learn the basics of application development such as GUIs, database creation and testing.", TopicID = "cs", Tuition = 199.00 },


                new Courses { CourseID = 202, CourseName = "It's Not Rocket Science: Aerospace Fundamentals", CourseDescription = "Master the principles and theories of aerospace science with these hands-on projects. Students build a model space shuttle, design and test airfoils that allow an object to fly, and create 3D models of rockets and spacecraft. Along the way, they will apply orbital mechanics concepts to build an accurate depiction of a rocket launch or a satellite in orbit.", TopicID = "phys", Tuition = 199.00 },


                new Courses { CourseID = 203, CourseName = "Let's Get Reactive: Chemistry Foundations", CourseDescription = "Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.", TopicID = "chem", Tuition = 199.00 },



                new Courses { CourseID = 301, CourseName = "Academic Accelerator: Algebra", CourseDescription = "A one-on-one course focused on Algebra.", TopicID = "math", Tuition = 149.00 },
                new Courses { CourseID = 302, CourseName = "Academic Accelerator: Physics", CourseDescription = "A one-on-one course focused on Physics.", TopicID = "phys", Tuition = 149.00 },
                new Courses { CourseID = 303, CourseName = "Academic Accelerator: Biology", CourseDescription = "A one-on-one course focused on Biology.", TopicID = "biol", Tuition = 149.00 }

                );
        }
    }
}
