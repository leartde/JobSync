using Entities.Models;

namespace Tests.Data;

public static class FakeEmployers
{
    public static List<Employer> Employers => new List<Employer>
    {
        new()
        {
            Id = new Guid("586e6f00-d455-43b0-8bc7-bc045dadcf98"),
            Name = "Employer1"
        },
        new()
        {
            Id = new Guid("05fabc90-ecf5-4f7f-a130-7a20011e3e34"),
            Name = "Employer2"
        }
    };

    public static Employer SingleEmployer => new()
    {
        Id = new Guid("586e6f00-d455-43b0-8bc7-bc045dadcf98"),
        Name = "Employer1",
        Headquarters = "Albania",
        Phone = "443191426"
    };
}