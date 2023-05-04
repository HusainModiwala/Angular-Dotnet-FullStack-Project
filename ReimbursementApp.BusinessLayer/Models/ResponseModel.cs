using System;
using System.Collections.Generic;
using System.Text;

namespace ReimbursementApp.BusinessLayer.Models
{
    public enum ResponseCode { Ok=1, Error=2};
    public class ResponseModel
    {
        public ResponseModel(ResponseCode responseCode, string responseMessage, object dataset)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            DataSet = dataset;
        }
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object DataSet { get; set; }
    }
}
