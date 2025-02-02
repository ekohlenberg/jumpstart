import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import AlertService from '../services/alert-service';

class AlertListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                alerts: []
        }
        this.addAlert = this.addAlert.bind(this);
        this.editAlert = this.editAlert.bind(this);
        this.deleteAlert = this.deleteAlert.bind(this);
    }

    deleteAlert(id){
        AlertService.deleteAlert(id).then( res => {
            this.setState({ alerts: this.state.alerts.filter(alert => alert.id !== id) });
        });
    }
    viewAlert(id){
        this.props.navigate(`/view-alert/${id}`);
    }
    editAlert(id){
        console.log("editing " + id)
        this.props.navigate(`/add-alert/${id}`);
    }

    componentDidMount(){
        AlertService.getAlerts().then((res) => {
            this.setState({ alerts: res.data});
        });
    }

    addAlert(){
        this.props.navigate('/add-alert/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Alert List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addAlert}> Add Alert</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Alert</th>
                                    
                                    <th>Metric</th>
                                    
                                    <th>Triggered</th>
                                    
                                    <th>Resolved</th>
                                    
                                    <th>Status</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.alerts.map(
                                        alert => 
                                        <tr key = { alert.id }>

                                                <td> { alert.id } </td>  
                                                
                                                <td> { alert.alert_rule_id } </td>  
                                                
                                                <td> { alert.metric_event_id } </td>  
                                                
                                                <td> { alert.triggered_at } </td>  
                                                
                                                <td> { alert.resolved_at } </td>  
                                                
                                                <td> { alert.status } </td>  
                                                
                                                <td> { alert.is_active } </td>  
                                                
                                                <td> { alert.created_by } </td>  
                                                
                                                <td> { alert.last_updated } </td>  
                                                
                                                <td> { alert.last_updated_by } </td>  
                                                
                                                <td> { alert.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editAlert(alert.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteAlert(alert.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(AlertListComponent);