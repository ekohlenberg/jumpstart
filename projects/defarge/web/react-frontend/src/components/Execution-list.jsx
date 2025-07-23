import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ExecutionService from '../services/execution-service';

class ExecutionListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                executions: []
        }
        this.addExecution = this.addExecution.bind(this);
        this.editExecution = this.editExecution.bind(this);
        this.deleteExecution = this.deleteExecution.bind(this);
    }

    deleteExecution(id){
        ExecutionService.deleteExecution(id).then( res => {
            this.setState({ executions: this.state.executions.filter(execution => execution.id !== id) });
        });
    }
    viewExecution(id){
        this.props.navigate(`/view-execution/${id}`);
    }
    editExecution(id){
        console.log("editing " + id)
        this.props.navigate(`/add-execution/${id}`);
    }

    componentDidMount(){
        ExecutionService.getExecutions().then((res) => {
            this.setState({ executions: res.data});
        });
    }

    addExecution(){
        this.props.navigate('/add-execution/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Execution List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addExecution}> Add Execution</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Execution ID</th>
                                    
                                    <th>Token</th>
                                    
                                    <th>Process</th>
                                    
                                    <th>Start Time</th>
                                    
                                    <th>End Time</th>
                                    
                                    <th>Status</th>
                                    
                                    <th>Log Output</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.executions.map(
                                        execution => 
                                        <tr key = { execution.id }>

                                                <td> { execution.id } </td>  
                                                
                                                <td> { execution.token } </td>  
                                                
                                                <td> { execution.process_id } </td>  
                                                
                                                <td> { execution.start_time } </td>  
                                                
                                                <td> { execution.end_time } </td>  
                                                
                                                <td> { execution.status } </td>  
                                                
                                                <td> { execution.log_output } </td>  
                                                
                                                <td> { execution.is_active } </td>  
                                                
                                                <td> { execution.created_by } </td>  
                                                
                                                <td> { execution.last_updated } </td>  
                                                
                                                <td> { execution.last_updated_by } </td>  
                                                
                                                <td> { execution.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editExecution(execution.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteExecution(execution.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ExecutionListComponent);