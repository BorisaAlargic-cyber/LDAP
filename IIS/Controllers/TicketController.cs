using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using IIS.Model;
using IIS.Model.Request;
using IIS.Repository;
using IIS.Service;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : DefaultController
    {
        TicketService service = new TicketService();
        private readonly IConverter _converter;

        public TicketController(IConfiguration config, IConverter converter) : base(config)
        {
            _converter = converter;
        }

        [HttpPost]
        [Route("/api/tickets")]
        public async Task<IActionResult> AddTicket(AddTicketRequest ticketData)
        {
            Ticket ticket = service.CreateTicket(ticketData);

            if(ticket == null)
            {
                return BadRequest();
            }

            return Ok(ticket);
        }

        [HttpPut]
        [Route("/api/tickets")]
        public async Task<IActionResult> EditTicket(AddTicketRequest ticketData)
        {
            Ticket ticket = service.EditTicket(ticketData);

            if (ticket == null)
            {
                return BadRequest();
            }

            return Ok(ticket);
        }

        [HttpGet]
        [Route("/api/tickets/get-all")]
        public async Task<IActionResult> AllTickets()
        {
            IEnumerable<Ticket> tickets = service.GetAllTickets();

            if(tickets == null)
            {
                return BadRequest();
            }

            return Ok(tickets);
        }

        [HttpPost]
        [Route("/api/tickets/search-tickets")]
        public async Task<IActionResult> SearchFlights(SearchFlightTicket data)
        {
            IEnumerable<Ticket> tickets = service.SearchTicket(data);

            if(tickets == null)
            {
                return BadRequest();
            }

            return Ok(tickets);
        }

        [HttpPost]
        [Route("/api/tickets/create-purcheser")]
        public async Task<IActionResult> CreatePurcheser(PurcheserRequest data)
        {
            Purcheser purcheser = service.CreatePurcheser(data);

            if(purcheser == null)
            {
                return BadRequest();
            }

            return Ok(purcheser);
        }

        [HttpDelete]
        [Route("/api/tickets/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            service.DeleteTicket(id);

            return Ok();
        }

        [HttpGet]
        [Route("/api/tickets/pdf/{id}")]
        public IActionResult GetPDF(int id)
        {
            var pdfFile = GenerateReport(id);
            return File(pdfFile,
            "application/octet-stream", "Ticket.pdf");
        }

        private byte[] GenerateReport(int id)
        {
            
            using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
            {
                Ticket ticket = unitOfWork.Tickets.GetTicket(id);

                var stream = new MemoryStream();
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                document.Add(new Paragraph("Company: " + ticket.AirCompany));
                document.Add(new Paragraph("From: " + ticket.From.Name));
                document.Add(new Paragraph("To: " + ticket.To.Name));
                document.Add(new Paragraph("Date departue: " + ticket.DateOfDeparture.ToLongDateString()));
                document.Add(new Paragraph("Date arraiving: " + ticket.DateOfArrival.ToLongDateString()));
                document.Add(new Paragraph("Price: " + ticket.Price));
                document.Add(new Paragraph("Number: " + ticket.TicketNumber));
                document.Close();
                return stream.ToArray();
            }

        }

    }
}
