using FirstCitizensBank;
using Raven.Client.Documents;
using System.Security.Cryptography.X509Certificates;

namespace FirstCitizentBank
{
    public class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> _store = new Lazy<IDocumentStore>(CreateDocumentStore);

        private static IDocumentStore CreateDocumentStore()
        {
            string serverURL = "https://a.free.bclark00.ravendb.cloud";
            string databaseName = "Contacts";

            IDocumentStore documentStore = new DocumentStore
            {
                Urls = new[] { serverURL },
                Database = databaseName,
                Certificate = new X509Certificate2(certificate.blob)
            };
           
            documentStore.Initialize();
            return documentStore;
        }

        public static IDocumentStore Store
        {
            get { return _store.Value; }
        }
    }
}
