using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class MakeupTypeRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();
        public static List<MakeupType> GetAllMakeupType()
        {
            return (from x in db.MakeupTypes select x).ToList();
        }

        public static List<int> GetAllMakeupTypeID()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList();
        }

        public static MakeupType GetLastMakeupType()
        {
            return db.MakeupTypes.ToList().LastOrDefault();
        }

        public static MakeupType GetMakeupTypeByID(int id)
        {
            return (from x in db.MakeupTypes where x.MakeupTypeID == id select x).FirstOrDefault();
        }

        public static void AddMakeUpType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = MakeupTypesFactory.Create(MakeupTypeID, MakeupTypeName);
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }
        public static void DeleteMakeupTypeByID(int id)
        {
            MakeupType type = GetMakeupTypeByID(id);
            db.MakeupTypes.Remove(type);
            db.SaveChanges();
        }

        public static void UpdateMakeupTypeByID(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType type = GetMakeupTypeByID(MakeupTypeID);
            type.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }
    }
}