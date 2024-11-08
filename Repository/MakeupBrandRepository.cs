using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class MakeupBrandRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<MakeupBrand> GetAllMakeupBrand()
        {
            return (from x in db.MakeupBrands select x).ToList();
        }

        public static List<MakeupBrand> GetAllMakeupBrandSortedByRating()
        {
            return (from x in db.MakeupBrands
                    orderby x.MakeupBrandRating descending
                    select x).ToList();
        }

        public static List<int> GetAllMakeupBrandID()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList();
        }

        public static MakeupBrand GetMakeupBrandByID(int id)
        {
            return (from x in db.MakeupBrands where x.MakeupBrandID == id select x).FirstOrDefault();
        }

        public static MakeupBrand GetLastMakeupBrand()
        {
            return db.MakeupBrands.ToList().LastOrDefault();
        }

        public static void DeleteMakeupBrandByID(int id)
        {
            MakeupBrand brand = GetMakeupBrandByID(id);
            db.MakeupBrands.Remove(brand);
            db.SaveChanges();
        }

        public static void AddMakeupBrand(int MakeupBrandID, string MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand brand = MakeupBrandsFactory.Create(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
            db.MakeupBrands.Add(brand);
            db.SaveChanges();
        }
        public static void UpdateMakeUpBrandByID(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand brand = GetMakeupBrandByID(MakeupBrandID);
            brand.MakeupBrandName = MakeupBrandName;
            brand.MakeupBrandRating = MakeupBrandRating;
            db.SaveChanges();

        }
    }
}
