using Dashboard.Microservice;
using Dashboard.Microservice.Controllers;
using Interview.Microservice.Entities;
using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User.Microservice.Entities;
using Xunit;

namespace InterviewTrackerTest.Tests.TestCases
{
    public class BusinessLogicTests
    {
        private Mock<IInterviewTrackerServices> interviewRepoMock;
        private readonly DashboardController dashController;
        private ApplicationUser _user;
        private UserInterview _interview;
        public BusinessLogicTests()
        {
            interviewRepoMock = new Mock<IInterviewTrackerServices>();
            dashController = new DashboardController(interviewRepoMock.Object);
            _user = new ApplicationUser()
            {
                //UserId = "5f0ec59dce04c32fb4d3160a",
                FirstName = "Name1",
                LastName = "Last1",
                Email = "namelast@gmail.com",
                ReportingTo = "Reportingto",
                UserTypes = UserType.Developer,
                Stat = Status.Locked,
                MobileNumber = 9631438113
            };
            _interview = new UserInterview()
            {
                //InterviewId = "5f10259f587fb74450a61c77",
                InterviewName = "Name1",
                Interviewer = "Interviewer-1",
                InterviewUser = "InterviewUser-1",
                UserSkills = ".net",
                InterviewDate = DateTime.Now,
                InterviewTime = DateTime.UtcNow,
                InterViewsStatus = InterviewStatus.Done,
                TInterViews = TechnicalInterviewStatus.Pass,
                Remark = "OK"
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static BusinessLogicTests()
        {
            if (!File.Exists("../../../../output_business_revised.txt"))
                try
                {
                    File.Create("../../../../output_business_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_business_revised.txt");
                File.Create("../../../../output_business_revised.txt").Dispose();
            }
        }
        
    }
}
