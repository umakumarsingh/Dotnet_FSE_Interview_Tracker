using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Microservice.Entities;
using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IInterviewTrackerServices
        /// and injecting Referance into constructor
        /// </summary>
        private readonly IInterviewTrackerServices _interviewTS;
        public DashboardController(IInterviewTrackerServices interviewTrackerServices)
        {
            _interviewTS = interviewTrackerServices;
            
        }
        //Get All Appliaction User on Load of API or calling this method
        // GET: api/User/GetBlogPost
        [HttpGet]
        public async Task<IEnumerable<UserInterview>> AllInterviewAsync()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Post method of AddNewInterview, to create a new interview
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddInterview")]
        public async Task<IActionResult> AddNewInterview([FromBody] AddInterviewViewModel model)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete a Interview from MongoDb Collection
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteInterview/{InterviewId}")]
        public async Task<IActionResult> DeleteInterview(string InterviewId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Interview
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <param name="interview"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpPut]
        [Route("Updateinterview/{InterviewId}")]
        public async Task<IActionResult> Updateinterview(string InterviewId, [FromBody] UserInterview interview)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a Interview by InterviewId
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpGet]
        [Route("Getinterview/{InterviewId}")]
        public async Task<IActionResult> Getinterview(string InterviewId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find a Interview by passing Interview name and Interviewer Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Searchinterview/{Name}")]
        public async Task<IActionResult> SearchInterview(string name)
        {
            //Do Code Here
            throw new NotImplementedException();

        }
        /// <summary>
        /// Get Total no of Interview in Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TotalInterview")]
        public IActionResult TotalInterview()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
