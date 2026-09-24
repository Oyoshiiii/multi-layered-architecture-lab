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
    public partial class GroupedByBodyPartsForm : Form
    {
        List<Prosthesis> prostheses = new List<Prosthesis>();

        /// <summary>
        /// Инициализация формы группировки протезов по всем частям тела
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        public GroupedByBodyPartsForm(Logic logic)
        {
            InitializeComponent();

            prostheses = logic.GroupByAllBodyParts();
            GetGroupedProstheses();
        }

        private void GetGroupedProstheses()
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
