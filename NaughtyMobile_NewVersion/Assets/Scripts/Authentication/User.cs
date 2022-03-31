using System;

/// <summary>
/// The user class, which gets uploaded to the Firebase Database
/// </summary>

[Serializable] // This makes the class able to be serialized into a JSON
public class User
{
    public string Name;
    public int Score;
    
    public User(string name)
    {
        Name = name;
    }
    
    public User(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
