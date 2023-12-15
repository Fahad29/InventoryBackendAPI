using IMS.Api.Common.Constant;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : BaseController
    {
        readonly IAttachmentCore _attachmentCore;
        APIResponse _apiResponse;
        public AttachmentsController(IAttachmentCore attachmentCore, APIResponse apiResponse)
        {
            _attachmentCore = attachmentCore;
            _apiResponse = apiResponse;
        }

        [AllowAnonymous, HttpGet, Route("GetAttachmentsById")]
        public async Task<IActionResult> GetAttachmentsById(long AttachmentId)
        {
            try
            {
                AttachmentResponse response = await _attachmentCore.GetAttachmentsById(AttachmentId);
                if (response != null)
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, response));
                else
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpGet, Route("GetAttachments")]
        public async Task<IActionResult> GetAttachments(int TypeId, long RequestId)
        {
            try
            {
                List<AttachmentResponse> attachments = await _attachmentCore.GetAttachments(TypeId, RequestId);
                if (attachments != null && attachments.Count() > 0)
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, attachments));
                else
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost, Route("UploadDocuments")]
        public async Task<IActionResult> UploadDocuments(List<IFormFile> attachments, int RequestId, int TypeId = 3)
        {
            try
            {
                if (attachments != null && attachments.Count > 0)
                {
                    List<AttachmentResponse> response = await _attachmentCore.UploadImages(attachments, UserID, RequestId, TypeId);
                    if (response != null && response.Count > 0)
                        return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, response));
                    else
                        return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound));

                }
                return BadRequest("Invalid file.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous, HttpDelete, Route("DeleteAttachmentsById")]
        public async Task<IActionResult> DeleteAttachmentsById(IEnumerable<long> AttachmentId)
        {
            try
            {
                APIResponse response = await _attachmentCore.DeleteAttachmentsById(AttachmentId, UserID);
                if (response != null)
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, response));
                else
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpDelete, Route("DeleteAttachments")]
        public async Task<IActionResult> DeleteAttachments(int TypeId, long RequestId)
        {
            try
            {
                APIResponse response = await _attachmentCore.DeleteAttachments(TypeId, RequestId, UserID);
                if (response != null)
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, response));
                else
                    return Ok(_apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.RecordNotFound));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
