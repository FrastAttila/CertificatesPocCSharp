using TechTalk.SpecFlow;
using CertificateIntegration;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using CertificateIntegration.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CertPoc.Specs
{
    [Binding]
    class PocBindings
    {
        private readonly IWrapper _wrapper;

        public PocBindings()
        {
            _wrapper = new Wrapper();
        }

        [Given(@"I selected the current user certificate suite from the machine I am on")]
        public void GivenISelectedTheCurrentUserCertificateSuiteFromTheMachineIAmOn()
        {
            _wrapper.ConnectToCurrentUserStore();
        }

        [When(@"I retrieve all certificates")]
        public void WhenIRetrieveAllCertificates()
        {
            var userCertificates = _wrapper.RetrieveCurrentUserCertificates();
            FeatureContext.Current.Set<X509Certificate2Collection>(userCertificates, "UserCertificates");
        }

        [Then(@"I make sure that certificates have been retrieved")]
        public void ThenIMakeSureThatCertificatesHaveBeenRetrieved()
        {
            var certificates = FeatureContext.Current.Get<X509Certificate2Collection>("UserCertificates");

            var count = certificates.Count;

            if (count == 0)
            {
                Assert.Fail();
            }

            _wrapper.CloseConnectionForCurrentUserStore();
        }
    }
}