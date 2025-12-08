using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class ITSupport
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
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
        public ITSupport(string username, string email, bool isActive, SpecializationType specialization)
        {
            UserName = username;
            Email = email;
            IsActive = isActive;
            Specialization = specialization;
        }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašība
        public override string ToString()
        {
            return $"Username: {UserName}, Email: {Email}, IsActive: {IsActive}, Specialization: {Specialization}";
        }
    }
}
