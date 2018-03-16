using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Util.Validation
{
    public class DefaultValidation : IValidationError
    {
        private readonly IDictionary<string, ICollection<string>> _validator;

        public DefaultValidation()
        {
            _validator = new Dictionary<string, ICollection<string>>();
        }

        public void AddError(string key, string errorMessage)
        {
            if (_validator.ContainsKey(key))
            {
                _validator[key].Add(errorMessage);
            }
            else
            {
                _validator.Add(key, new List<string>() { errorMessage });
            }
        }

        public void AddError(string errorMessage)
        {
            AddError("DefaultErrorMessage", errorMessage);
        }

        public void ClearErrors()
        {
            _validator.Clear();
        }

        public bool IsValid => !_validator.Any();

        public bool Validate(object @object, bool clearErrors = true)
        {
            try
            {
                if (clearErrors)
                    ClearErrors();

                var context = new ValidationContext(@object, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                bool valid = Validator.TryValidateObject(@object, context, results, validateAllProperties: true);

                foreach (var result in results)
                {
                    AddError(result.MemberNames.FirstOrDefault(), result.ErrorMessage);
                }

                return IsValid;
            }
            catch
            {
                AddError("DefaultErrorMessage", "The input is not in a valid format.");
                return false;
            }
        }

        public bool ValidateList(IEnumerable<dynamic> list, string name, bool clearErrors = true)
        {
            try
            {
                if (clearErrors)
                    ClearErrors();

                int index = 0;

                foreach (var item in list)
                {
                    var context = new ValidationContext(item, serviceProvider: null, items: null);
                    var results = new List<ValidationResult>();
                    bool valid = Validator.TryValidateObject(item, context, results, validateAllProperties: true);

                    foreach (var result in results)
                        AddError($"{name}[{index}].{result.MemberNames.FirstOrDefault()}", result.ErrorMessage);

                    index++;
                }

                return IsValid;
            }
            catch
            {
                AddError("DefaultErrorMessage", "The input list is not in a valid format.");
                return false;
            }
        }

        public ICollection<string> this[string key] => _validator[key];

        public IDictionary<string, ICollection<string>> GetErrors()
        {
            return _validator;
        }

        public string GetAllMessages()
        {
            if (IsValid)
            {
                return string.Empty;
            }

            var s = new StringBuilder();

            foreach (var item in _validator)
                s.Append($"{item.Key}: {string.Join(". ", item.Value)}");

            return s.ToString();
        }

        public override string ToString()
        {
            return GetAllMessages();
        }
    }
}
