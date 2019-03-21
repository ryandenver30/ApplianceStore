using Appliances.data.Models.ProductManagement;
using Appliances.Kernel.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Appliances.data.Controllers
{
    [RoutePrefix("api/v1/productSubCategory")]
    public class ProductSubCategoryController : ApiController
    {
        private IRepository<ProductSubCategory> _productSubCategoryRepository = new Repository<ProductSubCategory>();
    }
}