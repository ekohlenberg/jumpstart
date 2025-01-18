import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import UserActionGroupService from '../services/user_action_group-service';

class UserActionGroupListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                useractiongroups: []
        }
        this.addUserActionGroup = this.addUserActionGroup.bind(this);
        this.editUserActionGroup = this.editUserActionGroup.bind(this);
        this.deleteUserActionGroup = this.deleteUserActionGroup.bind(this);
    }

    deleteUserActionGroup(id){
        UserActionGroupService.deleteUserActionGroup(id).then( res => {
            this.setState({ useractiongroups: this.state.useractiongroups.filter(useractiongroup => useractiongroup.id !== id) });
        });
    }
    viewUserActionGroup(id){
        this.props.navigate(`/view-useractiongroup/${id}`);
    }
    editUserActionGroup(id){
        console.log("editing " + id)
        this.props.navigate(`/add-useractiongroup/${id}`);
    }

    componentDidMount(){
        UserActionGroupService.getUserActionGroups().then((res) => {
            this.setState({ useractiongroups: res.data});
        });
    }

    addUserActionGroup(){
        this.props.navigate('/add-useractiongroup/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">UserActionGroup List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addUserActionGroup}> Add UserActionGroup</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Member ID</th>
                                    
                                    <th>Username</th>
                                    
                                    <th>Action Group</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.useractiongroups.map(
                                        useractiongroup => 
                                        <tr key = { useractiongroup.id }>

                                                <td> { useractiongroup.id } </td>  
                                                
                                                <td> { useractiongroup.user_id } </td>  
                                                
                                                <td> { useractiongroup.action_group_id } </td>  
                                                
                                                <td> { useractiongroup.is_active } </td>  
                                                
                                                <td> { useractiongroup.created_by } </td>  
                                                
                                                <td> { useractiongroup.last_updated } </td>  
                                                
                                                <td> { useractiongroup.last_updated_by } </td>  
                                                
                                                <td> { useractiongroup.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editUserActionGroup(useractiongroup.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteUserActionGroup(useractiongroup.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(UserActionGroupListComponent);