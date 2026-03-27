public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = state;
        _country = country;
    }

    public bool IsInUSA()
    {
       return _country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_stateOrProvince}, {_country}";
    }
}