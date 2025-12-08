using Klases;
namespace MauiLietotne.Forms;

public partial class AddITSupport : ContentPage
{
	public IAdd dm;
    public AddITSupport()
	{
		InitializeComponent();
		cboIsActive.Items.Add("True");
		cboIsActive.Items.Add("False");
		cboIsActive.SelectedIndex = 0;
        cboSpecializationType.ItemsSource = Enum.GetNames(typeof(ITSupport.SpecializationType));
        cboSpecializationType.SelectedIndex = 0;
        dm = MyStaticItems.myDm.am;

    }

    private ITSupport _ITSp = null;

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        ITSupport ITSup = new ITSupport();
        // Validācija
        if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK"); // Internatā atrodu kā izveidot kļūdas paziņojumu
            return;
        }

        // Pārbaudām e-pastu
        if (!txtEmail.Text.Contains("@"))
        {
            await DisplayAlert("Kļūda", "Nederīgs e-pasta formāts!", "OK");
            return;
        }
        if (_ITSp == null)
        {
            // Izveidojam jaunu ITSupport objektu
            ITSup.UserName = txtUserName.Text;
            ITSup.Email = txtEmail.Text;
            ITSup.IsActive = cboIsActive.SelectedItem?.ToString() == "True";
            ITSup.Specialization = (ITSupport.SpecializationType)cboSpecializationType.SelectedIndex;


            // Pievienojam jauno ITSupport kolekcijai
            dm.addITSupport(ITSup);
            await Shell.Current.GoToAsync("//DataManagmentPage");

            txtUserName.Text = "";
            txtEmail.Text = "";
            cboIsActive.SelectedIndex = 0;
            cboSpecializationType.SelectedIndex = 0;
        }
    }
}