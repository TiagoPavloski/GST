namespace BI.GST.UI.MVC.DataSets
{


    partial class DataSetPPRA
    {
        public static DataSetPPRA AbrirDataSet(int id)
        {
            var ds = new DataSetPPRA();
            var PPRATableAdapter = new DataSets.DataSetPPRATableAdapters.PPRATableAdapter();
            PPRATableAdapter.Fill(ds.PPRA, id);

            var AgentePPRATableAdapter = new DataSets.DataSetPPRATableAdapters.AgentePPRATableAdapter();
            AgentePPRATableAdapter.Fill(ds.AgentePPRA, id);

            var CronogramaTableAdapter = new DataSets.DataSetPPRATableAdapters.CronogramaDeAcoesTableAdapter();
            CronogramaTableAdapter.Fill(ds.CronogramaDeAcoes, id);

            var FuncionarioTableAdapter = new DataSets.DataSetPPRATableAdapters.FuncionarioTableAdapter();
            FuncionarioTableAdapter.Fill(ds.Funcionario, 8);


            return ds;
        }
    }
}
