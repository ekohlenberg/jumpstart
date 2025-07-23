import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ProcessService from '../services/process-service';

class ProcessListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                processs: []
        }
        this.addProcess = this.addProcess.bind(this);
        this.editProcess = this.editProcess.bind(this);
        this.deleteProcess = this.deleteProcess.bind(this);
    }

    deleteProcess(id){
        ProcessService.deleteProcess(id).then( res => {
            this.setState({ processs: this.state.processs.filter(process => process.id !== id) });
        });
    }
    viewProcess(id){
        this.props.navigate(`/view-process/${id}`);
    }
    editProcess(id){
        console.log("editing " + id)
        this.props.navigate(`/add-process/${id}`);
    }

    componentDidMount(){
        ProcessService.getProcesss().then((res) => {
            this.setState({ processs: res.data});
        });
    }

    addProcess(){
        this.props.navigate('/add-process/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Process List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addProcess}> Add Process</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Process ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Script</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.processs.map(
                                        process => 
                                        <tr key = { process.id }>

                                                <td> { process.id } </td>  
                                                
                                                <td> { process.name } </td>  
                                                
                                                <td> { process.script_id } </td>  
                                                
                                                <td> { process.is_active } </td>  
                                                
                                                <td> { process.created_by } </td>  
                                                
                                                <td> { process.last_updated } </td>  
                                                
                                                <td> { process.last_updated_by } </td>  
                                                
                                                <td> { process.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editProcess(process.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteProcess(process.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ProcessListComponent);