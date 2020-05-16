using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlayService.Models;
using PlayService.Data;
using System;
using System.Linq;

namespace PlayService.Controllers {
    public abstract class CrudControllerBase<TEntity> 
    : ControllerBase where TEntity : EntityBase {
        public DbSet<TEntity> _entityContext;
        public IQueryable<TEntity> _queryableContext;

        protected readonly PlayServiceContext _context;

        public CrudControllerBase(
            PlayServiceContext context, 
            DbSet<TEntity> entityDbSet){
            _entityContext = entityDbSet;
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> GetAll() {
            return Ok(GetQueryableContext().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(Guid? id) {
            var entity = GetQueryableContext().FirstOrDefault(e => e.Id == id);

            if (entity == null) {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<TEntity> Post(TEntity model) {

            var entity = MapToEntity(model);

            _entityContext.Add(entity);
            _context.SaveChanges();

            return Ok(entity);
        }

        [HttpPut]
        public ActionResult<TEntity> Put(Guid id, TEntity model) {

            if (id != model.Id) {
                return BadRequest();
            }

            var entity = GetQueryableContext().First(e => e.Id == id);
            MapToEntity(model, entity);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<TEntity> Delete(Guid? id) {
            var entity = _entityContext.Find(id);

            if(entity == null) {
                return NotFound();
            }

            _entityContext.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        protected abstract TEntity MapToEntity(TEntity model, TEntity entity = null);
        protected abstract IQueryable<TEntity> GetQueryableContext();
    }
}