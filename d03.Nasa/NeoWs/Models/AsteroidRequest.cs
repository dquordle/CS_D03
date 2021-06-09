using System;

public class AsteroidRequest
{
    public DateTime StartDate;
    public DateTime EndDate;
    public int ResultCount;

    public AsteroidRequest(DateTime startDate, DateTime endDate, int resultCount)
    {
        StartDate = startDate;
        EndDate = endDate;
        ResultCount = resultCount;
    }
}