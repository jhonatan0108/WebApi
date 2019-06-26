using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.DAL;

namespace WebApi.Management.UsersBuilder
{
    public class UsersBuilder
    {
        public static DAL.Data.Users UserToEntity(ENT_Usuario ent_Usuario)
        {
            DAL.Data.Users response = new DAL.Data.Users()
            {
                ID = ent_Usuario.ID,
                FirstName = ent_Usuario.FirstName,
                LastName = ent_Usuario.LastName,
                UserName = ent_Usuario.UserName,
                EmailAddress = ent_Usuario.EmailAddress,
                PasswordHash = ent_Usuario.PasswordHash
            };
            return response;
        }
        public static ENT_Usuario EntityToUser(DAL.Data.Users data_User)
        {
            ENT_Usuario response = new ENT_Usuario()
            {
                ID = data_User.ID,
                FirstName = data_User.FirstName,
                LastName = data_User.LastName,
                UserName = data_User.UserName,
                EmailAddress = data_User.EmailAddress,
                PasswordHash = data_User.PasswordHash
            };
            return response;
        }
    }
}
