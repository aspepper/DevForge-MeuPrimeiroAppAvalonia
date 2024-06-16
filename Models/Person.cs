namespace Models;

public class Person
{

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int Age { get; set; }

    public GenderDataList Gender { get; set; }

    public bool IsOrganDonor { get; set; }

    public CityDataList BirthCity { get; set; }

}

public enum GenderDataList {
    None,
    Male,
    Female,
    Other
}

public enum CityDataList {
    Santos,
    SaoPaulo,
    RioDeJaneiro,
    Londres,
    NewYrok,
    Paris,
    Tokio,
    Roma    
}
