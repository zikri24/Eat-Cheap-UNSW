using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class OrderManager
    {
        private readonly Repository<Order> repo;

        public OrderManager()
        {
            repo = new Repository<Order>();
        }

        public ResultStatus Create(Order order)
        {
            ResultStatus result = new ResultStatus();
            try
            {
                repo.Add(order);
               repo.Save();
            }
            catch (Exception)
            {

                result = ResultStatus.Error;
            }
            return result;
           
        }


        public Result<IEnumerable<Order>> FindAll()
        {
            Result<IEnumerable<Order>> result = new Result<IEnumerable<Order>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<Order>();
                 }
            }
            catch (Exception)
            {

                result.Ststus = ResultStatus.Error;
            }
            return result;
            
        }

        public Result<Order> FindById(int id)
        {
            Result<Order> result = new Result<Order>();
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

        public void Update(Order order)
        {
            repo.Update(order);
            repo.Save();
        }

        public void Remove(Order order)
        {
            repo.Delete(order);
            repo.Save();
        }

        /*public int FindId()
        {
            int id = 0;
            id = repo.Query( o => o.Id where )
            return id;
        }*/

        /*public Result<IEnumerable<Order>> FindByBusinessId(int businessId)
        {
            Result<IEnumerable<Order>> result = new Result<IEnumerable<Order>>();
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
        }*/
    }
}
