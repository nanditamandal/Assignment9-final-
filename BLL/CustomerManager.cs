using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Customerdetail.Model;
using Customerdetail.Repository;

namespace Customerdetail.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository=new CustomerRepository();

        public bool Exitcode(CustomerModel customerModel)
        {
            return _customerRepository.Exitcode(customerModel);
        }

        public bool Exitcontact(CustomerModel customerModel)
        {
            return _customerRepository.Exitcontact(customerModel);
        }

        public bool Addcustomer(CustomerModel customerModel)
        {
            return _customerRepository.Addcustomer(customerModel);
        }
        public DataTable DistrictComboBox()
        {
            return _customerRepository.DistrictComboBox();
        }
        public List<CustomerModel> ShowCustomer()
        {
            return _customerRepository.ShowCustomer();
        }
      /*  public DataTable Search(CustomerModel customerModel)
        {
            return _customerRepository.Search(customerModel);
        }*/
        public List<CustomerModel> Search(CustomerModel customerModel)
        {
            return _customerRepository.Search(customerModel);
        }
        public bool Modificustomer(CustomerModel customerModel)
        {
            return _customerRepository.Modificustomer(customerModel);
        }

    }
}
