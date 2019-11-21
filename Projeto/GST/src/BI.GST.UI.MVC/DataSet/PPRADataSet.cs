namespace BI.GST.UI.MVC.DataSet
{


    partial class PPRADataSet
    {
        public static PPRADataSet AbrirDataSet(int id)
        {
            var ds = new PPRADataSet();
            var PPRATableAdapter = new DataSet.PPRADataSetTableAdapters.PPRATableAdapter();
            PPRATableAdapter.Fill(ds.PPRA, id);

            var AgentePPRATableAdapter = new DataSet.PPRADataSetTableAdapters.AgentePPRATableAdapter();
            AgentePPRATableAdapter.Fill(ds.AgentePPRA, id);

            var CronogramaTableAdapter = new DataSet.PPRADataSetTableAdapters.CronogramaDeAcoesTableAdapter();
            CronogramaTableAdapter.Fill(ds.CronogramaDeAcoes, id);

            var FuncionarioTableAdapter = new DataSet.PPRADataSetTableAdapters.FuncionarioTableAdapter();
            FuncionarioTableAdapter.Fill(ds.Funcionario, 2);

            var EmpresaTableAdapter = new DataSet.PPRADataSetTableAdapters.EmpresaTableAdapter();
            FuncionarioTableAdapter.Fill(ds.Funcionario, 2);

            var EscalaTableAdapter = new DataSet.PPRADataSetTableAdapters.EscalaTableAdapter();
            EscalaTableAdapter.Fill(ds.Escala, 2);

            var SetorTableAdapter = new DataSet.PPRADataSetTableAdapters.SetorTableAdapter();
            SetorTableAdapter.Fill(ds.Setor, 2);

            //var FisicoTableAdapter = new DataSet.PPRADataSetTableAdapters.FisicoTableAdapter();
            //FisicoTableAdapter.Fill(ds.Fisico, 2);

            var ErgonomicoTableAdapter = new DataSet.PPRADataSetTableAdapters.ErgonomicoTableAdapter();
            ErgonomicoTableAdapter.Fill(ds.Ergonomico, 2);

            //var QuimicoTableAdapter = new DataSet.PPRADataSetTableAdapters.QuimicoTableAdapter();
            //QuimicoTableAdapter.Fill(ds.Quimico, 2);

            var AcidenteTableAdapter = new DataSet.PPRADataSetTableAdapters.AcidenteTableAdapter();
            AcidenteTableAdapter.Fill(ds.Acidente, 2);

            return ds;
        }
    }
}
