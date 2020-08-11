using Interview.Microservice.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Interfaces
{
    public interface IInterviewTrackerServices
    {
        //List of method to perform all User related operation
        Task<UserInterview> AddInterview(UserInterview interview);
        Task<UserInterview> GetInterviewrById(string interviewId);
        Task<IEnumerable<UserInterview>> GetAllInterview();
        Task<bool> DeleteInterviewById(string interviewId);
        Task<UserInterview> UpdateInterview(string interviewId, UserInterview interview);
        long TotalCount();
        Task<IEnumerable<UserInterview>> InterviewByName(string name);

    }
}
