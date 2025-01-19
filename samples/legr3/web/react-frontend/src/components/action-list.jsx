import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ActionService from '../services/action-service';

class ActionListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                actions: []
        }
        this.addAction = this.addAction.bind(this);
        this.editAction = this.editAction.bind(this);
        this.deleteAction = this.deleteAction.bind(this);
    }

    deleteAction(id){
        ActionService.deleteAction(id).then( res => {
            this.setState({ actions: this.state.actions.filter(action => action.id !== id) });
        });
    }
    viewAction(id){
        this.props.navigate(`/view-action/${id}`);
    }
    editAction(id){
        console.log("editing " + id)
        this.props.navigate(`/add-action/${id}`);
    }

    componentDidMount(){
        ActionService.getActions().then((res) => {
            this.setState({ actions: res.data});
        });
    }

    addAction(){
        this.props.navigate('/add-action/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Action List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addAction}> Add Action</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Action ID</th>
                                    
                                    <th>Object</th>
                                    
                                    <th>Method</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.actions.map(
                                        action => 
                                        <tr key = { action.id }>

                                                <td> { action.id } </td>  
                                                
                                                <td> { action.objectname } </td>  
                                                
                                                <td> { action.methodname } </td>  
                                                
                                                <td> { action.is_active } </td>  
                                                
                                                <td> { action.created_by } </td>  
                                                
                                                <td> { action.last_updated } </td>  
                                                
                                                <td> { action.last_updated_by } </td>  
                                                
                                                <td> { action.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editAction(action.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteAction(action.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ActionListComponent);