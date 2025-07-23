import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ScheduleWorkflowService from '../services/schedule_workflow-service';

class ScheduleWorkflowListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                scheduleworkflows: []
        }
        this.addScheduleWorkflow = this.addScheduleWorkflow.bind(this);
        this.editScheduleWorkflow = this.editScheduleWorkflow.bind(this);
        this.deleteScheduleWorkflow = this.deleteScheduleWorkflow.bind(this);
    }

    deleteScheduleWorkflow(id){
        ScheduleWorkflowService.deleteScheduleWorkflow(id).then( res => {
            this.setState({ scheduleworkflows: this.state.scheduleworkflows.filter(scheduleworkflow => scheduleworkflow.id !== id) });
        });
    }
    viewScheduleWorkflow(id){
        this.props.navigate(`/view-scheduleworkflow/${id}`);
    }
    editScheduleWorkflow(id){
        console.log("editing " + id)
        this.props.navigate(`/add-scheduleworkflow/${id}`);
    }

    componentDidMount(){
        ScheduleWorkflowService.getScheduleWorkflows().then((res) => {
            this.setState({ scheduleworkflows: res.data});
        });
    }

    addScheduleWorkflow(){
        this.props.navigate('/add-scheduleworkflow/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">ScheduleWorkflow List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addScheduleWorkflow}> Add ScheduleWorkflow</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

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
                                    this.state.scheduleworkflows.map(
                                        scheduleworkflow => 
                                        <tr key = { scheduleworkflow.id }>

                                                <td> { scheduleworkflow.id } </td>  
                                                
                                                <td> { scheduleworkflow.schedule_id } </td>  
                                                
                                                <td> { scheduleworkflow.workflow_id } </td>  
                                                
                                                <td> { scheduleworkflow.is_active } </td>  
                                                
                                                <td> { scheduleworkflow.created_by } </td>  
                                                
                                                <td> { scheduleworkflow.last_updated } </td>  
                                                
                                                <td> { scheduleworkflow.last_updated_by } </td>  
                                                
                                                <td> { scheduleworkflow.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editScheduleWorkflow(scheduleworkflow.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteScheduleWorkflow(scheduleworkflow.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ScheduleWorkflowListComponent);