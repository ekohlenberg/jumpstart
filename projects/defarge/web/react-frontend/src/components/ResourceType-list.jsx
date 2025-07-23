import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ResourceTypeService from '../services/resource_type-service';

class ResourceTypeListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                resourcetypes: []
        }
        this.addResourceType = this.addResourceType.bind(this);
        this.editResourceType = this.editResourceType.bind(this);
        this.deleteResourceType = this.deleteResourceType.bind(this);
    }

    deleteResourceType(id){
        ResourceTypeService.deleteResourceType(id).then( res => {
            this.setState({ resourcetypes: this.state.resourcetypes.filter(resourcetype => resourcetype.id !== id) });
        });
    }
    viewResourceType(id){
        this.props.navigate(`/view-resourcetype/${id}`);
    }
    editResourceType(id){
        console.log("editing " + id)
        this.props.navigate(`/add-resourcetype/${id}`);
    }

    componentDidMount(){
        ResourceTypeService.getResourceTypes().then((res) => {
            this.setState({ resourcetypes: res.data});
        });
    }

    addResourceType(){
        this.props.navigate('/add-resourcetype/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">ResourceType List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addResourceType}> Add ResourceType</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.resourcetypes.map(
                                        resourcetype => 
                                        <tr key = { resourcetype.id }>

                                                <td> { resourcetype.id } </td>  
                                                
                                                <td> { resourcetype.name } </td>  
                                                
                                                <td> { resourcetype.is_active } </td>  
                                                
                                                <td> { resourcetype.created_by } </td>  
                                                
                                                <td> { resourcetype.last_updated } </td>  
                                                
                                                <td> { resourcetype.last_updated_by } </td>  
                                                
                                                <td> { resourcetype.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editResourceType(resourcetype.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteResourceType(resourcetype.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ResourceTypeListComponent);