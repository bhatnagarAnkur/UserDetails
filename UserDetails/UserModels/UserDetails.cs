using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserModels
{
    public class UserDetails
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public Nullable<DateTime> Date_of_Birth { get; set; }
        public string Gender { get; set; }
        public string Home_Number { get; set; }
        public string Work_Number { get; set; }
        public string Mobile_Number { get; set; }
    }
}