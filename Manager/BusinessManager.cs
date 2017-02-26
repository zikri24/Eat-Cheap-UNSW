using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class BusinessManager 
    {
        private readonly Repository<Business> repo;

        public BusinessManager()
        {
            repo = new Repository<Business>();
        }

        public ResultStatus Create(Business business)
        {
            ResultStatus result = new ResultStatus();
            try
            {
               repo.Add(business);
               repo.Save();
            }
            catch (Exception)
            {

                result = ResultStatus.Error;
            }
            return result;
           
        }

       
        public Result<IEnumerable<Business>> FindAll()
        {
            Result<IEnumerable<Business>> result = new Result<IEnumerable<Business>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<Business>();
                 }
            }
            catch (Exception)
            {

                result.Ststus = ResultStatus.Error;
            }
            return result;
            
        }

        public Result<Business> FindById(int id)
        {
            Result<Business> result = new Result<Business>();
            try
            {
                var returnResult = repo.FindById(id);
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = returnResult;
                }
            }
            catch (Exception)
            {
                
                result.Ststus = ResultStatus.Error;
            }
           
            return result;
        }

        public void Update(Business business)
        {
            repo.Update(business);
            repo.Save();
        }

        public void Remove(Business business)
        {
            repo.Delete(business);
            repo.Save();
        }

        public Result<IEnumerable<Business>> FindByUserName(String email)
        {
            Result<IEnumerable<Business>> result = new Result<IEnumerable<Business>>();
            try
            {
                var returnResult = repo.Query(e => e.email.Trim() == email.Trim());
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = returnResult;
                }
            }
            catch (Exception)
            {
                
                result.Ststus = ResultStatus.Error;
            }
           
            return result;
        }
       
    }
}
