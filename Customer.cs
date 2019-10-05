using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customerdetail.BLL;
using Customerdetail.Model;


namespace Customerdetail
{
    public partial class Customer : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public Customer()
        {
            InitializeComponent();
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {

            CustomerModel customerModel = new CustomerModel();

            if (this.saveButton.Text =="save")
            {
                // Addvalidetion();
               

                if (String.IsNullOrEmpty(codeTextBox.Text))
                {
                    MessageBox.Show("code Can not be Empty!!!");
                    return;
                }
                customerModel.Code = codeTextBox.Text;

                if (customerModel.Code.Length < 4)
                {
                    MessageBox.Show("code length must be 4!!!");
                    return;
                }
                bool isExit = _customerManager.Exitcode(customerModel);
                if (isExit)
                {
                    MessageBox.Show(codeTextBox.Text + "\t all ready exit...");
                    return;
                }
                //name
                if (String.IsNullOrEmpty(nameTextBox.Text))
                {
                    MessageBox.Show("name Can not be Empty!!!");
                    return ;
                }
                customerModel.Name = nameTextBox.Text;

                //address
                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("address Can not be Empty!!!");
                    return;
                }
                customerModel.Address = addressTextBox.Text;
                //contact
                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("contact Can not be Empty!!!");
                    return ;
                }
                customerModel.Contact = contactTextBox.Text;
                if (customerModel.Contact.Length < 11)
                {
                    MessageBox.Show("contact length must be 11 !!!");
                    return ;
                }
                bool ishas = _customerManager.Exitcontact(customerModel);
                if (ishas)
                {
                    MessageBox.Show(contactTextBox.Text + "\t all ready exit...");
                    return;
                }
                //district
                if (String.IsNullOrEmpty(districtcomboBox.Text))
                {
                    MessageBox.Show("district Can not be Empty!!!");
                    return;
                }

                customerModel.DistrictName = districtcomboBox.Text;

                bool add = _customerManager.Addcustomer(customerModel);
                    if (add)
                    {
                        //add
                        MessageBox.Show("add successfull..");
                        dataGridView.DataSource = _customerManager.ShowCustomer();


                    }
                    else
                    {
                        MessageBox.Show("add false..");
                    }

                
                   
                    
            }
            else if(this.saveButton.Text=="edit")
            {
 
               // customerModel.Code = codeTextBox.Text;
               // customerModel.Name = nameTextBox.Text;

               // customerModel.Address = addressTextBox.Text;

               // customerModel.Contact = contactTextBox.Text;
              //  customerModel.DistrictName = districtcomboBox.Text;
                if (String.IsNullOrEmpty(codeTextBox.Text))
                {
                    MessageBox.Show("code Can not be Empty!!!");
                    return;
                }
                customerModel.Code = codeTextBox.Text;

                if (customerModel.Code.Length < 4)
                {
                    MessageBox.Show("code length must be 4!!!");
                    return;
                }
                
                //name
                if (String.IsNullOrEmpty(nameTextBox.Text))
                {
                    MessageBox.Show("name Can not be Empty!!!");
                    return;
                }
                customerModel.Name = nameTextBox.Text;

                //address
                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("address Can not be Empty!!!");
                    return;
                }
                customerModel.Address = addressTextBox.Text;
                //contact
                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("contact Can not be Empty!!!");
                    return;
                }
                customerModel.Contact = contactTextBox.Text;
                if (customerModel.Contact.Length < 11)
                {
                    MessageBox.Show("contact length must be 11 !!!");
                    return;
                }
               
                //district
                if (String.IsNullOrEmpty(districtcomboBox.Text))
                {
                    MessageBox.Show("district Can not be Empty!!!");
                    return;
                }

                customerModel.DistrictName = districtcomboBox.Text;

               
                customerModel.Id =Convert.ToInt32(idTextBox.Text);
             



                bool update = _customerManager.Modificustomer(customerModel);
                if (update)
                {
                    MessageBox.Show(customerModel.Id + "update is ok..");
                    dataGridView.DataSource = _customerManager.ShowCustomer();
                    this.saveButton.Text ="save";
                    return;
                }
                else
                {
                    MessageBox.Show("no data found..");
                }
                
            }
            

        }
        

        private void Customer_Load(object sender, EventArgs e)
        {
            

            districtcomboBox.DataSource = _customerManager.DistrictComboBox();
            dataGridView.DataSource = _customerManager.ShowCustomer();

        }
        

        private void searchButton_Click(object sender, EventArgs e)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.Code = codeTextBox.Text;
            dataGridView.DataSource = _customerManager.Search(customerModel);

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
              
                codeTextBox.Text = row.Cells[1].Value.ToString();
                nameTextBox.Text = row.Cells[2].Value.ToString();
                addressTextBox.Text = row.Cells[3].Value.ToString();
                contactTextBox.Text = row.Cells[4].Value.ToString();
                districtcomboBox.Text = row.Cells[5].Value.ToString();
               idTextBox.Text = row.Cells[6].Value.ToString();

            }
            this.saveButton.Text = "edit";
            this.searchButton.Name = "edit";
        }


        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
        }

        private void contactTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
