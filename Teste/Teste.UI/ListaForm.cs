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
                var clientes = logic.List();
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

                var cliente = logic.Get(id);

                var form = new CadastroForm(this, cliente);
                form.Show();
            }
        }

        private void dgvClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var column = dgvClientes.CurrentRow?.Cells["Id"].Value.ToString();
                int.TryParse(column, out int id);

                if (id > 0)
                {
                    var dr = MessageBox.Show("Deseja realmente remover este registro?", "Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            using (var logic = new ClienteLogic())
                            {
                                logic.Remove(id);
                                AtualizarGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
