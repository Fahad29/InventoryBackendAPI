﻿using Azure;
using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

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

        [AllowAnonymous, HttpPost, Route("UploadImages")]
        public async Task<IActionResult> UploadImages(IFormFileCollection formFiles, int RequestId, int TypeId = 3)
        {
            try
            {
                if (formFiles != null && formFiles.Count > 0)
                {

                    APIResponse response = await _attachmentCore.UploadImages(formFiles, UserID, RequestId, TypeId);
                    if (response?.Response != null)
                        return Ok(response);

                }
                return BadRequest("Invalid file.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous, HttpGet, Route("DeleteAttachmentsById")]
        public async Task<IActionResult> DeleteAttachmentsById(long AttachmentId)
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

        [AllowAnonymous, HttpGet, Route("DeleteAttachments")]
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