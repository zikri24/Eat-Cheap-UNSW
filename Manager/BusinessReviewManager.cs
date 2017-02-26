using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class BusinessReviewManager
    {
         private readonly Repository<BusinessReview> repo;

         public BusinessReviewManager()
        {
            repo = new Repository<BusinessReview>();
        }

         public ResultStatus Create(BusinessReview review)
        {
            ResultStatus result = new ResultStatus();
            try
            {
               repo.Add(review);
               repo.Save();
            }
            catch (Exception)
            {
               result = ResultStatus.Error;
            }
            return result;           
        }

         public Result<IEnumerable<BusinessReview>> FindAll()
        {
            Result<IEnumerable<BusinessReview>> result = new Result<IEnumerable<BusinessReview>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<BusinessReview>();
                 }
            }
            catch (Exception)
            {
                result.Ststus = ResultStatus.Error;
            }
            return result;            
        }

         public Result<BusinessReview> FindById(int id)
        {
            Result<BusinessReview> result = new Result<BusinessReview>();
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

         public void Update(BusinessReview review)
        {
            repo.Update(review);
            repo.Save();
        }

         public void Remove(BusinessReview review)
        {
            repo.Delete(review);
            repo.Save();
        }

         public Result<IEnumerable<BusinessReview>> FindByBusinessId(int businessId)
        {
            Result<IEnumerable<BusinessReview>> result = new Result<IEnumerable<BusinessReview>>();
            try
            {
                var returnResult = repo.Query(b => b.BusinessId == businessId);
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
