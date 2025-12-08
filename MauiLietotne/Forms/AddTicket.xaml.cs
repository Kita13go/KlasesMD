using Klases;

namespace MauiLietotne.Forms;

public partial class AddTicket : ContentPage
{
	private AddManager dm;
    private Ticket _ticket = null;
    public AddTicket()
	{
		InitializeComponent();
        cboStatus.ItemsSource = Enum.GetNames(typeof(Ticket.TicketStatus));
        cboStatus.SelectedIndex = 0;
        cboIsResolved.Items.Add("True");
        cboIsResolved.Items.Add("False");
        cboIsResolved.SelectedIndex = 1;
        dm = MyStaticItems.myDm.am;
        cboCreatedBy.ItemsSource = dm.getEmployeeList();
    }
    public AddTicket(Ticket ticket): this()
    {
        _ticket = ticket;
        // Aizpildām laukus ar esošajiem datiem
        txtTitle.Text = ticket.Title;
        txtDescription.Text = ticket.Description;
        txtPriority.Text = ticket.Priority.ToString();
        var employeeList = dm.getTicketList().ToList();
        cboCreatedBy.SelectedIndex = employeeList.FindIndex(t => t.EmployeeID == ticket.EmployeeID);
        cboStatus.SelectedIndex = (int)ticket.Status;
        cboIsResolved.SelectedItem = ticket.IsResolved ? "True" : "False";
    }
    
    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        Ticket newTicket = new Ticket();
        // Validācija – visi lauki aizpildīti
        if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text) ||
            string.IsNullOrWhiteSpace(txtPriority.Text) ||
            cboCreatedBy.SelectedItem == null)
        {
            await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
            return;
        }

        // ID un prioritātes pārveide uz skaitli
        if (!int.TryParse(txtPriority.Text, out int priority))
        {
            await DisplayAlert("Kļūda", "Priority jābūt skaitlim!", "OK");
            return;
        }

        var creator = (Employee)cboCreatedBy.SelectedItem;
        if (_ticket == null)
        {
            // Izveidojam Ticket objektu
            newTicket.Title = txtTitle.Text.Trim();
            newTicket.Description = txtDescription.Text.Trim();
            newTicket.Priority = priority;
            newTicket.EmployeeID = creator.UserID;
            newTicket.Status = (Ticket.TicketStatus)cboStatus.SelectedIndex;
            newTicket.IsResolved = cboIsResolved.SelectedItem?.ToString() == "True";

            // Pievienojam un saglabājam
            dm.addTicket(newTicket);

            // Pārejam uz datu lapu vai notīrām laukus
            await Shell.Current.GoToAsync("//TicketList");
            // Notīrām laukus
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPriority.Text = "";
            cboIsResolved.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboCreatedBy.SelectedItem = null;
        }
        else 
        {

            // Atjaunojam esošo datus
            _ticket.Title = txtTitle.Text.Trim();
            _ticket.Description = txtDescription.Text.Trim();
            _ticket.Priority = int.Parse(txtPriority.Text);
            _ticket.EmployeeID = creator.UserID;
            _ticket.Status = (Ticket.TicketStatus)cboStatus.SelectedIndex;
            _ticket.IsResolved = cboIsResolved.SelectedItem?.ToString() == "True";
            // Pieņemot, ka dm ir atjauninājis biļeti kolekcijā
            dm.Save();
            await Navigation.PopAsync();
        }
    }
}