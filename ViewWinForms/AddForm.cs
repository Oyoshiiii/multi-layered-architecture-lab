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
    public partial class AddForm : Form
    {
        Logic logic = new Logic();

        /// <summary>
        /// Инициализация формы добавления протеза
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="bodyParts">Лист частей тела</param>
        /// <param name="originList">Лист локаций/мест нахождения</param>
        public AddForm(Logic logic, List<string> bodyParts, List<string> originList)
        {
            InitializeComponent();
            this.logic = logic;

            CmbBodyPart.DataSource = bodyParts;
            CmbOrigin.DataSource = originList;
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtID.Text))
            {
                MessageBox.Show("Введите ID");
                return;
            }

            if (!int.TryParse(TxtID.Text.Trim(), out int id))
            {
                MessageBox.Show("ID должен быть целым числом");
                return;
            }

            var all = logic.GetAllProstheses();
            if (all.Any(p => p.Id == id))
            {
                MessageBox.Show($"Протез с ID = {id} уже существует");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtModelName.Text))
            {
                MessageBox.Show("Введите название модели");
                TxtModelName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtBuffDescript.Text))
            {
                MessageBox.Show("Введите баффы протеза");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtDebuffDescript.Text))
            {
                MessageBox.Show("Введите дебаффы протеза");
                return;
            }

            string ModelName = TxtModelName.Text.Trim();
            string BodyPart = CmbBodyPart.SelectedItem.ToString();
            int PercentOfSanityLoss = (int)NumPercentOfSanityLoss.Value;
            string BuffDescription = TxtBuffDescript.Text.Trim();
            string DebuffDescription = TxtDebuffDescript.Text.Trim();
            string Origin = CmbOrigin.SelectedItem.ToString();

            logic.AddProsthesis(id, ModelName, BodyPart, PercentOfSanityLoss, BuffDescription, DebuffDescription, Origin);
            MessageBox.Show("Протез добавлен");

            this.Close();
        }
    }
}
