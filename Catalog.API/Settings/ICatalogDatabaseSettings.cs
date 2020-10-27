using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Settings
{
    public class ICatalogDatabaseSettings:ICatalogInterface
    {
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}
