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
    public class TestServices : ITestServices
    {
        private readonly UnitOfWork unitOfWork;
        public TestServices()
        {
            unitOfWork= new UnitOfWork();
        }
        public Test GetFirst()
        {
            return unitOfWork.TestRepository.GetFirst(p => p.Id != 0);
        }
    }
}
