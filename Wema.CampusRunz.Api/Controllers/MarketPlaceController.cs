using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wema.CampusRunz.Core.Configurations;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Data.Data;

namespace Wema.CampusRunz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarketPlaceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductManager _productManager;

        public MarketPlaceController(ApplicationDbContext context, IProductManager productManager)
        {
            _context = context;
            _productManager = productManager;
        }
        // POST: api/Products
        [HttpPost("{userId}/Product/fast-food")]
        public async Task<IActionResult> CreateFastFood([FromBody] ProductCreationDto.FastFoodDto productDto, string userId)
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
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }


                var fastFood = await _productManager.CreatFastFood(productDto, userId);
                if(fastFood != null)
                {
                    return Created("", new Response<ProductCreationDto.FastFoodDto>
                    {
                        Code = "201",
                        Message = $"You have successfully created a product with name {fastFood.Name}",
                        Data = fastFood

                    });

                }

                return BadRequest(new Response<string> { Code = "500", Message = "Internal server error" });
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return BadRequest(new Response<string> { Code = "500", Message = "Internal server error" });
        }


        //Gass Refill
        // POST: api/Products
        [HttpPost("{userId}/Product/gass-refill")]
        public async Task<IActionResult> RefillGass(ProductCreationDto.GasRefillDto productDto, string userId)
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
                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }


                ProductCreationDto.GasRefillDto refilledGass = await _productManager.CreateGasRefill(productDto, userId);
                if(refilledGass != null)
                {
                    return Created("", new Response<ProductCreationDto.GasRefillDto>
                    {
                        Code = "201",
                        Message = $"You have successfully created a product with name {refilledGass.Name}",
                        Data = refilledGass

                    });
                }
               
                return BadRequest(new Response<string> { Code = "500", Message = "Internal server error" });
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return BadRequest(new Response<string> { Code = "500", Message = "Internal server error" });
            }
            
        }
        
        // POST: api/Products
        [HttpPost("{userId}/Product/hotel")]
        public async Task<IActionResult> CreatHotel([FromBody] ProductCreationDto.HotelDto productDto, string userId)
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

                if (userId != User.FindFirst("id").Value)
                {
                    return Unauthorized();
                }

                var createdHotel = await _productManager.CreateHotel(productDto, userId);
                if(createdHotel != null)
                {
                    return Created("", new Response<ProductCreationDto.HotelDto>
                    {
                        Code = "201",
                        Message = $"You have successfully created a product with name {createdHotel.Name}",
                        Data = createdHotel

                    });
                }
                
                return BadRequest(new Response<string> { Code = "500", Message = "Internal server serror" });
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return BadRequest(new Response<string> { Code = "500", Message = "Internal server serror" });
            }
            
        }

        // POST: api/Products
        [HttpGet("Product")]
        public async Task<IActionResult> ProductById(int productId, string category)
        {
            try
            {
                GetProductDTO product = await _productManager.GetProductById(productId, category);
                if(product == null)
                {
                    return BadRequest(new Response<string>
                    {
                             Code = "404",
                             Message = "Product not found."
                    });
                }
                else
                {
                    return Ok(new 
                    {
                        Code = "200",
                        Data = product
                    });

                    
                }

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return BadRequest(new Response<string> { Code = "500", Message = "Internal server error" });
            }
            
        }

        
    }
}
