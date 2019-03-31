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

namespace Appliances.data.Controllers
{
    [RoutePrefix("api/v1/product")]
    public class ProductController : ApiController
    {
        private IRepository<Product> _productRepository = new Repository<Product>();
        private IRepository<ProductCategory> _productCategoryRepository = new Repository<ProductCategory>();
        private IRepository<ProductSubCategory> _productSubCategoryRepository = new Repository<ProductSubCategory>();
        
        /// <summary>
        /// Get all Product Categories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult GetProductCategories()
        {
                var categories = _productCategoryRepository.Find(new GetAllSpecification<ProductCategory>()).OrderBy(x => x.CategoryName);
                if (categories == null)
                    return NotFound();

                return Ok(categories.ToList());
        }

        /// <summary>
        /// Add Product Categories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult PostProductCategory(ProductCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {

                ProductCategory categories = ProductCategory.Create(categoryDTO.CategoryName);
                _productCategoryRepository.Add(categories);
                unitOfWork.SaveChanges();

                return GetProductCategories();
            }
        }
        
        
        /// <summary>
        /// Update Product Categories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductCategoryDTO>))]
        public IHttpActionResult PutProductCategory(ProductCategoryDTO categoryDTO)
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
        /// Get all Product Sub-Categories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductSubCategoryDTO>))]
        public IHttpActionResult GetProductSubCategories()
        {
                var categories = _productSubCategoryRepository.Find(new GetAllSpecification<ProductSubCategory>()).OrderBy(x => x.Name);
                if (categories == null)
                    return NotFound();

                return Ok(categories.ToList());
        }

        /// <summary>
        /// Add ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductSubCategoryDTO>))]
        public IHttpActionResult PostProductSubCategories(ProductSubCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {

                ProductSubCategory categories = ProductSubCategory.Create(categoryDTO.Name,categoryDTO.BrandName,categoryDTO.OperatingSystem,categoryDTO.Description);
                _productSubCategoryRepository.Add(categories);
                unitOfWork.SaveChanges();

                return GetProductSubCategories();
            }
        }
        /// <summary>
        /// Update ProductCategories
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ProductSubCategoryDTO>))]
        public IHttpActionResult PutProductSubCategories(ProductSubCategoryDTO categoryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var categoryRep = _productSubCategoryRepository.GetById(categoryDTO.Id);
                if (categoryRep == null)
                {
                    return NotFound();
                }
                categoryRep.Update(categoryDTO.Name,categoryDTO.BrandName,categoryDTO.OperatingSystem,categoryDTO.Description);
                unitOfWork.SaveChanges();

                return Ok(GetSubCategoryDTO(categoryRep));
            }
        }

        private ProductSubCategoryDTO GetSubCategoryDTO(ProductSubCategory category)
        {
            ProductSubCategoryDTO categoryDTO = new ProductSubCategoryDTO();
            categoryDTO.Name = category.Name;
            categoryDTO.BrandName = category.BrandName;
            categoryDTO.OperatingSystem = category.OperatingSystem;
            categoryDTO.Description = category.Description;
            return categoryDTO;
        }
    }
}