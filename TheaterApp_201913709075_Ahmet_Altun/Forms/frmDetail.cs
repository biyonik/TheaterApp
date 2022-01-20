using System;
using System.Linq;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;

namespace TheaterApp.Forms
{
    public partial class frmDetail : Form
    {
        private readonly Theatre _theatre;
        public frmDetail(Theatre theatre)
        {
            InitializeComponent();
            FillFilterComboBox();
            _theatre = theatre;
        }

        public void FillFilterComboBox()
        {
            cmbStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbStatus.SelectedIndex = 0;
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
            if(_theatre != null)
            {
                cmbStatus.SelectedItem = _theatre.Status;
                tbxTitle.Text = _theatre.Title;
                dtpDate.Value = _theatre.Date;
                tbxTime.Text = _theatre.Time;
                tbxCity.Text = _theatre.City;
                tbxTheater.Text = _theatre.Theater;
                tbxScene.Text = _theatre.Scene;
                tbxWriter.Text = _theatre.Writer;
                tbxTranslater.Text = _theatre.Translater;
                tbxDirectedBy.Text = _theatre.DirectedBy;
                tbxAdabtedBy.Text = _theatre.AdaptedBy;
                rtbxDescription.Text = _theatre.Description;
                rtbxRules.Text = string.Join(Environment.NewLine, _theatre.ActivityRules.ToArray());
                dtgTicketPrices.DataSource = _theatre.TicketPrices;
            }
            
        }
    }
}
