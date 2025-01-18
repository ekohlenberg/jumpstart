import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import EventService from '../services/event-service';

class EventListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                events: []
        }
        this.addEvent = this.addEvent.bind(this);
        this.editEvent = this.editEvent.bind(this);
        this.deleteEvent = this.deleteEvent.bind(this);
    }

    deleteEvent(id){
        EventService.deleteEvent(id).then( res => {
            this.setState({ events: this.state.events.filter(event => event.id !== id) });
        });
    }
    viewEvent(id){
        this.props.navigate(`/view-event/${id}`);
    }
    editEvent(id){
        console.log("editing " + id)
        this.props.navigate(`/add-event/${id}`);
    }

    componentDidMount(){
        EventService.getEvents().then((res) => {
            this.setState({ events: res.data});
        });
    }

    addEvent(){
        this.props.navigate('/add-event/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Event List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addEvent}> Add Event</button>
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
                                    this.state.events.map(
                                        event => 
                                        <tr key = { event.id }>

                                                <td> { event.id } </td>  
                                                
                                                <td> { event.object } </td>  
                                                
                                                <td> { event.method } </td>  
                                                
                                                <td> { event.script_id } </td>  
                                                
                                                <td> { event.is_active } </td>  
                                                
                                                <td> { event.created_by } </td>  
                                                
                                                <td> { event.last_updated } </td>  
                                                
                                                <td> { event.last_updated_by } </td>  
                                                
                                                <td> { event.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editEvent(event.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteEvent(event.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(EventListComponent);