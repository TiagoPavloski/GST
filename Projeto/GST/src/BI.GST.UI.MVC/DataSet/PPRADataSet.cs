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
            FuncionarioTableAdapter.Fill(ds.Funcionario, 8);

            var EmpresaTableAdapter = new DataSet.PPRADataSetTableAdapters.EmpresaTableAdapter();
            FuncionarioTableAdapter.Fill(ds.Funcionario, 8);

            return ds;
        }
    }
}
