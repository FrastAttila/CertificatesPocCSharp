using System.Security.Cryptography.X509Certificates;

namespace CertificateIntegration.Ports
{
    public interface IWrapper
    {
        void ConnectToCurrentUserStore();
        X509Certificate2Collection RetrieveCurrentUserCertificates();
        void CloseConnectionForCurrentUserStore();
    }
}