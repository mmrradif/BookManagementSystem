using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Context;
using PracticalExam.Interfaces;

namespace PracticalExam.Repositories
{
    public class GenericRepo<T> : IAll<T> where T : class
    {
        public BookDbContext bookDb = default!;
        internal DbSet<T> dbSet = default!;


        public GenericRepo
            (
                BookDbContext bookDb
            )
        {
            this.bookDb = bookDb;
            this.dbSet = this.bookDb.Set<T>();
        }

      


        // Get All 
        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                var result = await this.dbSet.ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }


        // Insert
        public virtual Task Insert(T entity)
        {
            throw new NotImplementedException();
        }


        // Update
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }


        // Delete
        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }


        // Save Changes
        public async Task CompleteAsync()
        {
            await bookDb.SaveChangesAsync();
            Dispose();
        }


        // Dispose
        public void Dispose()
        {
            bookDb.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
