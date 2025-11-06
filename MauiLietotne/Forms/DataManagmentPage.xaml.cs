using KlasesMD;

namespace MauiLietotne.Forms;

public partial class DataManagmentPage : ContentPage
{
	IDataManager dm;
	public DataManagmentPage()
	{
		InitializeComponent();
		dm = new JSONDataManager();
    }

    private void btnTestData_Clicked(object sender, EventArgs e)
    {
        dm.createTestData();
        lblData.Text = dm.print();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dm.reset();
        lblData.Text = dm.print();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        dm.save();
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.load();
        lblData.Text = dm.print();
    }

    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblData.Text = dm.print();
    }
}