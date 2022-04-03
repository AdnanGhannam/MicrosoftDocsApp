using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data;

public class EfRepository<T> : IEfRepository<T>
        where T : EntityBase, IAggregateRoot
{
    private readonly DbSet<T> _entity;

    private readonly AppDbContext _context;

    public EfRepository(AppDbContext context)
    {
        _entity = context.Set<T>();
        _context = context;
    }

    public async Task<IReadOnlyList<T>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _entity.ToListAsync(cancellationToken);
        return entities;
    }

    public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var results = ApplySpecification(specification);
        return await results.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default)
    {
        var entity = await _entity.FindAsync(id);
        return entity;
    }

    public Task<T> GetByIdAsync<TPrimary>(TPrimary id, ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var results = ApplySpecification(specification);
        return results.FirstOrDefaultAsync(r => r.Id == id.ToString(), cancellationToken);
    }

    public Task<T> GetFirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var results = ApplySpecification(specification);
        return results.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var results = await _entity.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();
        return results.Entity;
    }

    public async Task<T?> DeleteAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id);

        if (entity is not null)
        {
            var results = _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return results.Entity;
        }

        return default;
    }

    public async Task DeleteEntityAsync<E>(E entity, CancellationToken cancellationToken = default)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> UpdateAsync<TPrimary>(TPrimary id, T entity, CancellationToken cancellationToken = default)
    {
        var entityById = await GetByIdAsync(id);

        if (entityById is not null)
        {
            _context.Entry(entityById).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        return default;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, 
        CancellationToken cancellationToken = default)
        => await _entity.AnyAsync(predicate, cancellationToken);

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, 
        ISpecification<T> specification, 
        CancellationToken cancellationToken = default)
    {
        var results = ApplySpecification(specification);
        return results.AnyAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync() => await _entity.CountAsync();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var evaluator = new SpecificationEvaluator();
        return evaluator.GetQuery(_entity.AsQueryable(), spec);
    }
}

public class EfRepository<T, TMap> : EfRepository<T>, IEfRepository<T, TMap>
    where T : EntityBase, IAggregateRoot
    where TMap : EntityDtoBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EfRepository(AppDbContext context,
        IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TMap> AddAsync(T entity, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.AddAsync(entity, cancellationToken));

    public async Task<TMap> DeleteAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.DeleteAsync(id, cancellationToken));

    public async Task<TMap> GetByIdAsync<TPrimary>(TPrimary id, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.GetByIdAsync(id, cancellationToken));

    public async Task<TMap> GetByIdAsync<TPrimary>(TPrimary id, ISpecification<T> specification, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.GetByIdAsync(id, specification, cancellationToken));

    public async Task<TMap> GetFirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.GetFirstOrDefaultAsync(specification, cancellationToken));

    public async Task<IReadOnlyList<TMap>> GetListAsync(CancellationToken cancellationToken = default)
        => (await base.GetListAsync(cancellationToken)).Select(e => _mapper.Map<TMap>(e)).ToList();

    public async Task<IReadOnlyList<TMap>> GetListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        => (await base.GetListAsync(specification, cancellationToken)).Select(e => _mapper.Map<TMap>(e)).ToList();

    public async Task<TMap> UpdateAsync<TPrimary>(TPrimary id, T entity, CancellationToken cancellationToken = default)
        => _mapper.Map<TMap>(await base.UpdateAsync(id, entity, cancellationToken));
}
