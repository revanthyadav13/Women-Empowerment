using Microsoft.EntityFrameworkCore;


namespace Women_Empowerment.Models
{
    public class WomenEmpowerment : DbContext
    {

        public WomenEmpowerment(DbContextOptions<WomenEmpowerment> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<NGO> NGOs { get; set; }
        public DbSet<STEP> Trainees { get; set; }
    }

}
