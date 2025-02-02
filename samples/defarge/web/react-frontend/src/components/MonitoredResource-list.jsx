import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import MonitoredResourceService from '../services/monitored_resource-service';

class MonitoredResourceListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                monitoredresources: []
        }
        this.addMonitoredResource = this.addMonitoredResource.bind(this);
        this.editMonitoredResource = this.editMonitoredResource.bind(this);
        this.deleteMonitoredResource = this.deleteMonitoredResource.bind(this);
    }

    deleteMonitoredResource(id){
        MonitoredResourceService.deleteMonitoredResource(id).then( res => {
            this.setState({ monitoredresources: this.state.monitoredresources.filter(monitoredresource => monitoredresource.id !== id) });
        });
    }
    viewMonitoredResource(id){
        this.props.navigate(`/view-monitoredresource/${id}`);
    }
    editMonitoredResource(id){
        console.log("editing " + id)
        this.props.navigate(`/add-monitoredresource/${id}`);
    }

    componentDidMount(){
        MonitoredResourceService.getMonitoredResources().then((res) => {
            this.setState({ monitoredresources: res.data});
        });
    }

    addMonitoredResource(){
        this.props.navigate('/add-monitoredresource/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">MonitoredResource List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addMonitoredResource}> Add MonitoredResource</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Id</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Resource</th>
                                    
                                    <th>Ip</th>
                                    
                                    <th>Description</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Updated</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.monitoredresources.map(
                                        monitoredresource => 
                                        <tr key = { monitoredresource.id }>

                                                <td> { monitoredresource.id } </td>  
                                                
                                                <td> { monitoredresource.name } </td>  
                                                
                                                <td> { monitoredresource.resource_type } </td>  
                                                
                                                <td> { monitoredresource.ip_address } </td>  
                                                
                                                <td> { monitoredresource.description } </td>  
                                                
                                                <td> { monitoredresource.created_at } </td>  
                                                
                                                <td> { monitoredresource.updated_at } </td>  
                                                
                                                <td> { monitoredresource.is_active } </td>  
                                                
                                                <td> { monitoredresource.created_by } </td>  
                                                
                                                <td> { monitoredresource.last_updated } </td>  
                                                
                                                <td> { monitoredresource.last_updated_by } </td>  
                                                
                                                <td> { monitoredresource.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editMonitoredResource(monitoredresource.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteMonitoredResource(monitoredresource.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(MonitoredResourceListComponent);