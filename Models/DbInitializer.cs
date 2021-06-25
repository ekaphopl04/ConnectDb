using System;

namespace DotnedataBase.Models{

    public static class DbInitializer
    {
        public static void Initialize(ReportContext db){
           // Console.WriteLine("Create DataBase");
            db.Database.EnsureCreated();

        }

    }

}
