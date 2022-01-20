using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;

namespace TheaterApp.Forms
{
    public partial class frmUpdate : Form
    {
        /// <summary>
        /// Private readonly bir Theatre sınıfı
        /// Yapıcı metotta bir örneği dependency injection yaklaşımı ile alınır
        /// Statik tipteki bir Theatre sınıfı (updatedEntity)
        /// Yapıcı metotta bir örneği alınır
        /// Bu statik sınıfın btnAdd_Click metodunda içi dolduralacak 
        /// ve statik olduğu için program süresince sınıf ve değerlerine diğer formdan erişilebilecektir (bu form kapatıldığında bile)
        /// </summary>
        private readonly Theatre _theatre;
        public static Theatre updatedEntity;
        public frmUpdate(Theatre theatre)
        {
            InitializeComponent();
            FillFilterComboBox();

            _theatre = theatre;
            updatedEntity = new Theatre();
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
        /// Bu form üzerindeki görsel nesnelerin değerleri _theatre nesne örneğindeki propertylerin değerleri tarafından doldurulur (eğer nesne örneği null değil ise)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            if (_theatre != null)
            {
                updatedEntity.Id = _theatre.Id;
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

        /// <summary>
        /// Bu metotta butona tıklandığı zaman form üzerindeki nesnelerin değerleri okunur ve updatedEntity nesnesinin propertylerine değer olarak aktarılır
        /// ayrıca bu bir güncelleme işlemi olduğu için updatedEntity sınıfının Id propertysi eski değerleri taşıyan _theatre sınıf örneğinin Id propertsinin değerini alır
        /// Böylece Id dışındaki tüm değerler güncellemeye açıktır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            /**
             *  Formdan gelen değerler değişkenlere aktarılmıştır
             *  TextBox nesnelerinden gelen değerler direkt atanırken
             *  ActivityRules için rtbxRules nesnesinden gelen metin '\n' karakterine göre parçalanmış ve bir string Listesine dönüştürülmüştür
             *  Yine TicketPrices için datagridview deki değerler okunmuş ve Theatre sınıfındaki property tanımına göre
             *  TicketPrices hashseti içine bir nesne oluşturularak(TicketPrice sınıfı) eklenmiştir
             *  Daha sonra updatedEntity statik sınıf örneğinin propertylerine bu değişken değerleri atanmış ve form kapatılmıştır
             * 
             * */
            var status = (Status)cmbStatus.SelectedIndex;
            var title = tbxTitle.Text;
            var date = dtpDate.Value.Date;
            var time = tbxTime.Text;
            var city = tbxCity.Text;
            var theater = tbxTheater.Text;
            var scene = tbxScene.Text;
            var writer = tbxWriter.Text;
            var translater = tbxWriter.Text;
            var directedby = tbxDirectedBy.Text;
            var adaptedBy = tbxAdabtedBy.Text;
            var description = rtbxDescription.Text;
            ICollection<string> rules = new List<string>(rtbxRules.Text.Split('\u000A'));
            HashSet<TicketPrice> ticketPrices = new HashSet<TicketPrice>();
            if (dtgTicketPrices.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgTicketPrices.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        TicketPrice ticketPrice = new TicketPrice()
                        {
                            Level = row.Cells[0].Value.ToString(),
                            Price = decimal.Parse(row.Cells[1].Value.ToString())
                        };
                        ticketPrices.Add(ticketPrice);
                    }

                }
            }
            updatedEntity.Id = Guid.NewGuid().ToString();
            updatedEntity.Status = status;
            updatedEntity.Title = title;
            updatedEntity.Description = description;
            updatedEntity.Date = date;
            updatedEntity.Time = time;
            updatedEntity.City = city;
            updatedEntity.Theater = theater;
            updatedEntity.Scene = scene; ;
            updatedEntity.Writer = writer;
            updatedEntity.Translater = translater;
            updatedEntity.DirectedBy = directedby;
            updatedEntity.AdaptedBy = adaptedBy;
            updatedEntity.ActivityRules = rules;
            updatedEntity.TicketPrices = ticketPrices;
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
