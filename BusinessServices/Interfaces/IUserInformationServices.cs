using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.SQLDatabase;

namespace BusinessServices.Interfaces
{
    public interface IUserInformationServices
    {
        UserInformation GetUserInformation(string currentUserId);
        void InsertOrUpdateUserInformation(UserInformation information, string currentUserId);
    }
}
