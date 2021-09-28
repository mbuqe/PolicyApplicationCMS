using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using PolicyApplicationCMS.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyApplicationCMS.Models
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotationID { get; set; }

        public int Age { get; set; }
        public string Pre_existing_Conditions { get; set; }
        public Nullable<int> NumberofDepandents { get; set; }
        public Nullable<int> SpouseAge { get; set; }
        public Nullable<decimal> CoverAmount { get; set; }
        public Nullable<decimal> Premium { get; set; }
        public decimal Vat { get; set; }

        public decimal CalcOPtions()
        {
            decimal Options = 0;
            if (CoverAmount == 30000)
            {
                Options = 80;
            }
            else if (CoverAmount == 50000)
            {
                Options = 110;
            }
            else if (CoverAmount == 70000)
            {
                Options = 150;
            }
            else if (CoverAmount == 100000)
            {
                Options = 200;
            }
            return Options;
        }
        public int CalcAge()
        {
            int RiskCost = 0;
            if ((Age > 18) && (Age < 30))
            {
                RiskCost = 10;
            }
            else if ((Age > 29) && (Age < 50))
            {
                RiskCost = 20;
            }
            else RiskCost = 30;
            return RiskCost;
        }
        public int CalcSpouseAge()
        {
            int RiskCost = 0;
            if ((Age > 18) && (Age < 30))
            {
                RiskCost = 10;
            }
            else if ((Age > 29) && (Age < 50))
            {
                RiskCost = 20;
            }
            else RiskCost = 30;
            return RiskCost;
        }
        public decimal GetDisease()
        {
            decimal disease = 0;
            if (Pre_existing_Conditions == "Asthma")
            {
                disease = 10;
            }
            else if (Pre_existing_Conditions == "Diabetes")
            {
                disease = 15;
            }
            else if (Pre_existing_Conditions == "Cancer")
            {
                disease = 30;
            }
            else if (Pre_existing_Conditions == "Cystic Fibrosis")
            {
                disease = 30;
            }
            else if (Pre_existing_Conditions == "Heart Disease")
            {
                disease = 35;
            }
            else if (Pre_existing_Conditions == "Alzheimer's")
            {
                disease = 20;
            }
            else if (Pre_existing_Conditions == "Kidney Failure")
            {
                disease = 25;
            }
            else if (Pre_existing_Conditions == "Epilepsy")
            {
                disease = 20;
            }
            else if (Pre_existing_Conditions == "HIV")
            {
                disease = 20;
            }
            else if (Pre_existing_Conditions == "Haemophilia")
            {
                disease = 25;
            }
            else disease = 0;
            return disease;
        }
        public decimal GetVat()
        {
            return (CalcOPtions() * 10) / 100;
        }
        public decimal CalcTotalPremium()
        {
            return CalcOPtions() + GetVat() + CalcAge() + CalcSpouseAge() + GetDisease();
        }
        public double GetQuoteID()
        {
            InsuranceContext db = new InsuranceContext();
            var SingleListItem = (from c in db.Quotations
                                  select c.QuotationID).Last();
            return SingleListItem;
        }

    }
    public class Customer
    {
        [Key]
        public string C_IDNumber { get; set; }
        public int QuotationID { get; set; }
        public string C_Name { get; set; }
        public string C_Surname { get; set; }
        public string C_Address { get; set; }
        public string C_Cellphone { get; set; }
        public string C_Email { get; set; }
        public string C_Contact { get; set; }
        public string C_Gender { get; set; }
        public string C_Marital_Status { get; set; }

        public virtual Quotation Quotation { get; set; }

      
    }
    public class Apply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Policy_Number { get; set; }
        public int C_IDNumber { get; set; }
        public DateTime Commencement_date { get; set; }
        public int QuotationID { get; set; }
        public int Ben_IDNumber { get; set; }
        public string Application_Status { get; set; }
        public string Policy_Status { get; set; }
        public virtual Customer Customer {get; set;}
        public virtual Quotation Quotation { get; set; }
    }

}