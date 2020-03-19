using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class LoginService
    {
        DBService<User> service = new DBService<User>();
        DBService<RoleWiseScreenPermission> roleService = new DBService<RoleWiseScreenPermission>();
        Entities entity = new Entities();
        public List<Screen> GetMenuPermission(int roleid)
        {
            var entryPoint = (from ep in entity.Screens
                              join e in entity.RoleWiseScreenPermissions on ep.ScreenId equals e.ScreenId
                              where e.RoleId == roleid.ToString() orderby e.Screen.OrderBy
                              select ep );
            return entryPoint.ToList();
        }

        public List<User> GetAll()
        {
            return service.GetAll();
        }
        public User GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public User Save(User cus)
        {
            return service.Save(cus);

        }
        public User Update(User t, int id)
        {
            return service.Update(t, id);

        }
        public RoleWiseScreenPermission SaveRoleWisePermission(RoleWiseScreenPermission cus)
        {
            return roleService.Save(cus);

        }
        public RoleWiseScreenPermission UpdateRoleWisePermission(RoleWiseScreenPermission t, int id)
        {
            return roleService.Update(t, id);

        }
        public List<RoleWiseScreenPermission> GetRoleWiseService()
        {
            return roleService.GetAll();

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}