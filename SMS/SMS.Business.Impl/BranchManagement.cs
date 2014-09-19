using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Common.Storage.BranchConfig;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class BranchManagement : BaseManagement<BranchDto, Branch, long, IBranchRepository>, IBranchManagement
    {
        #region Fields

        public virtual IOrderDetailRepository OrderDetailRepository { get; set; }
        public virtual ICurrencyRepository CurrencyRepository { get; set; }

        #endregion

        #region Func

        public override Func<Branch, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.ID == y;
            }
        }

        #endregion

        public ServiceResult<IList<TModel>> GetUserAssignedBranches<TModel>(long userID)
        {
            if(userID == 0)
                return ServiceResult<IList<TModel>>.CreateSuccessResult(new List<TModel>());

            var result = Repository.Find(x => (x.Users.Select(y => y.ID).Contains(userID) && x.Enable)).ToList();
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public override ServiceResult<BranchDto> Save(BranchDto dto)
        {
            var result = new ServiceResult<BranchDto>();
            Branch branchToSave;

            if(dto.ID == 0)
            {
                branchToSave = new Branch();
                AssignBranchValues(dto, branchToSave);
                branchToSave.BranchInfo = new BranchInfo
                                              {
                                                  Branch = branchToSave
                                              };
                AssignBranchInfoValues(dto.BranchInfo, branchToSave.BranchInfo);
                Repository.Add(branchToSave);
            }
            else
            {
                branchToSave = Repository.Get(dto.ID);
                AssignBranchValues(dto, branchToSave);
                AssignBranchInfoValues(dto.BranchInfo, branchToSave.BranchInfo);
                Repository.Update(branchToSave);

                if (!branchToSave.UseKitchenFunction)
                {
                    var ordersInKitchen = OrderDetailRepository.Find(x => (x.OrderStatus == OrderStatus.SentToKitchen || x.OrderStatus == OrderStatus.Ordered || x.OrderStatus == OrderStatus.KitchenAccepted) 
                                                                        && x.OrderTable.Order.Branch.ID == branchToSave.ID);
                    foreach (var order in ordersInKitchen)
                    {
                        order.OrderStatus = OrderStatus.Done;
                        OrderDetailRepository.Update(order);
                    }
                }
            }

            StorageHelper.UpdateBranchConfig(branchToSave.ID, new BranchConfig
                                                                  {
                                                                      Currency = branchToSave.Currency.Name,
                                                                      ServiceFee = branchToSave.ServiceFee,
                                                                      UseServiceFee = branchToSave.UseServiceFee,
                                                                      UseKitchenFunction = branchToSave.UseKitchenFunction,
                                                                      UseDiscountOnProduct = branchToSave.UseDiscountOnProduct,
                                                                      Taxs = branchToSave.Taxs != null
                                                                             ? branchToSave.Taxs.ToDictionary(tax => tax.Tax.Name, tax => tax.Tax.Value)
                                                                             : new Dictionary<string, decimal>()
                                                                  });

            result.Data = Mapper.Map<BranchDto>(branchToSave);
            return result;
        }

        private void AssignBranchValues(BranchDto source, Branch destination)
        {
            destination.CreatedDate = source.CreatedDate;
            destination.CreatedUser = source.CreatedUser;
            destination.Currency = CurrencyRepository.Get(source.Currency.ID);
            destination.ENName = source.ENName;
            destination.Enable = source.Enable;
            destination.ModifiedDate = source.ModifiedDate;
            destination.ModifiedUser = source.ModifiedUser;
            destination.SEQ = source.SEQ;
            destination.ServiceFee = source.ServiceFee;
            destination.Taxs = Mapper.Map<IList<BranchTax>>(source.Taxs);
            destination.UseDiscountOnProduct = source.UseDiscountOnProduct;
            destination.UseKitchenFunction = source.UseKitchenFunction;
            destination.UseServiceFee = source.UseServiceFee;
            destination.Users = Mapper.Map<IList<User>>(source.Users);
            destination.VNName = source.VNName;
        }

        private void AssignBranchInfoValues(BranchInfoDto source, BranchInfo destination)
        {
            destination.Address = source.Address;
            destination.CompanyCode = source.CompanyCode;
            destination.CompanyName = source.CompanyName;
            destination.Email = source.Email;
            destination.Fax = source.Fax;
            destination.Info1 = source.Info1;
            destination.Info2 = source.Info2;
            destination.Info3 = source.Info3;
            destination.Info4 = source.Info4;
            destination.Info5 = source.Info5;
            destination.Info6 = source.Info6;
            destination.Info7 = source.Info7;
            destination.Info8 = source.Info8;
            destination.Info9 = source.Info9;
            destination.Info10 = source.Info10;
            destination.Phone = source.Phone;
            destination.TaxCode = source.TaxCode;
        }
    }
}