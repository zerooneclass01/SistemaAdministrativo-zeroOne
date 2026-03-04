using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades.Enum
{
    [Flags]
    public enum DiaDaSemana
    {
        None = 0,
        Monday = 1,    // Segunda
        Tuesday = 2,   // Terça
        Wednesday = 4, // Quarta
        Thursday = 8,  // Quinta
        Friday = 16,   // Sexta
        Saturday = 32, // Sábado
        Sunday = 64    // Domingo

    }
}
