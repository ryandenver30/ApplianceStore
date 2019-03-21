using Appliances.data.Models;
using Appliances.data.Models.ProductManagement;
using Appliances.Kernel.Framework.Modules.ProductManagement;
using Appliances.Kernel.Framework.Repository;
using Appliances.Kernel.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Product = Appliances.Kernel.Framework.Modules.ProductManagement.Product;
using ProductSubCategory = Appliances.Kernel.Framework.Modules.ProductManagement.ProductSubCategory;

namespace Appliances.data.Controllers
{
    [RoutePrefix("api/v1/product")]
    public class ProductController : ApiController
    {
        private IRepository<Product> _productRepository = new Repository<Product>();
        private IRepository<ProductSubCategory> _productSubCategoryRepository = new Repository<ProductSubCategory>();
        
        /// <summary>
        /// Get all ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Get()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {

                var categories = _productCategoryRepository.Find(new GetAllSpecification<ProductCategory>()).OrderBy(x => x.CategoryName);
                if (categories == null)
                    return NotFound();

                return Ok(categories.ToList());
            }
        }

        /// <summary>
        /// Add ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Post(ProductCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {

                ProductCategory categories = ProductCategory.Create(categoryDTO.CategoryName);
                _productCategoryRepository.Add(categories);
                unitOfWork.SaveChanges();

                return Get();
            }
        }
        /// <summary>
        /// Update ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Put(ProductCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var categoryRep = _productCategoryRepository.GetById(categoryDTO.Id);
                if (categoryRep == null)
                {
                    return NotFound();
                }
                categoryRep.Update(categoryDTO.CategoryName);
                unitOfWork.SaveChanges();

                return Ok(GetCategoryDTO(categoryRep));
            }
        }

        private ProductCategoryDTO GetCategoryDTO(ProductCategory category)
        {
            ProductCategoryDTO categoryDTO = new ProductCategoryDTO();
            categoryDTO.CategoryName = category.CategoryName;
            return categoryDTO;
        }

        /// <summary>
        /// Get all ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Get()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {

                var categories = _productCategoryRepository.Find(new GetAllSpecification<ProductCategory>()).OrderBy(x => x.CategoryName);
                if (categories == null)
                    return NotFound();

                return Ok(categories.ToList());
            }
        }

        /// <summary>
        /// Add ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Post(ProductCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {

                ProductCategory categories = ProductCategory.Create(categoryDTO.CategoryName);
                _productCategoryRepository.Add(categories);
                unitOfWork.SaveChanges();

                return Get();
            }
        }
        /// <summary>
        /// Update ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult Put(ProductCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var categoryRep = _productCategoryRepository.GetById(categoryDTO.Id);
                if (categoryRep == null)
                {
                    return NotFound();
                }
                categoryRep.Update(categoryDTO.CategoryName);
                unitOfWork.SaveChanges();

                return Ok(GetCategoryDTO(categoryRep));
            }
        }

        private ProductCategoryDTO GetCategoryDTO(ProductCategory category)
        {
            ProductCategoryDTO categoryDTO = new ProductCategoryDTO();
            categoryDTO.CategoryName = category.CategoryName;
            return categoryDTO;
        }
    }
}