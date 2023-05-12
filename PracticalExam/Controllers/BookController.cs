using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Models;
using PracticalExam.Interfaces;

namespace PracticalExam.Controllers
{
    public class BookController : Controller
    {
        private readonly IAll<Book> _book;

        public BookController(IAll<Book> book)
        {
            this._book = book;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _book.GetAll();

                if (data==null)
                {
                    return BadRequest();
                }

                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Book entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _book.Insert(entity);
                    await _book.CompleteAsync();
                }

                //TempData["SuccessMessage"] = "Data added successfully.";

                return View(entity);
            }
            catch (Exception)
            {
                throw;
            }

        }



        public async Task<IActionResult> Edit(int id)
        {
            var result = await _book.GetById(id);
            if (result == null)
            {
                return NotFound ();
            }

            return View(result);              
        }



        [HttpPost]
        public async Task<IActionResult> Update(Book entity)
       {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _book.Update(entity);

                    if (result)
                    {
                        await _book.CompleteAsync();
                        return RedirectToAction(nameof(Index));
                    }                 
                }

                return NotFound("Id Not Found");

            }
            catch (Exception)
            {
                throw;
            }
        }


        // Delete View
        public async Task<IActionResult> DeleteView(int id)
        {
            var result = await _book.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }



        // Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _book.Delete(id);
                if (!result)
                {
                    return BadRequest();
                }
                await _book.CompleteAsync();
                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
