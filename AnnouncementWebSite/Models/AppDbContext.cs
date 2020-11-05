using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementWebSite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebSite.Models
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Announcement>().HasData(new List<Announcement>()
                {
                    new Announcement()
                    {
                        CreatedAt = new DateTime(year:2020, 10, 15),
                        Description = "Полный курс по JavaScript + React - с нуля до результата (ОБНОВЛЕН) Освой самый популярный язык программирования - JavaScript, библиотеку React и научись применять на практике! Чему вы научитесь: Узнаешь основы программирования и алгоритмов Узнаешь основные концепции и принципы JavaScript, от самых простых до самых сложных Изучишь такие популярные технологии как AJAX, JSON и тд Научишься работать с Git и GitHub Научишься работать с npm, Babel, Browserify, Webpack и тд Узнаешь, какой фрэймворк или библиотеку выбрать в дальнейшем. Познакомишься с React, Angular, Vue, Jquery Изучишь библиотеку React и все, что с ней связано (в том числе и Redux) Научишься создавать полноценные web-приложения Закрепишь всё, что узнал на реальных проектах",
                        ShortDescription = "Полный курс по JavaScript + React - с нуля до результата",
                        Id = 1,
                        PhoneNumber = "0967883286",
                        Title = "Programming courses"
                    },
                    new Announcement()
                    {
                        CreatedAt = new DateTime(year:2020, 11, 2),
                        Description = "DriveSafe Online® Defensive Driving Courses: A convenient and inexpensive way to improve and refresh a driver’s education. Provides additional training and defensive driving skills to younger drivers whose insurance premiums tend to be higher. Save up to 10% on insurance premiums for up to three consecutive years, per policy, per driver. Check with your insurance agent to find out if you qualify. Safer drivers reduce the risk exposure for insurance providers (less exposure=lower rates). Quick and easy to complete, taking as little as 1 hour from start to finish for some DriveSafe courses. However, some states require longer courses.",
                        ShortDescription = "DRIVESAFE ONLINE DEFENSIVE DRIVING COURSES",
                        Id = 2,
                        PhoneNumber = "0957884286",
                        Title = "Drive courses"
                    },
                    new Announcement()
                    {
                        CreatedAt = new DateTime(year:2020, 10, 19),
                        Description = "Описание помещения: - Помещение капитальное, имеет стабильную температуру выше 10 градусов (Отопительная печь уже смонтирована), ровный заливной пол. Идеально подойдет для товаров которым необходим температурный режим. - Высота помещения - 4 метра - Спец. техника и команда работает 24/7 В стоимость включено: -Охрана по всему складу (видеонаблюдения/сигнализации); -Интернет; -Офисы с компьютерами; -Доступ к услугам склада и спец технике; -Вывоз мусора; -Парковка; -Рампа; -Туалет и зону отдыха; -Электричество; Цена за м2 = 90 Предложение от собственника. Работаем как с наличными так и безналичным расчетом(Комиссия без.нал. 0%). Предоставляем все официальные бумаги, также работаем с юридическими лицами - выдаем все документы, принимаем безналичный расчет, даже чеки и акты выполненных работ Место расположения: в 9 км от м.Героев Днепра По viber и telegram предоставим больше информации и фотографий",
                        ShortDescription = "Теплое складское помещение 65м2 для хранения товара и производства",
                        Id = 3,
                        PhoneNumber = "0987884986",
                        Title = "Складское помещение"
                    },
                    new Announcement()
                    {
                        CreatedAt = new DateTime(year:2020, 10, 12),
                        Description = "Фасадный вход! Первая линия! Аренда коммерческого помещения с ремонтом по ул. Шевченко. Общая площадь 45 кв.м В помещении установлена пожарная и охранная сигнализация, счётчики на все коммуникации.",
                        ShortDescription = "Фасадный вход! Первая линия! Аренда помещения с ремонтом",
                        Id = 4,
                        PhoneNumber = "0967585086",
                        Title = "Помещение с ремонтом"
                    },
                    new Announcement()
                    {
                        CreatedAt = new DateTime(year:2020, 10, 20),
                        Description = "AI is transforming how we live, work, and play. By enabling new technologies like self-driving cars and recommendation systems or improving old ones like medical diagnostics and search engines, the demand for expertise in AI and machine learning is growing rapidly. This course will enable you to take the first step toward solving important real-world problems and future-proofing your career.",
                        ShortDescription = "Learn to use machine learning in Python in this introductory course on artificial intelligence.",
                        Id = 5,
                        PhoneNumber = "0967383586",
                        Title = "CS50's Introduction to Artificial Intelligence with Python courses"
                    }
                });
        }
    }
}
