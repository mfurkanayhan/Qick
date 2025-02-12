using QickServer.Domain.QickDetails;
using QickServer.Domain.Shared;

namespace QickServer.Domain.Qicks;
public sealed class Qick : Entity
{
    public Qick(Title title, RoomNumber roomNumber)
    {
        Title = title;
        RoomNumber = roomNumber;        
    }
    public Title Title { get; private set; }
    public RoomNumber RoomNumber { get; private set; }

    public IReadOnlyCollection<QickDetail> Details { get; private set; } = default!;

    public void ChangeTitle(Title title)
    {
        Title = title;
    }

    public void ChangeRoomNumber(RoomNumber roomNumber)
    {
        RoomNumber= roomNumber;
    }
}
