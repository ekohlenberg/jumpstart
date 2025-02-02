import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import MetricReadingService from '../services/metric_reading-service';

class MetricReadingListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                metricreadings: []
        }
        this.addMetricReading = this.addMetricReading.bind(this);
        this.editMetricReading = this.editMetricReading.bind(this);
        this.deleteMetricReading = this.deleteMetricReading.bind(this);
    }

    deleteMetricReading(id){
        MetricReadingService.deleteMetricReading(id).then( res => {
            this.setState({ metricreadings: this.state.metricreadings.filter(metricreading => metricreading.id !== id) });
        });
    }
    viewMetricReading(id){
        this.props.navigate(`/view-metricreading/${id}`);
    }
    editMetricReading(id){
        console.log("editing " + id)
        this.props.navigate(`/add-metricreading/${id}`);
    }

    componentDidMount(){
        MetricReadingService.getMetricReadings().then((res) => {
            this.setState({ metricreadings: res.data});
        });
    }

    addMetricReading(){
        this.props.navigate('/add-metricreading/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">MetricReading List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addMetricReading}> Add MetricReading</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Id</th>
                                    
                                    <th>Metric</th>
                                    
                                    <th>Reading</th>
                                    
                                    <th>Value</th>
                                    
                                    <th>Created</th>
                                    
                                    <th>Updated</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.metricreadings.map(
                                        metricreading => 
                                        <tr key = { metricreading.id }>

                                                <td> { metricreading.id } </td>  
                                                
                                                <td> { metricreading.metric_id } </td>  
                                                
                                                <td> { metricreading.reading_timestamp } </td>  
                                                
                                                <td> { metricreading.value } </td>  
                                                
                                                <td> { metricreading.created_at } </td>  
                                                
                                                <td> { metricreading.updated_at } </td>  
                                                
                                                <td> { metricreading.is_active } </td>  
                                                
                                                <td> { metricreading.created_by } </td>  
                                                
                                                <td> { metricreading.last_updated } </td>  
                                                
                                                <td> { metricreading.last_updated_by } </td>  
                                                
                                                <td> { metricreading.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editMetricReading(metricreading.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteMetricReading(metricreading.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(MetricReadingListComponent);