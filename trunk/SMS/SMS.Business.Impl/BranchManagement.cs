using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Common;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class BranchManagement : BaseManagement<BranchDto, Branch, IBranchRepository>, IBranchManagement
    {
        #region Fields

        public virtual IOrderRepository OrderRepository { get; set; }
        public virtual ICurrencyRepository CurrencyRepository { get; set; }
        public virtual ITaxRepository TaxRepository { get; set; }

        #endregion

        public override ServiceResult<BranchDto> Save(BranchDto dto)
        {
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
                Repository.Save(branchToSave);
            }
            else
            {
                branchToSave = Repository.GetByID(dto.ID);
                AssignBranchValues(dto, branchToSave);
                AssignBranchInfoValues(dto.BranchInfo, branchToSave.BranchInfo);
                Repository.Save(branchToSave);

                if (!branchToSave.UseKitchenFunction)
                {
                    var statuses = new List<OrderStatus> { OrderStatus.SentToKitchen, OrderStatus.Ordered, OrderStatus.KitchenAccepted };
                    Expression<Func<Order, bool>> predicate = x => x.OrderTables.Any(y => y.OrderDetails.Any(z => statuses.Contains(z.OrderStatus))) && x.Branch.ID == branchToSave.ID;

                    var ordersInKitchen = OrderRepository.List(predicate);
                    foreach (var order in ordersInKitchen)
                    {
                        order.OrderTables.Apply(x => x.OrderDetails.Apply(y => y.OrderStatus = OrderStatus.Done));
                        OrderRepository.Save(order);
                    }
                }
            }

            SmsCache.Reload(CacheKey.BranchConfig);

            return ServiceResult<BranchDto>.CreateSuccessResult(Mapper.Map<BranchDto>(branchToSave));
        }

        private void AssignBranchValues(BranchDto source, Branch destination)
        {
            destination.CreatedDate = source.CreatedDate;
            destination.CreatedUser = source.CreatedUser;
            destination.Currency = CurrencyRepository.GetByID(source.Currency.ID);
            destination.ENName = source.ENName;
            destination.Enable = source.Enable;
            destination.ModifiedDate = source.ModifiedDate;
            destination.ModifiedUser = source.ModifiedUser;
            destination.SEQ = source.SEQ;
            destination.ServiceFee = source.ServiceFee;
            destination.Taxs = Mapper.Map<IList<Tax>>(source.Taxs);
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