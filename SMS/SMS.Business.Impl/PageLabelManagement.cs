using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
using Core.Common.Validation;
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

        public ServiceResult<IList<TDto>> GetByPageID<TDto>(int pageID)
        {
            return new ServiceResult<IList<TDto>> { Data = Mapper.Map<IList<TDto>>(Repository.Find(x => x.Page.ID == pageID).ToList()) };
        }

        public ServiceResult Save(int pageID, List<PageLabelDto> listLabels)
        {
            var labelIds = listLabels.ConvertAll(x => x.LabelID);
            var pageLabels = Repository.Find(x => x.Page.ID == pageID && labelIds.Contains(x.LabelID)).ToList();
            if (pageLabels.Any())
            {
                foreach (var pageLabel in pageLabels)
                {
                    pageLabel.VNText = listLabels.First(x => x.LabelID == pageLabel.LabelID).VNText;
                    pageLabel.ENText = listLabels.First(x => x.LabelID == pageLabel.LabelID).ENText;

                    Repository.Update(pageLabel);
                }
            }

            var insertItems = labelIds.Except(pageLabels.Select(x => x.LabelID)).ToList();
            if (insertItems.Any())
            {
                foreach (var labelID in insertItems)
                {
                    Repository.Add(new PageLabel
                                       {
                                           LabelID = labelID,
                                           Page = new Page {ID = pageID},
                                           VNText = listLabels.First(x => x.LabelID == labelID).VNText,
                                           ENText = listLabels.First(x => x.LabelID == labelID).ENText
                                       });
                }
            }

            return new ServiceResult();
        }
    }
}