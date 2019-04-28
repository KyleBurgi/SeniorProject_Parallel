using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IResponseService
    {
        Task<Response> AddResponse(Response response);
        Task<Response> UpdateResponse(Response response);
        Task<Response> GetResponse_Id(int id);
        Task<List<Response>> GetResponse_PostId(int post_id);
        Task<bool> DeleteResponse(int id);
        Task<List<Response>> GetBatchResponse();
    }   
}
