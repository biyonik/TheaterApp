using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;

namespace TheaterApp.Forms
{
    public partial class frmAdd : Form
    {
        /// <summary>
        /// Statik tipteki bir Theatre sınıfı
        /// Yapıcı metotta bir örneği alınır
        /// Bu statik sınıfın btnAdd_Click metodunda içi dolduralacak 
        /// ve statik olduğu için program süresince sınıf ve değerlerine diğer formdan erişilebilecektir (bu form kapatıldığında bile)
        /// </summary>
        public static Theatre theatre;
        public frmAdd()
        {
            InitializeComponent();
            // theatre sınıfının bir örneği alınıyor
            theatre = new Theatre();
    
            FillFilterComboBox();
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
        /// Bu metotta butona tıklandığı zaman form üzerindeki nesnelerin değerleri okunur ve theatre nesnesinin propertylerine değer olarak aktarılır
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            /**
             *  Formdan gelen değerler bir değişkene aktarılmıştır
             *  TextBox nesnelerinden gelen değerler direkt atanırken
             *  ActivityRules için rtbxRules nesnesinden gelen metin '\n' karakterine göre parçalanmış ve bir string Listesine dönüştürülmüştür
             *  Yine TicketPrices için datagridview deki değerler okunmuş ve Theatre sınıfındaki property tanımına göre
             *  TicketPrices hashseti içine bir nesne oluşturularak(TicketPrice sınıfı) eklenmiştir
             *  Daha sonra theatre statik sınıf örneğinin propertylerine bu değişken değerleri atanmış ve form kapatılmıştır
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
            var translater = tbxTranslater.Text;
            var directedby = tbxDirectedBy.Text;
            var adaptedBy = tbxAdabtedBy.Text;
            var description = rtbxDescription.Text;
            ICollection<string> rules = new List<string>(rtbxRules.Text.Split('\u000A'));
            HashSet<TicketPrice> ticketPrices = new HashSet<TicketPrice>();
            if(dtgTicketPrices.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dtgTicketPrices.Rows)
                {
                    if(row.Cells[0].Value != null && row.Cells[1].Value != null)
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
            theatre.Id = Guid.NewGuid().ToString();
            theatre.Status = status;
            theatre.Title = title;
            theatre.Description = description;
            theatre.Date = date;
            theatre.Time = time;
            theatre.City = city;
            theatre.Theater = theater;
            theatre.Scene = scene; ;
            theatre.Writer = writer;
            theatre.Translater = translater;
            theatre.DirectedBy = directedby;
            theatre.AdaptedBy = adaptedBy;
            theatre.ActivityRules = rules;
            theatre.TicketPrices = ticketPrices;
            this.Close();

        }

        private void frmAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
