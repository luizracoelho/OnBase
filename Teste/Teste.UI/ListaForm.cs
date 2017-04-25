using System;
using System.Windows.Forms;

namespace Teste.UI
{
    public partial class ListaForm : Form
    {
        public ListaForm()
        {
            InitializeComponent();
        }

        private void ListaForm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            using (var logic = new ClienteLogic())
            {
                var clientes = logic.Listar();
                bsClientes.DataSource = clientes;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CadastroForm(this);
            form.Show();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var logic = new ClienteLogic())
            {
                int.TryParse(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out int id);

                var cliente = logic.Encontrar(id);

                var form = new CadastroForm(this, cliente);
                form.Show();
            }
        }
    }
}
