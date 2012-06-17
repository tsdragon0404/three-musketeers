namespace BDSGiaKiem
{
    using System.Linq;
    partial class BDSDataContext
    {
        #region HomePic
        public void InsertHomePic(string imgurl)
        {
            HomePics.InsertOnSubmit(new HomePic(imgurl));
            SubmitChanges();
        }
        public int UpdateHomePic(int id, bool used)
        {
            var target = HomePics.Where(hp => hp.ID == id);
            if (target.Count() == 0)
                return 0;
            HomePic pic = target.First();
            pic.IsUsed = used;
            SubmitChanges();
            return 1;
        }
        public string DeleteHomePic(int id)
        {
            var target = HomePics.Where(hp => hp.ID == id);
            if (target.Count() == 0)
                return "";
            string rs = target.First().ImageUrl;
            HomePics.DeleteOnSubmit(target.First());
            SubmitChanges();
            return rs;
        }
        #endregion
        #region HomeLink
        public string getHomeLink(int id)
        {
            var target = HomeLinks.Where(l => l.ID == id);
            if (target.Count() == 0)
                return "";
            else
                return target.First().Link;
        }
        public void UpdateHomeLink(int id, string newurl)
        {
            var target = HomeLinks.Where(l => l.ID == id);
            if (target.Count() == 0)
                HomeLinks.InsertOnSubmit(new HomeLink(id, newurl));
            else
                target.First().Link = newurl;
            SubmitChanges();
        }
        #endregion
        #region Supporter
        public Supporter getSupporter(int id)
        {
            var target = Supporters.Where(s => s.ID == id);
            if (target.Count() == 0)
                return new Supporter();
            else
                return target.First();
        }

        public void UpdateSupporter(int id, string newname, string newphone, string newyahoo)
        {
            var target = Supporters.Where(s => s.ID == id);
            if (target.Count() == 0)
                Supporters.InsertOnSubmit(new Supporter(id, newname, newphone, newyahoo));
            else
            {
                target.First().Name = newname;
                target.First().Phone = newphone;
                target.First().Yahoo = newyahoo;
            }
            SubmitChanges();
        }
        #endregion
        #region Article
        public Article getArticle(int id)
        {
            var target = Articles.Where(a => a.ID == id);
            if (target.Count() == 0)
                return new Article();
            else
                return target.First();
        }
        public void UpdateArticle(int id, string title, string contenttext)
        {
            if (id <= 0)
            {
                if (Articles.Count() > 0)
                    id = (int)Articles.Max(a => a.ID) + 1;
                else
                    id = 1;
                Articles.InsertOnSubmit(new Article(id, title, contenttext));
            }
            else
            {
                var target = Articles.First(a => a.ID == id);
                target.Title = title;
                target.ContentText = contenttext;
            }
            SubmitChanges();
        }
        #endregion
    }

    partial class HomePic
    {
        public HomePic(string imgurl) : this(imgurl, true) { }
        
        public HomePic(string imgurl, bool isused)
        {
            ImageUrl = imgurl;
            IsUsed = isused;
            OnCreated();
        }
    }
    partial class HomeLink
    {
        public HomeLink(int id, string url)
        {
            ID = id;
            Link = url;
            OnCreated();
        }
    }
    partial class Supporter
    {
        public Supporter(int id, string phone)
            : this(id, "", phone, "")
        { }

        public Supporter(int id, string name, string phone, string yahoo)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Yahoo = yahoo;
            OnCreated();
        }
    }
    partial class Article
    {
        public Article(long id, string title, string content)
        {
            ID = id;
            Title = title;
            ContentText = content;
            OnCreated();
        }
    }
}
