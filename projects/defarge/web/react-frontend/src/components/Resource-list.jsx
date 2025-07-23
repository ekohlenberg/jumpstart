import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ResourceService from '../services/resource-service';

class ResourceListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                resources: []
        }
        this.addResource = this.addResource.bind(this);
        this.editResource = this.editResource.bind(this);
        this.deleteResource = this.deleteResource.bind(this);
    }

    deleteResource(id){
        ResourceService.deleteResource(id).then( res => {
            this.setState({ resources: this.state.resources.filter(resource => resource.id !== id) });
        });
    }
    viewResource(id){
        this.props.navigate(`/view-resource/${id}`);
    }
    editResource(id){
        console.log("editing " + id)
        this.props.navigate(`/add-resource/${id}`);
    }

    componentDidMount(){
        ResourceService.getResources().then((res) => {
            this.setState({ resources: res.data});
        });
    }

    addResource(){
        this.props.navigate('/add-resource/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Resource List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addResource}> Add Resource</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Resource</th>
                                    
                                    <th>Address</th>
                                    
                                    <th>Description</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.resources.map(
                                        resource => 
                                        <tr key = { resource.id }>

                                                <td> { resource.id } </td>  
                                                
                                                <td> { resource.name } </td>  
                                                
                                                <td> { resource.resource_type_id } </td>  
                                                
                                                <td> { resource.ip_address } </td>  
                                                
                                                <td> { resource.description } </td>  
                                                
                                                <td> { resource.is_active } </td>  
                                                
                                                <td> { resource.created_by } </td>  
                                                
                                                <td> { resource.last_updated } </td>  
                                                
                                                <td> { resource.last_updated_by } </td>  
                                                
                                                <td> { resource.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editResource(resource.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteResource(resource.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ResourceListComponent);