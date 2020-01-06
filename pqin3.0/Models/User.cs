using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ORMF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pqin3._0.Models
{
    [Table("AspNetUsers")]
    public class User : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public User()
        {

        }
        public User(string id, string userName, string pass)
        {
            Id = id;
            UserName = userName;
            PasswordHash = pass;
        }

    }
}