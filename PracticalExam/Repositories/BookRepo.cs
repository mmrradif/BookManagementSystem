//using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Context;
using PracticalExam.Database_Models;
using PracticalExam.Interfaces;
using System.Data;

namespace PracticalExam.Repositories
{
    public class BookRepo : GenericRepo<Book>
    {
        public BookRepo(BookDbContext bookDb) : base(bookDb)
        {
        }

        // Get All
        public override async Task<List<Book>> GetAll()
        {
            try
            {
                var result = await base.GetAll();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Get By Id
        public override async Task<Book> GetById(int id)
        {
            try
            {
                var result = await dbSet.FirstOrDefaultAsync(item => item.Id == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Insert
        public override async Task Insert(Book entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Update
        public override async Task<bool> Update(Book entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.Id == entity.Id);

                if (existdata != null)
                {
                    existdata.Date = entity.Date;
                    existdata.BookName = entity.BookName;
                    existdata.Author = entity.Author;
                    existdata.Quantity = entity.Quantity;
                   
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        // Delete
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return false;
                }

                var remove = dbSet.Remove(result);
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}
