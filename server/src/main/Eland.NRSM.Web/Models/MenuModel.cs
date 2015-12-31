using Formular.BaaS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eland.NRSM.Web.Models
{
    public class MenuModel
    {
        public string msg { get; set; }
        public string result { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string MenuVersion { get; set; }
        public Account AccountInfo { get; set; }
        public List<Section> Sections { get; set; }
    }
    public class Account
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsManager { get; set; }
    }

    public class Section
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
    }

    public class Menu
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public MobileViewType ViewType { get; set; }
        public string Icon { get; set; }
    }
}