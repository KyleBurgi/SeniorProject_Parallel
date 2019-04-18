using System;
using System.Collections.Generic;
using System.Linq;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;

namespace EwuConnect.Domain.Services
{
    class ResponseService : IResponseService
    {
        private ApplicationDbContext DbContext { get; }

        public ResponseService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Response AddResponse(Response response)
        {
            DbContext.Responses.Add(response);
            DbContext.SaveChanges();
            return response;
        }

        public void UpdateResponse(Response response)
        {
            DbContext.Responses.Update(response);
            DbContext.SaveChanges();
        }

        public Response GetResponse_Id(int id)
        {
            return DbContext.Responses
                .SingleOrDefault(r => r.Id == id);
        }

        public List<Response> GetResponse_PostId(int postId)
        {
            return DbContext.Responses.Where(r => r.Id == postId).ToList();
        }

        public bool DeleteResponse(int id)
        {
            Response foundResponse = DbContext.Responses.Find(id);

            if (foundResponse != null)
            {
                foundResponse.IsViewable = false;
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Response> GetBatchResponse()
        {
            return DbContext.Responses.ToList();

        }
    }
}
