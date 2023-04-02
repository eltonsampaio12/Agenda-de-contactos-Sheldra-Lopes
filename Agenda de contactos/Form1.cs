using Agenda_de_contactos.Entidades;
using System.Windows.Forms;

namespace Agenda_de_contactos
{
    public partial class Form1 : Form
    {
        ListView listView = new ListView();
        Pessoa? selectedPerson;
        List<Pessoa> pessoas;
        public Form1()
        {
            pessoas = new List<Pessoa>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listView.SelectedIndexChanged += new EventHandler(listView_SelectedIndexChanged);

            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;

            listView.HeaderStyle = ColumnHeaderStyle.None;
            listView.View = View.LargeIcon;
            listView.Columns.Add("", 800);
            listView.Columns.Add("", 800);

            foreach (Pessoa pessoa in pessoas)
            {
                ListViewItem item = new ListViewItem(new string[] { pessoa.Nome, pessoa.Id.ToString() });
                listView.Items.Add(item);
            }

            tabPage1.Controls.Add(listView);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa novaPessoa = new Pessoa("Novo Nome", "", 000000, 000000, "", "", "", "");
            pessoas.Add(novaPessoa);

            // Add new person to ListView
            ListViewItem novoItem = new ListViewItem(new string[] { novaPessoa.Nome, novaPessoa.Id.ToString() });
            listView.Items.Add(novoItem);
            listView.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (selectedPerson == null)
            {
                MessageBox.Show("Selecione uma pessoa");
                return;
            }
            tabControl1.SelectedIndex = 1;

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                int selectedPersonID = Convert.ToInt32(selectedItem.SubItems[1].Text);
                // Vai a lista de pessoa, e retorna a pessoa com o id
                selectedPerson = pessoas.Find(p => p.Id == selectedPersonID);

                // guard clause technique
                if (selectedPerson == null) return;

                NomeTextBox.Text = selectedPerson.Nome;
                SNTextBox.Text = selectedPerson.SobreNome;
                FoneTextBox.Text = selectedPerson.Fone.ToString();
                CLTextBox.Text = selectedPerson.Celular.ToString();
                EmailTextBox.Text = selectedPerson.Email;
                WebTextBox.Text = selectedPerson.Web;
                ENTextBox.Text = selectedPerson.Endereco;
                NTTextBox.Text = selectedPerson.Notas;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (selectedPerson == null) return;


            string nome = NomeTextBox.Text;
            string sobreNome = SNTextBox.Text;
            string fone = FoneTextBox.Text;
            string celular = CLTextBox.Text;
            string email = EmailTextBox.Text;
            string web = WebTextBox.Text;


            // verificar se o nome não é nulo
            // verificar se o nome tem um tamanho maior que zero
            // verifica se o nome dentro do formulário é diferente do nome da pessoa atual.

            if (nome != null && nome.Length > 0 && nome != selectedPerson.Nome)
            {
                selectedPerson.Nome = nome;
            }

            if (sobreNome != null && sobreNome.Length > 0 && sobreNome != selectedPerson.SobreNome)
            {
                selectedPerson.SobreNome = sobreNome;
            }

            if (fone != null && fone.Length > 0 && fone != selectedPerson.Fone.ToString())
            {
                selectedPerson.Fone = Convert.ToInt32(fone);
            }



            if (celular != null && celular.Length > 0 && celular != selectedPerson.Celular.ToString())
            {
                selectedPerson.Celular = Convert.ToInt32(celular);
            }

            if (email != null && email.Length > 0 && email != selectedPerson.Email)
            {
                selectedPerson.Email = email;
            }


            if (web != null && web.Length > 0 && web != selectedPerson.Web)
            {
                selectedPerson.Web = web;
            }



            Mensagem("Pessoa adicionada ou Editada");
            // atualizar a list view
            RefreshListView();
            selectedPerson = null;
            tabControl1.SelectedIndex = 0;


        }

        // metodo para atualizar a list view.
        public void RefreshListView()
        {
            listView.Items.Clear();
            foreach (Pessoa pessoa in pessoas)
            {
                ListViewItem item = new ListViewItem(new string[] { pessoa.Nome, pessoa.Id.ToString() });
                listView.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedPerson == null)
            {
                Mensagem("Selecione uma pessoa");
                return;
            }
            pessoas.Remove(selectedPerson);
            Mensagem("Pessoa removida");
            RefreshListView();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedPerson == null)
            {
                Mensagem("Selecione uma pessoa");
                return;
            };


            string endereco = ENTextBox.Text;
            string notas = NTTextBox.Text;



            // verificar se o nome não é nulo
            // verificar se o nome tem um tamanho maior que zero
            // verifica se o nome dentro do formulário é diferente do nome da pessoa atual.

            if (endereco != null && endereco.Length > 0 && endereco != selectedPerson.Endereco)
            {
                selectedPerson.Endereco = endereco;
            }

            if (notas != null && notas.Length > 0 && notas != selectedPerson.Endereco)
            {
                selectedPerson.Notas = notas;
            }


            Mensagem("Pessoa editada");
            tabControl1.SelectedIndex = 0;

        }

        private void Mensagem(string mensagem)
        {
            MessageBox.Show(mensagem);

        }
    }
}