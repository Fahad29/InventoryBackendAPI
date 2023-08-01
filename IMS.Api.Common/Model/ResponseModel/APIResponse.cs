using System.Net;
using System.Text.Json.Serialization;

namespace IMS.Api.Common.Model
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        [JsonIgnore]
        public object Response { get; set; }

        public APIResponse ReturnResponse(HttpStatusCode StatusCode, object response)
        {
            switch (StatusCode)
            {
                case HttpStatusCode.OK:
                    StatusMessage = "The request was successfully completed.";
                    break;
                case HttpStatusCode.Created:
                    StatusMessage = "A new resource was successfully created.";
                    break;
                case HttpStatusCode.BadRequest:
                    StatusMessage = "The server was unable to process the request sent by the client due to invalid syntax.";
                    break;
                case HttpStatusCode.NotFound:
                    StatusMessage = "The Page, Request, File or Detail not found.";
                    break;
                case HttpStatusCode.Unauthorized:
                    StatusMessage = "The request did not include an authentication token or the authentication token was expired.";
                    break;
                case HttpStatusCode.InternalServerError:
                    StatusMessage = "Internal Server Error";
                    break;
                default:
                    StatusMessage = "Not Found"; break;
            }
            this.StatusCode = ((int)StatusCode);
            this.Response = response;
            this.StatusMessage = StatusMessage;
            return this;
        }
    }
}
