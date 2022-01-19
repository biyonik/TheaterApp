using System;
using System.Windows.Forms;
using TheaterApp.Entities.Concrete;
using TheaterApp.Entities.Enums;
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
            GetAllTheatreAsync();
            FillFilterComboBox();
        }

        public async void GetAllTheatreAsync()
        {
            theaterDataGridView.DataSource = await theaterService.GetAllAsync();
            //var data = await theaterService.GetByIdAsync("721ba0ec-e96f-47e4-91c3-9105dc7a8f2c");
            //MessageBox.Show(data.ToString());
            //await theaterService.GetByIdAsync("a9f33330-eb55-4e08-8aa5-2133f18a2629");
        }

        public void FillFilterComboBox()
        {
            cmbBoxStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbBoxStatus.SelectedIndex = 0;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            Status status = (Status)cmbBoxStatus.SelectedValue;
            var filteredData = await theaterService.GetAllAsync(x => x.Status == status);
            theaterDataGridView.DataSource = filteredData;
        }

        private async void btnFilterReset_Click(object sender, EventArgs e)
        {
            theaterDataGridView.DataSource = await theaterService.GetAllAsync();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var tbx = sender as TextBox;
            if(tbx != null)
            {
                string text = tbx.Text;
                if(!string.IsNullOrEmpty(text))
                {
                    var filteredData = await theaterService.GetAllAsync(x => x.Title.Contains(text));
                    theaterDataGridView.DataSource = filteredData;
                } else
                {
                    theaterDataGridView.DataSource = await theaterService.GetAllAsync();
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //await theaterService.AddAsync(new Theatre
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Title = "Abc",
            //    Status = Status.Active,
            //    AdaptedBy = "Ahmet Altun",
            //    DirectedBy = "Ahmet Altun",
            //    Date = DateTime.Now.Date,
            //    Time = "21:00",
            //    Description = "C Sharp OOP Projesi"
            //});
        }
    }
}
