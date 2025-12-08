using Klases;
namespace MauiLietotne.Forms;

public partial class AddAssignment : ContentPage
{
	private AddManager dm;
    private Assignement _assignment = null;
    public AddAssignment()
	{
		InitializeComponent();
        dm = MyStaticItems.myDm.am;
        cboITSupport.ItemsSource = dm.getITSupportList();
        cboTicket.ItemsSource = dm.getTicketList();
    }
    // Konstruktors rediģēšanai
    public AddAssignment(Assignement assignment): this()
    {
        _assignment = assignment;
        // Aizpildām laukus ar esošajiem datiem
        var supportList = dm.getITSupportList().ToList();
        cboITSupport.SelectedIndex = supportList.FindIndex(s => s.UserID == assignment.ITSupportID);
        var ticketList = dm.getTicketList().ToList();
        cboTicket.SelectedIndex = ticketList.FindIndex(t => t.TicketID == assignment.TicketID);
        txtComment.Text = assignment.Comment;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        Assignement newAssignement = new Assignement();
        // Validācija – visi lauki aizpildīti
        if (cboITSupport.SelectedItem == null ||
            cboTicket.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtComment.Text))
        {
            await DisplayAlert("Kļūda", "Lūdzu, aizpildiet visus laukus!", "OK");
            return;
        }

        // Pārveidojam ID uz int
        // Saņemam izvēlēto ITSupport un Ticket objektus no ComboBox
        var support = (ITSupport)cboITSupport.SelectedItem;
        var ticket = (Ticket)cboTicket.SelectedItem;

        if (_assignment == null)
        {
            // Izveidojam Assignment objektu
            newAssignement.AssignedAt = DateTime.Now;
            newAssignement.ITSupportID = support.UserID;
            newAssignement.TicketID = ticket.TicketID;
            newAssignement.Comment = txtComment.Text.Trim();

            // Pievienojam un saglabājam
            dm.addAssignement(newAssignement);

            // Pārejam uz datu lapu vai notīrām laukus
            await Shell.Current.GoToAsync("//AssignmentList");

            // Notīrām laukus
            cboITSupport.SelectedItem = null;
            cboTicket.SelectedItem = null;
            txtComment.Text = string.Empty;
        }
        else 
        {
            // Atjaunojam esošo Assignment objektu
            _assignment.AssignedAt = DateTime.Now;
            _assignment.ITSupportID = support.UserID;
            _assignment.TicketID = ticket.TicketID;
            _assignment.Comment = txtComment.Text.Trim();
            // Saglabājam izmaiņas
            dm.Save();
            await Navigation.PopAsync();
        }
    }
}