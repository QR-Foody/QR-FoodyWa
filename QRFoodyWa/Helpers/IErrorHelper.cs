using Business.Dtos;
using System;


namespace QRFoodyWa.Helpers
{
    public interface IErrorHelper
    {
        ResponseDto GetFriendlyErrorResult(string errorId);

        ResponseDto GetFriendlyErrorResult();

        string LogError(Exception ex);
    }
}