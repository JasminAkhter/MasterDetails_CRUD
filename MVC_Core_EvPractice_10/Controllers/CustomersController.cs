using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Core_EvPractice_10.Models;

public class CustomersController : Controller
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Customers.ToListAsync());
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        // New
        var customers = await _context.Customers.Include(x => x.DeliveryAddresses).ToListAsync();

        ViewBag.EditCustomer = customer; // Pass selected customer for editing

        return View("Index", customers);

        //return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // New
                var existingCustomer = await _context.Customers.Include(c => c.DeliveryAddresses).FirstOrDefaultAsync(c => c.CustomerId == id);

                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);

                if (existingCustomer.DeliveryAddresses != null)
                {
                    _context.DeliveryAddresses.RemoveRange(existingCustomer.DeliveryAddresses);
                }

                if (customer.DeliveryAddresses != null && customer.DeliveryAddresses.Any())
                {
                    existingCustomer.DeliveryAddresses = customer.DeliveryAddresses;
                }
                // New

                //_context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.CustomerId == id);
    }
}