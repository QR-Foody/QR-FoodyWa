using Business.Dtos;
using System;


namespace QRFoodyWa.Helpers
{
    public class ErrorHelper : IErrorHelper
    {
        #region Constructor

        public ErrorHelper(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException("log", "log cannot be null.");
        }

        #endregion

        #region private declaration

        private readonly ILog log;

        #endregion

        public ResponseDto GetFriendlyErrorResult(string errorId)
        {
            return new ResponseDto
            {
                IsSuccessFul = false,
                Error = $"An error occurred while processing your request. Please forward to support team the error with id: {errorId}"
            };
        }

        public ResponseDto GetFriendlyErrorResult()
        {
            return new ResponseDto
            {
                IsSuccessFul = false,
                Error = "An error occurred while processing your request. Please contact support team."
            };
        }

        public string LogError(Exception ex)
        {
            return log.LogException(ex);
        }

    }
}