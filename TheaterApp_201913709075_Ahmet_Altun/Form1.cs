using System;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;
using TheaterApp.Forms;
using TheaterApp.Services.Concrete;

/**
 * 
 *  Ahmet ALTUN
 *  201913709075
 *  Bilgisayar Mühendisliği
 *  https://github.com/biyonik
 *  
 *  Uygulama yapılırken Biletix.com sitesindeki Sahne->Tiyatro sayfasındaki tiyatro oyunları örnek alınmış ve modellenmiştir
 * 
 * */
namespace TheaterApp
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Jenerik Servis sınıfından bir nesne oluşturmak için tanımlanmıştır
        /// Bu sınıf dışında erişim olmayacağı için private
        /// Sonradan değeri değiştirilmeyeceği için readonly dir
        /// </summary>
        private readonly Service<Theatre> theaterService;
        public frmMain()
        {
            InitializeComponent();
            // theaterService değişkenine Service jenerik sınıfından bir örnek atanıyor
            theaterService = new Service<Theatre>();
            // DatagridView için başlıkların otomatik oluşturulmasını engeller
            theaterDataGridView.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Formun ilk yüklenmesinde
        /// DataGridViewDoldurulur
        /// Filtreleme işlemindeki ComboBox Doldurulur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            GetAllTheatre();
            FillFilterComboBox();
        }

        /// <summary>
        /// Ana formdaki dataGridView in veri kaynağına Servis sınıfındaki GetAll metodundan dönen değerler atanıyor
        /// Tüm json dosyası içeriği okunup, deserileştirme işlemi yapılıp, gridviewde listelenmiştir
        /// </summary>
        public void GetAllTheatre()
        {
            theaterDataGridView.DataSource = theaterService.GetAll();
        }

        /// <summary>
        /// Status enumunu comboboxa veri kaynağı olarak atar
        /// </summary>
        public void FillFilterComboBox()
        {
            cmbBoxStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbBoxStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// Filtreleme işlemi için comboboxtaki seçili değer okunur ve Status enumuna cast edilir
        /// Daha sonra Servis sınıfının GetAll metodu çağrılır fakat expression olarak 
        /// x öyle ki x'in Status değeri comboboxtan gelen statusa eşit olanlar olmalı diye şart koşulur
        /// Bu metottan dönen değerler ki boş dahi olabilir gridview e veri kaynağı olarak aktarılır
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Status status = (Status)cmbBoxStatus.SelectedValue;
            var filteredData = theaterService.GetAll(x => x.Status == status);
            theaterDataGridView.DataSource = filteredData;
        }

        /// <summary>
        /// Filtrelemeyi temizlemek için
        /// gridviewin veri kaynağı servis sınıfındaki getAll metodu ile tekrar doldurulur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            theaterDataGridView.DataSource = theaterService.GetAll();
        }

        /// <summary>
        /// Arama metin kutusunun içeriği değiştikçe tetiklenir
        /// eğer metin kutusunda bir değer var ise
        /// bu değer ele alınarak Service sınıfındaki GetAll metodu çağrılır
        /// Fakat bu metot çağrılırken bir expression parametre verilir
        /// x öyleki x'in Title değeri textbox nesnesindeki değeri içermelidir
        /// Geri dönen değer ki bu değerler boş olabilir gridview in veri kaynağına atanır
        /// Eğer textbox ta değer kalmaz, içeriği silinir ise gridview tekrar getAll ile herhangi bir filtreleme olmadan doldurulur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var tbx = sender as TextBox;
            if(tbx != null)
            {
                string text = tbx.Text;
                if(!string.IsNullOrEmpty(text))
                {
                    var filteredData = theaterService.GetAll(x => x.Title.Contains(text));
                    theaterDataGridView.DataSource = filteredData;
                } else
                {
                    theaterDataGridView.DataSource = theaterService.GetAll();
                }
            }
        }

        /// <summary>
        /// Ekleme formunu açar
        /// Aynı zamanda diğer formdaki statik olan theatre adındaki sınıf örneğine de erişir
        /// eğer bu sınıf örneğinin title değeri null değil ise
        /// Service sınıfındaki Update metodu çağrılır ve parametre olarak bu entity verilir
        /// Daha sonra GetAllTheatre ile gridview in veri kaynağı yenilenir
        /// Ve ekleme formundaki statik theatre sınıf örneği ne null atanır
        /// Çünkü program süresince bir çok ekleme işlemi yapılabilir. 
        /// Statik öğenin sıfırlanması ve Title değerinin de boş olması için bu yöntem tercih edilmiştir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.ShowDialog();
            var addedEntity = frmAdd.theatre;
            if(!string.IsNullOrEmpty(addedEntity.Title))
            {
                await theaterService.AddAsync(addedEntity);
                GetAllTheatre();
                frmAdd.theatre= null;
            }
        }

        /// <summary>
        /// Silme işlemi yapar
        /// Yapmadan önce kullanıcıdan onay ister
        /// Onay verilirse ise gridview deki seçili satırın ilk hücresinin değerini alır
        /// İlk değer Id değerini tutuyor fakat görünürde gizlidir
        /// Service sınıfındaki getByIdAsync metodu ile seçili satır bir entity olarak ele alınır
        /// Yine Service sınıfındaki remove metodunda bu entity parametre olarak verilerek silme işlemi yapılmış olur
        /// GetAllTheatre ile gridview in veri kaynağı yenilenir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Bu kaydı silmek istiyor musunuz?","Soru",MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                var selectedItemId = theaterDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                var entity = await theaterService.GetByIdAsync(selectedItemId);
                theaterService.Remove(entity);
                GetAllTheatre();
            }
        }

        /// <summary>
        /// Detaylar formunu açar
        /// Açmadan önce gridview deki seçili satırın ilk hücresinin değerini alır
        /// İlk değer Id değerini tutuyor fakat görünürde gizlidir
        /// Service sınıfındaki getByIdAsync metodu ile seçili satır bir entity olarak ele alınır
        /// Bu entity detail formunun yapıcı metoduna parametre olarak geçilir
        /// frmDetail bir diyalog penceresi olarak ekranda gösterilir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDetails_Click(object sender, EventArgs e)
        {
            var selectedItemId = theaterDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            var entity = await theaterService.GetByIdAsync(selectedItemId);
            frmDetail frmDetail = new frmDetail(entity);
            frmDetail.ShowDialog();
        }

        /// <summary>
        /// Güncelleme formunu açar
        /// Açmadan önce gridview deki seçili satırın ilk hücresinin değerini alır
        /// İlk değer Id değerini tutuyor fakat görünürde gizlidir
        /// Service sınıfındaki getByIdAsync metodu ile seçili satır bir entity olarak ele alınır
        /// Bu entity güncelleme formunun yapıcı metoduna parametre olarak geçilir
        /// frmDetail bir diyalog penceresi olarak ekranda gösterilir
        /// updatedEntity ise frmUpdate sınıfındaki statik olan updatedEntity sınıfına erişir
        /// Eğer güncellenecek entitynin Title değeri boş değil ise
        /// Service sınıfının Update metodu çalıştırılır ve updatedEntity parametre olarak verilir
        /// gridViewin veri kaynağı yenilenir (GetAllTheatre)
        /// frmUpdate sınıfındaki updatedEntity statik sınıf örneğine null atanır
        /// Çünkü program süresince bir çok güncelleme işlemi yapılabilir. 
        /// Statik öğenin sıfırlanması ve Title değerinin de boş olması için bu yöntem tercih edilmiştir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedItemId = theaterDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            var entity = await theaterService.GetByIdAsync(selectedItemId);
            frmUpdate frmUpdate = new frmUpdate(entity);
            frmUpdate.ShowDialog();
            var updatedEntitiy = frmUpdate.updatedEntity;
            if(updatedEntitiy.Title != null)
            {
                theaterService.Update(updatedEntitiy);
                GetAllTheatre();
                frmUpdate.updatedEntity = null;
            }
        }
    }
}
