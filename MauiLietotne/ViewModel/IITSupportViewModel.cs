using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Klases;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiLietotne.ViewModel
{
    public interface IITSupportViewModel
    {
        string UserName { get; set; }
        string Email { get; set; }
        string Info { get; set; }
        bool[] ActiveValues { get; set; }
        bool SelectedActive { get; set; }
        string SubmitButtonText { get; set; }
        string[] SpecializationValues { get; set; }
        string SelectedSpecialization { get; set; }
        ObservableCollection<ITSupport> ITSupportList { get; set; }
        ITSupport SelectedITSupport { get; set; }
        bool IsDeleteVisible { get; set; }

        IRelayCommand addITSupportCommand { get; }

        IRelayCommand deleteCommand { get; }

        IRelayCommand itemSelectedCommand { get; }
    }
}
