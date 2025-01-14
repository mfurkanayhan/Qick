using QickServer.Domain.Qicks;
using QickServer.Domain.Shared;

namespace QickServer.Domain.QickDetails;
public sealed class QickDetail : Entity
{
    public Id QickId { get; set; } = default!;
    public Title Title { get; set; } = default!;
}