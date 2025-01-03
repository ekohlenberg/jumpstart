import React, { Component } from 'react'
import UserOrgService from '../services/UserOrgService';

class UserOrgListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                userorgs: []
        }
        this.addUserOrg = this.addUserOrg.bind(this);
        this.editUserOrg = this.editUserOrg.bind(this);
        this.deleteUserOrg = this.deleteUserOrg.bind(this);
    }

    deleteUserOrg(id){
        UserOrgService.deleteUserOrg(id).then( res => {
            this.setState({userorgs: this.state.userorgs.filter(userorg => userorg.id !== id)});
        });
    }
    viewUserOrg(id){
        this.props.history.push(`/view-userorg/${id}`);
    }
    editUserOrg(id){
        console.log("editing " + id)
        this.props.history.push(`/add-userorg/${id}`);
    }

    componentDidMount(){
        UserOrgService.getUserOrgs().then((res) => {
            this.setState({ userorgs: res.data});
        });
    }

    addUserOrg(){
        this.props.history.push('/add-userorg/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">UserOrg List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addUserOrg}> Add UserOrg</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>User Org ID</th>
                                    
                                    <th>Organization ID</th>
                                    
                                    <th>User ID</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.userorgs.map(
                                        userorg => 
                                        <tr key = {@(Model.DomainVar).id}>

                                                <td> {userorg.id)} </td>  
                                                
                                                <td> {userorg.org_id)} </td>  
                                                
                                                <td> {userorg.user_id)} </td>  
                                                
                                                <td> {userorg.is_active)} </td>  
                                                
                                                <td> {userorg.created_by)} </td>  
                                                
                                                <td> {userorg.last_updated)} </td>  
                                                
                                                <td> {userorg.last_updated_by)} </td>  
                                                
                                                <td> {userorg.version)} </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editUserOrg(userorg.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteUserOrg(userorg.id)} className="btn btn-danger">Delete </button>
                                                
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

export default UserOrgListComponent;