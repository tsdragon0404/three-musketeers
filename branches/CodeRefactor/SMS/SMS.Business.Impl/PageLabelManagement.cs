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
    public class PageLabelManagement : BaseManagement<PageLabelDto, PageLabel, IPageLabelRepository>, IPageLabelManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(long pageID, bool includeGlobalLabels = false)
        {
            var ids = new List<long>{ pageID };
            if (includeGlobalLabels)
                ids.Add(ConstPage.Global);

            var labels = Repository.List(x => ids.Contains(x.Page.ID) && x.BranchID == SmsSystem.SelectedBranchID).ToList();

            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(labels));
        }

        public ServiceResult Save(long pageID, List<PageLabelDto> pageLabels)
        {
            foreach (var pageLabel in pageLabels)
            {
                var entity = Mapper.Map<PageLabel>(pageLabel);
                entity.Page = new Page { ID = pageID };
                Repository.Save(entity);

                //or
                //Save(pageLabel) => test this.
            }

            //TODO: test new implementation to decide is it good to remove old code
            //var labelIds = listLabels.Select(x => x.LabelID);
            //var pageLabels = Repository.List(
            //    x => x.Page.ID == pageID && labelIds.Contains(x.LabelID) && x.BranchID == SmsSystem.SelectedBranchID).ToList();

            //if (pageLabels.Any())
            //{
            //    foreach (var pageLabel in pageLabels)
            //    {
            //        pageLabel.VNText = listLabels.First(x => x.LabelID == pageLabel.LabelID).VNText;
            //        pageLabel.ENText = listLabels.First(x => x.LabelID == pageLabel.LabelID).ENText;

            //        Repository.Update(pageLabel);
            //        Repository.SaveAllChanges();
            //    }
            //}

            //var insertItems = labelIds.Except(pageLabels.Select(x => x.LabelID)).ToList();
            //if (insertItems.Any())
            //{
            //    foreach (var labelID in insertItems)
            //    {
            //        Repository.Add(new PageLabel
            //                           {
            //                               BranchID = SmsSystem.SelectedBranchID,
            //                               LabelID = labelID,
            //                               Page = new Page {ID = pageID},
            //                               VNText = listLabels.First(x => x.LabelID == labelID).VNText,
            //                               ENText = listLabels.First(x => x.LabelID == labelID).ENText
            //                           });
            //        Repository.SaveAllChanges();
            //    }
            //}

            return ServiceResult.CreateSuccessResult();
        }
    }
}