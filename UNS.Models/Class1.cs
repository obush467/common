using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models
{

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public virtual StudentAddress Address { get; set; }
    }

    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
    public class Class1 : EntityTypeConfiguration<Student>
    {
        public Class1() : base()
        {
            HasOptional(s => s.Address).WithRequired(ad => ad.Student).WillCascadeOnDelete();
        }
    }
}
