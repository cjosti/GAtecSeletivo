using GAtec.Seletivo.Util;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IServiceBase
    {
        IValidationError Validator { get; set; }
    }
}
