﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class InvoiceDetailManagement : BaseManagement<InvoiceDetailDto, InvoiceDetail, long, IInvoiceDetailRepository>, IInvoiceDetailManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }

        #endregion

        public InvoiceDetailDto AddProductToInvoiceTable(long invoiceTableID, long productID, decimal quantity)
        {
            var product = ProductRepository.Get(productID);
            if(product == null)
                return null;
            var invoiceDetail = new InvoiceDetail
                                    {
                                        InvoiceTable = new InvoiceTable {ID = invoiceTableID},
                                        Quantity = quantity,
                                        ProductCode = product.ProductCode,
                                        ProductVNName = product.VNName,
                                        ProductENName = product.ENName,
                                        Price = product.Price*quantity,
                                        UnitVNName = product.Unit.VNName,
                                        UnitENName = product.Unit.ENName
                                    };
            Repository.Add(invoiceDetail);
            return Mapper.Map<InvoiceDetailDto>(invoiceDetail);
        }

        public InvoiceDetailDto UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string value)
        {
            var invoiceDetail = Repository.Get(invoiceDetailID);
            switch (columnName)
            {
                case "qty":
                    invoiceDetail.Quantity = decimal.Parse(value);
                    break;
                case "cmt":
                    invoiceDetail.Comment = value;
                    break;
            };
            Repository.Update(invoiceDetail);
            return Mapper.Map<InvoiceDetailDto>(invoiceDetail);
        }
    }
}