﻿using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BI.GST.Application.Interface
{
    public interface ICIPAEmpresaAppService : IDisposable
    {
        IEnumerable<CIPAEmpresaViewModel> ObterTodos();

        CIPAEmpresaViewModel ObterPorId(int id);

        bool Adicionar(CIPAEmpresaViewModel cipaEmpresaViewModel);

        bool Atualizar(CIPAEmpresaViewModel cipaEmpresaViewModel);

        bool Excluir(int id);

        IEnumerable<CIPAEmpresaViewModel> ObterGrid(int page, string pesquisa);

        int ObterTotalRegistros(string pesquisa);
    }
}