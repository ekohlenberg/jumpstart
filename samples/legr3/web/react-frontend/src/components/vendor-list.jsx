import React, { Component } from 'react'
import VendorService from '../services/vendor-service';

class VendorListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                vendors: []
        }
        this.addVendor = this.addVendor.bind(this);
        this.editVendor = this.editVendor.bind(this);
        this.deleteVendor = this.deleteVendor.bind(this);
    }

    deleteVendor(id){
        VendorService.deleteVendor(id).then( res => {
            this.setState({ vendors: this.state.vendors.filter(vendor => vendor.id !== id) });
        });
    }
    viewVendor(id){
        this.props.history.push(`/view-vendor/${id}`);
    }
    editVendor(id){
        console.log("editing " + id)
        this.props.history.push(`/add-vendor/${id}`);
    }

    componentDidMount(){
        VendorService.getVendors().then((res) => {
            this.setState({ vendors: res.data});
        });
    }

    addVendor(){
        this.props.history.push('/add-vendor/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Vendor List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addVendor}> Add Vendor</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Vendor </th>
                                    
                                    <th>Organization</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>First</th>
                                    
                                    <th>Last</th>
                                    
                                    <th>Email</th>
                                    
                                    <th>Phone</th>
                                    
                                    <th>Billing Address</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.vendors.map(
                                        vendor => 
                                        <tr key = { vendor.id }>

                                                <td> { vendor.id } </td>  
                                                
                                                <td> { vendor.org_id } </td>  
                                                
                                                <td> { vendor.vendor_name } </td>  
                                                
                                                <td> { vendor.first_name } </td>  
                                                
                                                <td> { vendor.last_name } </td>  
                                                
                                                <td> { vendor.email } </td>  
                                                
                                                <td> { vendor.phone } </td>  
                                                
                                                <td> { vendor.billing_address } </td>  
                                                
                                                <td> { vendor.created_date } </td>  
                                                
                                                <td> { vendor.is_active } </td>  
                                                
                                                <td> { vendor.created_by } </td>  
                                                
                                                <td> { vendor.last_updated } </td>  
                                                
                                                <td> { vendor.last_updated_by } </td>  
                                                
                                                <td> { vendor.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editVendor(vendor.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteVendor(vendor.id)} className="btn btn-danger">Delete </button>
                                                
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>

                 </div>

            </div>
        )
    }
}

export default VendorListComponent;