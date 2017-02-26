using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ProductManager
    {
        private readonly Repository<Product> repo;

        public ProductManager()
        {
            repo = new Repository<Product>();
        }

        public ResultStatus Create(Product product)
        {
            ResultStatus result = new ResultStatus();
            try
            {
               repo.Add(product);
               repo.Save();
            }
            catch (Exception)
            {

                result = ResultStatus.Error;
            }
            return result;
           
        }

       
        public Result<IEnumerable<Product>> FindAll()
        {
            Result<IEnumerable<Product>> result = new Result<IEnumerable<Product>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<Product>();
                 }
            }
            catch (Exception)
            {

                result.Ststus = ResultStatus.Error;
            }
            return result;
            
        }

        public Result<Product> FindById(int id)
        {
            Result<Product> result = new Result<Product>();
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

        public void Update(Product product)
        {
            repo.Update(product);
            repo.Save();
        }

        public void Remove(Product product)
        {
            repo.Delete(product);
            repo.Save();
        }

        public Result<IEnumerable<Product>> FindByBusinessId(int businessId)
        {
            Result<IEnumerable<Product>> result = new Result<IEnumerable<Product>>();
            try
            {
                var returnResult = repo.Query(b => b.businessId == businessId);
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
