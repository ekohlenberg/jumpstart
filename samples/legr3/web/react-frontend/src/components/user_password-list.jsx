import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import UserPasswordService from '../services/user_password-service';

class UserPasswordListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                userpasswords: []
        }
        this.addUserPassword = this.addUserPassword.bind(this);
        this.editUserPassword = this.editUserPassword.bind(this);
        this.deleteUserPassword = this.deleteUserPassword.bind(this);
    }

    deleteUserPassword(id){
        UserPasswordService.deleteUserPassword(id).then( res => {
            this.setState({ userpasswords: this.state.userpasswords.filter(userpassword => userpassword.id !== id) });
        });
    }
    viewUserPassword(id){
        this.props.navigate(`/view-userpassword/${id}`);
    }
    editUserPassword(id){
        console.log("editing " + id)
        this.props.navigate(`/add-userpassword/${id}`);
    }

    componentDidMount(){
        UserPasswordService.getUserPasswords().then((res) => {
            this.setState({ userpasswords: res.data});
        });
    }

    addUserPassword(){
        this.props.navigate('/add-userpassword/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">UserPassword List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addUserPassword}> Add UserPassword</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>User ID</th>
                                    
                                    <th>User ID</th>
                                    
                                    <th>Password</th>
                                    
                                    <th>Expiry</th>
                                    
                                    <th>Needs Reset</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.userpasswords.map(
                                        userpassword => 
                                        <tr key = { userpassword.id }>

                                                <td> { userpassword.id } </td>  
                                                
                                                <td> { userpassword.user_id } </td>  
                                                
                                                <td> { userpassword.password_hash } </td>  
                                                
                                                <td> { userpassword.expiry } </td>  
                                                
                                                <td> { userpassword.needs_reset } </td>  
                                                
                                                <td> { userpassword.is_active } </td>  
                                                
                                                <td> { userpassword.created_by } </td>  
                                                
                                                <td> { userpassword.last_updated } </td>  
                                                
                                                <td> { userpassword.last_updated_by } </td>  
                                                
                                                <td> { userpassword.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editUserPassword(userpassword.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteUserPassword(userpassword.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(UserPasswordListComponent);