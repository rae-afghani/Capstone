IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE TABLE [Programs] (
        [ProgramID] int NOT NULL IDENTITY,
        [ProgramType] nvarchar(50) NOT NULL,
        [ProgramDescription] nvarchar(500) NOT NULL,
        CONSTRAINT [PK_Programs] PRIMARY KEY ([ProgramID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE TABLE [Topics] (
        [TopicID] nvarchar(10) NOT NULL,
        [Name] nvarchar(25) NOT NULL,
        CONSTRAINT [PK_Topics] PRIMARY KEY ([TopicID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE TABLE [Courses] (
        [CourseID] int NOT NULL IDENTITY,
        [CourseName] nvarchar(200) NOT NULL,
        [CourseDescription] nvarchar(500) NOT NULL,
        [Tuition] float NOT NULL,
        [TopicID] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseID]),
        CONSTRAINT [FK_Courses_Topics_TopicID] FOREIGN KEY ([TopicID]) REFERENCES [Topics] ([TopicID]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE TABLE [CourseProgram] (
        [CourseID] int NOT NULL,
        [ProgramID] int NOT NULL,
        CONSTRAINT [PK_CourseProgram] PRIMARY KEY ([CourseID], [ProgramID]),
        CONSTRAINT [FK_CourseProgram_Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Courses] ([CourseID]) ON DELETE CASCADE,
        CONSTRAINT [FK_CourseProgram_Programs_ProgramID] FOREIGN KEY ([ProgramID]) REFERENCES [Programs] ([ProgramID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CourseID', N'CourseDescription', N'CourseName', N'TopicID', N'Tuition') AND [object_id] = OBJECT_ID(N'[Courses]'))
        SET IDENTITY_INSERT [Courses] ON;
    EXEC(N'INSERT INTO [Courses] ([CourseID], [CourseDescription], [CourseName], [TopicID], [Tuition])
    VALUES (101, N''Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.'', N''Let''''s Get Reactive: Chemistry Foundations'', N''chemistry'', 229.0E0),
    (102, N''Get ready to have some fun as you learn everything it takes to plan, design, and program your own 2D and 3D games. This class uses Unity''''s C# language to teach core game development skills. The projects you create will be brought to life with animation, sound effects, and music. In the final few weeks of this course, students will create an original game for class showcase day!'', N''Game Designer: Program Your Own Game'', N''computer science'', 229.0E0),
    (103, N''A step up from our introductory web development course, Web Masters is all about learning how to take static HTML files to the web! We will review HTML and CSS, continue into JavaScript, and dive into server-side scripting with PHP. By the end of this course, you''''ll have hands-on experience creating complete websites such as blogs, and portfolios, or even a simple eCommerce site.'', N''Web Masters: Advanced Web Development'', N''computer science'', 229.0E0),
    (104, N''Who am I? This is a question humans have been trying to answer since the dawn of time. In this course, students will build upon their knowledge of psychology, learning about theories, methods, and research around personality testing. In addition, we''''ll cover how we can use our understanding of personality and personality disorders in everyday situations.'', N''Advanced Psychology: Understanding You'', N''psychology'', 229.0E0),
    (105, N''Robotics is one of the more exciting and dynamic fields of engineering, with students have a blast building things and seeing them come to life. This course will give students a chance to learn the fundamentals of robotics and engineering through exciting, hands-on activities using Lego and VEX Robotics. Students will cover topics such as circuitry, hardware and software development, simple machines, Python programming, and more!'', N''Robotics: Build a Robot from Scratch'', N''computer science'', 229.0E0),
    (201, N''Python is a fast, easy and versatile language that can be used for everything from data science to game development. Students will learn how to make computer program using loops, conditionals and variables, with examples in Python libraries like Numpy and Pandas. Students will also learn the basics of application development such as GUIs, database creation and testing.'', N''Sssstrengthen Your Ssskills in Python'', N''computer science'', 199.0E0),
    (202, N''Master the principles and theories of aerospace science with these hands-on projects. Students build a model space shuttle, design and test airfoils that allow an object to fly, and create 3D models of rockets and spacecraft. Along the way, they will apply orbital mechanics concepts to build an accurate depiction of a rocket launch or a satellite in orbit.'', N''It''''s Not Rocket Science: Aerospace Fundamentals'', N''physics'', 199.0E0),
    (203, N''Chemistry means change. Whether we’re talking about hydrocarbons, the periodic table, or the study of how substances interact with one another, no matter what we focus on in chemistry, you can bet that it’ll be something that has some kind of effect on our world. We explore how things work together to create new things and help us understand the world around us. And if there’s anything chemistry teaches us, it’s that everything is connected - even across all forms of nature.'', N''Let''''s Get Reactive: Chemistry Foundations'', N''chemistry'', 199.0E0),
    (301, N''A one-on-one course focused on Algebra.'', N''Academic Accelerator: Algebra'', N''mathematics'', 149.0E0),
    (302, N''A one-on-one course focused on Physics.'', N''Academic Accelerator: Physics'', N''physics'', 149.0E0),
    (303, N''A one-on-one course focused on Biology.'', N''Academic Accelerator: Biology'', N''biology'', 149.0E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CourseID', N'CourseDescription', N'CourseName', N'TopicID', N'Tuition') AND [object_id] = OBJECT_ID(N'[Courses]'))
        SET IDENTITY_INSERT [Courses] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProgramID', N'ProgramDescription', N'ProgramType') AND [object_id] = OBJECT_ID(N'[Programs]'))
        SET IDENTITY_INSERT [Programs] ON;
    EXEC(N'INSERT INTO [Programs] ([ProgramID], [ProgramDescription], [ProgramType])
    VALUES (1, N''This is an in-person course led by an instructor. Our classroom ratios are 5:1. Classes meet once a week.'', N''Group Learning''),
    (2, N''The curriculum of our Academic Accelerators empowers students where their weak points are. Students enrolled in this program meet with an instructor once a week at our campus.'', N''1-On-1''),
    (3, N''This is a virtual course led by an instructor over Zoom. Upon enrollment, Science Lab provides all the necessary materials to succeed in this program. Classes meet once a week.'', N''Virtual Course'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProgramID', N'ProgramDescription', N'ProgramType') AND [object_id] = OBJECT_ID(N'[Programs]'))
        SET IDENTITY_INSERT [Programs] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TopicID', N'Name') AND [object_id] = OBJECT_ID(N'[Topics]'))
        SET IDENTITY_INSERT [Topics] ON;
    EXEC(N'INSERT INTO [Topics] ([TopicID], [Name])
    VALUES (N''biol'', N''Biology''),
    (N''chem'', N''Chemistry''),
    (N''cs'', N''Compuer Science''),
    (N''math'', N''Mathematics''),
    (N''phys'', N''Physics''),
    (N''psych'', N''Psychology'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TopicID', N'Name') AND [object_id] = OBJECT_ID(N'[Topics]'))
        SET IDENTITY_INSERT [Topics] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CourseID', N'ProgramID') AND [object_id] = OBJECT_ID(N'[CourseProgram]'))
        SET IDENTITY_INSERT [CourseProgram] ON;
    EXEC(N'INSERT INTO [CourseProgram] ([CourseID], [ProgramID])
    VALUES (101, 1),
    (102, 1),
    (103, 1),
    (104, 1),
    (105, 1),
    (201, 2),
    (202, 2),
    (203, 2),
    (301, 3),
    (302, 3),
    (303, 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CourseID', N'ProgramID') AND [object_id] = OBJECT_ID(N'[CourseProgram]'))
        SET IDENTITY_INSERT [CourseProgram] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE INDEX [IX_CourseProgram_ProgramID] ON [CourseProgram] ([ProgramID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    CREATE INDEX [IX_Courses_TopicID] ON [Courses] ([TopicID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128044352_seed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221128044352_seed', N'6.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221128052134_seedGD-1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221128052134_seedGD-1', N'6.0.11');
END;
GO

COMMIT;
GO

