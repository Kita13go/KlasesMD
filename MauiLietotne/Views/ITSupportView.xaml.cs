using MauiLietotne.ViewModel;
namespace MauiLietotne.Views;

public partial class ITSupportView : ContentPage
{
	private IITSupportViewModel _vm;
	public ITSupportView(IITSupportViewModel vm)
	{
		_vm = vm;
		this.BindingContext = _vm;
        InitializeComponent();
	}
}