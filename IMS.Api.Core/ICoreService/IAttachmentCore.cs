using IMS.Api.Common.Model.DataModel;
using IMS.Api.Common.Model.ResponseModel;
using Microsoft.AspNetCore.Http;

namespace IMS.Api.Core.ICoreService
{
    public interface IAttachmentCore
    {
        List<AttachmentType> GetAttachmentTypes();
        Task<AttachmentResponse> GetAttachmentsById(long AttachmentId);
        Task<List<AttachmentResponse>> GetAttachments(int TypeId, long RequestId);
        Task<List<AttachmentResponse>> UploadImages(List<IFormFile> formFiles, long UserId, long RequestId, int TypeId);
        Task<APIResponse> DeleteAttachmentsById(long AttachmentId, long UserId);
        Task<APIResponse> DeleteAttachments(int TypeId, long RequestId, long UserId);
    }
}
