﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominioService.MasterTables.Utility
{
    public class Tables
    {
        public class Action
        {
            public const string Insertar = "I";
            public const string Actualizar = "U";
        }

        public class Estado
        {
            public const string Activo = "1";
            public const string Inactivo="0";
        }
    }

}