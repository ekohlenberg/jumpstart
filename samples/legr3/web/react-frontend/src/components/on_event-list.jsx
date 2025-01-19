import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import OnEventService from '../services/on_event-service';

class OnEventListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                onevents: []
        }
        this.addOnEvent = this.addOnEvent.bind(this);
        this.editOnEvent = this.editOnEvent.bind(this);
        this.deleteOnEvent = this.deleteOnEvent.bind(this);
    }

    deleteOnEvent(id){
        OnEventService.deleteOnEvent(id).then( res => {
            this.setState({ onevents: this.state.onevents.filter(onevent => onevent.id !== id) });
        });
    }
    viewOnEvent(id){
        this.props.navigate(`/view-onevent/${id}`);
    }
    editOnEvent(id){
        console.log("editing " + id)
        this.props.navigate(`/add-onevent/${id}`);
    }

    componentDidMount(){
        OnEventService.getOnEvents().then((res) => {
            this.setState({ onevents: res.data});
        });
    }

    addOnEvent(){
        this.props.navigate('/add-onevent/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">OnEvent List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOnEvent}> Add OnEvent</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Event ID</th>
                                    
                                    <th>Object</th>
                                    
                                    <th>Method</th>
                                    
                                    <th>Script ID</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.onevents.map(
                                        onevent => 
                                        <tr key = { onevent.id }>

                                                <td> { onevent.id } </td>  
                                                
                                                <td> { onevent.objectname } </td>  
                                                
                                                <td> { onevent.methodname } </td>  
                                                
                                                <td> { onevent.script_id } </td>  
                                                
                                                <td> { onevent.is_active } </td>  
                                                
                                                <td> { onevent.created_by } </td>  
                                                
                                                <td> { onevent.last_updated } </td>  
                                                
                                                <td> { onevent.last_updated_by } </td>  
                                                
                                                <td> { onevent.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOnEvent(onevent.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOnEvent(onevent.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(OnEventListComponent);