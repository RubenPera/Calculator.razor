using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Calculator.Models;

namespace Calculator.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task CreateOrUpdate(TEntity entity);

        Task DeleteAll();

    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ILocalStorageService _storageService;
        private readonly string Key = typeof(TEntity).Name;
        public BaseRepository(ILocalStorageService localStorageService)
        {
            _storageService = localStorageService;
        }

        public async Task CreateOrUpdate(TEntity entity)
        {
            var entities = await GetAll();

            if (entity.Id == default || !entities.Exists(x => x.Id == entity.Id))
            {
                entity.Id = Guid.NewGuid();

                entities.Add(entity);
            }
            else
            {
                var index = entities.FindIndex(x => x.Id == entity.Id);

                entities[index] = entity;
            }

            await _storageService.SetItemAsync(Key, entities);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _storageService.GetItemAsync<List<TEntity>>(Key) ?? new List<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entities = await GetAll();

            return entities.FirstOrDefault(x => x.Id == id);
        }

        public async Task DeleteAll()
        {
            await _storageService.SetItemAsync(Key, new List<TEntity>());
        }
    }
}