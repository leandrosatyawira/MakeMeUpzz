using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class DatabaseSingleton
    {
        private static MakeMeUpzzEntities db = null;
        
        public static MakeMeUpzzEntities GetInstance()
        {
            if(db == null)
            {
                db = new MakeMeUpzzEntities();
            }
            return db;
        }
    }
}