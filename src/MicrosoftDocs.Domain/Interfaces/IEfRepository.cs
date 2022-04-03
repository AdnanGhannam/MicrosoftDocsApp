using Ardalis.Specification;
using MicrosoftDocs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Interfaces;

public interface IEfRepository<T>
        where T : EntityBase, IAggregateRoot
{
    Task<IReadOnlyList<T>> GetListAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync<TPrimary>(TPrimary id, ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<T> GetFirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default);
    Task DeleteEntityAsync<E>(E entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync<TPrimary>(TPrimary id, T entity, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<int> CountAsync();
    Task<int> SaveChangesAsync();
}

public interface IEfRepository<T, TMap> 
    where T : EntityBase, IAggregateRoot
    where TMap : EntityDtoBase
{
    Task<IReadOnlyList<TMap>> GetListAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TMap>> GetListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<TMap> GetByIdAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default);
    Task<TMap> GetByIdAsync<TPrimary>(TPrimary id, ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<TMap> GetFirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<TMap> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<TMap> DeleteAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default);
    Task<TMap> UpdateAsync<TPrimary>(TPrimary id, T entity, CancellationToken cancellationToken = default);
}
