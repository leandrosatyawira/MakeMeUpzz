using MakeMeUpzz_UAS.Handler;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Controller
{
    public class MakeupController
    {
        public static Response<List<Makeup>> GetAllMakeup()
        {
            return MakeupHandler.GetAllMakeup();
        }

        public static Response<Makeup> GetMakeupByID(int MakeupID)
        {
            return MakeupHandler.GetMakeupByID(MakeupID);
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrandSortedByRating()
        {
            return MakeupHandler.GetAllMakeupBrandSortedByRating();
        }

        public static Response<List<MakeupType>> GetAllMakeupType()
        {
            return MakeupHandler.GetAllMakeupType();
        }

        public static void DeleteMakeupByID(int id)
        {
            MakeupHandler.DeleteMakeupByID(id);
        }

        public static void DeleteMakeupTypeByID(int id)
        {
            
            MakeupHandler.DeleteMakeupTypeByID(id);
        }

        public static void DeleteMakeupBrandByID(int id)
        {

            MakeupHandler.DeleteMakeupBrandByID(id);
        }

        public static Response<Makeup> AddMakeup(String MakeupName, String priceTB, String weightTB, String selectedType, String selectedBrand)
        {
            if (MakeupName == "" || priceTB == "" || weightTB == "" || selectedType == "" || selectedBrand == "")
            {
                return new Response<Makeup>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {
                int MakeupPrice = Convert.ToInt32(priceTB);
                int MakeupWeight = Convert.ToInt32(weightTB);
                int MakeupTypeID = Convert.ToInt32(selectedType);
                int MakeupBrandID = Convert.ToInt32(selectedBrand);

                if (MakeupName.Length < 1 || MakeupName.Length > 99)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Makeup Name Length must be between 1-99",
                        Payload = null
                    };
                }
                else if (MakeupWeight > 1500)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Weight cannot be greater than 1500 since it is in grams",
                        Payload = null
                    };
                }
                else if (MakeupPrice < 1)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Price must be greater than or equal to 1",
                        Payload = null
                    };
                }
                return MakeupHandler.AddMakeup(MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
            }
        }

        public static Response<Makeup> UpdateMakeup(int MakeupID, String MakeupName, String priceTB, String weightTB, String selectedType, String selectedBrand)
        {
            if (MakeupName == "" || priceTB == "" || weightTB == "" || selectedType == "" || selectedBrand == "")
            {
                return new Response<Makeup>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {
                int MakeupPrice = Convert.ToInt32(priceTB);
                int MakeupWeight = Convert.ToInt32(weightTB);
                int MakeupTypeID = Convert.ToInt32(selectedType);
                int MakeupBrandID = Convert.ToInt32(selectedBrand);

                if (MakeupName.Length < 1 || MakeupName.Length > 99)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Makeup Name Length must be between 1-99",
                        Payload = null
                    };
                }
                else if (MakeupWeight > 1500)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Weight cannot be greater than 1500 since it is in grams",
                        Payload = null
                    };
                }
                else if (MakeupPrice < 1)
                {
                    return new Response<Makeup>()
                    {
                        Success = false,
                        Message = "Price must be greater than or equal to 1",
                        Payload = null
                    };
                }
                return MakeupHandler.UpdateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
            }
        }

        public static Response<MakeupBrand> AddMakeupBrand(String MakeupBrandName, String ratingTb)
        {
            if (MakeupBrandName == "" || ratingTb == "")
            {
                return new Response<MakeupBrand>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {
                int MakeupBrandRating = Convert.ToInt32(ratingTb);
                if (MakeupBrandName.Length < 1 || MakeupBrandName.Length > 99)
                {
                    return new Response<MakeupBrand>()
                    {
                        Success = false,
                        Message = "Brand Name must be Between 1 - 99 Characters",
                        Payload = null
                    };
                }
                else if (MakeupBrandRating < 0 || MakeupBrandRating > 100)
                {
                    return new Response<MakeupBrand>()
                    {
                        Success = false,
                        Message = "Rating must be between 0 - 100",
                        Payload = null
                    };
                }
                return MakeupHandler.AddMakeupBrand(MakeupBrandName, MakeupBrandRating);
            }
        }

        public static Response<MakeupBrand> UpdateMakeUpBrandByID(int MakeupBrandID, String MakeupBrandName, String ratingTb)
        {
            if (MakeupBrandName == "" || ratingTb == "")
            {
                return new Response<MakeupBrand>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {
                int MakeupBrandRating = Convert.ToInt32(ratingTb);
                if (MakeupBrandName.Length < 1 || MakeupBrandName.Length > 99)
                {
                    return new Response<MakeupBrand>()
                    {
                        Success = false,
                        Message = "Brand Name must be Between 1 - 99 Characters",
                        Payload = null
                    };
                }
                else if (MakeupBrandRating < 0 || MakeupBrandRating > 100)
                {
                    return new Response<MakeupBrand>()
                    {
                        Success = false,
                        Message = "Rating must be between 0 - 100",
                        Payload = null
                    };
                }
                return MakeupHandler.UpdateMakeUpBrandByID(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
            }
        }

        public static Response<MakeupType> AddMakeupType(String MakeupTypeName)
        {
            if (MakeupTypeName == "")
            {
                return new Response<MakeupType>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {

                if (MakeupTypeName.Length < 1 || MakeupTypeName.Length > 99)
                {
                    return new Response<MakeupType>()
                    {
                        Success = false,
                        Message = "Name length must be between 1-99",
                        Payload = null
                    };
                }
                return MakeupHandler.AddMakeUpType(MakeupTypeName);
            }
        }

        public static Response<MakeupType> UpdateMakeupTypeByID(int MakeupTypeID, String MakeupTypeName)
        {
            if (MakeupTypeName == "")
            {
                return new Response<MakeupType>()
                {
                    Success = false,
                    Message = "All fields must be filled",
                    Payload = null
                };
            }
            else
            {

                if (MakeupTypeName.Length < 1 || MakeupTypeName.Length > 99)
                {
                    return new Response<MakeupType>()
                    {
                        Success = false,
                        Message = "Name length must be between 1-99",
                        Payload = null
                    };
                }
                return MakeupHandler.UpdateMakeupTypeByID(MakeupTypeID, MakeupTypeName);
            }
        }

        public static List<int> GetAllMakeupTypeID()
        {
            return MakeupHandler.GetAllMakeupTypeID();
        }

        public static List<int> GetAllMakeupBrandID()
        {
            return MakeupHandler.GetAllMakeupBrandID();
        }
    }
}