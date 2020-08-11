using Interview.Microservice.Entities;
using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services
{
    public class InterviewTrackerServices : IInterviewTrackerServices
    {/// <summary>
     /// creating a referance object of IInterviewTrackerRepository
     /// </summary>
        private readonly IInterviewTrackerRepository _interviewTR;

        /// <summary>
        /// injecting IInterviewTrackerRepository in consructor to access all methods
        /// </summary>
        public InterviewTrackerServices(IInterviewTrackerRepository interviewTrackerRepository)
        {
            _interviewTR = interviewTrackerRepository;
        }
        public async Task<UserInterview> AddInterview(UserInterview interview)
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteInterviewById(string interviewId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserInterview>> GetAllInterview()
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public async Task<UserInterview> GetInterviewrById(string interviewId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserInterview>> InterviewByName(string name)
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public long TotalCount()
        {
            //Do Code Here
            throw new NotImplementedException();
        }

        public async Task<UserInterview> UpdateInterview(string interviewId, UserInterview interview)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
