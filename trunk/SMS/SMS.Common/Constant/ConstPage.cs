﻿using System.Collections.Generic;

namespace SMS.Common.Constant
{
    public class ConstPage
    {
        public const long Global = 0;
        public const long HomePage = 1;
        public const long Cashier = 2;
        public const long Kitchen = 3;
        public const long Login = 4;
        public const long AccessDenied = 5;
        public const long Error = 6;
        public const long NotFoundError = 7;
                     
        public const long Branch_Home = 20;
        public const long Branch_GlobalLabel = 21;
        public const long Branch_Role = 22;
        public const long Branch_User = 23;
                     
        public const long Data_Home = 40;
        public const long Data_Area= 41;
        public const long Data_Table = 42;
        public const long Data_ProductCategory = 43;
        public const long Data_Product = 44;
        public const long Data_Unit = 45;


        public const long Report_Dashboard = 60;

        public const long System_Home = 80;
        public const long System_Branch = 81;
        public const long System_User = 82;
        public const long System_Tax = 84;
        public const long System_Currency = 85;

        public const long ReportViewer = 99;

        public static List<long> PublicPages = new List<long> { Global, HomePage, Login, AccessDenied, Error, NotFoundError };
    }
}