using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Repository.POCO
{
    public class DBContext : IdentityDbContext<IdentityUser>
    {
        public DBContext() : base("GalleryDB", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DBInitializer());
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<GalleryType> GalleryTypes { get; set; }
    }

    public class DBInitializer : DropCreateDatabaseIfModelChanges<DBContext>
    //public class DBInitializer : DropCreateDatabaseAlways<DBContext>
    {

        protected override void Seed(DBContext db)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);


            var admin = new IdentityUser { UserName = "admin" };
            string password = "123123";

            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            db.GalleryTypes.Add(new GalleryType { GalleryID = 1, GalleryName = "картины" });
            db.GalleryTypes.Add(new GalleryType { GalleryID = 2, GalleryName = "пряники" });
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
