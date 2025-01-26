import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import EventServiceService from '../services/event_service-service';

class EventServiceListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                eventservices: []
        }
        this.addEventService = this.addEventService.bind(this);
        this.editEventService = this.editEventService.bind(this);
        this.deleteEventService = this.deleteEventService.bind(this);
    }

    deleteEventService(id){
        EventServiceService.deleteEventService(id).then( res => {
            this.setState({ eventservices: this.state.eventservices.filter(eventservice => eventservice.id !== id) });
        });
    }
    viewEventService(id){
        this.props.navigate(`/view-eventservice/${id}`);
    }
    editEventService(id){
        console.log("editing " + id)
        this.props.navigate(`/add-eventservice/${id}`);
    }

    componentDidMount(){
        EventServiceService.getEventServices().then((res) => {
            this.setState({ eventservices: res.data});
        });
    }

    addEventService(){
        this.props.navigate('/add-eventservice/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">EventService List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addEventService}> Add EventService</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Event ID</th>
                                    
                                    <th>Event Type</th>
                                    
                                    <th>Object Filter</th>
                                    
                                    <th>Method Filter</th>
                                    
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
                                    this.state.eventservices.map(
                                        eventservice => 
                                        <tr key = { eventservice.id }>

                                                <td> { eventservice.id } </td>  
                                                
                                                <td> { eventservice.event_type } </td>  
                                                
                                                <td> { eventservice.objectname_filter } </td>  
                                                
                                                <td> { eventservice.methodname_filter } </td>  
                                                
                                                <td> { eventservice.script_id } </td>  
                                                
                                                <td> { eventservice.is_active } </td>  
                                                
                                                <td> { eventservice.created_by } </td>  
                                                
                                                <td> { eventservice.last_updated } </td>  
                                                
                                                <td> { eventservice.last_updated_by } </td>  
                                                
                                                <td> { eventservice.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editEventService(eventservice.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteEventService(eventservice.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(EventServiceListComponent);