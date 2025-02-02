import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ScriptService from '../services/script-service';

class ScriptListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                scripts: []
        }
        this.addScript = this.addScript.bind(this);
        this.editScript = this.editScript.bind(this);
        this.deleteScript = this.deleteScript.bind(this);
    }

    deleteScript(id){
        ScriptService.deleteScript(id).then( res => {
            this.setState({ scripts: this.state.scripts.filter(script => script.id !== id) });
        });
    }
    viewScript(id){
        this.props.navigate(`/view-script/${id}`);
    }
    editScript(id){
        console.log("editing " + id)
        this.props.navigate(`/add-script/${id}`);
    }

    componentDidMount(){
        ScriptService.getScripts().then((res) => {
            this.setState({ scripts: res.data});
        });
    }

    addScript(){
        this.props.navigate('/add-script/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Script List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addScript}> Add Script</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Script ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Source Code</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.scripts.map(
                                        script => 
                                        <tr key = { script.id }>

                                                <td> { script.id } </td>  
                                                
                                                <td> { script.name } </td>  
                                                
                                                <td> { script.source } </td>  
                                                
                                                <td> { script.is_active } </td>  
                                                
                                                <td> { script.created_by } </td>  
                                                
                                                <td> { script.last_updated } </td>  
                                                
                                                <td> { script.last_updated_by } </td>  
                                                
                                                <td> { script.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editScript(script.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteScript(script.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ScriptListComponent);