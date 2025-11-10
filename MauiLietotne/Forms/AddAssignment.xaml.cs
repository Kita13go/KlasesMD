using Klases;
namespace MauiLietotne.Forms;

public partial class AddAssignment : ContentPage
{
	private IAdd dm;
    private Assignement _assignment = null;
    public AddAssignment()
	{
		InitializeComponent();
        dm = MyStaticItems.myDm.collections;

    }
    // Konstruktors rediģēšanai
    public AddAssignment(Assignement assignment): this()
    {
        _assignment = assignment;
        // Aizpildām laukus ar esošajiem datiem
        txtAssignmentID.Text = assignment.AssignementID.ToString();
        txtITSupportID.Text = assignment.Support.UserID.ToString();
        txtTicketID.Text = assignment.Ticket.TicketID.ToString();
        txtComment.Text = assignment.Comment;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (_assignment == null)
        {
            Assignement newAssignement = new Assignement();
            // Validācija – visi lauki aizpildīti
            if (string.IsNullOrWhiteSpace(txtAssignmentID.Text) ||
                string.IsNullOrWhiteSpace(txtITSupportID.Text) ||
                string.IsNullOrWhiteSpace(txtTicketID.Text) ||
                string.IsNullOrWhiteSpace(txtComment.Text))
            {
                await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
                return;
            }

            // Pārveidojam ID uz int
            if (!int.TryParse(txtAssignmentID.Text, out int assignmentId))
            {
                await DisplayAlert("Kļūda", "Assignment ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtITSupportID.Text, out int supportId))
            {
                await DisplayAlert("Kļūda", "Support ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtTicketID.Text, out int ticketId))
            {
                await DisplayAlert("Kļūda", "Ticket ID jābūt skaitlim!", "OK");
                return;
            }

            // Pārbaudām, vai ID jau eksistē
            var existing = dm.GetAllAssignments()?.FirstOrDefault(a => a.AssignementID == assignmentId);
            if (existing != null)
            {
                await DisplayAlert("Kļūda", $"Assignment ar ID {assignmentId} jau eksistē!", "OK");
                return;
            }

            // Atrodam ITSupport un Ticket objektus
            var support = dm.GetAllITSupports()?.FirstOrDefault(s => s.UserID == supportId);
            if (support == null)
            {
                await DisplayAlert("Kļūda", $"ITSupport ar ID {supportId} nav atrasts!", "OK");
                return;
            }

            var ticket = dm.GetAllTickets()?.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticket == null)
            {
                await DisplayAlert("Kļūda", $"Ticket ar ID {ticketId} nav atrasts!", "OK");
                return;
            }

            // Izveidojam Assignment objektu
            newAssignement.AssignementID = assignmentId;
            newAssignement.AssignedAt = DateTime.Now;
            newAssignement.Support = support;
            newAssignement.Ticket = ticket;
            newAssignement.Comment = txtComment.Text.Trim();

            // Pievienojam un saglabājam
            dm.addAssignment(newAssignement);

            // Pārejam uz datu lapu vai notīrām laukus
            await Shell.Current.GoToAsync("//AssignmentList");
        }
        else 
        {
            // Validācija – visi lauki aizpildīti
            if (string.IsNullOrWhiteSpace(txtAssignmentID.Text) ||
                string.IsNullOrWhiteSpace(txtITSupportID.Text) ||
                string.IsNullOrWhiteSpace(txtTicketID.Text) ||
                string.IsNullOrWhiteSpace(txtComment.Text))
            {
                await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
                return;
            }

            // Pārveidojam ID uz int
            if (!int.TryParse(txtAssignmentID.Text, out int assignmentId))
            {
                await DisplayAlert("Kļūda", "Assignment ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtITSupportID.Text, out int supportId))
            {
                await DisplayAlert("Kļūda", "Support ID jābūt skaitlim!", "OK");
                return;
            }
            if (!int.TryParse(txtTicketID.Text, out int ticketId))
            {
                await DisplayAlert("Kļūda", "Ticket ID jābūt skaitlim!", "OK");
                return;
            }

            // Pārbaudām, vai ID jau eksistē
            var existing = dm.GetAllAssignments()?.FirstOrDefault(a => a.AssignementID == assignmentId);
            if (existing != null && assignmentId != _assignment.AssignementID)
            {
                await DisplayAlert("Kļūda", $"Assignment ar ID {assignmentId} jau eksistē!", "OK");
                return;
            }

            // Atrodam ITSupport un Ticket objektus
            var support = dm.GetAllITSupports()?.FirstOrDefault(s => s.UserID == supportId);
            if (support == null)
            {
                await DisplayAlert("Kļūda", $"ITSupport ar ID {supportId} nav atrasts!", "OK");
                return;
            }

            var ticket = dm.GetAllTickets()?.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticket == null)
            {
                await DisplayAlert("Kļūda", $"Ticket ar ID {ticketId} nav atrasts!", "OK");
                return;
            }
            // Atjaunojam esošo Assignment objektu
            _assignment.AssignementID = assignmentId;
            _assignment.AssignedAt = DateTime.Now;
            _assignment.Support = support;
            _assignment.Ticket = ticket;
            _assignment.Comment = txtComment.Text.Trim();
            await Navigation.PopAsync();
        }
    }
}