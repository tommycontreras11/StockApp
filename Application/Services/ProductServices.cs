using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductServices
    {
        private readonly ProductsRepository _productsRepository;

        public ProductServices(ApplicationContext dbContext){
            _productsRepository = new (dbContext);
        }

        public async Task Add(SaveProductView vm)
        {
            Product product = new();
            product.Name = vm.Name;
            product.Description = vm.Description;
            product.Price = vm.Price;
            product.ImageUrl = vm.ImageUrl;
            product.CategoryId = vm.CategoryId;

          await _productsRepository.AddAsync(product);
        }

        public async Task Update(SaveProductView vm)
        {
            Product product = new();
            product.Id = vm.Id;
            product.Name = vm.Name;
            product.Description = vm.Description;
            product.Price = vm.Price;
            product.ImageUrl = vm.ImageUrl;
            product.CategoryId = vm.CategoryId;

            await _productsRepository.UpdateAsync(product);
        }

        public async Task<SaveProductView> GetByIdSaveViewModel(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);

            SaveProductView vm = new();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.Description = product.Description;
            vm.ImageUrl = product.ImageUrl;
            vm.Price = product.Price;
            vm.CategoryId = product.CategoryId;
            
            return vm;

           
        }
        public async Task<List<ProductViewModel>>GetAllViewModel()
        {

            var productList = await _productsRepository.GetAllAsync();
            return productList.Select(product => new ProductViewModel 
            { 
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,

            }).ToList();
        }

        public async Task Delete(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            await _productsRepository.DeleteAsync(product);
        }
    }
}
