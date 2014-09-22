using System.Collections.Generic;
using System.Linq;
using SMS.Common;
using SMS.Common.Storage;
using SMS.Common.Storage.BranchConfig;
using SMS.Common.Storage.Branding;
using SMS.Common.Storage.Message;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public class Utility
    {
        public static void SetStorageData()
        {
            #region Branch configs

            var branchService = ServiceLocator.Resolve<IBranchService>();
            var configData = branchService.GetAll().Data.ToDictionary(x => x.ID,
                                                                    y => new BranchConfig
                                                                    {
                                                                        Currency = y.Currency.Name,
                                                                        ServiceFee = y.ServiceFee,
                                                                        UseServiceFee = y.UseServiceFee,
                                                                        UseKitchenFunction = y.UseKitchenFunction,
                                                                        UseDiscountOnProduct = y.UseDiscountOnProduct,
                                                                        Taxs = y.Taxs != null 
                                                                               ? y.Taxs.ToDictionary(tax => tax.Tax.Name, tax => tax.Tax.Value)
                                                                               : new Dictionary<string, decimal>()
                                                                    });
            
            #endregion

            #region Error messages

            var errorMessageService = ServiceLocator.Resolve<IErrorMessageService>();
            var messages = errorMessageService.GetAll().Data;
            var messageData = new Dictionary<long, IList<Message>>();
            foreach (var message in messages)
            {
                if (!messageData.ContainsKey(message.BranchID))
                    messageData.Add(message.BranchID, new List<Message>());

                messageData[message.BranchID].Add(new Message(message.MessageID, message.VNMessage, message.ENMessage));
            }

            #endregion

            #region Branding texts

            var brandingTextService = ServiceLocator.Resolve<IBrandingTextService>();
            var brandingTexts = brandingTextService.GetAll().Data;
            var brandingData = new Dictionary<long, IList<BrandingItem>>();
            foreach (var brand in brandingTexts)
            {
                if (!brandingData.ContainsKey(brand.BranchID))
                    brandingData.Add(brand.BranchID, new List<BrandingItem>());

                brandingData[brand.BranchID].Add(new BrandingItem(brand.Key, brand.ENValue, brand.VNValue));
            }

            #endregion

            #region System informations

            var systemInformationService = ServiceLocator.Resolve<ISystemInfomationService>();
            var systemData = systemInformationService.GetAll().Data.ToDictionary(x => x.Name, y => y.Value);

            #endregion

            StorageHelper.SetStorageData(configData, messageData, brandingData, systemData);
        }
    }
}