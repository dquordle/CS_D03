public class AsteroidLookUp
{
    public string neo_reference_id { get; set; }
    public string name { get; set; }
    public string nasa_jpl_url { get; set; }
    public bool is_potentially_hazardous_asteroid { get; set; }
    public OrbitalData orbital_data { get; set; }
    
    public class OrbitalData
    {
        public OrbitClass orbit_class { get; set; }
    }
    public class OrbitClass
    {
        public string orbit_class_type { get; set; }
        public string orbit_class_description { get; set; }
    }

    public override string ToString()
    {
        string ret = $"-Asteroid {name}, SPK-ID: {neo_reference_id}\n";
        if (is_potentially_hazardous_asteroid)
            ret += "IS POTENTIALLY HAZARDOUS!\n";
        ret += $"Classification: {orbital_data.orbit_class.orbit_class_type}, " +
               $"{orbital_data.orbit_class.orbit_class_description}.\nUrl: {nasa_jpl_url}.";
        return ret;
    }
}
