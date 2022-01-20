using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;
using TheaterApp.Forms;
using TheaterApp.Services.Concrete;

namespace TheaterApp
{
    public partial class frmMain : Form
    {
        private readonly Service<Theatre> theaterService;
        public frmMain()
        {
            InitializeComponent();
            theaterService = new Service<Theatre>();
            theaterDataGridView.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetAllTheatre();
            FillFilterComboBox();
        }

        public void GetAllTheatre()
        {
            theaterDataGridView.DataSource = theaterService.GetAll();
        }

        public void FillFilterComboBox()
        {
            cmbBoxStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbBoxStatus.SelectedIndex = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Status status = (Status)cmbBoxStatus.SelectedValue;
            var filteredData = theaterService.GetAll(x => x.Status == status);
            theaterDataGridView.DataSource = filteredData;
        }

        private void btnFilterReset_Click(object sender, EventArgs e)
        {
            theaterDataGridView.DataSource = theaterService.GetAll();
        }

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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.ShowDialog();
            var addedEntity = frmAdd.theatre;
            if(!string.IsNullOrEmpty(addedEntity.Title))
            {
                await theaterService.AddAsync(addedEntity);
                GetAllTheatre();
                frmUpdate.updatedEntity = null;
            }
        }

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

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            var selectedItemId = theaterDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            var entity = await theaterService.GetByIdAsync(selectedItemId);
            frmDetail frmDetail = new frmDetail(entity);
            frmDetail.ShowDialog();
        }

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
