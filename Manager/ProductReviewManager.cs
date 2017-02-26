using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ProductReviewManager
    {
        private readonly Repository<ProductReview> repo;

         public ProductReviewManager()
        {
            repo = new Repository<ProductReview>();
        }

         public ResultStatus Create(ProductReview review)
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

         public Result<IEnumerable<ProductReview>> FindAll()
        {
            Result<IEnumerable<ProductReview>> result = new Result<IEnumerable<ProductReview>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<ProductReview>();
                 }
            }
            catch (Exception)
            {
                result.Ststus = ResultStatus.Error;
            }
            return result;            
        }

         public Result<ProductReview> FindById(int id)
        {
            Result<ProductReview> result = new Result<ProductReview>();
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

         public void Update(ProductReview review)
        {
            repo.Update(review);
            repo.Save();
        }

         public void Remove(ProductReview review)
        {
            repo.Delete(review);
            repo.Save();
        }

         public Result<IEnumerable<ProductReview>> FindByBusinessId(int productId)
        {
            Result<IEnumerable<ProductReview>> result = new Result<IEnumerable<ProductReview>>();
            try
            {
                var returnResult = repo.Query(b => b.ProductId == productId);
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
