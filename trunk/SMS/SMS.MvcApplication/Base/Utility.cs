using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Common;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage;
using SMS.Common.Storage.CacheObjects;
using SMS.Data.Dtos;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public class Utility
    {
        public static void SetStorageData()
        {
            #region Branch configs

            var branchService = ServiceLocator.Resolve<IBranchService>();
            var configData = branchService.ListAll().Data.ToDictionary(x => x.ID,
                                                                    y => new BranchConfig
                                                                    {
                                                                        Currency = y.Currency.Name,
                                                                        ServiceFee = y.ServiceFee,
                                                                        UseServiceFee = y.UseServiceFee,
                                                                        UseKitchenFunction = y.UseKitchenFunction,
                                                                        UseDiscountOnProduct = y.UseDiscountOnProduct,
                                                                        Taxs = y.Taxs != null 
                                                                               ? y.Taxs.ToDictionary(tax => tax.Name, tax => tax.Value)
                                                                               : new Dictionary<string, decimal>()
                                                                    });
            
            #endregion

            #region Error messages

            var errorMessageService = ServiceLocator.Resolve<IErrorMessageService>();
            var messages = errorMessageService.ListAll().Data;
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
            var brandingTexts = brandingTextService.ListAll().Data;
            var brandingData = new Dictionary<long, IList<BrandingItem>>();
            foreach (var brand in brandingTexts)
            {
                if (!brandingData.ContainsKey(brand.BranchID))
                    brandingData.Add(brand.BranchID, new List<BrandingItem>());

                brandingData[brand.BranchID].Add(new BrandingItem(brand.Key, brand.ENValue, brand.VNValue));
            }

            #endregion

            #region System informations

            var systemInformationService = ServiceLocator.Resolve<ISystemInformationService>();
            var systemData = systemInformationService.GetByType(SystemInformationType.Config).Data.ToDictionary(x => x.Name, y => y.Value);

            #endregion

            StorageHelper.SetStorageData(configData, messageData, brandingData, systemData);
        }

        public static long UploadFile(HttpPostedFileBase uploadedFile, UploadedFileCategory category)
        {
            var result = FileHelper.Upload(uploadedFile, category);
            if (!result.Success)
                return 0;

            var uploadedFileService = ServiceLocator.Resolve<IUploadedFileService>();
            var existingFile = uploadedFileService.GetByPhysicalPath(result.ActualPath);

            var dtoToSave = new UploadedFileDto
                                {
                                    PhysicalPath = result.ActualPath,
                                    Category = category,
                                    UploadedBy = SmsSystem.UserContext.UserName,
                                    UploadedDateTime = DateTime.Now
                                };

            if(existingFile.Success && existingFile.Data != null)
                dtoToSave.UploadedFileID = existingFile.Data.UploadedFileID;

            var saveResult = uploadedFileService.Save(dtoToSave);

            if (!saveResult.Success || saveResult.Data == null)
                return 0;

            return saveResult.Data.UploadedFileID;
        }

        public static string GetCurrentUserProfileImage()
        {
            var imageData = FileHelper.GetProfileImageAsStream(SmsSystem.UserContext.UserID);
            if (imageData == null) return string.Empty;
            return Convert.ToBase64String(imageData);
        }
    }
}