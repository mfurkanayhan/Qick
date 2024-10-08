using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.Qicks.CreateQick;

internal sealed class CreateQickCommandHandler(
    IQickRepository qickRepository) : IRequestHandler<CreateQickCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateQickCommand request, CancellationToken cancellationToken)
    {
        Title title = new(request.Title);
        int roomNumberInt = new Random().Next(000000, 999999);
        RoomNumber roomNumber = new(roomNumberInt);

        if (await qickRepository.IsRoomNumberExists(roomNumber, cancellationToken))
        {
            roomNumberInt = new Random().Next(000000, 999999);
            roomNumber = new(roomNumberInt);
        }

        Qick qick = new(title, roomNumber);
        await qickRepository.CreateAsync(qick, cancellationToken);

        return "Qick create is successful";
    }
}