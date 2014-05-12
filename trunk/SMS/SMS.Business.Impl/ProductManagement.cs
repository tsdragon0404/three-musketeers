﻿using System.Collections.Generic;
using System.Linq;
using Core.Common;
using SMS.Data;
using AutoMapper;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class ProductManagement : BaseManagement<ProductDto, Product, long, IProductRepository>, IProductManagement
    {
        #region Fields

        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }

        #endregion

        public IList<TProductDto> GetAll<TProductDto>()
        {
            return Mapper.Map<IList<TProductDto>>(Repository.GetAll().ToList());
        }

        public TProductDto GetByID<TProductDto>(long id)
        {
            return Mapper.Map<TProductDto>(Repository.Get(id));
        }

        public IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            var invoiceTable = InvoiceTableRepository.Get(invoiceTableID);
            var productCodes = invoiceTable.InvoiceDetails.Select(x => x.ProductCode).ToList();
            
            var products = Repository.Find(x => productCodes.Contains(x.ProductCode));
            var returnValue = Mapper.Map<IList<ProductBasicDto>>(products.ToList());

            returnValue.Apply(x => x.Quantity =
                invoiceTable.InvoiceDetails.FirstOrDefault(y => y.ProductCode == x.ProductCode) == null
                    ? 0
                    : invoiceTable.InvoiceDetails.First(y => y.ProductCode == x.ProductCode).Quantity);

            return returnValue;
        }
    }
}