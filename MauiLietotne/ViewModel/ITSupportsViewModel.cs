using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Klases;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Klases.ITSupport;
// Visu izpildīju pēc Jūsu piemēra, vienakārši pielāgoju savām klasēm un vajadzībām un pievienoju validāciju
namespace MauiLietotne.ViewModel
{
    //Lai var izmantot Mvvm anotācijas tālāk
    [ObservableObject]
    public partial class ITSupportsViewModel: IITSupportViewModel
    {
        private AddManager dm;
        public ITSupportsViewModel()
        {
            dm = MyStaticItems.myDm.am;
            refresh();
        }
        //Binding izmantojam
        [ObservableProperty]
        private string userName = "";

        [ObservableProperty]
        private string email = "";

        //parādīs paziņojumu, kāda darbība paveikta
        [ObservableProperty]
        private string info = "";

        //poga Add vai Update
        [ObservableProperty]
        private string submitButtonText = "Add ITSupport";

        //saraksts ar IT Supports DB
        [ObservableProperty]
        private ObservableCollection<ITSupport> iTSupportList = new ObservableCollection<ITSupport>() { new ITSupport("Marta Liepa", "marta.liepa@gmail.com", true, SpecializationType.Network) };

        //izvēlētais IT Support, ko rediģēt
        [ObservableProperty]
        private ITSupport selectedITSupport;

        [ObservableProperty]
        private bool isDeleteVisible = false;

        [ObservableProperty]
        private bool[] activeValues = new[] { true, false };

        [ObservableProperty]
        private bool selectedActive = true;

        [ObservableProperty]
        private string[] specializationValues = Enum.GetNames(typeof(Klases.ITSupport.SpecializationType));

        [ObservableProperty]
        private string selectedSpecialization = SpecializationType.Software.ToString();

        private ITSupport UpdateITSupport = null;

        IRelayCommand IITSupportViewModel.addITSupportCommand => throw new NotImplementedException();


        //izveido IRelayCommand addITSupportCommand { get; }
        //komandai pieliek delegātu uz šo metodi
        [RelayCommand]
        private void addITSupport()
        {
            // Validācija
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(UserName))
            {
                Info = "Lūdzu, aizpildiet visus laukus!";
                return;
            }
            // Pārbaudām e-pastu
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                Info = "Nederīgs e-pasta formāts!";
                return;
            }
            if (UpdateITSupport is null)
            {
                //izvēlēto Specializāciju no string pārvērš par Enum
                var ac = selectedActive;
                var sc = Enum.Parse<SpecializationType>(selectedSpecialization);
                ITSupport it = new ITSupport(userName, email, ac, sc);
                dm.addITSupport(it);
                Info = "IT Support Added";
            }
            else
            {
                int index = ITSupportList.IndexOf(UpdateITSupport);
                UpdateITSupport.UserName = UserName;
                UpdateITSupport.Email = Email;
                UpdateITSupport.IsActive = selectedActive;
                UpdateITSupport.Specialization = Enum.Parse<Klases.ITSupport.SpecializationType>(selectedSpecialization);
                if (index >= 0)
                {
                    ITSupportList[index] = UpdateITSupport;
                }
                dm.Save();
                Info = "ITSupport updated!";
                endEdit();
            }
            refresh();
        }

        //dabū no DB aktuālo elementu sarakstu
        [RelayCommand]
        private void refresh()
        {
            iTSupportList.Clear();
            UserName = "";
            Email = "";
            SelectedActive = true;
            SelectedSpecialization = SpecializationType.Software.ToString();
            foreach (var r in dm.getITSupportList())
            {
                iTSupportList.Add(r);
            }
        }

        //izdzēšam izvēlēto un pārejam uz pievienošanas režīmu
        [RelayCommand]
        private void delete()
        {
            if (UpdateITSupport != null)
            {

                dm.removeITSupport(UpdateITSupport);
                Info = "ITSupport deleted!";
                endEdit();
                refresh();
            }
        }

        //pārslēdzamies no Edit modes uz Add modi
        private void endEdit()
        {
            UpdateITSupport = null;
            SelectedITSupport = null;

            UserName = "";
            Email = "";
            SelectedActive = true;
            SelectedSpecialization = SpecializationType.Software.ToString();

            SubmitButtonText = "Add ITSupport";
            IsDeleteVisible = false;
        }

        //pārslēdzamies no Add modes uz Edit modi
        private void startEdit()
        {
            SubmitButtonText = "Update ITSupport";
            IsDeleteVisible = true;
        }

        //izvēlēts IT Supports un sākam viņa labošanu
        [RelayCommand]
        private void itemSelected()
        {
            if (SelectedITSupport != null)
            {
                UserName = SelectedITSupport.UserName;
                Email = SelectedITSupport.Email;
                SelectedActive = SelectedITSupport.IsActive;
                SelectedSpecialization = SelectedITSupport.Specialization.ToString();
                UpdateITSupport = (ITSupport)SelectedITSupport;
                startEdit();
            }
        }

        //izvēlēts ITSupport un sākam viņa labošanu
        [RelayCommand]
        private void itemSelectedParam(ITSupport r)
        {
            SelectedITSupport = r;
            itemSelected();
        }
    }
}
