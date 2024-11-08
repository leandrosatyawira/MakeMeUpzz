using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class MakeupRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<Makeup> GetAllMakeup()
        {
            return (from x in db.Makeups select x).ToList();
        }


        public static Makeup GetMakeupByID(int id)
        {
            return (from x in db.Makeups where x.MakeupID == id select x).FirstOrDefault();
        }

        public static Makeup GetLastMakeup()
        {
            return db.Makeups.ToList().LastOrDefault();
        }
        public static void DeleteMakeupByID(int id)
        {
            Makeup makeup = GetMakeupByID(id);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }


        public static void AddMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            Makeup makeup = MakeupsFactory.Create(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public static void UpdateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updatemakeup = GetMakeupByID(MakeupID);
            updatemakeup.MakeupName = MakeupName;
            updatemakeup.MakeupPrice = MakeupPrice;
            updatemakeup.MakeupWeight = MakeupWeight;
            updatemakeup.MakeupTypeID = MakeupTypeID;
            updatemakeup.MakeupBrandID = MakeupBrandID;
            db.SaveChanges();
        }

        public static List<int> GetMakeupIDByTypeID(int MakeupTypeID)
        {
            return (from x in db.Makeups where x.MakeupTypeID == MakeupTypeID select x.MakeupID).ToList();
        }

        public static List<int> GetMakeupIDByBrandID(int MakeupBrandID)
        {
            return (from x in db.Makeups where x.MakeupBrandID == MakeupBrandID select x.MakeupID).ToList();
        }

        /*
        public static void DeleteMakeupByTypeID(int MakeupTypeID)
        {
            List<Makeup> DeleteMakeup = GetMakeupByTypeID(MakeupTypeID);
            if(DeleteMakeup == null)
            {
                return;
            }
            foreach(Makeup makeup in DeleteMakeup)
            {
                db.Makeups.Remove(makeup);
            }
            db.SaveChanges();
        }

        public static void DeleteMakeupByBrandID(int MakeupBrandID)
        {
            List<Makeup> DeleteMakeup = GetMakeupByBrandID(MakeupBrandID);
            if (DeleteMakeup == null)
            {
                return;
            }
            foreach (Makeup makeup in DeleteMakeup)
            {
                db.Makeups.Remove(makeup);
            }
            db.SaveChanges();
        }
         */

    }
}