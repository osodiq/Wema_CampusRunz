using Microsoft.EntityFrameworkCore;
using System;
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
            var hotel = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if(hotel == null)
            {
                Product productToCreate = new Product
                {
                    Category = model.Category,
                    Name = model.Name,
                    Description = model.Description,
                    ConvinienceFee = model.ConvinienceFee,
                    Address = model.Address,
                    ProductCatory = model.HotelCategories,
                    Images = model.Images,
                    UserId = userId
                };
                _context.Products.Add(productToCreate);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
            }
            return null;

        }

       

        public async Task<ProductCreationDto.EventTicketDto> CreateEventTicket(ProductCreationDto.EventTicketDto model, string userId)
        {
           var ticket = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if(ticket == null)
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
                    ProductCatory = model.EventCategory,
                    Images = model.Images,
                    UserId = userId

                };
                _context.Products.Add(productToCreate);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return model;
                }
                return null;
            }
            return null;
        }

        public async Task<ProductCreationDto.GassRefillDto> CreateGassRefill(ProductCreationDto.GassRefillDto model, string userId)
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
                    Images = model.Images,
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

        public bool CreateProduct(Product product)
        {
            try
            {
                _productRepository.Insert(product);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductCreationDto.FastFoodDto> CreatFastFood(ProductCreationDto.FastFoodDto model, string userId)
        {
            var fastFood = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if (fastFood == null)
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
                    Images = model.Images,
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
    }
}
