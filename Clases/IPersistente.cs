﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    internal interface IPersistente
    {
        bool Create();
        bool Read(int id);
        bool Update();
        bool Delete(int id);
    }
}
