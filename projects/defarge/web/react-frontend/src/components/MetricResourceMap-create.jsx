import React, { Component } from 'react'
import MetricResourceMapService from '../services/metric_resource_map-service';
import { withNavigation } from './with-navigation';


class MetricResourceMapCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    resource_id: '' ,
                
                    metric_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeResourceIdHandler = this.changeResourceIdHandler.bind(this);
                                    
                    this.changeMetricIdHandler = this.changeMetricIdHandler.bind(this);
                        this.saveOrUpdateMetricResourceMap = this.saveOrUpdateMetricResourceMap.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("MetricResourceMap componentDidMount() ID= " + this.state.id )
            MetricResourceMapService.getMetricResourceMapById(this.state.id).then( (res) =>{
                let metricresourcemap = res.data;
                this.setState({

                            id: metricresourcemap.id ,
                        
                            resource_id: metricresourcemap.resource_id ,
                        
                            metric_id: metricresourcemap.metric_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateMetricResourceMap = (e) => {
        e.preventDefault();
        let metricresourcemap = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    resource_id: this.state.resource_id , 
                            
                    metric_id: this.state.metric_id  
                        };
        console.log('metricresourcemap => ' + JSON.stringify(metricresourcemap));

        // step 5
        if(this.state.id === '_add'){
            MetricResourceMapService.createMetricResourceMap(metricresourcemap).then(res =>{
                this.props.navigate('/metricresourcemap');
            });
        }else{
            MetricResourceMapService.updateMetricResourceMap(metricresourcemap, this.state.id).then( res => {
                this.props.navigate('/metricresourcemap');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeResourceIdHandler= (event) => {
            this.setState({resource_id: event.target.value});
        }
        
        changeMetricIdHandler= (event) => {
            this.setState({metric_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/metricresourcemap');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add MetricResourceMap</h3>
        }else{
            return <h3 className="text-center">Update MetricResourceMap</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                   <div className = "container">
                        <div className = "row">
                            <div className = "card col-md-6 offset-md-3 offset-md-3">
                                {
                                    this.getTitle()
                                }
                                <div className = "card-body">
                                    <form>
                                        
                    
                                            <div className = "form-group">
                                            <br/>
                                            <label> ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Resource: </label>
                                            <input placeholder="" name="resource_id" className="form-control" 
                                                value={this.state.resource_id} onChange={this.changeResourceIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Metric: </label>
                                            <input placeholder="" name="metric_id" className="form-control" 
                                                value={this.state.metric_id} onChange={this.changeMetricIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateMetricResourceMap}>Save</button>
                                        <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{marginLeft: "10px"}}>Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>

                   </div>
            </div>
        )
    }
}

export default withNavigation(MetricResourceMapCreateComponent);