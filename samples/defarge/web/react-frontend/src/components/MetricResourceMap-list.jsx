import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import MetricResourceMapService from '../services/metric_resource_map-service';

class MetricResourceMapListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                metricresourcemaps: []
        }
        this.addMetricResourceMap = this.addMetricResourceMap.bind(this);
        this.editMetricResourceMap = this.editMetricResourceMap.bind(this);
        this.deleteMetricResourceMap = this.deleteMetricResourceMap.bind(this);
    }

    deleteMetricResourceMap(id){
        MetricResourceMapService.deleteMetricResourceMap(id).then( res => {
            this.setState({ metricresourcemaps: this.state.metricresourcemaps.filter(metricresourcemap => metricresourcemap.id !== id) });
        });
    }
    viewMetricResourceMap(id){
        this.props.navigate(`/view-metricresourcemap/${id}`);
    }
    editMetricResourceMap(id){
        console.log("editing " + id)
        this.props.navigate(`/add-metricresourcemap/${id}`);
    }

    componentDidMount(){
        MetricResourceMapService.getMetricResourceMaps().then((res) => {
            this.setState({ metricresourcemaps: res.data});
        });
    }

    addMetricResourceMap(){
        this.props.navigate('/add-metricresourcemap/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">MetricResourceMap List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addMetricResourceMap}> Add MetricResourceMap</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Resource</th>
                                    
                                    <th>Metric</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.metricresourcemaps.map(
                                        metricresourcemap => 
                                        <tr key = { metricresourcemap.id }>

                                                <td> { metricresourcemap.id } </td>  
                                                
                                                <td> { metricresourcemap.resource_id } </td>  
                                                
                                                <td> { metricresourcemap.metric_id } </td>  
                                                
                                                <td> { metricresourcemap.is_active } </td>  
                                                
                                                <td> { metricresourcemap.created_by } </td>  
                                                
                                                <td> { metricresourcemap.last_updated } </td>  
                                                
                                                <td> { metricresourcemap.last_updated_by } </td>  
                                                
                                                <td> { metricresourcemap.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editMetricResourceMap(metricresourcemap.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteMetricResourceMap(metricresourcemap.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(MetricResourceMapListComponent);