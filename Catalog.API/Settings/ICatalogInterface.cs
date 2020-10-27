﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Settings
{
   public interface ICatalogInterface
    {
         string CollectionName { get; set; }
         string DatabaseName { get; set; }

         string ConnectionString { get; set; }

    }
}