import React from 'react';
import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'


// metric status (home page)
import HeaderComponent from './components/HeaderComponent';



  import OrgListComponent from './components/OrgListComponent';
  import OrgCreateComponent from './components/OrgCreateComponent';
  
  import UserListComponent from './components/UserListComponent';
  import UserCreateComponent from './components/UserCreateComponent';
  
  import UserOrgListComponent from './components/UserOrgListComponent';
  import UserOrgCreateComponent from './components/UserOrgCreateComponent';
  
  import AccountListComponent from './components/AccountListComponent';
  import AccountCreateComponent from './components/AccountCreateComponent';
  
  import CustomerListComponent from './components/CustomerListComponent';
  import CustomerCreateComponent from './components/CustomerCreateComponent';
  
  import VendorListComponent from './components/VendorListComponent';
  import VendorCreateComponent from './components/VendorCreateComponent';
  
  import InvoiceListComponent from './components/InvoiceListComponent';
  import InvoiceCreateComponent from './components/InvoiceCreateComponent';
  
  import InvoiceItemListComponent from './components/InvoiceItemListComponent';
  import InvoiceItemCreateComponent from './components/InvoiceItemCreateComponent';
  
  import BillListComponent from './components/BillListComponent';
  import BillCreateComponent from './components/BillCreateComponent';
  
  import BillItemListComponent from './components/BillItemListComponent';
  import BillItemCreateComponent from './components/BillItemCreateComponent';
  
  import PaymentListComponent from './components/PaymentListComponent';
  import PaymentCreateComponent from './components/PaymentCreateComponent';
  
  import TransactionListComponent from './components/TransactionListComponent';
  import TransactionCreateComponent from './components/TransactionCreateComponent';
  
  import CategoryListComponent from './components/CategoryListComponent';
  import CategoryCreateComponent from './components/CategoryCreateComponent';
  
  import TransactionCategoryListComponent from './components/TransactionCategoryListComponent';
  import TransactionCategoryCreateComponent from './components/TransactionCategoryCreateComponent';
  
  import BudgetListComponent from './components/BudgetListComponent';
  import BudgetCreateComponent from './components/BudgetCreateComponent';
  
// footer
import FooterComponent from './components/FooterComponent';

function App() {
  return (
    <div>
        <Router>
              <HeaderComponent />
                <div className="container">
                    <Switch> 
                         <Route path = "/" exact component = {OrgListComponent}></Route>
                    
                          //^(app-route-partial) 
                            <Route path = "/org" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-org/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/user" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-user/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/userorg" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-userorg/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/account" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-account/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/customer" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-customer/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/vendor" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-vendor/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/invoice" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-invoice/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/invoiceitem" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-invoiceitem/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/bill" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-bill/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/billitem" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-billitem/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/payment" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-payment/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/transaction" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-transaction/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/category" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-category/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/transactioncategory" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-transactioncategory/:id" component = {@(obj.DomainObj)CreateComponent}></Route>
                            <Route path = "/budget" component = {@(obj.DomainObj)ListComponent}></Route>
                            <Route path = "/add-budget/:id" component = {@(obj.DomainObj)CreateComponent}></Route>

                    </Switch>
                </div>
              <FooterComponent />
        </Router>
    </div>
    
  );
}

export default App;
