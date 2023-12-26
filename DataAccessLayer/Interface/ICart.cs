using DataAccessLayer.Models.OrderDetailsSet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICart
    {
        Task AddCartProducts(OrderDetailsAddDto orderDetailsAdd);
    }
}
