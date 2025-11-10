using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public abstract class User
    {
        // Privātie lauki
        private string userName;
        private string email;
        private int userID;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("@")) // Pārbauda, vai e-pasts satur "@" simbolu
                {
                    email = value;
                } // Ja nesatur, tad netiek mainīts
            }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public bool IsActive { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $"UserID: {userID}, Username: {userName}, Email: {email}, IsActive: {IsActive}";
        }
    }
}
