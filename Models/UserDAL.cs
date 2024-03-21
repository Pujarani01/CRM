using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CRM.Models
{
    public class UserDAL
    {
        static string conn = ConfigurationManager.ConnectionStrings["CRMDBConnectionString"].ConnectionString;
        CRMDBDataContext context = new CRMDBDataContext(conn);

        public user1 GetUser(string Email)
        {
            user1 user;
            try
            {
                user = (from u in context.user1s where u.Email == Email select u).Single();
                return user;
            }
            catch(Exception ex)
            {
                throw ex;

            }
           
        }
        public user1  AddUser(user1 user)
        {
            try
            {
                context.user1s.InsertOnSubmit(user);
                context.SubmitChanges();
                user = (from u in context.user1s where u.Email == user.Email select u).Single();
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}