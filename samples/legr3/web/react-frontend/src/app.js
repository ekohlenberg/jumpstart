import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'


// metric status (home page)
import HeaderComponent from './components/legr3-header';



  import OrgListComponent from './components/org-list';
  import OrgCreateComponent from './components/org-create';
  
  import UserListComponent from './components/user-list';
  import UserCreateComponent from './components/user-create';
  
  import ScriptListComponent from './components/script-list';
  import ScriptCreateComponent from './components/script-create';
  
  import OperationListComponent from './components/operation-list';
  import OperationCreateComponent from './components/operation-create';
  
  import OpRoleListComponent from './components/op_role-list';
  import OpRoleCreateComponent from './components/op_role-create';
  
  import AccountListComponent from './components/account-list';
  import AccountCreateComponent from './components/account-create';
  
  import CustomerListComponent from './components/customer-list';
  import CustomerCreateComponent from './components/customer-create';
  
  import VendorListComponent from './components/vendor-list';
  import VendorCreateComponent from './components/vendor-create';
  
  import CategoryListComponent from './components/category-list';
  import CategoryCreateComponent from './components/category-create';
  
  import UserOrgListComponent from './components/user_org-list';
  import UserOrgCreateComponent from './components/user_org-create';
  
  import UserPasswordListComponent from './components/user_password-list';
  import UserPasswordCreateComponent from './components/user_password-create';
  
  import EventServiceListComponent from './components/event_service-list';
  import EventServiceCreateComponent from './components/event_service-create';
  
  import OpRoleMapListComponent from './components/op_role_map-list';
  import OpRoleMapCreateComponent from './components/op_role_map-create';
  
  import OpRoleMemberListComponent from './components/op_role_member-list';
  import OpRoleMemberCreateComponent from './components/op_role_member-create';
  
  import TransactionListComponent from './components/transaction-list';
  import TransactionCreateComponent from './components/transaction-create';
  
  import InvoiceListComponent from './components/invoice-list';
  import InvoiceCreateComponent from './components/invoice-create';
  
  import BillListComponent from './components/bill-list';
  import BillCreateComponent from './components/bill-create';
  
  import BudgetListComponent from './components/budget-list';
  import BudgetCreateComponent from './components/budget-create';
  
  import TransactionCategoryListComponent from './components/transaction_category-list';
  import TransactionCategoryCreateComponent from './components/transaction_category-create';
  
  import InvoiceItemListComponent from './components/invoice_item-list';
  import InvoiceItemCreateComponent from './components/invoice_item-create';
  
  import PaymentListComponent from './components/payment-list';
  import PaymentCreateComponent from './components/payment-create';
  
  import BillItemListComponent from './components/bill_item-list';
  import BillItemCreateComponent from './components/bill_item-create';
  
// footer
import FooterComponent from './components/legr3-footer';

function App() {
  return (
    <div>
        <Router>
              <HeaderComponent />
                <div className="container">
                    <Routes> 
                         <Route path= '/' element = { < OrgListComponent /> } />
                           

                            <Route path='/org' element = { < OrgListComponent /> } />
                            <Route path='/add-org/:id' element = { < OrgCreateComponent /> } />
                            
                            <Route path='/user' element = { < UserListComponent /> } />
                            <Route path='/add-user/:id' element = { < UserCreateComponent /> } />
                            
                            <Route path='/script' element = { < ScriptListComponent /> } />
                            <Route path='/add-script/:id' element = { < ScriptCreateComponent /> } />
                            
                            <Route path='/operation' element = { < OperationListComponent /> } />
                            <Route path='/add-operation/:id' element = { < OperationCreateComponent /> } />
                            
                            <Route path='/oprole' element = { < OpRoleListComponent /> } />
                            <Route path='/add-oprole/:id' element = { < OpRoleCreateComponent /> } />
                            
                            <Route path='/account' element = { < AccountListComponent /> } />
                            <Route path='/add-account/:id' element = { < AccountCreateComponent /> } />
                            
                            <Route path='/customer' element = { < CustomerListComponent /> } />
                            <Route path='/add-customer/:id' element = { < CustomerCreateComponent /> } />
                            
                            <Route path='/vendor' element = { < VendorListComponent /> } />
                            <Route path='/add-vendor/:id' element = { < VendorCreateComponent /> } />
                            
                            <Route path='/category' element = { < CategoryListComponent /> } />
                            <Route path='/add-category/:id' element = { < CategoryCreateComponent /> } />
                            
                            <Route path='/userorg' element = { < UserOrgListComponent /> } />
                            <Route path='/add-userorg/:id' element = { < UserOrgCreateComponent /> } />
                            
                            <Route path='/userpassword' element = { < UserPasswordListComponent /> } />
                            <Route path='/add-userpassword/:id' element = { < UserPasswordCreateComponent /> } />
                            
                            <Route path='/eventservice' element = { < EventServiceListComponent /> } />
                            <Route path='/add-eventservice/:id' element = { < EventServiceCreateComponent /> } />
                            
                            <Route path='/oprolemap' element = { < OpRoleMapListComponent /> } />
                            <Route path='/add-oprolemap/:id' element = { < OpRoleMapCreateComponent /> } />
                            
                            <Route path='/oprolemember' element = { < OpRoleMemberListComponent /> } />
                            <Route path='/add-oprolemember/:id' element = { < OpRoleMemberCreateComponent /> } />
                            
                            <Route path='/transaction' element = { < TransactionListComponent /> } />
                            <Route path='/add-transaction/:id' element = { < TransactionCreateComponent /> } />
                            
                            <Route path='/invoice' element = { < InvoiceListComponent /> } />
                            <Route path='/add-invoice/:id' element = { < InvoiceCreateComponent /> } />
                            
                            <Route path='/bill' element = { < BillListComponent /> } />
                            <Route path='/add-bill/:id' element = { < BillCreateComponent /> } />
                            
                            <Route path='/budget' element = { < BudgetListComponent /> } />
                            <Route path='/add-budget/:id' element = { < BudgetCreateComponent /> } />
                            
                            <Route path='/transactioncategory' element = { < TransactionCategoryListComponent /> } />
                            <Route path='/add-transactioncategory/:id' element = { < TransactionCategoryCreateComponent /> } />
                            
                            <Route path='/invoiceitem' element = { < InvoiceItemListComponent /> } />
                            <Route path='/add-invoiceitem/:id' element = { < InvoiceItemCreateComponent /> } />
                            
                            <Route path='/payment' element = { < PaymentListComponent /> } />
                            <Route path='/add-payment/:id' element = { < PaymentCreateComponent /> } />
                            
                            <Route path='/billitem' element = { < BillItemListComponent /> } />
                            <Route path='/add-billitem/:id' element = { < BillItemCreateComponent /> } />
                            
                    </Routes>
                </div>
              <FooterComponent />
        </Router>
    </div>
    
  );
}

export default App;
