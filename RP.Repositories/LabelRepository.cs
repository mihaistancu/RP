﻿using RP.Services;
using RP.Services.Dependencies;

namespace RP.Repositories;

public class LabelRepository: ILabelRepository
{
    private record InMemoryRecord(string Code, string Version, string Country, string Language, string Content);
 
    List<InMemoryRecord> db = new List<InMemoryRecord>();

    private const string MetadataPath = "c:\\temp\\Labels";

    public void Add(LabelsToAdd labels) 
    {
        db.Add(new InMemoryRecord(labels.Code, labels.Version, labels.Country, labels.Language, labels.Content));
    }
}
