using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MakeMeUpzz_UAS.Handler
{
    public class MakeupHandler
    {

        public static void DeleteMakeupByID(int id)
        {
            CartRepository.DeleteCartByMakeupID(id);
            TransactionDetailsRepository.DeleteTransactionDetailsByMakeupID(id);
            MakeupRepository.DeleteMakeupByID(id);
        }

        public static void DeleteMakeupTypeByID(int id)
        {
            List<int> MakeupIDs = MakeupRepository.GetMakeupIDByTypeID(id);
            foreach (int MakeupID in MakeupIDs)
            {
                DeleteMakeupByID (MakeupID);
            }
            MakeupTypeRepository.DeleteMakeupTypeByID(id);
        }

        public static void DeleteMakeupBrandByID(int id)
        {
            List<int> MakeupIDs = MakeupRepository.GetMakeupIDByBrandID(id);
            foreach (int MakeupID in MakeupIDs)
            {
                DeleteMakeupByID(MakeupID);
            }
            MakeupBrandRepository.DeleteMakeupBrandByID(id);
        }
        public static Response<List<Makeup>> GetAllMakeup()
        {
            return new Response<List<Makeup>>()
            {
                Success = true,
                Message = "succesfully get all makeups",
                Payload = MakeupRepository.GetAllMakeup()
            };
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrandSortedByRating()
        {
            return new Response<List<MakeupBrand>>()
            {
                Success = true,
                Payload = MakeupBrandRepository.GetAllMakeupBrandSortedByRating()
            };
        }

        public static Response<List<MakeupType>> GetAllMakeupType()
        {
            return new Response<List<MakeupType>>()
            {
                Success = true,
                Payload = MakeupTypeRepository.GetAllMakeupType()
            };
        }


        private static int MakeupGenerateID()
        {
            Makeup makeup = MakeupRepository.GetLastMakeup();
            if (makeup == null)
            {
                return 1;
            }
            else
            {
                int makeupID = makeup.MakeupID + 1;
                return makeupID;
            }
        }

        private static int MakeupBrandGenerateId()
        {
            MakeupBrand brand = MakeupBrandRepository.GetLastMakeupBrand();
            if (brand == null)
            {
                return 1;
            }
            else
            {
                int makeupID = brand.MakeupBrandID + 1;
                return makeupID;
            }
        }

        public static int MakeupTypeGenerateId()
        {
            MakeupType makeupType = MakeupTypeRepository.GetLastMakeupType();
            if (makeupType == null)
            {
                return 1;
            }
            else
            {
                int makeupTypeID = makeupType.MakeupTypeID + 1;
                return makeupTypeID;
            }
        }
        public static Response<Makeup> AddMakeup(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.AddMakeup(MakeupGenerateID(), MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
            return new Response<Makeup>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<Makeup> UpdateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.UpdateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
            return new Response<Makeup>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<MakeupBrand> AddMakeupBrand(String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.AddMakeupBrand(MakeupBrandGenerateId(), MakeupBrandName, MakeupBrandRating);
            return new Response<MakeupBrand>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<MakeupBrand> UpdateMakeUpBrandByID(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.UpdateMakeUpBrandByID(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
            return new Response<MakeupBrand>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<MakeupType> AddMakeUpType(String MakeupTypeName)
        {
            MakeupTypeRepository.AddMakeUpType(MakeupTypeGenerateId(), MakeupTypeName);
            return new Response<MakeupType>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<MakeupType> UpdateMakeupTypeByID(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository.UpdateMakeupTypeByID(MakeupTypeID, MakeupTypeName);
            return new Response<MakeupType>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<Makeup> GetMakeupByID(int MakeupID)
        {
            return new Response<Makeup>()
            {
                Success = true,
                Payload = MakeupRepository.GetMakeupByID(MakeupID)
            };
        }

        public static List<int> GetAllMakeupTypeID()
        {
            return MakeupTypeRepository.GetAllMakeupTypeID();
        }

        public static List<int> GetAllMakeupBrandID()
        {
            return MakeupBrandRepository.GetAllMakeupBrandID();
        }

        
    }
}