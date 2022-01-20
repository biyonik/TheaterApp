using System;
using System.Linq;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;

namespace TheaterApp.Forms
{
    public partial class frmDetail : Form
    {
        /// <summary>
        /// Private readonly bir Theatre sınıfı
        /// Yapıcı metotta bir örneği dependency injection yaklaşımı ile alınır
        /// </summary>
        private readonly Theatre _theatre;
        public frmDetail(Theatre theatre)
        {
            InitializeComponent();
            FillFilterComboBox();
            _theatre = theatre;
        }

        /// <summary>
        /// Bu form üzerindeki cmbStatus combobox nesnesinin veri kaynağını doldurur
        /// Status enumundaki değerler bu seçim kutusunda listelenir
        /// </summary>
        public void FillFilterComboBox()
        {
            cmbStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// Bu form üzerindeki görsel nesnelerin değerleri theatre nesne örneğindeki propertylerin değerleri tarafından doldurulur
        /// Varsayılan olarak tüm görsel öğeler aktif değildir
        /// Sadece değerler görüntülenir.
        /// CRUD operasyon ailesinin R(ead) aksiyonu kotarılmış ve Jenerik Reponun GetById metodunun çalışılabilirliği kanıtlanmaya çalışılmıştır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
