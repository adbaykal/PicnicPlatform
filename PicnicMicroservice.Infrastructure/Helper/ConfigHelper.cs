using Microsoft.Extensions.Configuration;

namespace PicnicMicroservice.Infrastructure.Helper
{
    public static class ConfigHelper
    {
        private static IConfiguration _configuration;


        static ConfigHelper()
        {
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

        }

        public static string LogoURL
        {
            get { return _configuration.GetSection("PanelSettings:LogoURL").Value; }
        }

        public static string LoginBannerURL
        {
            get { return _configuration.GetSection("PanelSettings:LoginBannerURL").Value; }
        }


        public static string LoginTitle
        {
            get { return _configuration.GetSection("PanelSettings:LoginTitle").Value; }
        }

        public static string CompanyName
        {
            get { return _configuration.GetSection("PanelSettings:CompanyName").Value; }
        }

        public static bool SaveMsisdn
        {
            get { return bool.Parse(_configuration.GetSection("PanelSettings:SaveMsisdn").Value); }
        }

        public static string CaptchaSiteKey
        {
            get { return _configuration.GetSection("CaptchaSettings:SiteKey").Value; }
        }

        public static string CustomerCode
        {
            get { return _configuration.GetSection("PanelSettings:CustomerCode").Value; }
        }

        public static string SiteBaseUrl
        {
            get { return _configuration.GetSection("SiteSettings:BaseUrl").Value; }
        }

        public static string AdminUrl
        {
            get { return _configuration.GetSection("SiteSettings:AdminUrl").Value; }
        }

        public static string EnterpriseCaptchaProjectId
        {
            get { return _configuration.GetSection("CaptchaEnterpriseSettings:ProjectId").Value; }
        }

        public static string EnterpriseCaptchaSiteKey
        {
            get { return _configuration.GetSection("CaptchaEnterpriseSettings:SiteKey").Value; }
        }

        public static string EnterpriseCaptchaAction
        {
            get { return _configuration.GetSection("CaptchaEnterpriseSettings:Action").Value; }
        }

        public static string EnterpriseCaptchaApiKey
        {
            get { return _configuration.GetSection("CaptchaEnterpriseSettings:ApiKey").Value; }
        }
    }
}
