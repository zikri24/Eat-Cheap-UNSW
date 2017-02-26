using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class OrderItemManager
    {
        private readonly Repository<OrderItem> repo;

        public OrderItemManager()
        {
            repo = new Repository<OrderItem>();
        }

        public ResultStatus Create(OrderItem orderItem)
        {
            ResultStatus result = new ResultStatus();
            try
            {
                repo.Add(orderItem);
               repo.Save();
            }
            catch (Exception)
            {

                result = ResultStatus.Error;
            }
            return result;
           
        }


        public Result<IEnumerable<OrderItem>> FindAll()
        {
            Result<IEnumerable<OrderItem>> result = new Result<IEnumerable<OrderItem>>();
            try
            {
                 var returnResult = repo.GetAll();
                 if (returnResult != null)
                 {
                     result.Ststus = ResultStatus.Success;
                     result.Data = returnResult.AsEnumerable<OrderItem>();
                 }
            }
            catch (Exception)
            {

                result.Ststus = ResultStatus.Error;
            }
            return result;            
        }

        public Result<OrderItem> FindById(int id)
        {
            Result<OrderItem> result = new Result<OrderItem>();
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

        public void Update(OrderItem orderItem)
        {
            repo.Update(orderItem);
            repo.Save();
        }

        public void Remove(OrderItem orderItem)
        {
            repo.Delete(orderItem);
            repo.Save();
        }
    }
}
