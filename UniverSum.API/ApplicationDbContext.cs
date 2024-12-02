using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UniverSum.API.Identity;
using UniverSum.API.Models;
using UniverSum.API.Models.Administration;
using UniverSum.API.Models.Conversations;
using UniverSum.API.Models.Courses;
using UniverSum.API.Models.Schedule;
using UniverSum.API.Models.Tasks;
using CustomTask = UniverSum.API.Models.Tasks.CustomTask;
using Stream = UniverSum.API.Models.Administration.Stream;

namespace UniverSum.API
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<SpecialityCourse> SpecialityCourses { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<IndividualLesson> IndividualLessons { get; set; }
        public DbSet<LessonTimeSpan> LessonTimeSpans { get; set; }
        public DbSet<RecurringLesson> RecurringLessons { get; set; }
        public DbSet<CustomTask> Tasks { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Place>()
                .HasMany(e => e.Classrooms)
                .WithOne(e => e.Place)
                .HasForeignKey("PlaceId");

            builder.Entity<Department>()
                .HasMany(e => e.Teachers)
                .WithOne(e => e.Department)
                .HasForeignKey("DepartmentId");

            builder.Entity<EducationLevel>()
                .HasMany(e => e.Specialities)
                .WithOne(e => e.EducationLevel)
                .HasForeignKey("EducationLevelId")
                .IsRequired();

            builder.Entity<Faculty>()
                .HasMany(e => e.Departments)
                .WithOne(e => e.Faculty)
                .HasForeignKey("FacultyId")
                .IsRequired();

            builder.Entity<Faculty>()
                .HasMany(e => e.EducationLevels)
                .WithOne(e => e.Faculty)
                .HasForeignKey("FacultyId")
                .IsRequired();

            builder.Entity<Faculty>()
                .HasMany(e => e.Conversations)
                .WithOne(e => e.Faculty)
                .HasForeignKey("FacultyId");

            builder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Groups)
                .UsingEntity(j => j.HasData(
            new { StudentsId = 1, GroupsId = 1 },
            new { StudentsId = 1, GroupsId = 4 },
            new { StudentsId = 1, GroupsId = 5 },
            new { StudentsId = 1, GroupsId = 6 }

        ));

            builder.Entity<Speciality>()
                .HasMany(e => e.SpecialityCourses)
                .WithOne(e => e.Speciality)
                .HasForeignKey("SpecialityId")
                .IsRequired();

            builder.Entity<SpecialityCourse>()
                .HasMany(e => e.Streams)
                .WithOne(e => e.SpecialityCourse)
                .HasForeignKey("SpecialityCourseId")
                .IsRequired();

            builder.Entity<Stream>()
                .HasMany(e => e.Groups)
                .WithOne(e => e.Stream)
                .HasForeignKey("StreamId");

            builder.Entity<Conversation>()
               .HasMany(e => e.Members)
               .WithMany(e => e.Conversations)
               .UsingEntity(j => j.HasData(
            new { MembersId = 1, ConversationsId = 1 },
            new { MembersId = 1, ConversationsId = 2 },
            new { MembersId = 1, ConversationsId = 3 }

        ));

            builder.Entity<Conversation>()
                .HasMany(e => e.Messages)
                .WithOne(e => e.Conversation)
                .HasForeignKey("ConversationId");

            builder.Entity<Course>()
                .HasOne(e => e.Conversation)
                .WithOne(e => e.Course)
                .HasForeignKey<Conversation>(e => e.CourseId);

            builder.Entity<Content>()
                .HasMany(e => e.Links)
                .WithOne(e => e.Content)
                .HasForeignKey("ContentId");

            builder.Entity<Course>()
                .HasMany(e => e.Links)
                .WithOne(e => e.Course)
                .HasForeignKey("CourseId");

            builder.Entity<Course>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.Course)
                .HasForeignKey("CourseId");

            builder.Entity<Course>()
                .HasMany(e => e.Contents)
                .WithOne(e => e.Course)
                .HasForeignKey("CourseId")
                .IsRequired();

            builder.Entity<Course>()
                .HasMany(e => e.Members)
                .WithMany(e => e.Courses)
                .UsingEntity(j => j.HasData(
            new { CoursesId = 1, MembersId = 1 },
            new { CoursesId = 1, MembersId = 2 }
                        ));
            builder.Entity<Profile>()
                .HasMany(e => e.FavoriteLinks)
                .WithMany(e => e.FavoriteProfiles)
                .UsingEntity(j => j.HasData(
            new { FavoriteProfilesId = 1, FavoriteLinksId = 1 }
                        ));

            builder.Entity<Profile>()
                .HasMany(e => e.RecurringLessons)
                .WithMany(e => e.Members)
                .UsingEntity(j => j.HasData( 
            new { RecurringLessonsId = 1, MembersId = 1 },
            new { RecurringLessonsId = 2, MembersId = 1 },
            new { RecurringLessonsId = 3, MembersId = 1 },
            new { RecurringLessonsId = 4, MembersId = 1 },
            new { RecurringLessonsId = 5, MembersId = 1 },
            new { RecurringLessonsId = 6, MembersId = 1 },
            new { RecurringLessonsId = 7, MembersId = 1 },
            new { RecurringLessonsId = 8, MembersId = 1 },
            new { RecurringLessonsId = 9, MembersId = 1 },
            new { RecurringLessonsId = 10, MembersId = 1 },
            new { RecurringLessonsId = 11, MembersId = 1 },
            new { RecurringLessonsId = 12, MembersId = 1 }
                        ));

            builder.Entity<Profile>()
                .HasMany(e => e.CreatedTasks)
                .WithOne(e => e.Creator)
                .HasForeignKey("CreatorId");

            builder.Entity<Profile>()
                .HasMany(e => e.Results)
                .WithOne(e => e.Student)
                .HasForeignKey("StudentId");


            builder.Entity<IndividualLesson>()
                .HasMany(e => e.Messages)
                .WithOne(e => e.IndividualLesson)
                .HasForeignKey("IndividualLessonId");

            builder.Entity<CustomTask>()
                .HasMany(e => e.Messages)
                .WithOne(e => e.Task)
                .HasForeignKey("TaskId");

            builder.Entity<CustomTask>()
                .HasMany(e => e.Results)
                .WithOne(e => e.Task)
                .HasForeignKey("TaskId");

            builder.Entity<Place>(b =>
            {
                b.HasData(
                    new Place
                    {
                        Id = 1,
                        Title = "Головний корпус",
                    },
                    new Place
                    {
                        Id = 2,
                        Title = "вул. Чорновола, буд. 61",
                    },
                    new Place
                    {
                        Id = 3,
                        Title = "вул. Менцинського, буд. 8"
                    }
                    );
            });

            builder.Entity<Classroom>(b =>
            {
                b.HasData(
                    new Classroom
                    {
                        Id = 1,
                        Title = "439",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 2,
                        Title = "261",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 3,
                        Title = "112",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 4,
                        Title = "365",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 5,
                        Title = "116",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 6,
                        Title = "367",
                        PlaceId = 1
                    },
                    new Classroom
                    {
                        Id = 7,
                        Title = "366",
                        PlaceId = 1
                    }
                    );
            });

            builder.Entity<Faculty>(b =>
            {
                b.HasData(
                    new Faculty
                    {
                        Id = 1,
                        Title = "Прикладної математики та інформатики"
                    },
                    new Faculty
                    {
                        Id = 2,
                        Title = "Механіко-математичний"
                    },
                    new Faculty
                    {
                        Id = 3,
                        Title = "Електроніки та комп'ютерних технологій"
                    }
                    );
            });

            builder.Entity<Department>(b =>
            {
                b.HasData(
                    new Department
                    {
                        Id = 1,
                        Title = "Програмування",
                        FacultyId = 1
                    },
                    new Department
                    {
                        Id = 2,
                        Title = "Кібербезпеки",
                        FacultyId = 1
                    },
                    new Department
                    {
                        Id = 3,
                        Title = "Інформаційний систем",
                        FacultyId = 1
                    },
                    new Department
                    {
                        Id = 4,
                        Title = "Дискретного аналізу та інтелектуальних систем",
                        FacultyId = 1
                    }
                    );
            });

            builder.Entity<EducationLevel>(b =>
            {
                b.HasData(
                    new EducationLevel
                    {
                        Id = 1,
                        Type = Models.Enums.EducationLevelType.Bachelor,
                        FacultyId = 1
                    },
                    new EducationLevel
                    {
                        Id = 2,
                        Type = Models.Enums.EducationLevelType.Master,
                        FacultyId = 1
                    }
                    );
            });

            builder.Entity<Speciality>(b =>
            {
                b.HasData(
                    new Speciality
                    {
                        Id = 1,
                        Title = "122 Комп'ютерні науки",
                        EducationLevelId = 1
                    },
                    new Speciality
                    {
                        Id = 2,
                        Title = "125 Кібербезпека",
                        EducationLevelId = 1
                    },
                    new Speciality
                    {
                        Id = 3,
                        Title = "113 Прикладна математика",
                        EducationLevelId = 1
                    }
                    );
            });

            builder.Entity<SpecialityCourse>(b =>
            {
                b.HasData(
                    new SpecialityCourse
                    {
                        Id = 1,
                        Title = "2",
                        SpecialityId = 1
                    },
                    new SpecialityCourse
                    {
                        Id = 2,
                        Title = "3",
                        SpecialityId = 1
                    },
                    new SpecialityCourse
                    {
                        Id = 3,
                        Title = "4",
                        SpecialityId = 1
                    }
                    );
            });

            builder.Entity<Stream>(b =>
            {
                b.HasData(
                    new Stream
                    {
                        Id = 1,
                        Title = "1",
                        SpecialityCourseId = 3
                    },
                    new Stream
                    {
                        Id = 2,
                        Title = "2",
                        SpecialityCourseId = 3
                    }
                    );
            });

            builder.Entity<Group>(b =>
            {
                b.HasData(
                    new Group
                    {
                        Id = 1,
                        Title = "ПМІ-41",
                        StreamId = 1
                    },
                    new Group
                    {
                        Id = 2,
                        Title = "ПМІ-42",
                        StreamId = 1
                    },
                    new Group
                    {
                        Id = 3,
                        Title = "ПМІ-43",
                        StreamId = 1
                    },
                    new Group
                    {
                        Id = 4,
                        Title = "(ДВ 3) ООС Pharo 2024"
                    },
                    new Group
                    {
                        Id = 5,
                        Title = "(ДВ 2) Паралельні обчислення 2024"
                    },
                    new Group
                    {
                        Id = 6,
                        Title = "(ДВ 1) Дослідження операцій 2024"
                    }
                    );
            });

            builder.Entity<Course>(b =>
            {
                b.HasData(
                    new Course
                    {
                        Id = 1,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Технології захист інформації",
                        Description = "Курс розроблено таким чином, щоб надати учасникам знання принципів\r\nзахисту інформації, як необхідного інструменту для побудови захищених\r\nсистем. Тому у курсі представлено програмно-технічні методи захисту\r\nінформації як основу захищеної системи. Основну частину курсу займає\r\nрозгляд практичних і теоретичних аспектів захисту конфіденційності\r\nінформації, а також її цілісності та автентичності.",
                        ConversationId = 1,
                    },
                    new Course
                    {
                        Id = 2,
                        Type = Models.Enums.CourseType.FacultyElective,
                        Title = "(ДВ 3) ООС Pharo",
                        Description = "Фокус уваги курсу спрямовано на вивчення сучасної реалізації Pharo\r\nкласичної об’єктної системи програмування Smalltalk. Курс пов'язаний з\r\nдисциплінами \"Програмування\", \"Програмна інженерія\", \"Алгоритми і\r\nструктури даних\", \"Програмування та підтримка веб-застосувань\"."
                    },
                    new Course
                    {
                        Id = 3,
                        Type = Models.Enums.CourseType.FacultyElective,
                        Title = "(ДВ 2) Паралельні обчислення",
                        Description = "Курс “Паралельні та розподілені обчислення” присвячено проектуванню\r\nта розробці відмовостійких та масштабованих систем, що піддаються\r\nвисоким навантаженням. Розглянуто практичні підходи до ефективного\r\nрозпаралелення обчислювально складних задач.\r\nОсновна увага зосереджується на розробці архітектури та практичних\r\nаспектах побудови розподілених систем за використання сучасних засобів\r\nта технологій. Викладення матеріалу здійснюється за допомогою сучасних\r\nтермінів та понять з галузі інформаційних технологій."
                    },
                    new Course
                    {
                        Id = 4,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Українська мова (за професійним спрямуванням)",
                        Description = "Курс спрямований на розвиток і вдосконалення компетенції спілкуватися\r\nукраїнською мовою у майбутній професійній сфері; формувати навички\r\nкультури мовлення (усні і писемні) з урахуванням особливостей найбільш\r\nдоречного функціонального стилю мовлення та відповідно до норм сучасної\r\nукраїнської літературної мови. Теоретичні знання і практичні навички\r\nреалізації сучасних мовних норм (зокрема лексичних, граматичних,\r\nстилістичних, орфоепічних) у професійній сфері (передусім стосується\r\nнаукового, офіційно-ділового стилів) сприяють формуванню комунікативної\r\nповедінки фахівця, зокрема успішній комунікації та досягненні мети\r\nспілкування."
                    },
                    new Course
                    {
                        Id = 5,
                        Type = Models.Enums.CourseType.FacultyElective,
                        Title = "(ДВ 1) Дослідження операцій",
                        Description = "Цей курс охоплює такі розділи дослідження операцій: Моделі керування\r\nзапасами (МКЗ), Транспортна задача. Задачі дискретного програмування .\r\nЗадачі багатокритеріальної оптимізації. МГМ розв’язування екстремальних\r\nкомбінаторних задач. Моделі ЗУР в умовах невизначеності. Моделі ЗУР в\r\nумовах конфлікту. Антагоністичні ігри. Ситуації рівноваги Неша, елементи\r\nтеорії систем масового обслуговування. "
                    },
                    new Course
                    {
                        Id = 6,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Філософія",
                        Description = "У курсі філософії головна увага зосереджена на вузлових інтелектуальних пунктах розвитку філософського знання у контексті\r\nєвропейської і світової цивілізації. Українська філософська думка органічно вплетена в контекст практично всіх тем.\r\nЛогіка викладу матеріалу спрямована на перетворення засвоюваного студентами філософського знання у складник їх внутрішньої\r\nкультури і основи для критичного мислення, на виформування лінії поведінки у напрямку пошуку вищих вартостей – Істини, Добра, Краси\r\nНавчальним планом передбачено читання лекцій, проведення семінарських занять, написання розвиваючих тестових завдань по темах\r\nдвох головних змістових частин, на які розбитий курс.\r\n"
                    },
                    new Course
                    {
                        Id = 7,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Логічне та функціональне програмування",
                        Description = "Фокус уваги курсу спрямовано на вивчення засад декларативного програмування. Засоби та методи написання програм у логічному стилі проілюстровано мовою Пролог, засоби та методи функційного програмування – з\r\nвикористанням Лісп і Пайтон. Курс пов'язаний з дисциплінами \"Програмування\", \"Теорія алгоритмів\", \"Алгоритми і структури даних\".\r\n"
                    },
                    new Course
                    {
                        Id = 8,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Логічне та функціональне програмування",
                        Description = "Фокус уваги курсу спрямовано на вивчення засад декларативного програмування. Засоби та методи написання програм у логічному стилі проілюстровано мовою Пролог, засоби та методи функційного програмування – з\r\nвикористанням Лісп і Пайтон. Курс пов'язаний з дисциплінами \"Програмування\", \"Теорія алгоритмів\", \"Алгоритми і структури даних\".\r\n"
                    },
                    new Course
                    {
                        Id = 9,
                        Type = Models.Enums.CourseType.Required,
                        Title = "Моделювання еволюційних систем",
                        Description = "Дисципліна знайомить студентів з сучасними підходами до мікро –мезо та –\r\nмакромоделювання процесів еволюції і самоорганізації у складних\r\nдинамічних нелінійних нерівноважних матеріальних, суспільних та\r\nінформаційних системах.\r\n"
                    }
                        );
            });

            builder.Entity<Content>(b =>
            {
                b.HasData(
                    new Content
                    {
                        Id = 1,
                        Title = "Основні види та джерела атак на інформацію",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 2,
                        Title = "Методології захисту інформації",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 3,
                        Title = "Шкідливе програмне забезпечення та захист від нього",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 4,
                        Title = "Елементарна криптографія",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 5,
                        Title = "Блокові шифри",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 6,
                        Title = "Сучасні алгоритми блокового шифрування I",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 7,
                        Title = "Сучасні алгоритми блокового шифрування II",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 8,
                        Title = "Потокові шифри",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 9,
                        Title = "Елементи теорії чисел",
                        CourseId = 1
                    },
                    new Content
                    {
                        Id = 10,
                        Title = "Криптосистеми з відкритим ключем",
                        CourseId = 1
                    }
                    );
            });

            builder.Entity<LessonTimeSpan>(b =>
            {
                b.HasData(
                    new LessonTimeSpan
                    {
                        Id = 1,
                        LessonNumber = 1,
                        StartTime = new DateTime(1, 1, 1, 8, 30, 0),
                        EndTime = new DateTime(1, 1, 1, 9, 50, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 2,
                        LessonNumber = 2,
                        StartTime = new DateTime(1, 1, 1, 10, 10, 0),
                        EndTime = new DateTime(1, 1, 1, 11, 30, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 3,
                        LessonNumber = 3,
                        StartTime = new DateTime(1, 1, 1, 11, 50, 0),
                        EndTime = new DateTime(1, 1, 1, 13, 10, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 4,
                        LessonNumber = 4,
                        StartTime = new DateTime(1, 1, 1, 13, 30, 0),
                        EndTime = new DateTime(1, 1, 1, 14, 50, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 5,
                        LessonNumber = 5,
                        StartTime = new DateTime(1, 1, 1, 15, 05, 0),
                        EndTime = new DateTime(1, 1, 1, 16, 25, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 6,
                        LessonNumber = 6,
                        StartTime = new DateTime(1, 1, 1, 16, 40, 0),
                        EndTime = new DateTime(1, 1, 1, 18, 00, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 7,
                        LessonNumber = 7,
                        StartTime = new DateTime(1, 1, 1, 18, 10, 0),
                        EndTime = new DateTime(1, 1, 1, 19, 30, 0)
                    },
                    new LessonTimeSpan
                    {
                        Id = 8,
                        LessonNumber = 8,
                        StartTime = new DateTime(1, 1, 1, 19, 40, 0),
                        EndTime = new DateTime(1, 1, 1, 21, 00, 0)
                    }
                    );
            });

            builder.Entity<RecurringLesson>(b =>
            {
                b.HasData(
                    new RecurringLesson
                    {
                        Id = 1,
                        ClassroomId = 1,
                        CourseId = 1,
                        LessonTimeSpanId = 4,
                        WeekDay = Models.Enums.WeekDay.Monday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.Lecture,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new RecurringLesson
                    {
                        Id = 2,
                        ClassroomId = 2,
                        CourseId = 2,
                        LessonTimeSpanId = 5,
                        WeekDay = Models.Enums.WeekDay.Monday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)


                    },
                    new RecurringLesson
                    {
                        Id = 3,
                        ClassroomId = 3,
                        CourseId = 3,
                        LessonTimeSpanId = 6,
                        WeekDay = Models.Enums.WeekDay.Monday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new RecurringLesson
                    {
                        Id = 4,
                        ClassroomId = 3,
                        CourseId = 4,
                        LessonTimeSpanId = 4,
                        WeekDay = Models.Enums.WeekDay.Tuesday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.PracticalWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new RecurringLesson
                    {
                        Id = 5,
                        ClassroomId = 1,
                        CourseId = 5,
                        LessonTimeSpanId = 5,
                        WeekDay = Models.Enums.WeekDay.Tuesday,
                        WeekMode = Models.Enums.WeekMode.Denominator,
                        LessonType = Models.Enums.LessonType.Lecture,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new RecurringLesson
                    {
                        Id = 6,
                        ClassroomId = 1,
                        CourseId = 6,
                        LessonTimeSpanId = 5,
                        WeekDay = Models.Enums.WeekDay.Tuesday,
                        WeekMode = Models.Enums.WeekMode.Numerator,
                        LessonType = Models.Enums.LessonType.Lecture,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new RecurringLesson
                    {
                        Id = 7,
                        ClassroomId = 4,
                        CourseId = 5,
                        LessonTimeSpanId = 6,
                        WeekDay = Models.Enums.WeekDay.Tuesday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 8,
                        ClassroomId = 5,
                        CourseId = 1,
                        LessonTimeSpanId = 7,
                        WeekDay = Models.Enums.WeekDay.Tuesday,
                        WeekMode = Models.Enums.WeekMode.Numerator,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 9,
                        ClassroomId = 6,
                        CourseId = 6,
                        LessonTimeSpanId = 4,
                        WeekDay = Models.Enums.WeekDay.Wednesday,
                        WeekMode = Models.Enums.WeekMode.Numerator,
                        LessonType = Models.Enums.LessonType.PracticalWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 10,
                        ClassroomId = 6,
                        CourseId = 3,
                        LessonTimeSpanId = 5,
                        WeekDay = Models.Enums.WeekDay.Wednesday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.Lecture,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 11,
                        ClassroomId = 7,
                        CourseId = 7,
                        LessonTimeSpanId = 6,
                        WeekDay = Models.Enums.WeekDay.Wednesday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 12,
                        ClassroomId = 1,
                        CourseId = 9,
                        LessonTimeSpanId = 4,
                        WeekDay = Models.Enums.WeekDay.Friday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.LaboratoryWork,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    },
                    new RecurringLesson
                    {
                        Id = 13,
                        ClassroomId = 1,
                        CourseId = 9,
                        LessonTimeSpanId = 5,
                        WeekDay = Models.Enums.WeekDay.Friday,
                        WeekMode = Models.Enums.WeekMode.Both,
                        LessonType = Models.Enums.LessonType.Lecture,
                        StartDate = new DateTime(2024, 9, 1),
                        EndDate = new DateTime(2024, 12, 31)

                    }
                    );
            });

            builder.Entity<CustomTask>(b =>
            {
                b.HasData(
                    new CustomTask
                    {
                        Id = 1,
                        Title = "Лабораторна робота №1",
                        CourseId = 1,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 3),
                        MaxMark = 20,
                        Priority = Models.Enums.TaskPriority.Medium,
                        Status = Models.Enums.TaskStatus.NotStarted
                    },
                    new CustomTask
                    {
                        Id = 2,
                        Title = "Підготувати презентацію",
                        CourseId = 2,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 4),
                        MaxMark = 25,
                        Priority = Models.Enums.TaskPriority.High,
                        Status = Models.Enums.TaskStatus.InProcess,
                    },
                    new CustomTask
                    {
                        Id = 3,
                        Title = "Лабораторна робота №3",
                        CourseId = 3,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 5),
                        MaxMark = 30,
                        Priority = Models.Enums.TaskPriority.Low,
                        Status = Models.Enums.TaskStatus.InProcess,
                    },
                    new CustomTask
                    {
                        Id = 4,
                        Title = "Практична робота №4",
                        CourseId = 4,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 6),
                        MaxMark = 10,
                        Priority = Models.Enums.TaskPriority.Low,
                        Status = Models.Enums.TaskStatus.Completed,
                    },
                    new CustomTask
                    {
                        Id = 5,
                        Title = " №4",
                        CourseId = 5,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 7),
                        MaxMark = 15,
                        Priority = Models.Enums.TaskPriority.High,
                        Status = Models.Enums.TaskStatus.Completed,
                    },
                    new CustomTask
                    {
                        Id = 6,
                        Title = "Підготувати доповідь на тему Політика безпеки та її структура",
                        CourseId = 1,
                        CreatorId = 2,
                        EndDateTime = new DateTime(2024, 11, 8),
                        MaxMark = 20,
                        Priority = Models.Enums.TaskPriority.Medium,
                        Status = Models.Enums.TaskStatus.Completed,
                    }
                    );
            });

            builder.Entity<Result>(b =>
            {
                b.HasData(
                    new Result
                    {
                        Id = 1,
                        TaskId = 6,
                        Mark = 19,
                        StudentId = 1
                    }
                    );
            });

            builder.Entity<IndividualLesson>(b =>
            {
                b.HasData(
                    new IndividualLesson
                    {
                        Id = 1,
                        RecurringLessonId = 1,
                        Date = new DateTime(2024, 12, 2),
                        TaskId = 1,
                        ContentId = 1

                    },
                    new IndividualLesson
                    {
                        Id = 2,
                        RecurringLessonId = 2,
                        Date = new DateTime(2024, 12, 2),
                    },
                     new IndividualLesson
                     {
                         Id = 3,
                         RecurringLessonId = 3,
                         Date = new DateTime(2024, 12, 2),
                     },
                     new IndividualLesson
                     {
                         Id = 4,
                         RecurringLessonId = 4,
                         Date = new DateTime(2024, 12, 3),
                     },
                     new IndividualLesson
                     {
                         Id = 6,
                         RecurringLessonId = 5,
                         Date = new DateTime(2024, 12, 3),
                     },
                     new IndividualLesson
                     {
                         Id = 7,
                         RecurringLessonId = 6,
                         Date = new DateTime(2024, 12, 3)
                     },
                     new IndividualLesson
                     {
                         Id = 8,
                         RecurringLessonId = 8,
                         Date = new DateTime(2024, 12, 3),
                     }
                    );
            });

            builder.Entity<Conversation>(b =>
            {
                b.HasData(
                    new Conversation
                    {
                        Id = 1,
                        CourseId = 1,

                    },
                    new Conversation
                    {
                        Id = 2,
                        FacultyId = 1,
                        Title = "Деканат"

                    },
                    new Conversation
                    {
                        Id = 3,
                        IsUniversity = true,
                        Title = "Студентський уряд"
                    }
                    );
            });

            builder.Entity<Message>(b =>
            {
                b.HasData(
                    new Message
                    {
                        Id = 1,
                        TaskId = 6,
                        Text = "Чудова робота, але наступного разу коректніше форматуйте текст.",
                        ConversationId = 1,
                        SenderId = 2,
                        SendingDateTime = new DateTime(2024, 12, 7, 10, 45, 00),
                    },
                    new Message
                    {
                        Id = 2,
                        Text = "Можна, будь ласка, перенести дане заняття на інший день?",
                        ConversationId = 1,
                        IndividualLessonId = 1,
                        SenderId = 1,
                        SendingDateTime = new DateTime(2024, 12, 1, 09, 56, 10),
                    },
                    new Message
                    {
                        Id = 3,
                        Text = "Кінцевий термін слухання повторних курсів 8 травня 2024 року. З 10 до 13 травня 2024 року будуть відбуватися здачі іспитів, заліків, диференційованих заліків та комп'ютерних проектів по повторних курсах згідно розкладу кафедр викладачів.",
                        ConversationId = 2,
                        SenderId = 3,
                        SendingDateTime = new DateTime(2024, 05, 1, 15, 39, 15),
                    }
                    );
            });

            builder.Entity<Link>(b =>
            {
                b.HasData(
                    new Link
                    {
                        Id = 1,
                        Title = "Сайт університету",
                        Url = new Uri("https://lnu.edu.ua"),
                        IsUniversity = true,

                    },
                    new Link
                    {
                        Id = 2,
                        Title = "Сайт студентського уряду",
                        Url = new Uri("http://studentgovernment.lnu.edu.ua/"),
                        IsUniversity = true,

                    },
                    new Link
                    {
                        Id = 3,
                        Title = "Сайт факультету",
                        Url = new Uri("https://ami.lnu.edu.ua/"),
                        FacultyId = 1
                    },
                    new Link
                    {
                        Id = 4,
                        Title = "Сайт програми Кібербезпека",
                        Url = new Uri("https://cybersecurity.lnu.edu.ua/"),
                        FacultyId = 1
                    },
                    new Link
                    {
                        Id = 5,
                        Title = "Презентація до розділу 1",
                        Url = new Uri("https://example.com/"),
                        ContentId = 1
                    },
                    new Link
                    {
                        Id = 6,
                        Title = "Teams-нарада",
                        Url = new Uri("https://example.com/"),
                        ContentId = 1
                    }

                    );
            });

            builder.Entity<Profile>(b =>
            {
                b.HasData(
                    new Profile
                    {
                        Id = 1,
                        Role = Models.Enums.ProfileRole.Student,
                        FirstName = "Петро",
                        LastName = "Петренко",
                        MiddleName = "Петрович",
                        Email = "student1@example.com"
                    },
                    new Profile
                    {
                        Id = 2,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Ірина",
                        LastName = "Бернакевич",
                        MiddleName = "Євстахіївна",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 3
                        
                    },
                    new Profile
                    {
                        Id = 3,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Сергій",
                        LastName = "Ярошко",
                        MiddleName = "Адамович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 1
                    },
                    new Profile
                    {
                        Id = 4,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Оксана",
                        LastName = "Ярошко",
                        MiddleName = "Сергіївна",
                        Position = Models.Enums.TeacherPosition.Assistant,
                        DepartmentId = 3
                    },
                    new Profile
                    {
                        Id = 5,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Георгій",
                        LastName = "Шинкаренко",
                        MiddleName = "Андрійович",
                        Position = Models.Enums.TeacherPosition.Professor,
                        DepartmentId = 3
                    },
                    new Profile
                    {
                        Id = 6,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Михайло",
                        LastName = "Яджак",
                        MiddleName = "Степанович",
                        Position = Models.Enums.TeacherPosition.Professor,
                        DepartmentId = 3,
                    },
                    new Profile
                    {
                        Id = 7,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Андріана",
                        LastName = "Чучвара",
                        MiddleName = "Петрівна",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId=1
                    },
                    new Profile
                    {
                        Id = 8,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Роман",
                        LastName = "Олійник",
                        MiddleName = "Миколайович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 4,
                    },
                    new Profile
                    {
                        Id = 9,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Наталія",
                        LastName = "Коркуна",
                        MiddleName = "Михайлівна",
                        Position = Models.Enums.TeacherPosition.Assistant,
                        DepartmentId=4,
                    },
                    new Profile
                    {
                        Id = 10,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Олександр",
                        LastName = "Вовк",
                        MiddleName = "Дмитрович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId=3,
                    },
                    new Profile
                    {
                        Id = 11,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Валерій",
                        LastName = "Джунь",
                        MiddleName = "Володимирович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId=1
                    },
                    new Profile
                    {
                        Id = 12,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Наталія",
                        LastName = "Івасько",
                        MiddleName = "Михайлівна",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 1

                    },
                    new Profile
                    {
                        Id = 13,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Роман",
                        LastName = "Селіверстов",
                        MiddleName = "Григорович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 1
                    },
                    new Profile
                    {
                        Id = 14,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Володимир",
                        LastName = "Вовк",
                        MiddleName = "Дмитрович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor,
                        DepartmentId = 1
                    },
                    new Profile
                    {
                        Id = 15,
                        Role = Models.Enums.ProfileRole.Teacher,
                        FirstName = "Віталій",
                        LastName = "Горлач",
                        MiddleName = "Михайлович",
                        Position = Models.Enums.TeacherPosition.AssociateProfessor
                    }
                );
            });

            base.OnModelCreating(builder);
        }
    }
}
