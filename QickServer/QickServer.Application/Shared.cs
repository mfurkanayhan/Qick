namespace QickServer.Application;
public static class Shared
{
    public static List<Participants> Participants = new()
    {
        new(603041, new("taner","tanersaydam@gmail.com", 0)),
        new(603041, new("furkan","mfurkanayhan@gmail.com", 0)),
        new(603041, new("emre","emre@gmail.com", 0)),
        new(603041, new("enes","enes@gmail.com", 0)),
        new(603041, new("ramazan","ramazan@gmail.com", 0)),
        new(603041, new("mehmetcan","mehmetcan@gmail.com", 0)),
        new(603041, new("cuma","cuma@gmail.com", 0)),
    };
}

public sealed record Participants(
    int RoomNumber,
    Participant Participant);

public sealed record Participant(
    string UserName,
    string Email,
    int Point = 0);