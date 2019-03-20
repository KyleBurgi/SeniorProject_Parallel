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

        public void AddResponse(Response post)
        {
            DbContext.Responses.Add(post);
            DbContext.SaveChanges();
        }

        public void UpdateResponse(Response post)
        {
            DbContext.Responses.Update(post);
            DbContext.SaveChanges();
        }

        public Response GetResponse(int id)
        {
            return DbContext.Responses
                .SingleOrDefault(u => u.Id == id);
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
    }
}
