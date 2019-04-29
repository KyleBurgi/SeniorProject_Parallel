using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Services
{
    public class ResponseService : IResponseService
    {
        private ApplicationDbContext DbContext { get; }

        public ResponseService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Response> AddResponse(Response response)
        {
            DbContext.Responses.Add(response);
            await DbContext.SaveChangesAsync();
            return response;
        }

        public async Task<Response> UpdateResponse(Response response)
        {
            DbContext.Responses.Update(response);
            await DbContext.SaveChangesAsync();
            return response;
        }

        public async Task<Response> GetResponse_Id(int id)
        {
            return await DbContext.Responses.FindAsync(id);
        }

        public async Task<List<Response>> GetResponse_PostId(int postId)
        {
            return await DbContext.Responses.Where(r => r.Id == postId).ToListAsync();
        }

        public async Task<bool> DeleteResponse(int id)
        {
            Response foundResponse = await DbContext.Responses.FindAsync(id);

            if (foundResponse != null)
            {
                foundResponse.IsViewable = false;
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Response>> GetBatchResponse()
        {
            return await DbContext.Responses.ToListAsync();

        }
    }
}
