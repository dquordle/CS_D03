using System;

public class MediaOfToday
{
    public string copyright { get; set; }
    public DateTime date { get; set; }
    public string explanation { get; set; }
    public string title { get; set; }
    public string hdurl { get; set; }
    public string url { get; set; }

    public override string ToString()
    {
        string res = $"{date:d}\n'{title}'";
        if (!string.IsNullOrEmpty(copyright))
            res += $" by {copyright}";
        res += $"\n{explanation}\n{hdurl}";
        if (string.IsNullOrEmpty(hdurl))
            res += $"{url}";
        return res;
    }
}