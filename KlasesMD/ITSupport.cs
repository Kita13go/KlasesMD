using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasesMD
{
    public class ITSupport: User
    {
        public enum SpecializationType
        {
            Hardware,
            Software,
            Network,
            Security
        } // Tas ir vērtības, kuras automatiski piedavāja

        public SpecializationType Specialization { get; set; }

        public ITSupport()
        {
            Specialization = SpecializationType.Software; // Lai nebūtu tukšs konstruktors, pievienoju noklusētu vērtību
        }

        // Konstruktors, kurš aizpilda visus laukus
        public ITSupport(string username, string email, int userID, bool isActive, SpecializationType specialization)
        {
            UserName = username;
            Email = email;
            UserID = userID;
            IsActive = isActive;
            Specialization = specialization;
        }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības (arī mantoto)
        public override string ToString()
        {
            return base.ToString() + $", Specialization: {Specialization}";
        }
    }
}
