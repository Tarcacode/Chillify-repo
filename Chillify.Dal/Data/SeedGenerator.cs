namespace Chillify.Dal.Data;

public class SeedGenerator
{
    private DateTime dateStart;
    private Random rdmGen;
    private int dateRange;

    public SeedGenerator()
    {
        dateStart = new DateTime(1991, 1, 1);
        rdmGen = new Random();
        dateRange = (DateTime.Today - dateStart).Days;
    }
    public List<Member> GetMembers()
    {
        return Enumerable.Range(1, 100)
            .Select(index => new Member
            {
                Id = index,
                EmailAddress = $"member{index}@gmail.com",
                Pseudo = $"Member{index}",
                PswdHash = "Ch1llify",
                FirstName = NextFirstName(),
                LastName = NextLastName(),
                BirthDate = NextDate(),
                RoleId = NextRole()
            }
            ).ToList();
    }

    public List<Address> GetAddresses()
    {
        return Enumerable.Range(1, 100)
            .Select(index => new Address
            {
                Id = index,
                Street = "Chaussée de Wavre",
                Number = index.ToString(),
                PostCode = "1160",
                City = "Brussels",
                Country = "Belgium"
            }).ToList();
    }

    public List<MemberAddress> GetMemberAddresses()
    {
        return Enumerable.Range(1, 100)
            .Select(index => new MemberAddress
            {
                MemberId = index,
                AddressId = index
            }).ToList();
    }

    private DateTime NextDate()
    {
        return dateStart.AddDays(rdmGen.Next(dateRange))
                        .AddHours(rdmGen.Next(0, 24))
                        .AddMinutes(rdmGen.Next(0, 60))
                        .AddSeconds(rdmGen.Next(0, 60));
    }

    private string NextFirstName()
    {
        string[] firstNames =
        {
            "Michel",
            "Elisabeth",
            "Bernard",
            "Martine",
            "Simon",
            "Julie",
            "Julien",
            "Marie",
            "Martin",
            "Catherine",
            "Albert",
            "Gertrude",
            "Arnaud",
            "Justine",
            "Robin"
        };
        int roll = rdmGen.Next(0, 15);
        return firstNames[roll];
    }
    private string NextLastName()
    {
        string[] lastNames =
        {
            "Peeters",
            "Janssens",
            "Maes",
            "Jacobs",
            "Mertens",
            "Willems",
            "Claes",
            "Goossens",
            "Wouters",
            "De Smet",
            "Durand",
            "Petit",
            "Leroy",
            "Moreau",
            "Dubois",
        };
        int roll = rdmGen.Next(0, 15);
        return lastNames[roll];
    }
    private int NextRole()
    {
        return rdmGen.Next(1, 6);
    }
}
