using System;
using System.Windows.Forms;

namespace Teste.UI
{
    public partial class CadastroForm : Form
    {
        ListaForm _listaForm;
        Cliente _cliente;

        public CadastroForm(ListaForm listaForm)
        {
            InitializeComponent();

            _listaForm = listaForm;
        }

        public CadastroForm(ListaForm listaForm, Cliente cliente) : this(listaForm)
        {
            _cliente = cliente;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int.TryParse(txtId.Text, out int id);
            var cliente = new Cliente
            {
                Id = id,
                Nome = txtNome.Text,
                Email = txtEmail.Text
            };

            try
            {
                using (var logic = new ClienteLogic())
                {
                    logic.Save(cliente);
                    _listaForm.AtualizarGrid();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void CadastroForm_Load(object sender, EventArgs e)
        {
            if (_cliente != null)
            {
                txtId.Text = _cliente.Id.ToString();
                txtNome.Text = _cliente.Nome;
                txtEmail.Text = _cliente.Email;
            }
        }
    }
}
