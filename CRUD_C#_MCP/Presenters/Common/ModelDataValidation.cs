using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUD_C__MCP.Presenters.Common
{
    public class ModelDataValidation
    {
        public void ValidateModel(object model)
        {
            string errorMessage = "";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    errorMessage += result.ErrorMessage + "\n";
                }
                throw new Exception(errorMessage);
            }
        }
    }
}
