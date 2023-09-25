using IMS.Api.Common.Constant;
using IMS.Api.Common.Model;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Core.ICoreService;
using IMS.Api.Service.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IMS.Api.Core.CoreService
{
    public class AttachmentCore : IAttachmentCore
    {
        IRepository<Attachment> _iRepository;
        APIResponse _apiResponse;
        public AttachmentCore(IRepository<Attachment> iRepository, APIResponse apiResponse)
        {
            _iRepository = iRepository;
            _apiResponse = apiResponse;
        }
        public List<AttachmentType> GetAttachmentTypes()
        {
            List<AttachmentType> attachmentTypes = _iRepository.Search<AttachmentType>(null, Constant.SpGetAttachmentTypes).ToList();
            return attachmentTypes;
        }
        public async Task<AttachmentResponse> GetAttachmentsById(long AttachmentId)
        {
            AttachmentResponse? attachment = _iRepository.Search<AttachmentResponse>(new { AttachmentId = AttachmentId }, Constant.SpGetAttachmentById).FirstOrDefault();
            return attachment;
        }
        public async Task<List<AttachmentResponse>> GetAttachments(int TypeId, long RequestId)
        {
            List<AttachmentResponse> attachments = _iRepository.Search<AttachmentResponse>(new { AttachmentTypeId = TypeId, RequestId = RequestId },
                                                                            Constant.SpGetAttachments).ToList();
            return attachments;
        }
        public async Task<List<AttachmentResponse>> UploadImages(List<IFormFile> formFiles, long UserId, long RequestId, int TypeId)
        {
            try
            {
                List<AttachmentType> attachmentTypes = GetAttachmentTypes();
                List<AttachmentResponse> attachments = new List<AttachmentResponse>();
                string attachmentFolder = attachmentTypes.Where(x => x.Id == TypeId).FirstOrDefault()?.Name;

                foreach (var file in formFiles)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string attachName = DateTime.UtcNow.ToString("ddMMyyyyHHmmssfff") + fileExtension;
                    string folderPath = Path.Combine(Constant.RootPath, attachmentFolder);
                    string attachmentPath = Path.Combine(folderPath, attachName.Trim());

                    Attachment attachment = new Attachment
                    {
                        AttachmentName = attachName,
                        AttachmentPath = attachmentPath,
                        OrignalName = file.FileName,
                        Extension = fileExtension,
                        AttachmentType = TypeId,
                        CreatedOn = DateTime.UtcNow,
                        RequestId = RequestId,
                        CreatedBy = UserId,
                    };

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Combine the path with the unique file name

                    // Save the file to the server
                    using (var stream = new FileStream(attachmentPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    AttachmentResponse attachmentRes = _iRepository.CreateSP<AttachmentResponse>(attachment, Constant.SpGetAddAttachments);
                    attachments.Add(attachmentRes);
                }
                return attachments;

            }
            catch (Exception ex)
            {
                APIConfig.Log.Debug("Exception: " + ex.Message);
                throw;
            }
        }

        public async Task<APIResponse> DeleteAttachmentsById(long AttachmentId, long UserId)
        {
            try
            {
                bool isDelete = _iRepository.Delete(new { AttachmentId = AttachmentId }, Constant.SpDeleteAttachmentById);
                if (isDelete)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Request Id");

            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }
        public async Task<APIResponse> DeleteAttachments(int TypeId, long RequestId, long UserId)
        {

            try
            {
                bool isDelete = _iRepository.Delete(new { AttachmentTypeId = TypeId, RequestId = RequestId }, Constant.SpDeleteAttachments);
                if (isDelete)
                    return _apiResponse.ReturnResponse(HttpStatusCode.OK, Constant.DeleteRecord);
                else
                    return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, "Invalid Request Id");

            }
            catch (Exception ex)
            {
                return _apiResponse.ReturnResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
