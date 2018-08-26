using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Concrete
{
    public class UserRepository
    {
        

        //public IEnumerable<UserDetails> GetUsers()
        //{
        //    List<UserDetails> userDetails=new List<UserDetails>();
        //    using (var context = new UsersDbContext())
        //    {
        //        var userList = context.UserDetails.ToList();
        //        foreach (var user in userList)
        //        {
        //            UserDetails userDetail = new UserDetails();
        //            userDetail.ID = user.ID;
        //            userDetail.Forename = user.Forename;
        //            userDetail.Surname = user.Surname;
        //            userDetail.DateofBirth = user.Date_of_Birth;
        //            userDetail.Gender = user.Gender;
        //            userDetail.HomeNumber = user.Home_Number;
        //            userDetail.WorkNumber = user.Work_Number;
        //            userDetail.MobileNumber = user.Mobile_Number;

        //            userDetails.Add(userDetail);
        //        }
        //    }

        //    return userDetails;
        //}

        public IEnumerable<UserDetail> GetUsers()
        {
            using (var context = new UsersDbContext())
            {
                var userList = context.UserDetails.ToList();
                return userList;
            }
        }

        public bool Add(UserDetail userDetails)
        {
            bool flag = true;
            try
            {
                using (var context = new UsersDbContext())
                {
                    context.UserDetails.Add(userDetails);
                    context.SaveChanges();
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}