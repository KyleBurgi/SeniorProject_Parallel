using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IResponseService
    {
        void AddResponse(Response response);
        void UpdateResponse(Response response);
        Response GetResponse(int id);
        bool DeleteResponse(int id);
    }   
}
