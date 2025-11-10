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
        dm = MyStaticItems.myDm.collections;

    }

    private ITSupport _ITSp = null;

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (_ITSp == null)
        {
            ITSupport ITSup = new ITSupport();
            // Validācija
            if (string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK"); // Internatā atrodu kā izveidot kļūdas paziņojumu
                return;
            }
            // Pārveidojam UserID uz int
            int userId;
            if (!int.TryParse(txtUserID.Text, out userId))
            {
                await DisplayAlert("Kļūda", "User ID jābūt skaitlim!", "OK");
                return;
            }

            // Pārbaudām, vai tāds UserID jau eksistē
            var existing = dm.GetAllITSupports()?.FirstOrDefault(s => s.UserID == userId);
            if (existing != null)
            {
                await DisplayAlert("Kļūda", $"Lietotājs ar ID {userId} jau eksistē!", "OK");
                return;
            }

            // Pārbaudām e-pastu
            if (!txtEmail.Text.Contains("@"))
            {
                await DisplayAlert("Kļūda", "Nederīgs e-pasta formāts!", "OK");
                return;
            }

            // Izveidojam jaunu ITSupport objektu
            ITSup.UserName = txtUserName.Text;
            ITSup.Email = txtEmail.Text;
            ITSup.UserID = userId;
            ITSup.IsActive = cboIsActive.SelectedItem?.ToString() == "True";
            ITSup.Specialization = (ITSupport.SpecializationType)cboSpecializationType.SelectedIndex;


            // Pievienojam jauno ITSupport kolekcijai
            dm.addITSupport(ITSup);
            await Shell.Current.GoToAsync("//DataManagmentPage");

            txtUserID.Text = "";
            txtUserName.Text = "";
            txtEmail.Text = "";
            cboIsActive.SelectedIndex = 0;
            cboSpecializationType.SelectedIndex = 0;
        }
    }
}