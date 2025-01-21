import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import OpRoleMapService from '../services/op_role_map-service';

class OpRoleMapListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                oprolemaps: []
        }
        this.addOpRoleMap = this.addOpRoleMap.bind(this);
        this.editOpRoleMap = this.editOpRoleMap.bind(this);
        this.deleteOpRoleMap = this.deleteOpRoleMap.bind(this);
    }

    deleteOpRoleMap(id){
        OpRoleMapService.deleteOpRoleMap(id).then( res => {
            this.setState({ oprolemaps: this.state.oprolemaps.filter(oprolemap => oprolemap.id !== id) });
        });
    }
    viewOpRoleMap(id){
        this.props.navigate(`/view-oprolemap/${id}`);
    }
    editOpRoleMap(id){
        console.log("editing " + id)
        this.props.navigate(`/add-oprolemap/${id}`);
    }

    componentDidMount(){
        OpRoleMapService.getOpRoleMaps().then((res) => {
            this.setState({ oprolemaps: res.data});
        });
    }

    addOpRoleMap(){
        this.props.navigate('/add-oprolemap/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">OpRoleMap List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOpRoleMap}> Add OpRoleMap</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Operation Role Map ID</th>
                                    
                                    <th>Operation ID</th>
                                    
                                    <th>Role ID</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.oprolemaps.map(
                                        oprolemap => 
                                        <tr key = { oprolemap.id }>

                                                <td> { oprolemap.id } </td>  
                                                
                                                <td> { oprolemap.op_id } </td>  
                                                
                                                <td> { oprolemap.op_role_id } </td>  
                                                
                                                <td> { oprolemap.is_active } </td>  
                                                
                                                <td> { oprolemap.created_by } </td>  
                                                
                                                <td> { oprolemap.last_updated } </td>  
                                                
                                                <td> { oprolemap.last_updated_by } </td>  
                                                
                                                <td> { oprolemap.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOpRoleMap(oprolemap.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOpRoleMap(oprolemap.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(OpRoleMapListComponent);