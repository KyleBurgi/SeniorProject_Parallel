using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IResponseService
    {
        Response AddResponse(Response response);
        void UpdateResponse(Response response);
        Response GetResponse_Id(int id);
        List<Response> GetResponse_PostId(int post_id);
        bool DeleteResponse(int id);
        List<Response> GetBatchResponse();
    }   
}
