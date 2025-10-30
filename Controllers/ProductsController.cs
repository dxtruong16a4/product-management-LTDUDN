using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: Products
    public async Task<IActionResult> Index(string? searchTerm, int pageNumber = 1)
    {
        const int pageSize = 5;
        var pagedResult = await _service.GetPagedAsync(pageNumber, pageSize, searchTerm);
        
        ViewData["CurrentFilter"] = searchTerm;
        ViewData["CurrentPage"] = pageNumber;
        
        return View(pagedResult);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _service.GetByIdAsync(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock,Description")] ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateAsync(productDto);
            TempData["SuccessMessage"] = $"Product '{productDto.Name}' has been created successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(productDto);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _service.GetByIdAsync(id.Value);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock,Description")] ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(productDto);
            TempData["SuccessMessage"] = $"Product '{productDto.Name}' has been updated successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(productDto);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _service.GetByIdAsync(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product != null)
        {
            await _service.DeleteAsync(id);
            TempData["SuccessMessage"] = $"Product '{product.Name}' has been deleted successfully!";
        }
        return RedirectToAction(nameof(Index));
    }
}
