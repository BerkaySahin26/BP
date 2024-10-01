using System;
using BP.Api.Data.Models;
using BP.Api.Models;
using BP.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BP.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;
        private readonly ILogger <ContactController> logger;

        public ContactController(IConfiguration Configuration,IContactService ContactService,ILogger <ContactController>logger)
        {
            configuration = Configuration;
            contactService = ContactService;
            this.logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            logger.LogInformation("get method is LogInformation");
            logger.LogWarning("get method is LogWarning");
            logger.LogTrace("get method is LogTrace");
            logger.LogError("get method is LogError");
            logger.LogDebug("get method is LogDebug");

            return configuration["ReadMe"].ToString();
        }

        [ResponseCache(Duration = 10)]

        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }


        [HttpPost]
        public ContactDVO CreateContact(ContactDVO Contact)
        {
            return Contact;
         
        }
    }
}
