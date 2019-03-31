using Appliances.data.Models;
using Appliances.Kernel.Framework.Modules;
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
    [RoutePrefix("api/v1/country")]
    public class CountryController : ApiController
    {
        private IRepository<Country> _countryRepository = new Repository<Country>();

        /// <summary>
        /// Get all Country
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<CountryDTO>))]
        public IHttpActionResult Get()
        {
                var countries = _countryRepository.Find(new GetAllSpecification<Country>()).OrderBy(x => x.CountryName);
                if (countries == null)
                    return NotFound();

                return Ok(countries.ToList());
        }

        /// <summary>
        /// Add Country
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<CountryDTO>))]
        public IHttpActionResult Post(CountryDTO countryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                Country country = Country.Create(countryDTO.Name,countryDTO.CountryCode,countryDTO.CountryPhoneCode);
                _countryRepository.Add(country);
                

                unitOfWork.SaveChanges();

                return Get();
            }
        }
        /// <summary>
        /// Update Country
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<CountryDTO>))]
        public IHttpActionResult Put(CountryDTO countryDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var countryRep = _countryRepository.GetById(countryDTO.Id);
                if(countryRep == null)
                {
                    return NotFound();
                }
                countryRep.Update(countryDTO.Name, countryDTO.CountryCode, countryDTO.CountryPhoneCode);
                unitOfWork.SaveChanges();

                return Ok(GetDTO(countryRep));
            }
        }

        private CountryDTO GetDTO(Country country)
        {
            CountryDTO countryDTO = new CountryDTO();
            countryDTO.Name = country.CountryName;
            countryDTO.CountryCode = country.CountryCode;
            countryDTO.CountryPhoneCode = country.CountryPhoneCode;
            return countryDTO;
        }
    }
}