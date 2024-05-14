using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Administracion_equipos.Validations
{
    public class NoNullorEmtyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;
            if (string.IsNullOrEmpty(val)) {
                return new ValidationResult(false, "Este campo es requerido");

            }

            return new ValidationResult(true, null);

        }
    }
}
