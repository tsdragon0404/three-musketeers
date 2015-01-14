﻿using System;
using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class SqlStatementDA : BaseDA, ISqlStatementDA
    {
        public SqlStatementDA(IConfig config) : base(config)
        {
        }

        public List<SqlStatement> ListAll()
        {
            const string sql = "SELECT * FROM SQLSTATEMENT";
            return DAHelper.Select<SqlStatement>(config, sql);
        }
    }

    public class SqlStatementDictionary
    {
        private readonly Dictionary<string, string> statements;

        public SqlStatementDictionary(Dictionary<string, string> statements)
        {
            this.statements = statements;
        }

        private string Get(string key)
        {
            if (statements.ContainsKey(key))
                return statements[key];
            throw new Exception("Cannot find the sql statement.");
        }

        public string ReceiptNote_ListAll { get { return Get("ReceiptNote_ListAll"); } }
    }
}