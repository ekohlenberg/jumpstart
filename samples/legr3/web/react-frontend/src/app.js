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
  
  import UserOrgListComponent from './components/user_org-list';
  import UserOrgCreateComponent from './components/user_org-create';
  
  import AccountListComponent from './components/account-list';
  import AccountCreateComponent from './components/account-create';
  
  import CustomerListComponent from './components/customer-list';
  import CustomerCreateComponent from './components/customer-create';
  
  import VendorListComponent from './components/vendor-list';
  import VendorCreateComponent from './components/vendor-create';
  
  import InvoiceListComponent from './components/invoice-list';
  import InvoiceCreateComponent from './components/invoice-create';
  
  import InvoiceItemListComponent from './components/invoice_item-list';
  import InvoiceItemCreateComponent from './components/invoice_item-create';
  
  import BillListComponent from './components/bill-list';
  import BillCreateComponent from './components/bill-create';
  
  import BillItemListComponent from './components/bill_item-list';
  import BillItemCreateComponent from './components/bill_item-create';
  
  import PaymentListComponent from './components/payment-list';
  import PaymentCreateComponent from './components/payment-create';
  
  import TransactionListComponent from './components/transaction-list';
  import TransactionCreateComponent from './components/transaction-create';
  
  import CategoryListComponent from './components/category-list';
  import CategoryCreateComponent from './components/category-create';
  
  import TransactionCategoryListComponent from './components/transaction_category-list';
  import TransactionCategoryCreateComponent from './components/transaction_category-create';
  
  import BudgetListComponent from './components/budget-list';
  import BudgetCreateComponent from './components/budget-create';
  
  import ScriptListComponent from './components/script-list';
  import ScriptCreateComponent from './components/script-create';
  
  import ActionListComponent from './components/action-list';
  import ActionCreateComponent from './components/action-create';
  
  import ActionGroupListComponent from './components/action_group-list';
  import ActionGroupCreateComponent from './components/action_group-create';
  
  import OnEventListComponent from './components/on_event-list';
  import OnEventCreateComponent from './components/on_event-create';
  
  import ActionGroupMapListComponent from './components/action_group_map-list';
  import ActionGroupMapCreateComponent from './components/action_group_map-create';
  
  import UserActionGroupListComponent from './components/user_action_group-list';
  import UserActionGroupCreateComponent from './components/user_action_group-create';
  
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
                            
                            <Route path='/userorg' element = { < UserOrgListComponent /> } />
                            <Route path='/add-userorg/:id' element = { < UserOrgCreateComponent /> } />
                            
                            <Route path='/account' element = { < AccountListComponent /> } />
                            <Route path='/add-account/:id' element = { < AccountCreateComponent /> } />
                            
                            <Route path='/customer' element = { < CustomerListComponent /> } />
                            <Route path='/add-customer/:id' element = { < CustomerCreateComponent /> } />
                            
                            <Route path='/vendor' element = { < VendorListComponent /> } />
                            <Route path='/add-vendor/:id' element = { < VendorCreateComponent /> } />
                            
                            <Route path='/invoice' element = { < InvoiceListComponent /> } />
                            <Route path='/add-invoice/:id' element = { < InvoiceCreateComponent /> } />
                            
                            <Route path='/invoiceitem' element = { < InvoiceItemListComponent /> } />
                            <Route path='/add-invoiceitem/:id' element = { < InvoiceItemCreateComponent /> } />
                            
                            <Route path='/bill' element = { < BillListComponent /> } />
                            <Route path='/add-bill/:id' element = { < BillCreateComponent /> } />
                            
                            <Route path='/billitem' element = { < BillItemListComponent /> } />
                            <Route path='/add-billitem/:id' element = { < BillItemCreateComponent /> } />
                            
                            <Route path='/payment' element = { < PaymentListComponent /> } />
                            <Route path='/add-payment/:id' element = { < PaymentCreateComponent /> } />
                            
                            <Route path='/transaction' element = { < TransactionListComponent /> } />
                            <Route path='/add-transaction/:id' element = { < TransactionCreateComponent /> } />
                            
                            <Route path='/category' element = { < CategoryListComponent /> } />
                            <Route path='/add-category/:id' element = { < CategoryCreateComponent /> } />
                            
                            <Route path='/transactioncategory' element = { < TransactionCategoryListComponent /> } />
                            <Route path='/add-transactioncategory/:id' element = { < TransactionCategoryCreateComponent /> } />
                            
                            <Route path='/budget' element = { < BudgetListComponent /> } />
                            <Route path='/add-budget/:id' element = { < BudgetCreateComponent /> } />
                            
                            <Route path='/script' element = { < ScriptListComponent /> } />
                            <Route path='/add-script/:id' element = { < ScriptCreateComponent /> } />
                            
                            <Route path='/action' element = { < ActionListComponent /> } />
                            <Route path='/add-action/:id' element = { < ActionCreateComponent /> } />
                            
                            <Route path='/actiongroup' element = { < ActionGroupListComponent /> } />
                            <Route path='/add-actiongroup/:id' element = { < ActionGroupCreateComponent /> } />
                            
                            <Route path='/onevent' element = { < OnEventListComponent /> } />
                            <Route path='/add-onevent/:id' element = { < OnEventCreateComponent /> } />
                            
                            <Route path='/actiongroupmap' element = { < ActionGroupMapListComponent /> } />
                            <Route path='/add-actiongroupmap/:id' element = { < ActionGroupMapCreateComponent /> } />
                            
                            <Route path='/useractiongroup' element = { < UserActionGroupListComponent /> } />
                            <Route path='/add-useractiongroup/:id' element = { < UserActionGroupCreateComponent /> } />
                            
                    </Routes>
                </div>
              <FooterComponent />
        </Router>
    </div>
    
  );
}

export default App;
