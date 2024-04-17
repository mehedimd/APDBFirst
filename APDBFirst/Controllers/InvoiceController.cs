using APDBFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private APContext context;
        public InvoiceController(APContext _context)
        {
            this.context = _context;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
            return await context.Invoices.Where(i => i.InvoiceTotal > (i.PaymentTotal + i.CreditTotal)).ToListAsync();
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice(int id)
        //{
        //    if(context.Invoices == null)
        //    {
        //        return NotFound();
        //    }
        //    var inv = await context.Invoices.Where(i=>i.VendorId.Equals(id)).ToListAsync();

        //    if (inv == null)
        //    {
        //        return NotFound();
        //    }
        //    return inv;
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var inv = await context.Invoices.FindAsync(id);

            if (inv == null)
            {
                return NotFound();
            }
            return inv;
        }
    }
}
