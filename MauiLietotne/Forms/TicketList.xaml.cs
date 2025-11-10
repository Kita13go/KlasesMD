using Klases;
namespace MauiLietotne.Forms;

public partial class TicketList : ContentPage
{
	private Collections dm;
    public TicketList()
	{
		InitializeComponent();
        dm = MyStaticItems.myDm.collections;
        cVList.ItemsSource = dm.GetAllTickets();
    }


    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Ticket)
            {
                var sq = (Ticket)b.BindingContext;
                var sqPage = new AddTicket(sq);
                await Navigation.PushAsync(sqPage);
            }
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button btn = (Button)sender;
            if (btn.BindingContext is Ticket)
            {
                Ticket tic = (Ticket)btn.BindingContext;
                bool answer = await DisplayAlert("Question?", "Vai gribat dz?st? " + tic.ToString(), "yes", "no");
                if (answer)
                {
                    dm.Tickets.Remove(tic);
                    cVList.ItemsSource = null;
                    cVList.ItemsSource = dm.GetAllTickets();
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        cVList.ItemsSource = null;
        cVList.ItemsSource = dm.GetAllTickets();
    }
}