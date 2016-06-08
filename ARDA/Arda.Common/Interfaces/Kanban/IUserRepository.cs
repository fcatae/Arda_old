﻿using Arda.Common.ViewModels.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arda.Common.Interfaces.Kanban
{
    public interface IUserRepository
    {
        // Add a new user to the database.
        bool AddNewUser(UserViewModel user);

        // Delete a user based on id.
        bool DeleteUserByID(string userID);
    }
}
