﻿using EmreSenturk.WebApiDemo.DataAccess;
using EmreSenturk.WebApiDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmreSenturk.WebApiDemo.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductId == productId);
                if (product == null)
                {
                    return NotFound($"There is no product with Id = {productId}");
                }
                return Ok(product);
            }
            catch
            { }
            return BadRequest();
        }

        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch
            {


            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch
            {


            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId });
                return Ok();
            }
            catch
            {


            }
            return BadRequest();
        }

        [HttpGet("GetProductDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
                var result = _productDal.GetProductWithDetails();
                return Ok(result);
            }
            catch
            {


            }
            return BadRequest();
        }
    }
}
