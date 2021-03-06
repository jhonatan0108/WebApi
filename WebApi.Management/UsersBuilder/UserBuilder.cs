﻿using System;
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
        public static DAL.Data.Users UserToEntity(UsuarioModel ent_Usuario)
        {
            DAL.Data.Users response = new DAL.Data.Users()
            {
                ID = ent_Usuario.ID,
                FirstName = ent_Usuario.FirstName.ToUpper(),
                LastName = ent_Usuario.LastName.ToUpper(),
                UserName = ent_Usuario.UserName.ToUpper(),
                EmailAddress = ent_Usuario.EmailAddress.ToUpper(),
                PasswordHash = ent_Usuario.PasswordHash
            };
            return response;
        }
        public static UsuarioModel EntityToUser(DAL.Data.Users data_User)
        {
            UsuarioModel response = new UsuarioModel()
            {
                ID = data_User.ID,
                FirstName = data_User.FirstName.ToUpper(),
                LastName = data_User.LastName.ToUpper(),
                UserName = data_User.UserName.ToUpper(),
                EmailAddress = data_User.EmailAddress.ToUpper(),
                PasswordHash = data_User.PasswordHash
            };
            return response;
        }
        public static List<DAL.Data.Users> ListUserToEntity(List<UsuarioModel> List_Usuario)
        {
            List<DAL.Data.Users> listData = new List<DAL.Data.Users>();
            foreach (var item in List_Usuario)
            {
                DAL.Data.Users Response = new DAL.Data.Users()
                {
                    ID = item.ID,
                    FirstName = item.FirstName.ToUpper(),
                    LastName = item.LastName.ToUpper(),
                    UserName = item.UserName.ToUpper(),
                    EmailAddress = item.EmailAddress.ToUpper(),
                    PasswordHash = item.PasswordHash
                };
                listData.Add(Response);
            }
            return listData;
        }
        public static List<UsuarioModel> ListEntityToUser(List<DAL.Data.Users> Listdata_User)
        {
            List<UsuarioModel> listData = new List<UsuarioModel>();
            foreach (var item in Listdata_User)
            {
                UsuarioModel Response = new UsuarioModel()
                {
                    ID = item.ID,
                    FirstName = item.FirstName.ToUpper(),
                    LastName = item.LastName.ToUpper(),
                    UserName = item.UserName.ToUpper(),
                    EmailAddress = item.EmailAddress.ToUpper(),
                    PasswordHash = item.PasswordHash
                };
                listData.Add(Response);
            }
            return listData;
        }
    }
}
