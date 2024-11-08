using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Factory
{
    public class MakeupsFactory
    {
        public static Makeup Create(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            Makeup makeup = new Makeup();
            makeup.MakeupID = MakeupID;
            makeup.MakeupName = MakeupName;
            makeup.MakeupPrice = MakeupPrice;
            makeup.MakeupWeight = MakeupWeight;
            makeup.MakeupTypeID = MakeupTypeID;
            makeup.MakeupBrandID = MakeupBrandID;

            return makeup;
        }
    }
}