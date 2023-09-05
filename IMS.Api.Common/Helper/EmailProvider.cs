using IMS.Api.Common.Extensions;
using IMS.Api.Common.IHelper;
using IMS.Api.Common.Model.CommonModel;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Diagnostics.CodeAnalysis;
namespace IMS.Api.Common.Helper
{
    public class EmailProvider : IEmailProvider
    {
        private SendGridMessage _mailMessage = null;
   
        SendGridClient client = new SendGridClient("Enter here SendGrid key"); 

        string _content = string.Empty;
        string _htmlContent = string.Empty;
        string _subject = string.Empty;

        private EmailProvider(string fromAddress, List<string> toAddresses)
        {
            List<EmailAddress> toEmails = new List<EmailAddress>();
            Dictionary<string, string> listdictionary = new Dictionary<string, string>();
            foreach (var item in toAddresses)
            {
                toEmails.Add(new EmailAddress { Email = item });

                listdictionary.Add(item, item);
            }


            _mailMessage = MailHelper.CreateSingleEmailToMultipleRecipients(new EmailAddress(fromAddress), toEmails, string.Empty, string.Empty, string.Empty);
        }

        public static IEmailProvider CreateEmail(string fromAddress, List<string> strings)
        {
            fromAddress = !string.IsNullOrEmpty(fromAddress) ? fromAddress : IMS.Api.Common.Constant.Constant.FromEmail;
            return new EmailProvider(fromAddress, strings);
        }

        [ExcludeFromCodeCoverage]
        public IEmailProvider From(string fromAddress)
        {
            return this;
        }

        [ExcludeFromCodeCoverage]
        public IEmailProvider To(params string[] toAddresses)
        {
            EmailAddress emailaddress = new EmailAddress();
            List<EmailAddress> emailaddresslist = new List<EmailAddress>();
            foreach (string toAddress in toAddresses)
            {
                emailaddress.Email = toAddress;
                emailaddresslist?.Add(emailaddress);
            }
            _mailMessage.AddTos(emailaddresslist);
            return this;
        }

        [ExcludeFromCodeCoverage]
        public IEmailProvider CC(params string[] ccAddresses)
        {
            //foreach (string ccAddress in ccAddresses)
            //{
            //    if (!string.IsNullOrEmpty(ccAddress))
            //        _mailMessage.AddCc(ccAddress);
            //}

            //return this;



            List<EmailAddress> emailaddresslist = new List<EmailAddress>();
            if (ccAddresses != null)
            {
                if (ccAddresses.ToList().Count > 0)
                {
                    foreach (string toAddress in ccAddresses)
                    {
                        EmailAddress emailaddress = new EmailAddress();
                        emailaddress.Email = toAddress;
                        emailaddresslist.Add(emailaddress);
                    }
                    _mailMessage.AddCcs(emailaddresslist);
                }
            }

            return this;

        }
        [ExcludeFromCodeCoverage]
        public IEmailProvider BCC(params string[] bccAddresses)
        {
            //foreach (string bccAddress in bccAddresses)
            //{
            //    if (!string.IsNullOrEmpty(bccAddress))
            //        _mailMessage.AddBcc(bccAddress);
            //}

            //return this;

            List<EmailAddress> emailaddresslist = new List<EmailAddress>();
            if (bccAddresses != null)
            {
                if (bccAddresses.ToList().Count > 0)
                {
                    foreach (string toAddress in bccAddresses)
                    {
                        EmailAddress emailaddress = new EmailAddress();
                        emailaddress.Email = toAddress;
                        emailaddresslist.Add(emailaddress);
                    }
                    _mailMessage.AddBccs(emailaddresslist);
                }
            }

            return this;
        }

        public IEmailProvider WithSubject(string subject)
        {
            _subject = subject;

            _mailMessage.SetSubject(_subject);


            return this;
        }
        [ExcludeFromCodeCoverage]
        /// <summary>
        /// text/plain  content Type
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IEmailProvider WithContent(string content)
        {
            _content = content;

            _mailMessage.AddContent("text/plain", content);
            return this;
        }
        /// <summary>
        /// text/html ContentType
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>

        public IEmailProvider WithHtmlContent(string content)
        {
            _htmlContent = content;

            _mailMessage.AddContent("text/html", content);
            return this;
        }
        [ExcludeFromCodeCoverage]
        public IEmailProvider WithAttachment(string filename, string filestream)
        {
            _mailMessage.AddAttachment(filename, filestream, "application/csv", "attachment", "banner");

            return this;
        }
        [ExcludeFromCodeCoverage]
        public IEmailProvider SetGlobalSubject(string subject)
        {
            _mailMessage.SetGlobalSubject(subject);
            return this;
        }

        public IEmailProvider WithMutipleAttachments(List<string> filename, List<string> filepathURL, List<Stream> MultiplePdfs)
        {
            int loopcount = 0;

            foreach (var item in filename)
            {
                try
                {
                    Attachment attachment;
                    attachment = new Attachment() { };

                    foreach (var steampdf1 in MultiplePdfs)
                    {
                        WithAttachment(filename[loopcount], steampdf1.ConvertToBase64());
                    }

                    loopcount += 1;

                }
                catch (Exception ex)
                {
                    APIConfig.Log.Debug("Email Attachment File URL " + item.ToString() + "Exception  Email List" + ex.Message + " Stack Track " + ex.StackTrace);
                }
            }
            return this;
        }
        public async Task<object> Send()
        {
            var ObjHttpResponse = await client.SendEmailAsync(_mailMessage);

            var emailResponse = ObjHttpResponse.Body.ReadAsStringAsync();

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(emailResponse.Result);


            return await Task.FromResult(response);
        }
    }
}
