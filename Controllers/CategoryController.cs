using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels.ProductViewModels;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category>Get()
        {
            return _repository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            //Find() ainda não suporta AsNoTracking
            return _repository.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Category> GetProducts(int id)
        {
            return _repository.GetProduts(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public ResultViewModel Post([FromBody]Category category)
        {
            _repository.Save(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = category
            };
        }

        [Route("v1/categories")]
        [HttpPut]
        public ResultViewModel Put ([FromBody]Category category)
        {
            _repository.Update(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = category
            };
        }

        [Route("v1/categories")]
        [HttpDelete]
        public ResultViewModel Delete ([FromBody]Category category)
        {
            _repository.Delete(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto excluído com sucesso!",
                Data = category
            };
        }
    }
}