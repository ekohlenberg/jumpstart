import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import OperationService from '../services/operation-service';

class OperationListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                operations: []
        }
        this.addOperation = this.addOperation.bind(this);
        this.editOperation = this.editOperation.bind(this);
        this.deleteOperation = this.deleteOperation.bind(this);
    }

    deleteOperation(id){
        OperationService.deleteOperation(id).then( res => {
            this.setState({ operations: this.state.operations.filter(operation => operation.id !== id) });
        });
    }
    viewOperation(id){
        this.props.navigate(`/view-operation/${id}`);
    }
    editOperation(id){
        console.log("editing " + id)
        this.props.navigate(`/add-operation/${id}`);
    }

    componentDidMount(){
        OperationService.getOperations().then((res) => {
            this.setState({ operations: res.data});
        });
    }

    addOperation(){
        this.props.navigate('/add-operation/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Operation List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOperation}> Add Operation</button>
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
                                    this.state.operations.map(
                                        operation => 
                                        <tr key = { operation.id }>

                                                <td> { operation.id } </td>  
                                                
                                                <td> { operation.objectname } </td>  
                                                
                                                <td> { operation.methodname } </td>  
                                                
                                                <td> { operation.is_active } </td>  
                                                
                                                <td> { operation.created_by } </td>  
                                                
                                                <td> { operation.last_updated } </td>  
                                                
                                                <td> { operation.last_updated_by } </td>  
                                                
                                                <td> { operation.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOperation(operation.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOperation(operation.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(OperationListComponent);