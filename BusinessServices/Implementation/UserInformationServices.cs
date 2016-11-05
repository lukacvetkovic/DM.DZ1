using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Interfaces;
using DataModel.GenericRepository;
using DataModel.SQLDatabase;
using DataModel.UnitOfWork;

namespace BusinessServices.Implementation
{
    public class UserInformationServices : IUserInformationServices
    {
        private readonly UnitOfWork unitOfWork;
        public UserInformationServices()
        {
            unitOfWork = new UnitOfWork();
        }

        public UserInformation GetUserInformation(string currentUserId)
        {
            return unitOfWork.UserInformationRepository.GetFirst(p => p.UserId == currentUserId);
        }

        public void InsertOrUpdateUserInformation(UserInformation information, string currentUserId)
        {
            if (currentUserId != null && information != null)
            {
                var curentUserInfo = unitOfWork.UserInformationRepository.GetFirst(p => p.UserId == currentUserId);
                if (curentUserInfo != null)
                {
                    curentUserInfo.Name = information.Name;
                    curentUserInfo.Email = information.Email;
                    curentUserInfo.Location = information.Location;
                }
                else
                {
                    information.UserId = currentUserId;
                    unitOfWork.UserInformationRepository.Insert(information);
                }

                unitOfWork.Save();
            }
        }
    }
}
