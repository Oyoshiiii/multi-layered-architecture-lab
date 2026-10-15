using BusinessLogic;
using Entities;
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
    public partial class ChangeForm : Form
    {
        Logic logic = new Logic();
        Prosthesis prosthesis;

        /// <summary>
        /// Инициализация формы изменения протеза
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="bodyParts">Лист частей тела</param>
        /// <param name="originList">Лист локаций/мест нахождения</param>
        public ChangeForm(Prosthesis prosthesis, Logic logic, List<string> bodyParts, List<string> originList)
        {
            InitializeComponent();
            this.logic = logic;
            this.prosthesis = prosthesis;

            CmbBodyPart.DataSource = bodyParts;
            CmbOrigin.DataSource = originList;

            TxtID.Text = prosthesis.Id.ToString();
            TxtModelName.Text = prosthesis.ModelName;
            CmbBodyPart.SelectedItem = prosthesis.BodyPart;
            NumPercentOfSanityLoss.Value = prosthesis.PercentOfSanityLoss;
            TxtBuffDescript.Text = prosthesis.BuffDescription;
            TxtDebuffDescript.Text = prosthesis.DebuffDescription;
            CmbOrigin.SelectedItem = prosthesis.Origin;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtModelName.Text))
            {
                MessageBox.Show("Введите название модели");
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

            logic.ChangeProsthesis(prosthesis.Id, ModelName, BodyPart, PercentOfSanityLoss, BuffDescription, DebuffDescription, Origin);
            MessageBox.Show("Изменения сохранены");

            this.Close();
        }
    }
}
