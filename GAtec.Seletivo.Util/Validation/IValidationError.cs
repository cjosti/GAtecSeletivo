using System;
using System.Linq;
using System.Collections.Generic;

namespace GAtec.Seletivo.Util
{
    public interface IValidationError
    {
        void AddError(string key, string errorMessage);
        void AddError(string errorMessage);
        void ClearErrors();

        bool IsValid { get; }

        bool Validate(object @object, bool clearErrors = true);
        bool ValidateList(IEnumerable<dynamic> list, string name, bool clearErrors = true);

        ICollection<string> this[string key] { get; }

        IDictionary<string, ICollection<string>> GetErrors();

        string GetAllMessages();
    }


}
