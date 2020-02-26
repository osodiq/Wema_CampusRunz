using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wema.CampusRunz.Core.Configurations;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Models;
using Wema.CampusRunz.Data.Data;

namespace Wema.CampusRunz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Services
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ServiceDto serviceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new Response<string>
                    {

                        Code = "400",
                        Message = "Invalid model"
                    });
                }

                //process photo upload
                var upload = ProcessPhotos(serviceDto.UploadedImageList);
                if (upload)
                {
                    //var product = _mapper.Map<Product>(productDto);
                    // var request =  _productManger.CreateProduct(product);
                    //if (request)
                    //{
                    //    return Ok(new Response<string>
                    //    {
                    //        
                    //        Code = "201",
                    //        Message = $"You have successfully created a product with name {productDto.Name}"
                    //    });
                    //}
                    var service = new Service
                    {
                        BusinessName = serviceDto.BusinessName,
                        BusinessPhoneNumber = serviceDto.BusinessPhoneNumber,
                        BusinessDescription = serviceDto.BusinessDescription,
                        EmailAddress = serviceDto.EmailAddress,
                        Address = serviceDto.Address,
                        TwitterHandle = serviceDto.TwitterHandle,
                        InstagramHandle = serviceDto.InstagramHandle,
                    };

                    _context.Services.Add(service);
                    _context.SaveChanges();

                    return Ok(new Response<string>
                    {
                        Code = "201",
                        Message = $"You have successfully created a service with business name {serviceDto.BusinessName}"
                    });

                }

                return BadRequest(new Response<string> { Code = "400", Message = "Internal server serror" });
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return BadRequest(new Response<string> { Code = "400", Message = "Internal server serror" });
        }

        private bool ProcessPhotos(List<string> photos)
        {
            //implemetation later
            return true;
        }
    }
}
