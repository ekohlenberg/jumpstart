import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import UserService from '../services/user-service';

class UserListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                users: []
        }
        this.addUser = this.addUser.bind(this);
        this.editUser = this.editUser.bind(this);
        this.deleteUser = this.deleteUser.bind(this);
    }

    deleteUser(id){
        UserService.deleteUser(id).then( res => {
            this.setState({ users: this.state.users.filter(user => user.id !== id) });
        });
    }
    viewUser(id){
        this.props.navigate(`/view-user/${id}`);
    }
    editUser(id){
        console.log("editing " + id)
        this.props.navigate(`/add-user/${id}`);
    }

    componentDidMount(){
        UserService.getUsers().then((res) => {
            this.setState({ users: res.data});
        });
    }

    addUser(){
        this.props.navigate('/add-user/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">User List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addUser}> Add User</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>User ID</th>
                                    
                                    <th>First</th>
                                    
                                    <th>Last</th>
                                    
                                    <th>Username</th>
                                    
                                    <th>Email</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Last Login</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.users.map(
                                        user => 
                                        <tr key = { user.id }>

                                                <td> { user.id } </td>  
                                                
                                                <td> { user.first_name } </td>  
                                                
                                                <td> { user.last_name } </td>  
                                                
                                                <td> { user.username } </td>  
                                                
                                                <td> { user.email } </td>  
                                                
                                                <td> { user.created_date } </td>  
                                                
                                                <td> { user.last_login_date } </td>  
                                                
                                                <td> { user.is_active } </td>  
                                                
                                                <td> { user.created_by } </td>  
                                                
                                                <td> { user.last_updated } </td>  
                                                
                                                <td> { user.last_updated_by } </td>  
                                                
                                                <td> { user.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editUser(user.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteUser(user.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(UserListComponent);