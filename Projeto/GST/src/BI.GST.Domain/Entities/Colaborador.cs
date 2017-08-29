﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Colaborador : Pessoa
  {
    public int ColaboradorId { get; set; }

    public virtual Empresa Empresa { get; set; }

    public bool Delete { get; set; }
  }
}
