﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class PageLabelManagement : BaseManagement<PageLabelDto, PageLabel, long, IPageLabelRepository>, IPageLabelManagement
    {
        #region Fields

        #endregion

        #region Func

        public override Func<PageLabel, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.BranchID == y;
            }
        }

        #endregion

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false)
        {
            var ids = new List<long>{ pageID };
            if (includeGlobalLabels)
                ids.Add(ConstPage.Global);

            var labels = Repository.Find(x => ids.Contains(x.Page.ID) && x.BranchID == SmsSystem.SelectedBranchID).ToList();

            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(labels));
        }

        public ServiceResult Save(long pageID, List<PageLabelDto> listLabels)
        {
            var labelIds = listLabels.ConvertAll(x => x.LabelID);
            var pageLabels = Repository.Find(
                x => x.Page.ID == pageID && labelIds.Contains(x.LabelID) && x.BranchID == SmsSystem.SelectedBranchID).ToList();

            if (pageLabels.Any())
            {
                foreach (var pageLabel in pageLabels)
                {
                    pageLabel.VNText = listLabels.First(x => x.LabelID == pageLabel.LabelID).VNText;
                    pageLabel.ENText = listLabels.First(x => x.LabelID == pageLabel.LabelID).ENText;

                    Repository.Update(pageLabel);
                    Repository.SaveAllChanges();
                }
            }

            var insertItems = labelIds.Except(pageLabels.Select(x => x.LabelID)).ToList();
            if (insertItems.Any())
            {
                foreach (var labelID in insertItems)
                {
                    Repository.Add(new PageLabel
                                       {
                                           BranchID = SmsSystem.SelectedBranchID,
                                           LabelID = labelID,
                                           Page = new Page {ID = pageID},
                                           VNText = listLabels.First(x => x.LabelID == labelID).VNText,
                                           ENText = listLabels.First(x => x.LabelID == labelID).ENText
                                       });
                    Repository.SaveAllChanges();
                }
            }

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult Copy(long fromBranchID, long toBranchID)
        {
            var pageLabels = Repository.GetAll(x => x.BranchID == fromBranchID);

            foreach (var pageLabel in pageLabels)
            {
                Repository.Add(new PageLabel
                               {
                                   BranchID = toBranchID,
                                   LabelID = pageLabel.LabelID,
                                   Page = pageLabel.Page,
                                   VNText = pageLabel.VNText,
                                   ENText = pageLabel.ENText
                               });
            }

            return ServiceResult.CreateSuccessResult();
        }
    }
}