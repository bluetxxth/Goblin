using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace GoblinV1.Logic
{
    public class AdminEngine
    {

       private ApplicationDbContext m_context = new ApplicationDbContext();
       private IdentityDbContext m_idbctx = new IdentityDbContext();
       private UserManager m_userManager = new UserManager();
       private RoleManager<IdentityRole> m_roleManager; 
       private List<IdentityUser> m_identityUserList = new List<IdentityUser>();

        /// <summary>
        /// Constructs an object of type AdminEngine
        /// </summary>
        public AdminEngine()
        {

            //instantiate roleManager and rolemanagement context
            m_roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(m_context));

        }

        /// <summary>
        /// Provides accessor and mutator for m_roleManager
        /// </summary>
        public RoleManager<IdentityRole> MyRoleManager
        {
            get { return m_roleManager; }
            set { m_roleManager = value; }
        }

        /// <summary>
        /// Provide accessor and mutator to m_context
        /// </summary>
        public ApplicationDbContext MyAppContext
        {
            get { return m_context; }
            set { m_context = value; }
        }


        /// <summary>
        /// Provide accessor and mutator to m_userManager
        /// </summary>
        public UserManager MyUserManager 
        {
            get { return m_userManager; }
            set { m_userManager = value; }
        }

        IdentityDbContext MyIdentityDBCOntext
        {
            get { return m_idbctx; }
            set { m_idbctx = value; }
        }

        /// <summary>
        /// get a list of all roles
        /// </summary>
        /// <returns>string list with rolenames</returns>
        public List<string> getIdentityRoleList()
        {
            //create identityDBcontext
            var allRoles = m_idbctx.Roles;

            //instantiate a string list
            List<string> roleList = new List<string>();

            //traverse the role list
            foreach (var role in allRoles)
            {
                //add rolenames to role list
                roleList.Add(role.Name);
            }
            return roleList;
        }


        /// <summary>
        /// Return a list of application users
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> getApplicationUserList()
        {

            List<ApplicationUser> users = null;

            try
            {
                var allUsers = m_context.Users.ToList();
                users = allUsers;

            }
            catch (EntityCommandExecutionException ex)
            {
                    HttpContext.Current.Session["Error"] = ex;

                    HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");
            }

            return users;
        }

        /// <summary>
        /// Return a list of identity users
        /// </summary>
        /// <returns>Identity users</returns>
        public List<IdentityUser> getIdentityUserList()
        {
            //instantiate identity dbcontext
            IdentityDbContext idbctx = new IdentityDbContext();

            var allUsers = idbctx.Users.ToList();

            //get all the user accounts
            List<IdentityUser> users = allUsers;

            return users;
        }

        /// <summary>
        /// Get identity user list
        /// </summary>
        /// <returns></returns>
        public string getUser()
        {
            string usersInList = null;

            List<IdentityUser> userList = getIdentityUserList();

            int n = 0;

            List<string> userName = new List<string>();

            foreach(IdentityUser user in userList){

                userName.Add(user.UserName);
             
                n++;
            }

            return usersInList;
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="myRole">the role to add</param>
        public void CreateRole(string myRole)
        {
            if (!MyRoleManager.RoleExists(myRole))
            {
                MyRoleManager.Create(new IdentityRole(myRole));
            }
        }

        /// <summary>
        /// Add user to role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        public void addUserToRole(string userName, string roleName)
        {

            var user = new ApplicationUser() { UserName = userName};

            var selectedUser = MyUserManager.FindByName(user.UserName);

            //HttpContext.Current.Session["Error"] = user.UserName;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            MyUserManager.AddToRole(selectedUser.Id, roleName);
        }



        /// <summary>
        /// Add user to role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        public void removeUserFromRole(string userName, string roleName)
        {
            var user = new ApplicationUser() { UserName = userName };

            var selectedUser = MyUserManager.FindByName(user.UserName);

            MyUserManager.RemoveFromRole(selectedUser.Id, roleName);
        }

        /// <summary>
        /// Create roles
        /// </summary>
        /// <param name="roleName">a string represetning the name of the role to be created</param>
        public void createRole(string roleName)
        {
            //check if the role exists
            if (!MyRoleManager.RoleExists(roleName))
            {
                //create role
                CreateRole(roleName);
            }
        }

        /// <summary>
        /// Create roles
        /// </summary>
        /// <param name="roleName">a string represetning the name of the role to be created</param>
        public void removeRole(string roleName)
        {
            //check if the role exists
            if (MyRoleManager.RoleExists(roleName))
            {
                var role = m_idbctx.Roles.Where(r => r.Name == roleName).FirstOrDefault();
                m_idbctx.Roles.Remove(role);
                m_idbctx.SaveChanges();
            }
            else
            {

                HttpContext.Current.Session["Error"] = roleName + " does not exist";
                HttpContext.Current.Response.Redirect("~/UserPages/ErrorPage.aspx");
            }
        }


        /// <summary>
        /// Checks if a user is in the given role
        /// </summary>
        /// <param name="searchRole">the role to explore</param>
        /// <returns>true or false depending if the user is in the passed role</returns>
        public bool checkRoles(string searchRole)
        {
            bool isInRole = false;

            var allRoles = m_context.Roles.ToList();
            var allUsers = m_context.Users.ToList();

            //create a list of roles
            List<IdentityRole> roles = allRoles;
            List<ApplicationUser> users = allUsers;


            //counter
            int n = 0;

            //traverse the role list
            foreach (IdentityRole role in roles)
            {
                //find out if user is in the given role
                if (m_userManager.IsInRole(users[n].Id, searchRole))
                {
                    isInRole = true;
                }
                else
                {
                    isInRole = false;
                }

                n++;
            }

            return isInRole;
        }


        /// <summary>
        /// Get a list of identity user roles from an application user
        /// </summary>
        /// <param name="user">an application user</param>
        /// <returns>a string list with representing the user's roles</returns>
        public List<string> getIdentityUserRoles(ApplicationUser user)
        {
            //instantiate a list of strings to store role names
            List<string> myRoleList = new List<string>();

            foreach (IdentityUserRole role in user.Roles)
            {
                myRoleList.Add(role.ToString());
            }

           return myRoleList;
        }

        /// <summary>
        /// Get a list of identity user roles from an identity user
        /// </summary>
        /// <param name="user">an application user</param>
        /// <returns>a string list with representing the user's roles</returns>
        public List<string> getIdentyUserRoles(IdentityUser user)
        {

            //instantiate a list of strings to store role names
            List<string> myIdentityRoleList = getIdentyUserRoles(user);

            return myIdentityRoleList;
        }
        

        /// <summary>
        /// Get a list application users
        /// </summary>
        /// <param name="user">the aaplication user</param>
        /// <returns>a string representation of the application user list</returns>
        public List<string> getApplicationUserlist(ApplicationUser user){

            List<string> myApplicationUserList = getApplicationUserlist(user);

            return myApplicationUserList;

        }



        /// <summary>
        /// Get a string with user name
        /// </summary>
        /// <param name="user">An identity user</param>
        /// <returns>string representing user's name</returns>
        public string getUserByName(IdentityUser user)
        {
            string userNameString = null;

            userNameString = user.UserName;

            return userNameString;
        }


        

    }
}