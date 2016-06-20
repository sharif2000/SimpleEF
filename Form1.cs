using System.Windows.Forms;
using System.Linq;
using System;

namespace SimpleEF
{
    public partial class Form1 : Form
    {

        // Define a container to hold the database information.
        Model1Container ThisContainer;

        public Form1()
        {
            InitializeComponent();

            // Instantiate the container.
            ThisContainer = new Model1Container();

        }

        private void btnCount_Click(object sender, System.EventArgs e)
        {
            // Display the number of database records.
            MessageBox.Show("There are " + ThisContainer.Customers.Count().ToString() + " Records.");
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            // Create a new record.
            Customer ThisCustomer = ThisContainer.Customers.Create();
            // Add some random data.
            Random ThisValue = new Random(DateTime.Now.Millisecond);
            ThisCustomer.FirstName = ThisValue.Next().ToString();
            ThisCustomer.LastName = ThisValue.Next().ToString();
            ThisCustomer.AddressLine1 = ThisValue.Next().ToString();
            ThisCustomer.AddressLine2 = ThisValue.Next().ToString();
            ThisCustomer.City = ThisValue.Next().ToString();
            ThisCustomer.State_Province = ThisValue.Next().ToString();
            ThisCustomer.ZIP_Postal_Code = ThisValue.Next().ToString();
            ThisCustomer.Region_Country = ThisValue.Next().ToString();
            // Add a new record.
            ThisContainer.Customers.Add(ThisCustomer);
            ThisContainer.SaveChanges();
            // Inform the user.
            MessageBox.Show("Added " + ThisCustomer.CustomerID.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Obtain the first record.
            Customer ThisCustomer = null;
            if (ThisContainer.Customers.Count() > 0)
                ThisCustomer = ThisContainer.Customers.First();
            else
            {
                // Display an error message if there are no records to delete.
                MessageBox.Show("No Records to Delete");
                return;
            }
            // Delete it.
            ThisContainer.Customers.Remove(ThisCustomer);
            ThisContainer.SaveChanges();
            // Inform the user.
            MessageBox.Show("Deleted " + ThisCustomer.CustomerID.ToString());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Save the database.
            ThisContainer.SaveChanges();
            // End the program.
            Close();
        }
    }
}
