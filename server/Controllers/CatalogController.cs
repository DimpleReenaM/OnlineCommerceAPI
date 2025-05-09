﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalogService;
        private readonly IMapper mapper;

        public CatalogController(ICatalogService catalogService, IMapper mapper)
        {
            this.catalogService = catalogService;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("product/getall")]
        public async Task<ActionResult<ResponseDto>> GetAllProducts(CatalogSpec req)
        {
            ResponseDto response = new ResponseDto();

            ProductPagination res = await catalogService.GetAllProducts(req);

            response.Data = new ProductPaginationRes()
            {
                PageIndex = res.PageIndex,
                PageSize = res.PageSize,
                Data = mapper.Map<IReadOnlyList<ProductResDto>>(res.Data),
                Count = res.Count,
                MinPrice = res.MinPrice,
                MaxPrice = res.MaxPrice,
            };




            return Ok(response);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ResponseDto>> GetProduct(int productId)
        {
            ResponseDto response = new ResponseDto();

            Product? product = await catalogService.GetProductById(productId);

            response.Data = mapper.Map<ProductResDto>(product);

            return Ok(response);
        }

        [HttpPost]
        [Route("product/create")]
        public async Task<ActionResult> CreateProducts( CreateProductReq newProduct)
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");

            if (newProduct.CreatedBy == 0)
            {
                newProduct.CreatedBy = userId;
            }

            Product product = await catalogService.CreateProduct(newProduct);


            ResponseDto response = new ResponseDto();
            response.Data = product;
            return Ok(response);
        }



        [HttpGet]
        [Route("product/myprodcts/{userId}")] // Added "product/" to match Angular request
        public async Task<ActionResult<ResponseDto>> GetMyProducts(int userId)
        {
            ResponseDto response = new ResponseDto();
            var products = await catalogService.GetProductsByUserId(userId);
            response.Data = mapper.Map<IEnumerable<ProductResDto>>(products);
            return Ok(response);
        }




        [HttpDelete]
        [Route("product/delete/{productId}")]
        public async Task<ActionResult<ResponseDto>> DaleteProducts(int productId)
        {
            ResponseDto response = new ResponseDto();
            await catalogService.DeleteProduct(productId);
            return Ok(response);
        }



        #region category api
        [HttpGet]
        [Route("category/getall")]
        public async Task<ActionResult<ResponseDto>> GetAllCategories()
        {
            ResponseDto response = new ResponseDto();

            IEnumerable<Category> categories = await catalogService.GetAllCategery();

            response.Data = mapper.Map<IEnumerable<CategoryResDto>>(categories);

            return Ok(response);
        }

        [HttpPost]
        [Route("category/create")]
        public async Task<ActionResult> CreateCategory(CreateCategoryReq newCategory)
        {
            Category category = await catalogService.CreateCategery(newCategory);
            ResponseDto response = new ResponseDto();
            response.Data = category;
            return Ok(response);
        }


        [HttpDelete]
        [Route("category/delete/{categorytId}")]
        public async Task<ActionResult<ResponseDto>> DaleteCategory(int categorytId)
        {
            ResponseDto response = new ResponseDto();
            await catalogService.DeleteCategery(categorytId);
            return Ok(response);
        }

        #endregion


        #region Brand api
        [HttpGet]
        [Route("brand/getall")]
        public async Task<ActionResult<ResponseDto>> GetAllBrands()
        {
            ResponseDto response = new ResponseDto();

            IEnumerable<Brand> brands = await catalogService.GetAllBrand();

            foreach (var brand in brands)
            {
                Console.WriteLine($"Brand: {brand.Name}, Image URL: {brand.Image?.Url}");
            }
            response.Data = mapper.Map<IEnumerable<BrandResDto>>(brands);

            return Ok(response);
        }

        [HttpPost]
        [Route("brand/create")]
        public async Task<ActionResult> CreateBrand(CreateBrandReq newBrand)
        {
            Brand brand = await catalogService.CreateBrand(newBrand);
            ResponseDto response = new ResponseDto();
            response.Data = brand;
            return Ok(response);
        }


        [HttpDelete]
        [Route("brand/delete/{brandId}")]
        public async Task<ActionResult<ResponseDto>> DaleteBrand(int brandId)
        {
            ResponseDto response = new ResponseDto();
            await catalogService.DeleteBrand(brandId);
            return Ok(response);
        }

        #endregion
    }
}
