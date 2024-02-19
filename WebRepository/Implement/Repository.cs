using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;
using WebDataModel.BaseClass;
using WebEntryModel;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class Repository<TEnty> : IRepository<TEnty>
        where TEnty : class
    {
        protected readonly AppDatabase _appDatabase;
        private readonly DbSet<TEnty> _dbSet;

        public Repository(AppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
            _dbSet = _appDatabase.Set<TEnty>();
        }

        public bool Add(TEnty entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> AddAsync(TEnty entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public bool AddRange(IEnumerable<TEnty> entities)
        {
            try
            {
                _dbSet.AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEnty> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> CheckWord(Expression<Func<TEnty, bool>> expression)
        {
            try
            {
                return await _dbSet.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEnty, bool>> expression)
        {
            try
            {
                if (expression.GetLambdaOrNull() != null)
                {
                    return await _dbSet.CountAsync(expression);
                }
                else
                {
                    return await _dbSet.CountAsync();
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> CountAsyncs(IList<Expression<Func<TEnty, bool>>> expression)
        {
            int count = 0;
            try
            {
                if (expression.Count>0)
                {
                    foreach (var item in expression)
                    {
                        count = await _dbSet.CountAsync(item);
                    }
                }
                else
                {
                    count = await _dbSet.CountAsync();
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            return count;
        }

        public TEnty Get(Expression<Func<TEnty, bool>> expression)
        {
            try
            {
                return _dbSet.SingleOrDefault(expression);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public IQueryable<TEnty> GetAll(Paginationpage<TEnty> paginationpage)
        {
            try
            {
                var data = _dbSet.AsQueryable();
                if (paginationpage.Expression != null)
                {
                    foreach (var item in paginationpage.Expression)
                    {
                        data = data.Where(item);
                    }
                }
                data = data.Skip(paginationpage.PerPage * (paginationpage.PageNumber - 1))
                            .Take(paginationpage.PerPage);

                return data;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public IQueryable<TEnty> GetAll(Expression<Func<TEnty, bool>> expression)
        {
            try
            {
                return _dbSet.Where(expression).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public IQueryable<TEnty> GetAll()
        {
            try
            {
                var data = _dbSet.AsQueryable();
                return data;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<IEnumerable<TEnty>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.ToListAsync<TEnty>(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<IEnumerable<TEnty>> GetAllAsync(Expression<Func<TEnty, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.Where(expression).ToListAsync<TEnty>(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<TEnty> GetAsync(Expression<Func<TEnty, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public bool Remove(TEnty entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public bool RemoveRange(IEnumerable<TEnty> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public bool Update(TEnty entity)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public bool UpdateRange(IEnumerable<TEnty> entities)
        {
            try
            {
                _dbSet.UpdateRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}