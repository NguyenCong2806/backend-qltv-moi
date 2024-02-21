using System.Collections.Generic;
using System.Linq.Expressions;
using WebDataModel.BaseClass;

namespace WebService.Interface
{
    public interface IService<TModel, TEnty>
        where TModel : class
        where TEnty : class
    {
        Task<Resultreturn<TModel>> GetAll(Paginationpage<TEnty> paginationpage);
        Task<IList<TModel>> GetAll();
        Task<IList<TModel>> GetAll(Expression<Func<TEnty, bool>> expression);
        Task<bool> Add(TModel model);
        Task<bool> Add(IList<TModel> model);

        Task<bool> Update(TModel model);
        Task<bool> Update(IList<TModel> model);

        Task<bool> Delete(Expression<Func<TEnty, bool>> expression);
        Task<bool> DeleteAll(Expression<Func<TEnty, bool>> expression);
        Task<TModel> Get(Expression<Func<TEnty, bool>> expression);
    }
}