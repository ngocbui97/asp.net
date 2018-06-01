using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace apiModel
{
   public class ApiDbcontext:DbContext
    {
        public ApiDbcontext():base("ApiConnection")
        {

        }
        static ApiDbcontext()
        {
            Database.SetInitializer<ApiDbcontext>(new IdentityDbInit());
        }

        public static ApiDbcontext create()
        {
            return new ApiDbcontext();
        }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }
        internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApiDbcontext>
        {
            public void Seed(ApiDbcontext context)
            {
                PerformInit();
                base.Seed(context);
            }

            public void PerformInit()
            {

            }
        }
        public DbSet<TTGV> TTGVs { get; set; }
        public DbSet<TTLOP> TTLOPs { get; set; }
        public DbSet<TTSV> TTSVs { get; set; }

       
        // code tiep phan controler
    }

}
