import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import MetricEventService from '../services/metric_event-service';

class MetricEventListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                metricevents: []
        }
        this.addMetricEvent = this.addMetricEvent.bind(this);
        this.editMetricEvent = this.editMetricEvent.bind(this);
        this.deleteMetricEvent = this.deleteMetricEvent.bind(this);
    }

    deleteMetricEvent(id){
        MetricEventService.deleteMetricEvent(id).then( res => {
            this.setState({ metricevents: this.state.metricevents.filter(metricevent => metricevent.id !== id) });
        });
    }
    viewMetricEvent(id){
        this.props.navigate(`/view-metricevent/${id}`);
    }
    editMetricEvent(id){
        console.log("editing " + id)
        this.props.navigate(`/add-metricevent/${id}`);
    }

    componentDidMount(){
        MetricEventService.getMetricEvents().then((res) => {
            this.setState({ metricevents: res.data});
        });
    }

    addMetricEvent(){
        this.props.navigate('/add-metricevent/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">MetricEvent List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addMetricEvent}> Add MetricEvent</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Metric</th>
                                    
                                    <th>Event Time</th>
                                    
                                    <th>Value</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.metricevents.map(
                                        metricevent => 
                                        <tr key = { metricevent.id }>

                                                <td> { metricevent.id } </td>  
                                                
                                                <td> { metricevent.metric_id } </td>  
                                                
                                                <td> { metricevent.event_time } </td>  
                                                
                                                <td> { metricevent.value } </td>  
                                                
                                                <td> { metricevent.is_active } </td>  
                                                
                                                <td> { metricevent.created_by } </td>  
                                                
                                                <td> { metricevent.last_updated } </td>  
                                                
                                                <td> { metricevent.last_updated_by } </td>  
                                                
                                                <td> { metricevent.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editMetricEvent(metricevent.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteMetricEvent(metricevent.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(MetricEventListComponent);