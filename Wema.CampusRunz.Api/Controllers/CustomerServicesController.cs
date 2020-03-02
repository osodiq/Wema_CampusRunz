using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize/*(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)*/]
    public class CustomerServicesController : ControllerBase
    {
        private readonly ICustomerService _customerServices;
        private readonly ILogger<CustomerServicesController> _logger;

        public CustomerServicesController(ICustomerService customerServices, ILogger<CustomerServicesController> logger)
        {
            _customerServices = customerServices;
            _logger = logger;
        }

        [HttpPost("{userId}/{productId}/refill-gass")]
        public async Task<IActionResult> OrderForGassRefill(int productId, string userId, string deliveryAddress)
        {
            try
            {
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }

                var gassRefillOrder = await _customerServices.CreateGassRefillOrder(productId, userId, deliveryAddress);
                if (gassRefillOrder == null)
                {
                    return BadRequest(new { Code = "400", Message = "Oops!, An Error Occured." });
                }
                return Created("", new { Code = "201", data = gassRefillOrder });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return StatusCode(500, new { Message = "Internal Server Error"});
                
            }
        }

        [HttpPost("{userId}/{productId}/media-order")]
        public async Task<IActionResult> CreateMediaAndProductionOrder(int productId, string userId, OrderDTO.MediaOrderDto mediaOrderDto)
        {
            try
            {
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }


                var mediaOrder = await _customerServices.CreateMediaOrder(productId, userId, mediaOrderDto);
                if (mediaOrder == null)
                {
                    return BadRequest(new { Code = "400", Message = "Oops!, An Error Occured." });
                }
                return Created("", new { Code = "201", data = mediaOrder });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return StatusCode(500, new { Message = "Internal Server Error" });

            }

        }

        [HttpPost("{userId}/{productId}/hotel-order")]
        public async Task<IActionResult> BookHotel(int productId, string userId, List<OrderCategory> orderCategoryVm)
        {
            try
            {
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }


                var hotelOrder = await _customerServices.CreateHotelOrder(productId, userId, orderCategoryVm);
                if (hotelOrder == null)
                {
                    return BadRequest(new { Code = "400", Message = "Oops!, An Error Occured." });
                }
                return Created("", new { Code = "201", data = hotelOrder });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return StatusCode(500, new { Message = "Internal Server Error" });

            }
        }

        [HttpPost("{userId}/{productId}/ticket-order")]
        public async Task<IActionResult> BuyEventTicket(int productId, string userId, [FromBody]List<OrderCategory> orderCategoryVm)
        {
            try
            {
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }

                var ticketOrder = await _customerServices.CreateEventTicketOrder(productId, userId, orderCategoryVm);
                if (ticketOrder == null)
                {
                    return BadRequest(new { Code = "400", Message = "Oops!, An Error Occured." });
                }
                return Created("", new { Code = "201", data = ticketOrder });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return StatusCode(500, new { Message = "Internal Server Error" });

            }

        }

        [HttpPost("{userId}/{productId}/food-order")]
        public async Task<IActionResult> OderFastFood(int productId, string userId, OrderDTO.FastFood fastFoodDto)
        {
            try
            {
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }

                var foodOrder = await _customerServices.OrderFastFood(productId, userId, fastFoodDto);
                if (foodOrder == null)
                {
                    return BadRequest(new { Code = "400", Message = "Oops!, An Error Occured." });
                }
                return Created("", new { Code = "201", data = foodOrder });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return StatusCode(500, new { Message = "Internal Server Error" });

            }

        }


    }
}