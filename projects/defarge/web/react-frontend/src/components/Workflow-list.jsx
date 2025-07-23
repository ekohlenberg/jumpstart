import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import WorkflowService from '../services/workflow-service';

class WorkflowListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                workflows: []
        }
        this.addWorkflow = this.addWorkflow.bind(this);
        this.editWorkflow = this.editWorkflow.bind(this);
        this.deleteWorkflow = this.deleteWorkflow.bind(this);
    }

    deleteWorkflow(id){
        WorkflowService.deleteWorkflow(id).then( res => {
            this.setState({ workflows: this.state.workflows.filter(workflow => workflow.id !== id) });
        });
    }
    viewWorkflow(id){
        this.props.navigate(`/view-workflow/${id}`);
    }
    editWorkflow(id){
        console.log("editing " + id)
        this.props.navigate(`/add-workflow/${id}`);
    }

    componentDidMount(){
        WorkflowService.getWorkflows().then((res) => {
            this.setState({ workflows: res.data});
        });
    }

    addWorkflow(){
        this.props.navigate('/add-workflow/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Workflow List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addWorkflow}> Add Workflow</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th></th>
                                    
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
                                    this.state.workflows.map(
                                        workflow => 
                                        <tr key = { workflow.id }>

                                                <td> { workflow.id } </td>  
                                                
                                                <td> { workflow.parent_workflow_id } </td>  
                                                
                                                <td> { workflow.name } </td>  
                                                
                                                <td> { workflow.description } </td>  
                                                
                                                <td> { workflow.is_active } </td>  
                                                
                                                <td> { workflow.created_by } </td>  
                                                
                                                <td> { workflow.last_updated } </td>  
                                                
                                                <td> { workflow.last_updated_by } </td>  
                                                
                                                <td> { workflow.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editWorkflow(workflow.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteWorkflow(workflow.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(WorkflowListComponent);