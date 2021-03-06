﻿using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class PageLabelManagement : BaseManagement<PageLabelDto, PageLabel, IPageLabelRepository>, IPageLabelManagement
    {
        #region Fields

        public virtual IPageRepository PageRepository { get; set; }

        #endregion

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false)
        {
            var ids = new List<long>{ pageID };
            if (includeGlobalLabels)
                ids.Add(ConstPage.Global);

            var labels = Repository.List(x => ids.Contains(x.Page.ID) && x.BranchID == (SmsCache.UserContext == null ? ConstConfig.NoBranchID : SmsCache.UserContext.CurrentBranchId)).ToList();

            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(labels));
        }

        public ServiceResult Save(List<PageLabelDto> pageLabels)
        {
            if (!pageLabels.Any())
                return ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));

            var pageID = pageLabels[0].Page.ID;
            var labelIds = pageLabels.ConvertAll(x => x.LabelID);

            var labels = Repository
                .List(x => x.Page.ID == pageID && labelIds.Contains(x.LabelID) && x.BranchID == SmsCache.UserContext.CurrentBranchId)
                .ToList();

            var pages = PageRepository.ListAll();

            pageLabels.ForEach(x =>
                                   {
                                       var oldLabel = labels.FirstOrDefault(y => y.LabelID == x.LabelID);
                                       if (oldLabel != null)
                                           x.ID = oldLabel.ID;

                                       var label = Mapper.Map<PageLabel>(x);
                                       label.BranchID = SmsCache.UserContext.CurrentBranchId;
                                       label.Page = pages.FirstOrDefault(p => p.ID == x.Page.ID);

                                       if(label.Page ==  null)
                                           return;
                                       Repository.Save(label);
                                   });

            return ServiceResult.CreateSuccessResult();
        }
    }
}