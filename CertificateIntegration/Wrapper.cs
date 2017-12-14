using CertificateIntegration.Ports;
using System.Security.Cryptography.X509Certificates;

namespace CertificateIntegration
{
    public class Wrapper : IWrapper
    {
        X509Store _currentUserStore = new X509Store(StoreName.Root, StoreLocation.CurrentUser);

        public void ConnectToCurrentUserStore()
        {
            _currentUserStore.Open(OpenFlags.ReadOnly);
        }

        public X509Certificate2Collection RetrieveCurrentUserCertificates()
        {

            X509Certificate2Collection currentUserCertificates = _currentUserStore.Certificates;

            return currentUserCertificates;
        }

        public void CloseConnectionForCurrentUserStore()
        {
            _currentUserStore.Close();
        }
    }
}