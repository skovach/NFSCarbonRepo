using System;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NFSCarbonAppMvc4.Models
{
    public interface INFSCarbondb : IDisposable
    {
        IQueryable<T> Query<T>() where T: class; 
    }

    public class NFSCarbondb : DbContext, INFSCarbondb
    {
        public NFSCarbondb() : base("name=DefaultConnection")
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarReview> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        IQueryable<T> INFSCarbondb.Query<T>()
        {
            return Set<T>();
        }
    }
}