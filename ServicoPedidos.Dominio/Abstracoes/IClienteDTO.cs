﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoPedidos.Dominio.Abstracoes
{
    public interface IClienteDTO : IEntidade
    {
        string Nome { get; set; }
    }
}
