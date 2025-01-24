using CsvHelper.Configuration;
namespace PersonDetails.Models 
{
    public class CSV_map : ClassMap<Person>
    {
        public CSV_map()
        {
            Map(m => m.first_name).Name("First Name");
            Map(m => m.last_name).Name("Last Name");
            Map(m => m.telephone_code).Name("Country code");
            Map(m => m.telephone_number).Name("Number");
            Map(m => m.address).Convert(row =>
            {
                var fullAddress = row.Row.GetField<string>("Full Address");
                var parts = fullAddress?.Split(',', StringSplitOptions.TrimEntries);
                return parts?.Length > 1 ? parts[0] : fullAddress;
            });
            Map(m => m.country).Convert(row =>
            {
                // Retrieve the full address as a string
                var fullAddress = row.Row.GetField<string>("Full Address");

                // Split the full address by comma and return the country part (last part)
                var parts = fullAddress?.Split(',', StringSplitOptions.TrimEntries);
                return parts?.Length > 1 ? parts[^1] : string.Empty;  // Use the last part as country
            });
        }
    }
}
