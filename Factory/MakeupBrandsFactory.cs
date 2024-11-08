using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Factory
{
    public class MakeupBrandsFactory
    {
        public static MakeupBrand Create(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand makeupBrand = new MakeupBrand();
            makeupBrand.MakeupBrandID = MakeupBrandID;
            makeupBrand.MakeupBrandName = MakeupBrandName;
            makeupBrand.MakeupBrandRating = MakeupBrandRating;
            return makeupBrand;
        }
    }
}