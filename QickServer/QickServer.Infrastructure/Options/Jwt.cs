using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QickServer.Infrastructure.Options;
public class Jwt
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = string.Empty;
    public string SecretKey { get; set; } = default!;
}
