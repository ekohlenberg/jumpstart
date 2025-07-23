import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import WorkflowProcessService from '../services/workflow_process-service';

class WorkflowProcessListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                workflowprocesss: []
        }
        this.addWorkflowProcess = this.addWorkflowProcess.bind(this);
        this.editWorkflowProcess = this.editWorkflowProcess.bind(this);
        this.deleteWorkflowProcess = this.deleteWorkflowProcess.bind(this);
    }

    deleteWorkflowProcess(id){
        WorkflowProcessService.deleteWorkflowProcess(id).then( res => {
            this.setState({ workflowprocesss: this.state.workflowprocesss.filter(workflowprocess => workflowprocess.id !== id) });
        });
    }
    viewWorkflowProcess(id){
        this.props.navigate(`/view-workflowprocess/${id}`);
    }
    editWorkflowProcess(id){
        console.log("editing " + id)
        this.props.navigate(`/add-workflowprocess/${id}`);
    }

    componentDidMount(){
        WorkflowProcessService.getWorkflowProcesss().then((res) => {
            this.setState({ workflowprocesss: res.data});
        });
    }

    addWorkflowProcess(){
        this.props.navigate('/add-workflowprocess/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">WorkflowProcess List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addWorkflowProcess}> Add WorkflowProcess</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th>Sequence</th>
                                    
                                    <th></th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.workflowprocesss.map(
                                        workflowprocess => 
                                        <tr key = { workflowprocess.id }>

                                                <td> { workflowprocess.id } </td>  
                                                
                                                <td> { workflowprocess.workflow_id } </td>  
                                                
                                                <td> { workflowprocess.process_id } </td>  
                                                
                                                <td> { workflowprocess.execution_sequence } </td>  
                                                
                                                <td> { workflowprocess.server_id } </td>  
                                                
                                                <td> { workflowprocess.is_active } </td>  
                                                
                                                <td> { workflowprocess.created_by } </td>  
                                                
                                                <td> { workflowprocess.last_updated } </td>  
                                                
                                                <td> { workflowprocess.last_updated_by } </td>  
                                                
                                                <td> { workflowprocess.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editWorkflowProcess(workflowprocess.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteWorkflowProcess(workflowprocess.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(WorkflowProcessListComponent);