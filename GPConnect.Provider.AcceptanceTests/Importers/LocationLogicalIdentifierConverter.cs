﻿namespace GPConnect.Provider.AcceptanceTests.Importers
{
    using CsvHelper.Configuration;
    using Data;

    internal sealed class LocationLogicalIdentifierConverter : CsvClassMap<LocationLogicalIdentifierMap>
    {
        public LocationLogicalIdentifierConverter()
        {
            Map(l => l.Location).Name("Location");
            Map(p => p.LogicalIdentifier).Name("LogicalIdentifier");
        }
    }
}
