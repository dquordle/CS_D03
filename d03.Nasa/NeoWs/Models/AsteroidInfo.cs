using System;
using System.Collections.Generic;

public class AsteroidInfo
{
    public string id { get; set; }
    public double distance { get; set; }
    public List<CloseApproachData> close_approach_data { get; set; }

    public class CloseApproachData
    {
        public MissDistance miss_distance { get; set; }
    }
    
    public class MissDistance
    {
        public string kilometers { get; set; }
    }
}
public class FeedResponse
{ 
    public Dictionary<DateTime, AsteroidInfo[]> near_earth_objects { get; set; }
}