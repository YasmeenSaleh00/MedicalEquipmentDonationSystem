using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.EntityConfiguration;
using MedicalEquipmentDonationSystem.Helper;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Context
{
    public class MEDSDbContext:DbContext
    {


        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }   
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TransactionOrder> Transactions { get; set; }   
        public DbSet<Testimonial> Testimonials { get; set; }
   
        public MEDSDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //pre data
            modelBuilder.Entity<LookupType>().HasData(
           new LookupType { Id = 1, Name = "Nationality", NameAr = "الجنسية" },
           new LookupType { Id = 2, Name = "Gender", NameAr = "الجنس" },
           new LookupType { Id = 3, Name = "StatusProduct", NameAr = "حالة المنتج" },
           new LookupType { Id = 4, Name = "TestimonialTypeId", NameAr = "نوع الشهادة" },
           new LookupType { Id = 5, Name = "StatusOrder", NameAr = "حالة الطلب" },
           new LookupType { Id = 6, Name = "Role", NameAr = " نوع المستخدم" } );

            modelBuilder.Entity<LookupItem>().HasData(
           new LookupItem { Id = 1, LookupTypeId = 1, Value = "Jordanian", ValueAr = "اردني" },
           new LookupItem { Id = 2, LookupTypeId = 1, Value = "Egyptian", ValueAr = "مصري" },
           new LookupItem { Id = 3, LookupTypeId = 1, Value = "Palestinian", ValueAr = "فلسطيني" },
           new LookupItem { Id = 4, LookupTypeId = 1, Value = "Saudi", ValueAr = "سعودي" },
           new LookupItem { Id = 5, LookupTypeId = 2, Value = "Male", ValueAr = "ذكر" },
           new LookupItem { Id = 6, LookupTypeId = 2, Value = "Female", ValueAr = "أنثى" },
           new LookupItem { Id = 7, LookupTypeId = 2, Value = "Other", ValueAr = "آخر" },
           new LookupItem { Id = 8, LookupTypeId = 3, Value = "Available", ValueAr = "متاح" },
           new LookupItem { Id = 9, LookupTypeId = 3, Value = "Not Available", ValueAr = "غير متاح" },
           new LookupItem { Id = 10, LookupTypeId = 3, Value = "Under Maintenance", ValueAr = "قيد الصيانة" },
           new LookupItem { Id = 11, LookupTypeId = 4, Value = "User Experience", ValueAr = "تجربة المستخدم" },
           new LookupItem { Id = 12, LookupTypeId = 4, Value = "Product Feedback", ValueAr = "ملاحظات المنتج" },
           new LookupItem { Id = 13, LookupTypeId = 5, Value = "Pending", ValueAr = "معلق" },
           new LookupItem { Id = 14, LookupTypeId = 5, Value = "Accepted", ValueAr = "مقبول" },
           new LookupItem { Id = 15, LookupTypeId = 5, Value = "Rejected", ValueAr = "مرفوض" },
           new LookupItem { Id = 16, LookupTypeId = 6, Value = "User", ValueAr = "مستخدم" },
           new LookupItem { Id = 17, LookupTypeId = 6, Value = "Admin", ValueAr = "مسؤول" },
           new LookupItem { Id =18, LookupTypeId =4,Value= "Donor Recognition",ValueAr= "تقدير المتبرعين" }
           );

            modelBuilder.Entity<Users>().HasData(
            new Users {Id=1,
                FirstName ="Yasmeen",
                LastName ="Saleh",
                Email=EncryptionHelper.GenerateSHA384String("yasmeensaleh147@gmail.com"),
                Password = EncryptionHelper.GenerateSHA384String("yas123@t"),
                Phone="0788205614",
                BirthDate = DateOnly.Parse("2000-03-06"),
                NationalityId = 1,
                GenderId =6,
                Adress="Jordan - Amman",
                UserTypeId =17
            });
            

            

            modelBuilder.ApplyConfiguration(new LookupTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TestimonialEntityConfiguration());  
            modelBuilder.ApplyConfiguration(new OrderEntityConfigration());
            modelBuilder.ApplyConfiguration(new TransactionEntityConfigration());
        }

    }
}
