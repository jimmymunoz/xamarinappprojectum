using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;

namespace SeniorAssistance.Database
{
   public  class ContactTypeDatabase : CrudDatabase
    {
        protected override void initDababase()
        {
            Connection.CreateTable<ContactType>();
            iniTypeContact();
        }
        public void iniTypeContact()
        {    
            ContactType mother = new ContactType();
            mother.Image = "family.png";
            mother.Name = "Mother";
            this.Connection.Insert(mother);

            ContactType brother = new ContactType();
            mother.Image = "family.png";
            mother.Name = "brother";
            this.Connection.Insert(mother);


            ContactType Son = new ContactType();
            mother.Image = "family.png";
            mother.Name = "Son";
            this.Connection.Insert(mother);

            ContactType Daughter = new ContactType();
            mother.Image = "family.png";
            mother.Name = "Daughter";
            this.Connection.Insert(mother);

            ContactType grandchild = new ContactType();
            mother.Image = "family.png";
            mother.Name = "grandchild";
            this.Connection.Insert(mother);

            ContactType Nurse = new ContactType();
            mother.Image = "nurse2.png";
            mother.Name = "Nurse";
            this.Connection.Insert(mother);

            ContactType Doctor = new ContactType();
            mother.Image = "nurse.png";
            mother.Name = "Doctor";
            this.Connection.Insert(mother);
        }    

    }
}
