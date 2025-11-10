using Klases;

namespace MauiLietotne.Forms;

public partial class AddTicket : ContentPage
{
	private IAdd dm;
    private Ticket _ticket = null;
    public AddTicket()
	{
		InitializeComponent();
        cboStatus.ItemsSource = Enum.GetNames(typeof(Ticket.TicketStatus));
        cboStatus.SelectedIndex = 0;
        cboIsResolved.Items.Add("True");
        cboIsResolved.Items.Add("False");
        cboIsResolved.SelectedIndex = 1;
        dm = MyStaticItems.myDm.collections;
    }
    public AddTicket(Ticket ticket): this()
    {
        _ticket = ticket;
        // Aizpildām laukus ar esošajiem datiem
        txtTicketID.Text = ticket.TicketID.ToString();
        txtTitle.Text = ticket.Title;
        txtDescription.Text = ticket.Description;
        txtPriority.Text = ticket.Priority.ToString();
        txtCreatedByID.Text = ticket.CreatedBy.UserID.ToString();
        cboStatus.SelectedIndex = (int)ticket.Status;
        cboIsResolved.SelectedItem = ticket.IsResolved ? "True" : "False";
    }
    
    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (_ticket == null)
        {
            Ticket newTicket = new Ticket();
            // Validācija – visi lauki aizpildīti
            if (string.IsNullOrWhiteSpace(txtTicketID.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPriority.Text) ||
                string.IsNullOrWhiteSpace(txtCreatedByID.Text))
            {
                await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
                return;
            }

            // ID un prioritātes pārveide uz skaitli
            if (!int.TryParse(txtTicketID.Text, out int ticketId))
            {
                await DisplayAlert("Kļūda", "Ticket ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtPriority.Text, out int priority))
            {
                await DisplayAlert("Kļūda", "Priority jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtCreatedByID.Text, out int createdById))
            {
                await DisplayAlert("Kļūda", "Created By (UserID) jābūt skaitlim!", "OK");
                return;
            }

            // Pārbaudām, vai Ticket ID jau eksistē
            var existingTicket = dm.GetAllTickets()?.FirstOrDefault(t => t.TicketID == ticketId);
            if (existingTicket != null)
            {
                await DisplayAlert("Kļūda", $"Biļete ar ID {ticketId} jau eksistē!", "OK");
                return;
            }

            // Atrodam darbinieku pēc ID
            var creator = dm.GetAllEmployees()?.FirstOrDefault(e1 => e1.UserID == createdById);
            if (creator == null)
            {
                await DisplayAlert("Kļūda", $"Darbinieks ar ID {createdById} netika atrasts!", "OK");
                return;
            }

            // Izveidojam Ticket objektu
            newTicket.TicketID = ticketId;
            newTicket.Title = txtTitle.Text.Trim();
            newTicket.Description = txtDescription.Text.Trim();
            newTicket.Priority = priority;
            newTicket.CreatedBy = creator;
            newTicket.Status = (Ticket.TicketStatus)cboStatus.SelectedIndex;
            newTicket.IsResolved = cboIsResolved.SelectedItem?.ToString() == "True";

            // Pievienojam un saglabājam
            dm.addTicket(newTicket);

            // Pārejam uz datu lapu vai notīrām laukus
            await Shell.Current.GoToAsync("//TicketList");
        }
        else 
        {
            // Validācija – visi lauki aizpildīti
            if (string.IsNullOrWhiteSpace(txtTicketID.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtPriority.Text) ||
                string.IsNullOrWhiteSpace(txtCreatedByID.Text))
            {
                await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
                return;
            }

            // ID un prioritātes pārveide uz skaitli
            if (!int.TryParse(txtTicketID.Text, out int ticketId))
            {
                await DisplayAlert("Kļūda", "Ticket ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtPriority.Text, out int priority))
            {
                await DisplayAlert("Kļūda", "Priority jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtCreatedByID.Text, out int createdById))
            {
                await DisplayAlert("Kļūda", "Created By (UserID) jābūt skaitlim!", "OK");
                return;
            }

            // Pārbaudām, vai Ticket ID jau eksistē
            var existingTicket = dm.GetAllTickets()?.FirstOrDefault(t => t.TicketID == ticketId);
            if (existingTicket != null && ticketId != _ticket.TicketID)
            {
                await DisplayAlert("Kļūda", $"Biļete ar ID {ticketId} jau eksistē!", "OK");
                return;
            }

            // Atrodam darbinieku pēc ID
            var creator = dm.GetAllEmployees()?.FirstOrDefault(e1 => e1.UserID == createdById);
            if (creator == null)
            {
                await DisplayAlert("Kļūda", $"Darbinieks ar ID {createdById} netika atrasts!", "OK");
                return;
            }
            // Atjaunojam esošo datus
            _ticket.TicketID = ticketId;
            _ticket.Title = txtTitle.Text.Trim();
            _ticket.Description = txtDescription.Text.Trim();
            _ticket.Priority = int.Parse(txtPriority.Text);
            _ticket.Status = (Ticket.TicketStatus)cboStatus.SelectedIndex;
            _ticket.IsResolved = cboIsResolved.SelectedItem?.ToString() == "True";
            // Pieņemot, ka dm ir atjauninājis biļeti kolekcijā
            await Navigation.PopAsync();
        }
    }
}