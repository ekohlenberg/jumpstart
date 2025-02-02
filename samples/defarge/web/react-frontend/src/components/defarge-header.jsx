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
                    <div><a style={{marginLeft: "10px"}} className="navbar-brand">defarge</a></div>
                    

                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/category">Category</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/uom">Unit of Measure</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/org">Organization</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/user">User</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/script">Scripts</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/operation">Operations</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/oprole">Operation Role</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/metric">Metric</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/resource">Resource</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/userpassword">Password</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/eventservice">Events</a></div>
                        
                        <div><a style={{marginLeft: "10px"}}className="navbar" href="/alertrule">Alert Rule</a></div>
                        
                    </nav>
                </header>
            </div>
        )
    }
}

export default HeaderComponent