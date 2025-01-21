import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import OpRoleService from '../services/op_role-service';

class OpRoleListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                oproles: []
        }
        this.addOpRole = this.addOpRole.bind(this);
        this.editOpRole = this.editOpRole.bind(this);
        this.deleteOpRole = this.deleteOpRole.bind(this);
    }

    deleteOpRole(id){
        OpRoleService.deleteOpRole(id).then( res => {
            this.setState({ oproles: this.state.oproles.filter(oprole => oprole.id !== id) });
        });
    }
    viewOpRole(id){
        this.props.navigate(`/view-oprole/${id}`);
    }
    editOpRole(id){
        console.log("editing " + id)
        this.props.navigate(`/add-oprole/${id}`);
    }

    componentDidMount(){
        OpRoleService.getOpRoles().then((res) => {
            this.setState({ oproles: res.data});
        });
    }

    addOpRole(){
        this.props.navigate('/add-oprole/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">OpRole List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOpRole}> Add OpRole</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Role ID</th>
                                    
                                    <th>Role Name</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.oproles.map(
                                        oprole => 
                                        <tr key = { oprole.id }>

                                                <td> { oprole.id } </td>  
                                                
                                                <td> { oprole.name } </td>  
                                                
                                                <td> { oprole.is_active } </td>  
                                                
                                                <td> { oprole.created_by } </td>  
                                                
                                                <td> { oprole.last_updated } </td>  
                                                
                                                <td> { oprole.last_updated_by } </td>  
                                                
                                                <td> { oprole.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOpRole(oprole.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOpRole(oprole.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(OpRoleListComponent);