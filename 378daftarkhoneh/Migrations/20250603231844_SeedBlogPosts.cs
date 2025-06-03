using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _378daftarkhoneh.Migrations
{
    /// <inheritdoc />
    public partial class SeedBlogPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Category", "Content", "CreatedAt", "ImageUrl", "IsFeatured", "IsPublished", "MetaDescription", "MetaKeywords", "PublishedAt", "Slug", "Summary", "Tags", "Title", "UpdatedAt", "ViewCount" },
                values: new object[,]
                {
                    { 1, "دفترخانه ۳۷۸", "اسناد املاک", "خرید و فروش املاک یکی از مهم‌ترین تصمیمات مالی در زندگی هر فرد محسوب می‌شود. این فرآیند پیچیده نیازمند رعایت دقیق قوانین و مقررات است تا از حقوق طرفین معامله محافظت شود.\n\nمراحل اصلی معامله املاک:\n\n1. بررسی اسناد ملک: قبل از هر اقدامی، بررسی دقیق سند مالکیت، استعلام از ثبت اسناد و اطمینان از عدم وجود محدودیت قانونی ضروری است.\n\n2. تنظیم قرارداد: قرارداد باید شامل تمام جزئیات ملک، قیمت، شرایط پرداخت و تعهدات طرفین باشد.\n\n3. پرداخت و انتقال: انجام مراحل نقل و انتقال در دفترخانه با حضور طرفین و ارائه مدارک لازم.\n\nمدارک مورد نیاز:\n- اصل سند مالکیت\n- شناسنامه و کارت ملی طرفین\n- گواهی عدم محکومیت\n- نقشه UTM ملک\n- مفاصاحساب آب، برق و گاز\n\nنکات مهم:\n- حتماً از صحت اسناد اطمینان حاصل کنید\n- قیمت معامله را متناسب با نرخ بازار تعیین کنید\n- از خدمات مشاورین حقوقی استفاده کنید", new DateTime(2025, 5, 5, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9430), "https://images.unsplash.com/photo-1560518883-ce09059eeffa?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80", true, true, "راهنمای جامع خرید و فروش املاک، مراحل قانونی، مدارک لازم و نکات مهم معامله", "خرید املاک، فروش املاک، دفترخانه، سند ملک", new DateTime(2025, 5, 5, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9436), "guide-real-estate-transaction", "تمام مراحل قانونی خرید و فروش املاک از ابتدا تا انتها، مدارک مورد نیاز و نکات مهم برای طرفین معامله.", "املاک، خرید، فروش، سند، دفترخانه", "راهنمای کامل خرید و فروش املاک در دفترخانه", null, 156 },
                    { 2, "دفترخانه ۳۷۸", "اسناد حقوقی", "وکالتنامه سندی است که به موجب آن شخصی (موکل) اختیار انجام کاری را به شخص دیگری (وکیل) می‌دهد. این سند در بسیاری از امور اداری و حقوقی کاربرد دارد.\n\nانواع وکالتنامه:\n\n1. وکالتنامه عمومی: شامل تمام اختیارات قانونی و اداری موکل\n2. وکالتنامه خاص: محدود به انجام کار یا اختیار خاص\n3. وکالتنامه بانکی: ویژه امور بانکی و مالی\n4. وکالتنامه املاک: مربوط به معاملات ملکی\n\nشرایط تنظیم:\n- حضور موکل در دفترخانه\n- ارائه مدارک شناسایی معتبر\n- تعیین دقیق حدود اختیارات وکیل\n- مشخص کردن مدت زمان اعتبار\n\nکاربردهای رایج:\n- انجام امور بانکی\n- فروش یا خرید ملک\n- دریافت مدارک اداری\n- حضور در ادارات دولتی\n\nنکات مهم:\n- وکالتنامه باید دقیق و شفاف نوشته شود\n- موکل می‌تواند در هر زمان وکالت را لغو کند\n- وکیل باید طبق حدود مندرج در وکالتنامه عمل کند", new DateTime(2025, 5, 10, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9444), "https://images.unsplash.com/photo-1521791055366-0d553872125f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80", true, true, "راهنمای کامل انواع وکالتنامه، شرایط تنظیم و کاربردهای آنها در امور حقوقی", "وکالتنامه، انواع وکالتنامه، اسناد رسمی، حقوق", new DateTime(2025, 5, 10, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9445), "types-of-power-of-attorney", "شناخت انواع مختلف وکالتنامه، شرایط تنظیم، اعتبار زمانی و کاربردهای هر یک در امور مختلف حقوقی و اداری.", "وکالتنامه، حقوق، اسناد رسمی، اختیار", "انواع وکالتنامه و کاربرد آنها در امور حقوقی", null, 203 },
                    { 3, "دفترخانه ۳۷۸", "ازدواج و طلاق", "شروط ضمن عقد ازدواج یکی از مهم‌ترین ابزارهای حمایت از حقوق زوجین محسوب می‌شود. این شروط در زمان تنظیم عقد ازدواج اعمال شده و دارای اعتبار قانونی است.\n\nانواع شروط مجاز:\n\n1. شروط مالی:\n- تعیین میزان مهریه\n- نحوه تقسیم هزینه‌های زندگی\n- شرایط کار و فعالیت زن\n\n2. شروط اجتماعی:\n- تحصیل زن\n- حق انتخاب محل سکونت\n- حق سفر و مسافرت\n\n3. شروط خانوادگی:\n- تعداد فرزندان\n- نحوه تربیت فرزندان\n- روابط با خانواده‌ها\n\nشروط مهم و کاربردی:\n- حق طلاق برای زن در شرایط خاص\n- ممنوعیت ازدواج مجدد مرد بدون رضایت زن\n- تعیین میزان نفقه در صورت جدایی\n- حق تعیین محل سکونت\n\nنکات حقوقی:\n- شروط نباید مخالف شرع و قانون باشد\n- تمام شروط باید واضح و قابل اجرا نوشته شود\n- زوجین می‌توانند بعد از ازدواج شروط جدید اضافه کنند\n\nاهمیت شروط ضمن عقد:\n- حمایت از حقوق زن\n- جلوگیری از اختلافات آینده\n- ایجاد شفافیت در روابط زناشویی", new DateTime(2025, 5, 15, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9449), "https://images.unsplash.com/photo-1469371670807-013ccf25f16a?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80", false, true, "راهنمای تنظیم شروط ضمن عقد ازدواج، انواع شروط مجاز و نکات حقوقی مهم", "شروط ضمن عقد، ازدواج، عقد نکاح، حقوق زوجین", new DateTime(2025, 5, 15, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9449), "marriage-contract-conditions", "راهنمای تنظیم شروط ضمن عقد ازدواج، انواع شروط مجاز، اثرات حقوقی و اهمیت این شروط در حفظ حقوق زوجین.", "ازدواج، شروط ضمن عقد، حقوق زوجین، عقد نکاح", "نکات مهم در تنظیم شروط ضمن عقد ازدواج", null, 189 },
                    { 4, "دفترخانه ۳۷۸", "اطلاعات عمومی", "تعرفه خدمات دفترخانه طبق آخرین مصوبات سازمان ثبت اسناد و املاک کشور برای سال ۱۴۰۳ به شرح زیر است:\n\nخدمات اسناد رسمی:\n\n1. تنظیم سند رسمی:\n- سند بیع (خرید و فروش): ۳/۰ درصد ارزش معامله\n- سند هبه: ۲/۰ درصد ارزش ملک\n- سند اجاره: حداقل ۵۰۰,۰۰۰ ریال\n- سند رهن: ۱/۵ درصد ارزش رهن\n\n2. وکالتنامه:\n- وکالتنامه عمومی: ۱,۵۰۰,۰۰۰ ریال\n- وکالتنامه خاص: ۱,۰۰۰,۰۰۰ ریال\n- وکالتنامه بانکی: ۸۰۰,۰۰۰ ریال\n- وکالتنامه امور مالیاتی: ۶۰۰,۰۰۰ ریال\n\n3. گواهی امضا:\n- گواهی امضا عادی: ۳۰۰,۰۰۰ ریال\n- گواهی امضا بانکی: ۴۰۰,۰۰۰ ریال\n- گواهی امضا ویژه: ۵۰۰,۰۰۰ ریال\n\n4. اقرارنامه و تعهدنامه:\n- اقرارنامه عادی: ۷۰۰,۰۰۰ ریال\n- تعهدنامه: ۸۰۰,۰۰۰ ریال\n- رضایتنامه: ۶۰۰,۰۰۰ ریال\n\n5. عقد ازدواج:\n- تنظیم عقد ازدواج: ۱,۲۰۰,۰۰۰ ریال\n- شروط ضمن عقد: ۳۰۰,۰۰۰ ریال\n- طلاق توافقی: ۲,۰۰۰,۰۰۰ ریال\n\nهزینه‌های اضافی:\n- حق‌الثبت اسناد\n- عوارض شهرداری\n- مالیات بر ارزش افزوده\n\nنکته مهم: تمام مبالغ فوق طبق آخرین مصوبات رسمی بوده و ممکن است تغییر کند.", new DateTime(2025, 5, 20, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9453), "https://images.unsplash.com/photo-1554224155-6726b3ff858f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80", true, true, "لیست کامل تعرفه خدمات دفترخانه سال ۱۴۰۳ شامل اسناد، وکالتنامه و گواهی امضا", "تعرفه دفترخانه، هزینه خدمات، ۱۴۰۳، اسناد رسمی", new DateTime(2025, 5, 20, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9454), "notary-office-fees-1403", "لیست کامل تعرفه‌های رسمی خدمات دفترخانه شامل تنظیم اسناد، گواهی امضا، وکالتنامه و سایر خدمات طبق مصوبات سال ۱۴۰۳.", "تعرفه، هزینه، خدمات دفترخانه، ۱۴۰۳", "تعرفه خدمات دفترخانه در سال ۱۴۰۳", null, 267 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(8893));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 2, 57, 827, DateTimeKind.Local).AddTicks(360));
        }
    }
}
