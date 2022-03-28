public class SetSedStatus
{
    public void Execute(SetSedStatusRequest request)
    {
        
    }
}

public record SetSedStatusRequest(List<SedToUpdate> seds, string status) {}

public record SedToUpdate(string sed, string version) {}