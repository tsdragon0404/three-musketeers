using System.Collections.Generic;
using System.Linq;
using SMS.Services;
using SMS.Common;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Common.Storage.CacheObjects;

namespace SMS.MvcApplication
{
    public static class CacheConfig
    {
        public static void Configure()
        {
            ServerCache.Add(CacheKey.UserAccess, () => new UserDataCollection());
            ServerCache.Add(CacheKey.BranchConfig, BranchConfigCallback);
            ServerCache.Add(CacheKey.Message, MessageCallback);
            ServerCache.Add(CacheKey.Branding, BrandingCallback);
            ServerCache.Add(CacheKey.SystemInformation, SystemInformationCallback);
        }

        private static BranchConfigCollection BranchConfigCallback()
        {
            var result = new BranchConfigCollection();
            var branchData = ServiceLocator.Resolve<IBranchService>().ListAll().Data;
            result.AddRange(branchData.Select(branchDto => new BranchConfig
                                                               {
                                                                   BranchID = branchDto.ID,
                                                                   Currency = branchDto.Currency.Name, 
                                                                   ServiceFee = branchDto.ServiceFee, 
                                                                   UseServiceFee = branchDto.UseServiceFee, 
                                                                   UseKitchenFunction = branchDto.UseKitchenFunction, 
                                                                   UseDiscountOnProduct = branchDto.UseDiscountOnProduct, 
                                                                   Taxs = branchDto.Taxs.ToDictionary(tax => tax.Name, tax => tax.Value),
                                                               }));

            return result;
        }

        private static MessageDictionary MessageCallback()
        {
            var result = new MessageDictionary();
            var messageData = ServiceLocator.Resolve<IErrorMessageService>().ListAll().Data;
            foreach (var message in messageData)
            {
                if (!result.ContainsKey(message.BranchID))
                    result.Add(message.BranchID, new List<Message>());

                result[message.BranchID].Add(new Message(message.MessageID, message.VNMessage, message.ENMessage));
            }

            return result;
        }

        private static BrandingDictionary BrandingCallback()
        {
            var result = new BrandingDictionary();
            var brandingData = ServiceLocator.Resolve<IBrandingTextService>().ListAll().Data;
            foreach (var brand in brandingData)
            {
                if (!result.ContainsKey(brand.BranchID))
                    result.Add(brand.BranchID, new List<BrandingItem>());

                result[brand.BranchID].Add(new BrandingItem(brand.Key, brand.ENValue, brand.VNValue));
            }

            return result;
        }

        private static Dictionary<string, string> SystemInformationCallback()
        {
            var systemData = ServiceLocator.Resolve<ISystemInformationService>().GetByType(SystemInformationType.Config).Data;
            return systemData.ToDictionary(x => x.Name, y => y.Value);
        }
    }
}