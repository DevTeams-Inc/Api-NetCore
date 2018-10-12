using Model;
using Model.VM;
using Service.IServices.IBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface ISaleService : IBaseService<Sale>
    {
        bool Add(SaleProductVM viewModelPV);
        SaleProductVM GetSaleDetail(int id);
    }
}
