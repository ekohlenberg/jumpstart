import React, { Component } from 'react'

class HeaderComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                 
        }
    }

    render() {
        return (
            <div>
                <header>
                    <nav className="navbar navbar-expand-md navbar-dark bg-dark">
                    <div><a style={{marginLeft: "10px"}} className="navbar-brand">^(namespace)</a></div>
                    

                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/org">Organization</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/user">User</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/userorg">Users</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/account">Account</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/customer">Customer</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/vendor">Vendor</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/invoice">Invoice</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/invoiceitem">Invoice Items</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/bill">Bill</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/billitem">Bill Items</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/payment">Payment</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/transaction">Transaction</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/category">Category</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/transactioncategory">Category Map</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/budget">Budget</a></div>
                        
                    </nav>
                </header>
            </div>
        )
    }
}

export default HeaderComponent