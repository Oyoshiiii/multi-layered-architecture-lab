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
    public partial class SearchByIdForm : Form
    {
        Logic logic = new Logic();
        public SearchByIdForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
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

            Prosthesis prosthesis = logic.GetProsthesisById(id);

            if(prosthesis == null)
            {
                LblResult.Text = $"Протез с ID = {id} не найден.";
                return;
            }

            LblResult.Text =
                $"ID: {prosthesis.Id}\r\n" +
                $"Модель: {prosthesis.ModelName}\r\n" +
                $"Часть тела: {prosthesis.BodyPart}\r\n" +
                $"Процент потери рассудка: {prosthesis.PercentOfSanityLoss}%\r\n" +
                $"Баффы: {prosthesis.BuffDescription}\r\n" +
                $"Дебаффы: {prosthesis.DebuffDescription}\r\n" +
                $"Локация/место нахождения: {prosthesis.Origin}";
        }
    }
}
