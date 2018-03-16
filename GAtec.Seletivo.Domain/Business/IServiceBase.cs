using GAtec.Seletivo.Util;

namespace GAtec.Seletivo.Domain.Business
{
    interface IServiceBase
    {
        IValidationError Validator { get; set; }
    }
}
