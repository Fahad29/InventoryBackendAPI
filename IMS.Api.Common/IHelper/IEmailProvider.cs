namespace IMS.Api.Common.IHelper
{
    public interface IEmailProvider
    {
        IEmailProvider From(string fromAddress);
        IEmailProvider To(params string[] toAddresses);
        IEmailProvider CC(params string[] ccAddresses);
        IEmailProvider BCC(params string[] bccAddresses);
        IEmailProvider WithSubject(string subject);
        IEmailProvider WithContent(string content);
        IEmailProvider WithHtmlContent(string htmlContent);
        IEmailProvider WithAttachment(string filename, string filestream);
        IEmailProvider SetGlobalSubject(string subject);
        IEmailProvider WithMutipleAttachments(List<string> filename, List<string> filepath, List<Stream> pdfStreams);
        Task<object> Send();
    }
}
