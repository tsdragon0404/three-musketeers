﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4961
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BatDongSan
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="WebBatDongSan")]
	public partial class BDSDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAdministrator(Administrator instance);
    partial void UpdateAdministrator(Administrator instance);
    partial void DeleteAdministrator(Administrator instance);
    partial void InsertSupporter(Supporter instance);
    partial void UpdateSupporter(Supporter instance);
    partial void DeleteSupporter(Supporter instance);
    partial void InsertArticle(Article instance);
    partial void UpdateArticle(Article instance);
    partial void DeleteArticle(Article instance);
    partial void InsertHouse(House instance);
    partial void UpdateHouse(House instance);
    partial void DeleteHouse(House instance);
    partial void InsertPartner(Partner instance);
    partial void UpdatePartner(Partner instance);
    partial void DeletePartner(Partner instance);
    partial void InsertQuestion(Question instance);
    partial void UpdateQuestion(Question instance);
    partial void DeleteQuestion(Question instance);
    #endregion
		
		public BDSDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["WebBatDongSanConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BDSDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDSDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDSDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDSDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Administrator> Administrators
		{
			get
			{
				return this.GetTable<Administrator>();
			}
		}
		
		public System.Data.Linq.Table<Supporter> Supporters
		{
			get
			{
				return this.GetTable<Supporter>();
			}
		}
		
		public System.Data.Linq.Table<Article> Articles
		{
			get
			{
				return this.GetTable<Article>();
			}
		}
		
		public System.Data.Linq.Table<House> Houses
		{
			get
			{
				return this.GetTable<House>();
			}
		}
		
		public System.Data.Linq.Table<Partner> Partners
		{
			get
			{
				return this.GetTable<Partner>();
			}
		}
		
		public System.Data.Linq.Table<Project> Projects
		{
			get
			{
				return this.GetTable<Project>();
			}
		}
		
		public System.Data.Linq.Table<Question> Questions
		{
			get
			{
				return this.GetTable<Question>();
			}
		}
	}
	
	[Table(Name="dbo.Administrator")]
	public partial class Administrator : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _UserName;
		
		private string _Password;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
		
		public Administrator()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Supporter")]
	public partial class Supporter : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Phone;
		
		private string _Yahoo;
		
		private System.Nullable<bool> _IsValid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnYahooChanging(string value);
    partial void OnYahooChanged();
    partial void OnIsValidChanging(System.Nullable<bool> value);
    partial void OnIsValidChanged();
    #endregion
		
		public Supporter()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(100)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Phone", DbType="VarChar(20)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[Column(Storage="_Yahoo", DbType="VarChar(50)")]
		public string Yahoo
		{
			get
			{
				return this._Yahoo;
			}
			set
			{
				if ((this._Yahoo != value))
				{
					this.OnYahooChanging(value);
					this.SendPropertyChanging();
					this._Yahoo = value;
					this.SendPropertyChanged("Yahoo");
					this.OnYahooChanged();
				}
			}
		}
		
		[Column(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this.OnIsValidChanging(value);
					this.SendPropertyChanging();
					this._IsValid = value;
					this.SendPropertyChanged("IsValid");
					this.OnIsValidChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Article")]
	public partial class Article : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private string _Summary;
		
		private string _Contents;
		
		private System.Nullable<System.DateTime> _PostDate;
		
		private System.Nullable<System.DateTime> _LatestModifiedDate;
		
		private System.Nullable<bool> _IsValid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnSummaryChanging(string value);
    partial void OnSummaryChanged();
    partial void OnContentsChanging(string value);
    partial void OnContentsChanged();
    partial void OnPostDateChanging(System.Nullable<System.DateTime> value);
    partial void OnPostDateChanged();
    partial void OnLatestModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLatestModifiedDateChanged();
    partial void OnIsValidChanging(System.Nullable<bool> value);
    partial void OnIsValidChanged();
    #endregion
		
		public Article()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(200)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="VarChar(250)")]
		public string Summary
		{
			get
			{
				return this._Summary;
			}
			set
			{
				if ((this._Summary != value))
				{
					this.OnSummaryChanging(value);
					this.SendPropertyChanging();
					this._Summary = value;
					this.SendPropertyChanged("Summary");
					this.OnSummaryChanged();
				}
			}
		}
		
		[Column(Storage="_Contents", DbType="NVarChar(MAX)")]
		public string Contents
		{
			get
			{
				return this._Contents;
			}
			set
			{
				if ((this._Contents != value))
				{
					this.OnContentsChanging(value);
					this.SendPropertyChanging();
					this._Contents = value;
					this.SendPropertyChanged("Contents");
					this.OnContentsChanged();
				}
			}
		}
		
		[Column(Storage="_PostDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PostDate
		{
			get
			{
				return this._PostDate;
			}
			set
			{
				if ((this._PostDate != value))
				{
					this.OnPostDateChanging(value);
					this.SendPropertyChanging();
					this._PostDate = value;
					this.SendPropertyChanged("PostDate");
					this.OnPostDateChanged();
				}
			}
		}
		
		[Column(Storage="_LatestModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LatestModifiedDate
		{
			get
			{
				return this._LatestModifiedDate;
			}
			set
			{
				if ((this._LatestModifiedDate != value))
				{
					this.OnLatestModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._LatestModifiedDate = value;
					this.SendPropertyChanged("LatestModifiedDate");
					this.OnLatestModifiedDateChanged();
				}
			}
		}
		
		[Column(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this.OnIsValidChanging(value);
					this.SendPropertyChanging();
					this._IsValid = value;
					this.SendPropertyChanged("IsValid");
					this.OnIsValidChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.House")]
	public partial class House : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private string _Picture;
		
		private string _Price;
		
		private string _Description;
		
		private System.Nullable<bool> _IsValid;
		
		private System.Nullable<long> _ViewCount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnIsValidChanging(System.Nullable<bool> value);
    partial void OnIsValidChanged();
    partial void OnViewCountChanging(System.Nullable<long> value);
    partial void OnViewCountChanged();
    #endregion
		
		public House()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(200)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Picture", DbType="VarChar(100)")]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[Column(Storage="_Price", DbType="NVarChar(100)")]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this.OnIsValidChanging(value);
					this.SendPropertyChanging();
					this._IsValid = value;
					this.SendPropertyChanged("IsValid");
					this.OnIsValidChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt")]
		public System.Nullable<long> ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Partner")]
	public partial class Partner : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private string _Picture;
		
		private string _URL;
		
		private string _Description;
		
		private System.Nullable<bool> _IsValid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnURLChanging(string value);
    partial void OnURLChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnIsValidChanging(System.Nullable<bool> value);
    partial void OnIsValidChanged();
    #endregion
		
		public Partner()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(100)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Picture", DbType="VarChar(100)")]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[Column(Storage="_URL", DbType="NVarChar(100)")]
		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				if ((this._URL != value))
				{
					this.OnURLChanging(value);
					this.SendPropertyChanging();
					this._URL = value;
					this.SendPropertyChanged("URL");
					this.OnURLChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this.OnIsValidChanging(value);
					this.SendPropertyChanging();
					this._IsValid = value;
					this.SendPropertyChanged("IsValid");
					this.OnIsValidChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Project")]
	public partial class Project
	{
		
		private long _ID;
		
		private string _Title;
		
		private string _Picture;
		
		private string _Summary;
		
		private string _Description;
		
		private System.Nullable<System.DateTime> _PostDate;
		
		private System.Nullable<System.DateTime> _LastestModifiedDate;
		
		private System.Nullable<long> _ViewCount;
		
		private System.Nullable<bool> _IsValid;
		
		public Project()
		{
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="BigInt NOT NULL IDENTITY", IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(200)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[Column(Storage="_Picture", DbType="VarChar(100)")]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this._Picture = value;
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="NVarChar(250)")]
		public string Summary
		{
			get
			{
				return this._Summary;
			}
			set
			{
				if ((this._Summary != value))
				{
					this._Summary = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[Column(Storage="_PostDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PostDate
		{
			get
			{
				return this._PostDate;
			}
			set
			{
				if ((this._PostDate != value))
				{
					this._PostDate = value;
				}
			}
		}
		
		[Column(Storage="_LastestModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastestModifiedDate
		{
			get
			{
				return this._LastestModifiedDate;
			}
			set
			{
				if ((this._LastestModifiedDate != value))
				{
					this._LastestModifiedDate = value;
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt")]
		public System.Nullable<long> ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this._ViewCount = value;
				}
			}
		}
		
		[Column(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this._IsValid = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Question")]
	public partial class Question : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private string _Email;
		
		private string _Phone;
		
		private string _Text;
		
		private System.Nullable<System.DateTime> _PostDate;
		
		private System.Nullable<System.DateTime> _AnswerDate;
		
		private System.Nullable<bool> _IsAnswered;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnPostDateChanging(System.Nullable<System.DateTime> value);
    partial void OnPostDateChanged();
    partial void OnAnswerDateChanging(System.Nullable<System.DateTime> value);
    partial void OnAnswerDateChanged();
    partial void OnIsAnsweredChanging(System.Nullable<bool> value);
    partial void OnIsAnsweredChanged();
    #endregion
		
		public Question()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="VarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[Column(Storage="_Phone", DbType="VarChar(20)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[Column(Storage="_Text", DbType="NVarChar(MAX)")]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[Column(Storage="_PostDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PostDate
		{
			get
			{
				return this._PostDate;
			}
			set
			{
				if ((this._PostDate != value))
				{
					this.OnPostDateChanging(value);
					this.SendPropertyChanging();
					this._PostDate = value;
					this.SendPropertyChanged("PostDate");
					this.OnPostDateChanged();
				}
			}
		}
		
		[Column(Storage="_AnswerDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> AnswerDate
		{
			get
			{
				return this._AnswerDate;
			}
			set
			{
				if ((this._AnswerDate != value))
				{
					this.OnAnswerDateChanging(value);
					this.SendPropertyChanging();
					this._AnswerDate = value;
					this.SendPropertyChanged("AnswerDate");
					this.OnAnswerDateChanged();
				}
			}
		}
		
		[Column(Storage="_IsAnswered", DbType="Bit")]
		public System.Nullable<bool> IsAnswered
		{
			get
			{
				return this._IsAnswered;
			}
			set
			{
				if ((this._IsAnswered != value))
				{
					this.OnIsAnsweredChanging(value);
					this.SendPropertyChanging();
					this._IsAnswered = value;
					this.SendPropertyChanged("IsAnswered");
					this.OnIsAnsweredChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
