using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CRM.Models
{
    public class CustomerDAL
    {
        static string conn = ConfigurationManager.ConnectionStrings["CRMDBConnectionString"].ConnectionString;
        CRMDBDataContext context = new CRMDBDataContext(conn);
        public List<Customer> GetCustomers() 
        {
            List<Customer> customers;
            try 
            {

                customers = (from c in context.Customers select c).ToList();
                return customers;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public Customer Getcustomer(int Id)
        {
            Customer customer;
            try
            {
                
                    customer = (from u in context.Customers where u.Id==Id select u).Single();
               
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AddCustomer(Customer customer, string userid)
        {
            try
            {
                customer.UserId = int.Parse(userid);
                context.Customers.InsertOnSubmit(customer);
                context.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCustomer(Customer newcustomer)
        {
            try
            {
                Customer oldStudent = context.Customers.Single(c => c.Id==newcustomer.Id);
                oldStudent.Name = newcustomer.Name;
                oldStudent.City = newcustomer.City;
                oldStudent.Mobile = newcustomer.Mobile;
                oldStudent.Email = newcustomer.Email;
                oldStudent.Phone_call = newcustomer.Phone_call;
                oldStudent.Email_ans = newcustomer.Email_ans;
                oldStudent.Call_timing = newcustomer.Call_timing;
                oldStudent.Open_Issue = newcustomer.Open_Issue;
                oldStudent.Communication_channel = newcustomer.Communication_channel;
                oldStudent.Totalsale = newcustomer.Totalsale;
                oldStudent.Return_cancellation = newcustomer.Return_cancellation;
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteCustomer(int Id)
        {
            try
            {
                Customer Customers = context.Customers.Single(U => U.Id == Id);
                Customers.Status = "inactive";
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}