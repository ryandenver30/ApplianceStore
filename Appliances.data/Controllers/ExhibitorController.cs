using Appliances.data.Models.StoreManagement;
using Appliances.Kernel.Framework.Modules;
using Appliances.Kernel.Framework.Modules.StoreManagement;
using Appliances.Kernel.Framework.Repository;
using Appliances.Kernel.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Appliances.data.Controllers
{
    [RoutePrefix("api/v1/exhibitor")]
    public class ExhibitorController : ApiController
    {
        private IRepository<State> _stateRepository = new Repository<State>();
        private IRepository<Country> _countryRepository = new Repository<Country>();
        private IRepository<ExhibitorStore> _exhibitorStoreRepository = new Repository<ExhibitorStore>();
        private IRepository<ExhibitorAddress> _exhibitorStoreAddressRepository = new Repository<ExhibitorAddress>();

        /// <summary>
        /// Get all Exhibitor Stores
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ExhibitorStoreDTO>))]
        public IHttpActionResult GetExhibitor()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {
                var stores = _exhibitorStoreRepository.Find(new GetAllSpecification<ExhibitorStore>()).OrderBy(x => x.Name); ;
                if (stores == null)
                    return NotFound();

                return Ok(stores.ToList());
            }
        }

        /// <summary>
        /// Add stores
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ExhibitorStoreDTO>))]
        public IHttpActionResult Post(ExhibitorStoreDTO storeDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                ExhibitorStore store = ExhibitorStore.Create(storeDTO.Name, storeDTO.WebsiteURL);
                _exhibitorStoreRepository.Add(store);
                foreach (ExhibitorAddressDTO address in storeDTO.ExhibitorAddresses)
                {
                    ExhibitorAddress _address = ExhibitorAddress.Create(address.Address, address.ZipCode, address.PhoneNo, address.OfficeNo, address.ExhibitorName, address.EmailId, address.Location);
                    var state = _stateRepository.GetById(address.State.Id);
                    _address.State = state;
                    var country = _countryRepository.GetById(address.Country.Id);
                    _address.Country = country;
                    _address.Exhibitor = store;
                    _exhibitorStoreAddressRepository.Add(_address);
                }

                unitOfWork.SaveChanges();

                return GetExhibitor();
            }
        }
        /// <summary>
        /// Update Store
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<ExhibitorStoreDTO>))]
        public IHttpActionResult Put(ExhibitorStoreDTO storeDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var storeRep = _exhibitorStoreRepository.GetById(storeDTO.Id);
                if (storeRep == null)
                {
                    return NotFound();
                }
                storeRep.Update(storeDTO.Name, storeDTO.WebsiteURL);
                unitOfWork.SaveChanges();

                return Ok(GetDTO(storeRep));
            }
        }

        /// <summary>
        /// Get Nearby Stores
        /// </summary>
        /// <returns></returns>
        [Route("GetNearbyStore")]
        [ResponseType(typeof(List<ExhibitorStore>))]
        public IHttpActionResult GetNearbyStores(string location)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {
                DbGeography userLocation = DbGeography.FromText(location);
                var criteria = new ExhibitorStoreCriteria { location = userLocation };
                var specification = new ExhibitorStoreSpecification(criteria);
                var addresses = _exhibitorStoreAddressRepository.Find(new GetAllSpecification<ExhibitorAddress>()).OrderBy(x => x.Location.Distance(userLocation));
                List<ExhibitorStoreDTO> storesDTO = new List<ExhibitorStoreDTO>();
                foreach (ExhibitorAddress address in addresses)
                {
                    var exhibitorStore = _exhibitorStoreRepository.GetById(address.Exhibitor.Id);
                    var storeDTO = GetStoreDTO(exhibitorStore,address);
                    storesDTO.Add(storeDTO);
                }

                return Ok(storesDTO);
            }
        }


        private ExhibitorStoreDTO GetDTO(ExhibitorStore storeRep)
        {
            ExhibitorStoreDTO storeDTO = new ExhibitorStoreDTO();
            storeDTO.Id = storeRep.Id;
            storeDTO.Name = storeRep.Name;
            storeDTO.WebsiteURL = storeRep.WebsiteURL;
            return storeDTO;
        }

        private ExhibitorStoreDTO GetStoreDTO(ExhibitorStore store,ExhibitorAddress address)
        {
            ExhibitorStoreDTO storeDTO = new ExhibitorStoreDTO();
            storeDTO.Id = store.Id;
            storeDTO.Name = store.Name;
            storeDTO.WebsiteURL = store.WebsiteURL;

            ExhibitorAddressDTO addressDTO = new ExhibitorAddressDTO();
            addressDTO.Id = address.Id;
            addressDTO.Address = address.Address;
            addressDTO.EmailId = address.EmailId;
            addressDTO.ExhibitorName = address.ExhibitorName;
            addressDTO.OfficeNo = address.OfficeNo;
            addressDTO.PhoneNo = address.PhoneNo;
            addressDTO.ZipCode = address.ZipCode;

            storeDTO.ExhibitorAddresses.Add(addressDTO);
            return storeDTO;
        }

        private IList<ExhibitorStoreDTO> GetDTO(IList<ExhibitorStore> storeReps)
        {
            IList<ExhibitorStoreDTO> exhibitorStores = new List<ExhibitorStoreDTO>();
            foreach (ExhibitorStore store in storeReps)
            {
                ExhibitorStoreDTO storeDTO = new ExhibitorStoreDTO();
                storeDTO.Name = store.Name;
                storeDTO.WebsiteURL = store.WebsiteURL;
                exhibitorStores.Add(storeDTO);
            }
            return exhibitorStores;
        }


    }
}