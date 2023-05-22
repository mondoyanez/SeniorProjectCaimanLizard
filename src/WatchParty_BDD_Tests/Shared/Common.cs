﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchParty_BDD_Tests.Shared
{
    // Sitewide definitions and useful methods
    public class Common
    {
        public const string BaseUrl = "http://localhost:5053";     // copied from launchSettings.json


        // File to store browser cookies in
        public const string CookieFile = "..\\..\\..\\..\\..\\..\\..\\StandupsCookies.txt";

        // Page names that everyone should use
        // A handy way to look these up
        public static readonly Dictionary<string, string> Paths = new()
        {
            { "CreatePost", "/Post/Create" },
            { "Home" , "/" },
            { "Login", "/Identity/Account/Login" },
            { "Post", "/Post/Index" },
            { "Register", "/Identity/Account/Register" }
        };

        public static string PathFor(string pathName) => Paths[pathName];
        public static string UrlFor(string pathName) => BaseUrl + Paths[pathName];
    }
}