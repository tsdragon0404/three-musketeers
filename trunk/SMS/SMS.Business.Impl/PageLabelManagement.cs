using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
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

        public IList<TDto> GetByPageID<TDto>(int pageID)
        {
            return Mapper.Map<IList<PageLabel>, IList<TDto>>(Repository.Find(x => x.Page.ID == pageID).ToList());
        }

        public bool Save(int pageID, string labelID, string text)
        {
            var pageLabel = Repository.FindOne(x => x.Page.ID == pageID && x.LabelID == labelID);
            if(pageLabel == null)
            {
                Repository.Add(new PageLabel
                                   {
                                       LabelID = labelID,
                                       Page = new Page { ID = pageID },
                                       VNText = UserContext.Language == Language.Vietnamese ? text : "",
                                       ENText = UserContext.Language == Language.English ? text : ""
                                   });
            }
            else
            {
                pageLabel.VNText = UserContext.Language == Language.Vietnamese ? text : pageLabel.VNText;
                pageLabel.ENText = UserContext.Language == Language.English ? text : pageLabel.ENText;
                Repository.Update(pageLabel);
            }
            return true;
        }

        public bool Save(int pageID, List<PageLabelDto> listLabels)
        {
            var labelIds = listLabels.ConvertAll(x => x.LabelID);
            var pageLabels = Repository.Find(x => x.Page.ID == pageID && labelIds.Contains(x.LabelID)).ToList();
            if (pageLabels.Any())
            {
                foreach (var pageLabel in pageLabels)
                {
                    pageLabel.VNText = UserContext.Language == Language.Vietnamese ? listLabels.First(x => x.LabelID == pageLabel.LabelID).VNText : pageLabel.VNText;
                    pageLabel.ENText = UserContext.Language == Language.English ? listLabels.First(x => x.LabelID == pageLabel.LabelID).ENText : pageLabel.ENText;

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
                                           VNText = UserContext.Language == Language.Vietnamese ? listLabels.First(x => x.LabelID == labelID).VNText : "",
                                           ENText = UserContext.Language == Language.English ? listLabels.First(x => x.LabelID == labelID).ENText : ""
                                       });
                }
            }

            return true;
        }
    }
}