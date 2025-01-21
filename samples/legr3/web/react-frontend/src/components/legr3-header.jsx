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
                    <div><a style={{marginLeft: "10px"}} className="navbar-brand">legr3</a></div>
                    

                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/org">Organization</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/user">User</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/script">Scripts</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/operation">Operations</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/oprole">Operation Role</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/account">Account</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/customer">Customer</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/vendor">Vendor</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/category">Category</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/userpassword">Password</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/eventservice">Events</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/invoice">Invoice</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/bill">Bill</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/budget">Budget</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/payment">Payment</a></div>
                        
                    </nav>
                </header>
            </div>
        )
    }
}

export default HeaderComponent