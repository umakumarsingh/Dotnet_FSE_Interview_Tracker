using Interview.Microservice.Entities;
using InterviewTracker.DataLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services.Repository
{
    public class InterviewTrackerRepository : IInterviewTrackerRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<UserInterview> _dbCollection;
        
        public InterviewTrackerRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<UserInterview>(typeof(UserInterview).Name);
        }
        /// <summary>
        /// Add a new interview into MongoDb Collection
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<UserInterview> AddInterview(UserInterview interview)
        {
            try
            {
                if (interview == null)
                {
                    throw new ArgumentNullException(typeof(UserInterview).Name + "Object is Null");
                }
                _dbCollection = _mongoContext.GetCollection<UserInterview>(typeof(UserInterview).Name);
                await _dbCollection.InsertOneAsync(interview);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return interview;
        }
        /// <summary>
        /// Delate a saved interview by passing InterviewId
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteInterviewById(string interviewId)
        {
            try
            {
                var objectId = new ObjectId(interviewId);
                FilterDefinition<UserInterview> filter = Builders<UserInterview>.Filter.Eq("InterviewId", objectId);
                var result = await _dbCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all Interview and show on Dashboard Api
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserInterview>> GetAllInterview()
        {
            try
            {
                var list = _mongoContext.GetCollection<UserInterview>("UserInterview")
                .Find(Builders<UserInterview>.Filter.Empty, null)
                .SortByDescending(e => e.InterviewName);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get a single interview from MongoDb Collection
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public async Task<UserInterview> GetInterviewrById(string interviewId)
        {
            try
            {
                var objectId = new ObjectId(interviewId);
                FilterDefinition<UserInterview> filter = Builders<UserInterview>.Filter.Eq("InterviewId", objectId);
                _dbCollection = _mongoContext.GetCollection<UserInterview>(typeof(UserInterview).Name);
                return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Search in interview Collection by Passing Interview name and Interviewer name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserInterview>> InterviewByName(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<UserInterview>();
                var fnterviewName = filterBuilder.Eq(s => s.InterviewName, name);
                var fnterviewer = filterBuilder.Eq(s => s.Interviewer, name.ToString());
                _dbCollection = _mongoContext.GetCollection<UserInterview>(typeof(UserInterview).Name);
                var result = await _dbCollection.FindAsync(fnterviewName | fnterviewer).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Total Count of Interview In MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public long TotalCount()
        {
            var count = _dbCollection.CountDocuments(new FilterDefinitionBuilder<UserInterview>().Empty);
            return count;
        }
        /// <summary>
        /// Update an Existing Interview
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<UserInterview> UpdateInterview(string InterviewId, UserInterview interview)
        {
            if (interview == null && InterviewId == null)
            {
                throw new ArgumentNullException(typeof(UserInterview).Name + "Object or may be InterviewId is Null");
            }
            var update = await _dbCollection.FindOneAndUpdateAsync(Builders<UserInterview>.
                Filter.Eq("InterviewId", interview.InterviewId), Builders<UserInterview>.
                Update.Set("Interviewer", interview.Interviewer).Set("InterviewName", interview.InterviewName)
                .Set("InterviewUser", interview.InterviewUser).Set("UserSkills", interview.UserSkills).
                Set("InterviewDate", interview.InterviewDate).Set("InterviewTime", interview.InterviewTime).
                Set("InterViewsStatus", interview.InterViewsStatus).Set("TInterViews", interview.TInterViews).
                Set("Remark", interview.Remark));
            return update;
        }
    }
}
