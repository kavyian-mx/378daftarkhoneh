using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Models;

namespace _378daftarkhoneh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            });

            // UserFile configurations
            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProcessedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.ProcessedByUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Seed initial admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123", // در محیط واقعی باید هش شود
                    FirstName = "مدیر",
                    LastName = "سیستم",
                    Email = "admin@notary378.ir",
                    Role = UserRole.SuperAdmin,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            // Seed initial categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "اسناد املاک", Description = "خرید، فروش، اجاره املاک", Color = "#3498db", Icon = "fas fa-home" },
                new Category { Id = 2, Name = "وکالتنامه", Description = "انواع وکالتنامه‌ها", Color = "#e74c3c", Icon = "fas fa-gavel" },
                new Category { Id = 3, Name = "اقرارنامه", Description = "انواع اقرارنامه‌ها", Color = "#27ae60", Icon = "fas fa-file-signature" },
                new Category { Id = 4, Name = "ازدواج و طلاق", Description = "شروط ضمن عقد، طلاق", Color = "#f39c12", Icon = "fas fa-ring" },
                new Category { Id = 5, Name = "گواهی و استعلام", Description = "گواهی امضا، استعلام", Color = "#9b59b6", Icon = "fas fa-certificate" }
            );

            // Seed initial blog posts
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "راهنمای کامل خرید و فروش املاک در دفترخانه",
                    Summary = "تمام مراحل قانونی خرید و فروش املاک از ابتدا تا انتها، مدارک مورد نیاز و نکات مهم برای طرفین معامله.",
                    Content = "خرید و فروش املاک یکی از مهم‌ترین تصمیمات مالی در زندگی هر فرد محسوب می‌شود. این فرآیند پیچیده نیازمند رعایت دقیق قوانین و مقررات است تا از حقوق طرفین معامله محافظت شود.\n\nمراحل اصلی معامله املاک:\n\n1. بررسی اسناد ملک: قبل از هر اقدامی، بررسی دقیق سند مالکیت، استعلام از ثبت اسناد و اطمینان از عدم وجود محدودیت قانونی ضروری است.\n\n2. تنظیم قرارداد: قرارداد باید شامل تمام جزئیات ملک، قیمت، شرایط پرداخت و تعهدات طرفین باشد.\n\n3. پرداخت و انتقال: انجام مراحل نقل و انتقال در دفترخانه با حضور طرفین و ارائه مدارک لازم.\n\nمدارک مورد نیاز:\n- اصل سند مالکیت\n- شناسنامه و کارت ملی طرفین\n- گواهی عدم محکومیت\n- نقشه UTM ملک\n- مفاصاحساب آب، برق و گاز\n\nنکات مهم:\n- حتماً از صحت اسناد اطمینان حاصل کنید\n- قیمت معامله را متناسب با نرخ بازار تعیین کنید\n- از خدمات مشاورین حقوقی استفاده کنید",
                    Author = "دفترخانه ۳۷۸",
                    ImageUrl = "https://images.unsplash.com/photo-1560518883-ce09059eeffa?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Category = "اسناد املاک",
                    Tags = "املاک، خرید، فروش، سند، دفترخانه",
                    IsPublished = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    PublishedAt = DateTime.Now.AddDays(-30),
                    ViewCount = 156,
                    MetaDescription = "راهنمای جامع خرید و فروش املاک، مراحل قانونی، مدارک لازم و نکات مهم معامله",
                    MetaKeywords = "خرید املاک، فروش املاک، دفترخانه، سند ملک",
                    Slug = "guide-real-estate-transaction"
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "انواع وکالتنامه و کاربرد آنها در امور حقوقی",
                    Summary = "شناخت انواع مختلف وکالتنامه، شرایط تنظیم، اعتبار زمانی و کاربردهای هر یک در امور مختلف حقوقی و اداری.",
                    Content = "وکالتنامه سندی است که به موجب آن شخصی (موکل) اختیار انجام کاری را به شخص دیگری (وکیل) می‌دهد. این سند در بسیاری از امور اداری و حقوقی کاربرد دارد.\n\nانواع وکالتنامه:\n\n1. وکالتنامه عمومی: شامل تمام اختیارات قانونی و اداری موکل\n2. وکالتنامه خاص: محدود به انجام کار یا اختیار خاص\n3. وکالتنامه بانکی: ویژه امور بانکی و مالی\n4. وکالتنامه املاک: مربوط به معاملات ملکی\n\nشرایط تنظیم:\n- حضور موکل در دفترخانه\n- ارائه مدارک شناسایی معتبر\n- تعیین دقیق حدود اختیارات وکیل\n- مشخص کردن مدت زمان اعتبار\n\nکاربردهای رایج:\n- انجام امور بانکی\n- فروش یا خرید ملک\n- دریافت مدارک اداری\n- حضور در ادارات دولتی\n\nنکات مهم:\n- وکالتنامه باید دقیق و شفاف نوشته شود\n- موکل می‌تواند در هر زمان وکالت را لغو کند\n- وکیل باید طبق حدود مندرج در وکالتنامه عمل کند",
                    Author = "دفترخانه ۳۷۸",
                    ImageUrl = "https://images.unsplash.com/photo-1521791055366-0d553872125f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Category = "اسناد حقوقی",
                    Tags = "وکالتنامه، حقوق، اسناد رسمی، اختیار",
                    IsPublished = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now.AddDays(-25),
                    PublishedAt = DateTime.Now.AddDays(-25),
                    ViewCount = 203,
                    MetaDescription = "راهنمای کامل انواع وکالتنامه، شرایط تنظیم و کاربردهای آنها در امور حقوقی",
                    MetaKeywords = "وکالتنامه، انواع وکالتنامه، اسناد رسمی، حقوق",
                    Slug = "types-of-power-of-attorney"
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "نکات مهم در تنظیم شروط ضمن عقد ازدواج",
                    Summary = "راهنمای تنظیم شروط ضمن عقد ازدواج، انواع شروط مجاز، اثرات حقوقی و اهمیت این شروط در حفظ حقوق زوجین.",
                    Content = "شروط ضمن عقد ازدواج یکی از مهم‌ترین ابزارهای حمایت از حقوق زوجین محسوب می‌شود. این شروط در زمان تنظیم عقد ازدواج اعمال شده و دارای اعتبار قانونی است.\n\nانواع شروط مجاز:\n\n1. شروط مالی:\n- تعیین میزان مهریه\n- نحوه تقسیم هزینه‌های زندگی\n- شرایط کار و فعالیت زن\n\n2. شروط اجتماعی:\n- تحصیل زن\n- حق انتخاب محل سکونت\n- حق سفر و مسافرت\n\n3. شروط خانوادگی:\n- تعداد فرزندان\n- نحوه تربیت فرزندان\n- روابط با خانواده‌ها\n\nشروط مهم و کاربردی:\n- حق طلاق برای زن در شرایط خاص\n- ممنوعیت ازدواج مجدد مرد بدون رضایت زن\n- تعیین میزان نفقه در صورت جدایی\n- حق تعیین محل سکونت\n\nنکات حقوقی:\n- شروط نباید مخالف شرع و قانون باشد\n- تمام شروط باید واضح و قابل اجرا نوشته شود\n- زوجین می‌توانند بعد از ازدواج شروط جدید اضافه کنند\n\nاهمیت شروط ضمن عقد:\n- حمایت از حقوق زن\n- جلوگیری از اختلافات آینده\n- ایجاد شفافیت در روابط زناشویی",
                    Author = "دفترخانه ۳۷۸",
                    ImageUrl = "https://images.unsplash.com/photo-1469371670807-013ccf25f16a?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Category = "ازدواج و طلاق",
                    Tags = "ازدواج، شروط ضمن عقد، حقوق زوجین، عقد نکاح",
                    IsPublished = true,
                    IsFeatured = false,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    PublishedAt = DateTime.Now.AddDays(-20),
                    ViewCount = 189,
                    MetaDescription = "راهنمای تنظیم شروط ضمن عقد ازدواج، انواع شروط مجاز و نکات حقوقی مهم",
                    MetaKeywords = "شروط ضمن عقد، ازدواج، عقد نکاح، حقوق زوجین",
                    Slug = "marriage-contract-conditions"
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "تعرفه خدمات دفترخانه در سال ۱۴۰۳",
                    Summary = "لیست کامل تعرفه‌های رسمی خدمات دفترخانه شامل تنظیم اسناد، گواهی امضا، وکالتنامه و سایر خدمات طبق مصوبات سال ۱۴۰۳.",
                    Content = "تعرفه خدمات دفترخانه طبق آخرین مصوبات سازمان ثبت اسناد و املاک کشور برای سال ۱۴۰۳ به شرح زیر است:\n\nخدمات اسناد رسمی:\n\n1. تنظیم سند رسمی:\n- سند بیع (خرید و فروش): ۳/۰ درصد ارزش معامله\n- سند هبه: ۲/۰ درصد ارزش ملک\n- سند اجاره: حداقل ۵۰۰,۰۰۰ ریال\n- سند رهن: ۱/۵ درصد ارزش رهن\n\n2. وکالتنامه:\n- وکالتنامه عمومی: ۱,۵۰۰,۰۰۰ ریال\n- وکالتنامه خاص: ۱,۰۰۰,۰۰۰ ریال\n- وکالتنامه بانکی: ۸۰۰,۰۰۰ ریال\n- وکالتنامه امور مالیاتی: ۶۰۰,۰۰۰ ریال\n\n3. گواهی امضا:\n- گواهی امضا عادی: ۳۰۰,۰۰۰ ریال\n- گواهی امضا بانکی: ۴۰۰,۰۰۰ ریال\n- گواهی امضا ویژه: ۵۰۰,۰۰۰ ریال\n\n4. اقرارنامه و تعهدنامه:\n- اقرارنامه عادی: ۷۰۰,۰۰۰ ریال\n- تعهدنامه: ۸۰۰,۰۰۰ ریال\n- رضایتنامه: ۶۰۰,۰۰۰ ریال\n\n5. عقد ازدواج:\n- تنظیم عقد ازدواج: ۱,۲۰۰,۰۰۰ ریال\n- شروط ضمن عقد: ۳۰۰,۰۰۰ ریال\n- طلاق توافقی: ۲,۰۰۰,۰۰۰ ریال\n\nهزینه‌های اضافی:\n- حق‌الثبت اسناد\n- عوارض شهرداری\n- مالیات بر ارزش افزوده\n\nنکته مهم: تمام مبالغ فوق طبق آخرین مصوبات رسمی بوده و ممکن است تغییر کند.",
                    Author = "دفترخانه ۳۷۸",
                    ImageUrl = "https://images.unsplash.com/photo-1554224155-6726b3ff858f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Category = "اطلاعات عمومی",
                    Tags = "تعرفه، هزینه، خدمات دفترخانه، ۱۴۰۳",
                    IsPublished = true,
                    IsFeatured = true,
                    CreatedAt = DateTime.Now.AddDays(-15),
                    PublishedAt = DateTime.Now.AddDays(-15),
                    ViewCount = 267,
                    MetaDescription = "لیست کامل تعرفه خدمات دفترخانه سال ۱۴۰۳ شامل اسناد، وکالتنامه و گواهی امضا",
                    MetaKeywords = "تعرفه دفترخانه، هزینه خدمات، ۱۴۰۳، اسناد رسمی",
                    Slug = "notary-office-fees-1403"
                }
            );

            // BlogPost configuration
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Summary).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Author).HasMaxLength(200);
                entity.Property(e => e.Category).HasMaxLength(100);
                entity.Property(e => e.Tags).HasMaxLength(500);
                entity.Property(e => e.MetaDescription).HasMaxLength(160);
                entity.Property(e => e.MetaKeywords).HasMaxLength(100);
                entity.Property(e => e.Slug).HasMaxLength(200);
                entity.HasIndex(e => e.Slug).IsUnique();
            });
        }
    }
} 