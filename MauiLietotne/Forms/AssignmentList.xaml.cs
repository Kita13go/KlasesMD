using Klases;
using Microsoft.Maui.ApplicationModel.DataTransfer;
namespace MauiLietotne.Forms;

public partial class AssignmentList : ContentPage
{
    private Collections dm;
    public AssignmentList()
	{
		InitializeComponent();
        dm = MyStaticItems.myDm.collections;
        cVList.ItemsSource = dm.GetAllAssignments();
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Assignement)
            {
                var sq = (Assignement)b.BindingContext;
                var sqPage = new AddAssignment(sq);
                await Navigation.PushAsync(sqPage);
            }
        }

    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button btn = (Button)sender;
            if (btn.BindingContext is Assignement)
            {
                Assignement assig = (Assignement)btn.BindingContext;
                bool answer = await DisplayAlert("Question?", "Vai gribat dz?st? " + assig.ToString(), "yes", "no");
                if (answer)
                {
                    dm.Assignements.Remove(assig);
                    cVList.ItemsSource = null;
                    cVList.ItemsSource = dm.GetAllAssignments();
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        cVList.ItemsSource = null;
        cVList.ItemsSource = dm.GetAllAssignments();
    }
}