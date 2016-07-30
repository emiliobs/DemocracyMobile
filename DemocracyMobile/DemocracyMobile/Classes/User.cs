using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemocracyApp.Classes
{
    public class User
    {
        //para enviar este modelo a bd debe tener un atributo primarykey:
        [PrimaryKey]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

       

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Grade { get; set; }

        public string Group { get; set; }

        public string Photo { get; set; }

        public string GradeEdited
        {
            get
            {
                return $"Grade: {this.Grade}";

            }
        }

        public string GroupEdited
        {
            get
            {
                return $"Group: {this.Group}";

            }
        }

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";

            }
        }

        public string PhotoFullPath
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Photo))
                {
                   return $"http://zulu-software.com/Democracy/{this.Photo.Substring(1)}";
                }

                return string.Empty;
            }
        }

        public override int GetHashCode()
        {
            return this.UserId;
        }
    }
}
