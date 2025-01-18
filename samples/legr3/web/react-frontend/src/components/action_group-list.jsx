import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ActionGroupService from '../services/action_group-service';

class ActionGroupListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                actiongroups: []
        }
        this.addActionGroup = this.addActionGroup.bind(this);
        this.editActionGroup = this.editActionGroup.bind(this);
        this.deleteActionGroup = this.deleteActionGroup.bind(this);
    }

    deleteActionGroup(id){
        ActionGroupService.deleteActionGroup(id).then( res => {
            this.setState({ actiongroups: this.state.actiongroups.filter(actiongroup => actiongroup.id !== id) });
        });
    }
    viewActionGroup(id){
        this.props.navigate(`/view-actiongroup/${id}`);
    }
    editActionGroup(id){
        console.log("editing " + id)
        this.props.navigate(`/add-actiongroup/${id}`);
    }

    componentDidMount(){
        ActionGroupService.getActionGroups().then((res) => {
            this.setState({ actiongroups: res.data});
        });
    }

    addActionGroup(){
        this.props.navigate('/add-actiongroup/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">ActionGroup List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addActionGroup}> Add ActionGroup</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Group ID</th>
                                    
                                    <th>Group Name</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.actiongroups.map(
                                        actiongroup => 
                                        <tr key = { actiongroup.id }>

                                                <td> { actiongroup.id } </td>  
                                                
                                                <td> { actiongroup.name } </td>  
                                                
                                                <td> { actiongroup.is_active } </td>  
                                                
                                                <td> { actiongroup.created_by } </td>  
                                                
                                                <td> { actiongroup.last_updated } </td>  
                                                
                                                <td> { actiongroup.last_updated_by } </td>  
                                                
                                                <td> { actiongroup.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editActionGroup(actiongroup.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteActionGroup(actiongroup.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ActionGroupListComponent);