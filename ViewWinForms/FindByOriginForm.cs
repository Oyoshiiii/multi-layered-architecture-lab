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
    public partial class FindByOriginForm : Form
    {
        Logic logic = new Logic();
        List<Prosthesis> prostheses = new List<Prosthesis>();

        /// <summary>
        /// Инициализация формы поиска протезов по локации/месту нахождения
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        public FindByOriginForm(Logic logic)
        {
            InitializeComponent();
            CmbOrigin.DataSource = logic.GetOriginList();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            prostheses = logic.GroupBySpecificOrigin(CmbOrigin.Text);
            GetBySpecificOriginProstheses();

            if(prostheses.Count == 0) MessageBox.Show("В этой локации нет протезов");
        }

        private void GetBySpecificOriginProstheses()
        {
            prosthesesDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            prosthesesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            prosthesesDataGridView.Rows.Clear();

            foreach (Prosthesis prosthesis in prostheses)
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
    }
}
