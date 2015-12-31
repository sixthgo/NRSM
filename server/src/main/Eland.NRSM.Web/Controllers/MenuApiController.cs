using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eland.NRSM.Web.Models;
using Formular.BaaS.Domain;
using Formular.BaaS.Service;
using Spring.Context;
using System.Web.Http.Cors;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MenuApiController : ApiController
    {
        public IMembershipService MembershipService { get; set; }
        public IMessageSource MessageSource { get; set; }

        public MenuModel Get(string appId, string loginId, string currentMenuVersion, string locale, string deviceModelName, string menuId)
        {
            string tempDeviceModelName = deviceModelName;
            string tempMenuId = menuId;

            // add try for assure business logic execution
            try
            {
                // menu clicked request
                if (!string.IsNullOrEmpty(tempMenuId))
                {
                    // not pc web browser
                    if (!string.IsNullOrEmpty(tempDeviceModelName))
                    {
                        //
                        // add device logging logic
                        //
                        string test = string.Empty;
                    }
                }
            }
            catch
            {
            }

            User user = MembershipService.GetUserByUserName(loginId);
            Member member = MembershipService.GetMember(user.Id);
            List<Role> roles = MembershipService.SearchRoleByUserId(user.Id);
            bool IsManager = roles.Where(c => c.Name == System.Configuration.ConfigurationManager.AppSettings["ManagerRoleName"]).Count() > 0;
            user.AppDivision = MembershipService.GetAppdivisionByUserId(user.Id);

            if (user.AppDivision.Version == currentMenuVersion)
            {
                return new MenuModel()
                {
                    msg = ""
                    ,
                    result = "success"
                    ,
                    data = new Data()
                    {
                        MenuVersion = user.AppDivision.Version
                        ,
                        AccountInfo = new Eland.NRSM.Web.Models.Account() { Email = member.Email, Name = member.Name, Id = member.UserId, IsManager = IsManager }
                    }
                };
            }

            List<ProgramMenu> result = MembershipService.GetProgramMenuByUserId(user.Id);

            int MobileMenuKey = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["MobileRootMenuKey"]); // Configration

            List<ProgramMenu> menus = result.Where(c => c.Id == MobileMenuKey).OrderBy(c => c.DisplaySeq).ToList();

            List<Section> sectionSet = new List<Section>();
            Section section = null;

            menus[0].SubMenu.ForEach(menu =>
            {
                section = new Section { Name = MessageSource.GetMessage(menu.Name) ?? menu.Name, Index = menu.DisplaySeq, Menus = new List<Menu>() };
                menu.SubMenu.ForEach(programMenu =>
                {
                    if (programMenu.program.IsUsed) { 
                        section.Menus.Add(new Menu
                        {
                            //Name = MessageSource.GetMessage(programMenu.Name) ?? programMenu.Name,
                            Name = programMenu.Desc,
                            Index = programMenu.DisplaySeq,
                            Icon = programMenu.program.MobileProgram.IconName,
                            Url = programMenu.program.MobileProgram.Url,
                            ViewType = programMenu.program.MobileProgram.ViewType
                        });
                    }
                });
                sectionSet.Add(section);
            });


            MenuModel menuModel = new MenuModel();
            menuModel.msg = "";
            menuModel.result = "success";

            menuModel.data = new Data();
            menuModel.data.MenuVersion = user.AppDivision.Version;
            menuModel.data.AccountInfo = new Eland.NRSM.Web.Models.Account() { Email = member.Email, Name = member.Name, Id = member.UserId, IsManager = IsManager };
            menuModel.data.Sections = sectionSet;

            return menuModel;
        }
    }
}
