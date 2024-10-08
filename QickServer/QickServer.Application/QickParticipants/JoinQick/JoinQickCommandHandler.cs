using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.QickParticipants.JoinQick;

internal sealed class JoinQickCommandHandler(
    IQickRepository qickRepository) : IRequestHandler<JoinQickCommand, Result<string>>
{
    public async Task<Result<string>> Handle(JoinQickCommand request, CancellationToken cancellationToken)
    {
        RoomNumber roomNumber = new(request.RoomNumber);
        Qick? qick = await qickRepository.GetByRoomNumberAsync(roomNumber, cancellationToken);

        if (qick is null)
        {
            return Result<string>.Failure("Qick not found");
        }

        //signalR oluştur, signalR'da buraya giriş yapanları kayıt altına alıyorsunuz. Ama kayıt altına alıtken qick numarasına dikkat ederek alıyorsunuz. Yani a numaralı qick(oda)'te a kişi var. B numaralı qick'te b kişi var gibi. Buradan geriye sadece ilgili qick'in kullanıcı listesini döndürüyorsunuz

        return "Join is successful";
    }
}
