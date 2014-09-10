using System.Collections.Generic;
using System.Linq;
using SMS.Common;
using SMS.Common.Session;
using SMS.Common.Storage;
using SMS.Common.Storage.Branding;
using SMS.Common.Storage.Message;
using SMS.Data.Dtos;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public class Utility
    {
        public static void SetStorageData()
        {
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

            StorageHelper.SetStorageData(messageData, brandingData);

            var branchService = ServiceLocator.Resolve<IBranchService>();
            var branches = branchService.GetAll();
            SetBranchConfigs(branches.Data);
        }

        private static void SetBranchConfigs(IEnumerable<BranchDto> branches)
        {
            foreach (var branch in branches)
            {
                SmsSystem.SetBranchConfig(branch.ID, new BranchConfig
                {
                    Currency = branch.Currency.Name,
                    ServiceFee = branch.ServiceFee,
                    UseServiceFee = branch.UseServiceFee,
                    UseKitchenFunction = branch.UseKitchenFunction,
                    UseDiscountOnProduct = branch.UseDiscountOnProduct,
                    Taxs = branch.Taxs != null
                           ? branch.Taxs.ToDictionary(tax => tax.Tax.Name, tax => tax.Tax.Value)
                           : new Dictionary<string, decimal>()
                });
            }
        }
    }
}