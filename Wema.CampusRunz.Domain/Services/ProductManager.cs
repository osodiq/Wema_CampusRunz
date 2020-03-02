using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Core.Models;
using Wema.CampusRunz.Data.Data;

namespace Wema.CampusRunz.Domain.Services
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly ApplicationDbContext _context;

        public ProductManager(IRepository<Product> productRepository, ApplicationDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task<ProductCreationDto.HotelDto> CreateHotel(ProductCreationDto.HotelDto model, string userId)
        {
           
                Product productToCreate = new Product
                {
                    Category = model.Category,
                    Name = model.Name,
                    Description = model.Description,
                    ConvinienceFee = model.ConvinienceFee,
                    Address = model.Address,
                    UserId = userId,
                    Images = JsonConvert.SerializeObject(model.Images),

                };

                var productCategories = new List<ProductCategory>();
                foreach (var item in model.HotelCategories)
                {
                    productCategories.Add(new ProductCategory { ProductId = productToCreate.Id, Category = item.Category, Amount = item.Amount });
                };
                _context.Products.Add(productToCreate);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
           

        }

       

        public async Task<ProductCreationDto.EventTicketDto> CreateEventTicket(ProductCreationDto.EventTicketDto model, string userId)
        {
                Product productToCreate = new Product
                {
                    Category = model.Category,
                    Name = model.Name,
                    Description = model.Description,
                    Address = model.Venue,
                    ConvinienceFee = model.ConvinienceFee,
                    EventDate = model.EventDate,
                    EventTime = model.EventTime,
                    UserId = userId,
                    Images = JsonConvert.SerializeObject(model.UploadedImageList)

                };

                var productCategories = new List<ProductCategory>();
                foreach (var item in model.EventCategories)
                {
                    productCategories.Add(new ProductCategory { ProductId = productToCreate.Id, Category = item.Category, Amount = item.Amount });
                };

                _context.Products.Add(productToCreate);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
           
        }

        public async Task<ProductCreationDto.GasRefillDto> CreateGasRefill(ProductCreationDto.GasRefillDto model, string userId)
        {
            var gass = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if (gass == null)
            {
                Product productToCreate = new Product
                {
                    Category = model.Category,
                    Name = model.Name,
                    Amount = model.Amount,
                    Description = model.Description,
                    ConvinienceFee = model.ConvinienceFee,
                    Images = JsonConvert.SerializeObject(model.UploadedImageList),
                    UserId = userId

                };
                _context.Products.Add(productToCreate);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
            }
            return null;

        }


        public async Task<ProductCreationDto.FastFoodDto> CreatFastFood(ProductCreationDto.FastFoodDto model, string userId)
        {
           
                Product productToCreate = new Product
                {
                    Address = model.Address,
                    Category = model.Category,
                    Name = model.Name,
                    Amount = model.Amount,
                    Vendor = model.Vendor,
                    Description = model.Description,
                    ConvinienceFee = model.ConvinienceFee,
                    Images = JsonConvert.SerializeObject(model.UploadedImageList),
                    UserId = userId
                };
                _context.Products.Add(productToCreate);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
          

        }

        public async Task<GetProductDTO> GetProductById(int productId, string category)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && x.Category == category);
            if(product == null)
            {
                return null;
            }
            else
            {
                GetProductDTO productToReturn = new GetProductDTO
                {
                  ProductId = product.Id,
                  Address = product.Address,
                  Vendor = product.Vendor,
                  Visibility = product.Visibility,
                  Category = product.Category,
                  Name = product.Name,
                  ConvinienceFee = product.ConvinienceFee,
                  Amount = product.Amount,
                  CreatedAt = product.CreatedAt,
                  Description = product.Description
                  
                };
                return productToReturn;
            }
        }


        public async Task<List<GetFastFoodDto>> GetGasRefill()
        {
            var result = _context.Products.Where(x => x.Category.ToLower().Equals("fast food")).ToList()
                .Select(x => new GetFastFoodDto
                {
                    ProductId = x.Id,
                    Category = x.Category,
                    Name = x.Name,
                    Amount = x.Amount,
                    Vendor = x.Vendor,
                    Visibility = x.Visibility,
                    Image = JsonConvert.DeserializeObject<List<string>>(x.Images).FirstOrDefault(),
                    CreatedAt = x.CreatedAt
                }).ToList();

            return result;
        }


        public async Task<GetFastFoodByIdDto> GetFastFoodById(int productId)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Category.ToLower().Equals("fast food") && x.Id == productId);

            if (result == null)
            {
                return null;
            }
            var model = new GetFastFoodByIdDto
            {
                ProductId = result.Id,
                Category = result.Category,
                Name = result.Name,
                Amount = result.Amount,
                Vendor = result.Vendor,
                Address = result.Address,
                Description = result.Description,
                ConvenienceFee = result.ConvinienceFee.ToString(),
                Visibility = result.Visibility,
                UploadedImageList = JsonConvert.DeserializeObject<List<string>>(result.Images),
                CreatedAt = result.CreatedAt
            };

            return model;
        }

    }
}
