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

        public bool Save(int pageID, Dictionary<string, string> labelDictionary)
        {
            var pageLabels = Repository.Find(x => x.Page.ID == pageID && labelDictionary.Keys.Contains(x.LabelID)).ToList();
            if (pageLabels.Any())
            {
                foreach (var pageLabel in pageLabels)
                {
                    pageLabel.VNText = UserContext.Language == Language.Vietnamese ? labelDictionary[pageLabel.LabelID] : pageLabel.VNText;
                    pageLabel.ENText = UserContext.Language == Language.English ? labelDictionary[pageLabel.LabelID] : pageLabel.ENText;

                    Repository.Update(pageLabel);
                }
            }

            var insertItems = labelDictionary.Keys.Except(pageLabels.Select(x => x.LabelID)).ToList();
            if (insertItems.Any())
            {
                foreach (var labelID in insertItems)
                {
                    Repository.Add(new PageLabel
                                       {
                                           LabelID = labelID,
                                           Page = new Page {ID = pageID},
                                           VNText = UserContext.Language == Language.Vietnamese ? labelDictionary[labelID] : "",
                                           ENText = UserContext.Language == Language.English ? labelDictionary[labelID] : ""
                                       });
                }
            }

            return true;
        }
    }
}