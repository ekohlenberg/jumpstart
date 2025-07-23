import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import OpRoleMemberService from '../services/op_role_member-service';

class OpRoleMemberListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                oprolemembers: []
        }
        this.addOpRoleMember = this.addOpRoleMember.bind(this);
        this.editOpRoleMember = this.editOpRoleMember.bind(this);
        this.deleteOpRoleMember = this.deleteOpRoleMember.bind(this);
    }

    deleteOpRoleMember(id){
        OpRoleMemberService.deleteOpRoleMember(id).then( res => {
            this.setState({ oprolemembers: this.state.oprolemembers.filter(oprolemember => oprolemember.id !== id) });
        });
    }
    viewOpRoleMember(id){
        this.props.navigate(`/view-oprolemember/${id}`);
    }
    editOpRoleMember(id){
        console.log("editing " + id)
        this.props.navigate(`/add-oprolemember/${id}`);
    }

    componentDidMount(){
        OpRoleMemberService.getOpRoleMembers().then((res) => {
            this.setState({ oprolemembers: res.data});
        });
    }

    addOpRoleMember(){
        this.props.navigate('/add-oprolemember/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">OpRoleMember List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOpRoleMember}> Add OpRoleMember</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Member ID</th>
                                    
                                    <th>Username</th>
                                    
                                    <th>Role</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.oprolemembers.map(
                                        oprolemember => 
                                        <tr key = { oprolemember.id }>

                                                <td> { oprolemember.id } </td>  
                                                
                                                <td> { oprolemember.user_id } </td>  
                                                
                                                <td> { oprolemember.op_role_id } </td>  
                                                
                                                <td> { oprolemember.is_active } </td>  
                                                
                                                <td> { oprolemember.created_by } </td>  
                                                
                                                <td> { oprolemember.last_updated } </td>  
                                                
                                                <td> { oprolemember.last_updated_by } </td>  
                                                
                                                <td> { oprolemember.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOpRoleMember(oprolemember.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOpRoleMember(oprolemember.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(OpRoleMemberListComponent);