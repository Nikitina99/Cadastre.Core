using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cadastre.Core.Models;
using Cadastre.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using ClientDb = Cadastre.Core.DataAccess.Entities.Client;
using ClientDto = Cadastre.Core.Models.Client;
using Cadastre.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace Cadastre.Core.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly AppDBContext _appDBContext;

        public ClientController(ILogger<ClientController> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }
       
        
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetData")]
        public ActionResult GetData()
        {
            List<ClientDto> clientList = _appDBContext.Clients.ToList().Select(x => x.ToDto()).ToList();
            return Json(new { data = clientList });           
        }


        [Route("Add")]
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            return View(new Client());
        }

        [Route("Edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
             var record = _appDBContext.Clients.Where(x => x.Id == id).FirstOrDefault().ToDto();
             return View(record);

        }

        [Route("Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ClientDto client)
        {
            if (ModelState.IsValid) { 
                     _appDBContext.Clients.Add(client.ToEntity());
                     await _appDBContext.SaveChangesAsync();
            }

           return Json(new { success = true, message = "Запись сохранена успешно" });            
        }

        [Route("Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientDto client)
        {
            if (ModelState.IsValid)
            {
                var record = _appDBContext.Clients.Where(x => x.Id == client.ClientId).FirstOrDefault();
                record.INN = client.INN;
                record.IsBlackListed = client.IsBlackListed;
                record.LegalAddress = client.LegalAddress;
                record.MailingAddress = client.MailingAddress;
                record.Name = client.ClientName;
                record.ActualAddress = client.ActualAddress;
                record.Type = client.TypeClient;
                record.Country = client.Country;


                _appDBContext.Clients.Update(record);
                await _appDBContext.SaveChangesAsync();
            }
                return Json(new { success = true, message = "Запись изменена успешно" });
            
        }
    }
}


