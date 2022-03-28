public class DeleteSedMetadata
{
    public void Execute(DeleteSedMetadataRequest request)
    {
        
    }
}

public record DeleteSedMetadataRequest(List<SedToDelete> seds){}

public record SedToDelete(string sed, string version){}