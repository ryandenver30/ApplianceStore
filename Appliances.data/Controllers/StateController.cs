﻿using Appliances.data.Models;
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
    [RoutePrefix("api/v1/state")]
    public class StateController : ApiController
    {
        private IRepository<State> _stateRepository = new Repository<State>();
        private IRepository<Country> _countryRepository = new Repository<Country>();

        /// <summary>
        /// Get all State
        /// </summary>
        /// <param name="organizerId"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<StateDTO>))]
        public IHttpActionResult Get()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {
                var states = _stateRepository.Find(new GetAllSpecification<State>()).OrderBy(x => x.StateName);
                if (states == null)
                    return NotFound();

                return Ok(states.ToList());
            }
        }
        /// <summary>
        /// Add State
        /// </summary>
        /// <param name="organizerId"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(List<StateDTO>))]
        public IHttpActionResult Post(Guid countryId ,StateDTO stateDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var country = _countryRepository.GetById(countryId);
                if (country == null)
                    return NotFound();

                var state = State.Create(stateDTO.StateName,stateDTO.StateCode);
                state.Country = country;
                _stateRepository.Add(state);
                unitOfWork.SaveChanges();
                return Get();
            }
        }

        /// <summary>
        /// Update State
        /// </summary>
        /// <param name="organizerId"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(StateDTO))]
        public IHttpActionResult Put(StateDTO stateDTO)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var state = _stateRepository.GetById(stateDTO.Id);
                if (state == null)
                    return NotFound();
                state.Update(stateDTO.StateName, stateDTO.StateCode);
                unitOfWork.SaveChanges();
                return Ok(GetDTO(state));
            }
        }

        private StateDTO GetDTO(State state)
        {
            StateDTO stateDTO = new StateDTO();
            stateDTO.StateName = state.StateName;
            stateDTO.StateCode = state.StateCode;
            return stateDTO;
        }

    }
}