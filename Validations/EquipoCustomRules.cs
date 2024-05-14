using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Administracion_equipos.Validations
{
    public class EquipoCustomRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;
            int len = val.Length;
            if (len < 8 || len > 25 )
            {
                return new ValidationResult(false, "Nombre de equipo debe tener entre o y 25 caracteres");
            }
            if (len == 0)
            {
                return new ValidationResult(false, "Nombre de equipo no puede estar vacio");
            }

            return new ValidationResult(true, null);

        }
    }
}
