namespace RP.UseCases;

using RP.UseCases.Dependencies;

public class SetSedStatus
{
    public void Execute(SetSedStatusRequest request)
    {
        Context.Seds.SetStatusAsync(request.Seds, request.Status);
    }
}

public record SetSedStatusRequest(List<SedToUpdate> Seds, string Status) {}

public record SedToUpdate(string Sed, string Version) {}