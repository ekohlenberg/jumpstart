import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import MetricService from '../services/metric-service';

class MetricListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                metrics: []
        }
        this.addMetric = this.addMetric.bind(this);
        this.editMetric = this.editMetric.bind(this);
        this.deleteMetric = this.deleteMetric.bind(this);
    }

    deleteMetric(id){
        MetricService.deleteMetric(id).then( res => {
            this.setState({ metrics: this.state.metrics.filter(metric => metric.id !== id) });
        });
    }
    viewMetric(id){
        this.props.navigate(`/view-metric/${id}`);
    }
    editMetric(id){
        console.log("editing " + id)
        this.props.navigate(`/add-metric/${id}`);
    }

    componentDidMount(){
        MetricService.getMetrics().then((res) => {
            this.setState({ metrics: res.data});
        });
    }

    addMetric(){
        this.props.navigate('/add-metric/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Metric List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addMetric}> Add Metric</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Category</th>
                                    
                                    <th>Unit</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.metrics.map(
                                        metric => 
                                        <tr key = { metric.id }>

                                                <td> { metric.id } </td>  
                                                
                                                <td> { metric.name } </td>  
                                                
                                                <td> { metric.category_id } </td>  
                                                
                                                <td> { metric.uom_id } </td>  
                                                
                                                <td> { metric.is_active } </td>  
                                                
                                                <td> { metric.created_by } </td>  
                                                
                                                <td> { metric.last_updated } </td>  
                                                
                                                <td> { metric.last_updated_by } </td>  
                                                
                                                <td> { metric.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editMetric(metric.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteMetric(metric.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(MetricListComponent);