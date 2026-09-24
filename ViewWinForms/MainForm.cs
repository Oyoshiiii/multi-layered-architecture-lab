using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWinForms
{
    public partial class MainForm : Form
    {
        Logic logic = new Logic();
        List<Prosthesis> prostheses = new List<Prosthesis>();

        List<string> bodyParts = new List<string>();
        List<string> originList = new List<string>();

        /// <summary>
        /// Инициализация главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            prostheses = logic.GetAllProstheses();

            bodyParts = logic.GetBodyPartsList();
            originList = logic.GetOriginList();
        }

        private void GetAllBtn_Click(object sender, EventArgs e)
        {
            ascending.Checked = false;
            descending.Checked = false;

            GetAllProstheses(prostheses);
        }

        private void GetAllProstheses(List<Prosthesis> prostheses)
        {
            prosthesesDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            prosthesesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            prosthesesDataGridView.Rows.Clear();

            foreach(Prosthesis prosthesis in prostheses)
            {
                prosthesesDataGridView.Rows.Add(
                    prosthesis.Id,
                    prosthesis.ModelName,
                    prosthesis.BodyPart,
                    prosthesis.PercentOfSanityLoss,
                    prosthesis.BuffDescription,
                    prosthesis.DebuffDescription,
                    prosthesis.Origin
                );
            }
        }

        private void GetByIDBtn_Click(object sender, EventArgs e)
        {
            var searchByIdForm = new SearchByIdForm(logic);
            searchByIdForm.ShowDialog();

            GetAllProstheses(prostheses);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(logic, bodyParts, originList);
            addForm.ShowDialog();

            GetAllProstheses(prostheses);
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            var prosthesis = GetSelectedProsthesis();

            if (prosthesis == null)
            {
                MessageBox.Show("Выберите протез, который хотите изменить");
                return;
            }

            var changeForm = new ChangeForm(prosthesis, logic, bodyParts, originList);
            changeForm.ShowDialog();

            GetAllProstheses(prostheses);
        }

        private Prosthesis GetSelectedProsthesis()
        {
            if (prosthesesDataGridView.SelectedRows.Count == 0)
                return null;

            var row = prosthesesDataGridView.SelectedRows[0];

            Prosthesis prosthesis = logic.GetProsthesisById(Convert.ToInt32(row.Cells["Id"].Value));

            return prosthesis;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var prosthesis = GetSelectedProsthesis();

            if (prosthesis == null)
            {
                MessageBox.Show("Выберите протез, который хотите удалить");
                return;
            }

            DialogResult result = MessageBox.Show("Точно хотите удалить протез?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                logic.DeleteProsthesis(prosthesis.Id);
                MessageBox.Show($"Протез ID: {prosthesis.Id} удален");
            }

            GetAllProstheses(prostheses);
        }

        private void ascending_CheckedChanged(object sender, EventArgs e)
        {
            if(ascending.Checked)
            {
                List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLoss(prostheses);
                GetAllProstheses(sortedProstheses);
            }
        }

        private void descending_CheckedChanged(object sender, EventArgs e)
        {

            if (descending.Checked)
            {
                List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLossDescending(prostheses);
                GetAllProstheses(sortedProstheses);
            }
        }

        private void GroupByBodyPart_Click(object sender, EventArgs e)
        {
            var groupedForm = new GroupedByBodyPartsForm(logic);
            groupedForm.ShowDialog();

            GetAllProstheses(prostheses);
        }

        private void FindByOriginBtn_Click(object sender, EventArgs e)
        {
            var findForm = new FindByOriginForm(logic);
            findForm.ShowDialog();

            GetAllProstheses(prostheses);
        }
    }
}
