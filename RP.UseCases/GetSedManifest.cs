namespace RP.UseCases;

public class GetSedManifest
{
    public List<Sector> Execute()
    {
        return new List<Sector> {
            new Sector("P", "Pensions", new List<Sed>{
                new Sed("P_BUC_01", "Pensions 1", new List<Version>{
                    new Version("4.2", "Published"),
                    new Version("4.3", "Draft")
                }),
                new Sed("P_BUC_02", "Pensions 2", new List<Version>{
                    new Version("4.2", "Published"),
                    new Version("4.3", "Draft")
                })
            }),
            new Sector("S", "Sickness", new List<Sed>{
                new Sed("S_BUC_01", "Sickness 1", new List<Version>{
                    new Version("4.2", "Published"),
                    new Version("4.3", "Draft")
                }),
                new Sed("S_BUC_02", "Sickness 2", new List<Version>{
                    new Version("4.2", "Published"),
                    new Version("4.3", "Draft")
                })
            })
        };
    }

    public record Sector(string Code, string Name, List<Sed> seds)
    {
    }

    public record Sed(string Code, string Name, List<Version> versions)
    {
    }

    public record Version(string version, string status) 
    {
    }
}