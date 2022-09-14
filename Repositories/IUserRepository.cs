﻿using System.Collections.Generic;
using System.Net;

namespace ModernUI.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel? GetById(int id);
        IEnumerable<UserModel> GetByAll();
    }
}