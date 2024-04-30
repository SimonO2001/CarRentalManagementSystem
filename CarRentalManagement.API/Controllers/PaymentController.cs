// Controllers/PaymentController.cs
using Microsoft.AspNetCore.Mvc;
using CarRentalManagement.Repository.Interfaces;
using CarRentalManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return Ok(await _paymentRepository.GetAllPaymentsAsync());
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _paymentRepository.AddPaymentAsync(payment);
            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            await _paymentRepository.UpdatePaymentAsync(payment);
            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
