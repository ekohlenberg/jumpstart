import React, { Component } from 'react'
import MetricReadingService from '../services/metric_reading-service';
import { withNavigation } from './with-navigation';


class MetricReadingCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    metric_id: '' ,
                
                    reading_timestamp: '' ,
                
                    value: '' ,
                
                    created_at: '' ,
                
                    updated_at: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeMetricIdHandler = this.changeMetricIdHandler.bind(this);
                                    
                    this.changeReadingTimestampHandler = this.changeReadingTimestampHandler.bind(this);
                                    
                    this.changeValueHandler = this.changeValueHandler.bind(this);
                                    
                    this.changeCreatedAtHandler = this.changeCreatedAtHandler.bind(this);
                                    
                    this.changeUpdatedAtHandler = this.changeUpdatedAtHandler.bind(this);
                        this.saveOrUpdateMetricReading = this.saveOrUpdateMetricReading.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("MetricReading componentDidMount() ID= " + this.state.id )
            MetricReadingService.getMetricReadingById(this.state.id).then( (res) =>{
                let metricreading = res.data;
                this.setState({

                            id: metricreading.id ,
                        
                            metric_id: metricreading.metric_id ,
                        
                            reading_timestamp: metricreading.reading_timestamp ,
                        
                            value: metricreading.value ,
                        
                            created_at: metricreading.created_at ,
                        
                            updated_at: metricreading.updated_at 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateMetricReading = (e) => {
        e.preventDefault();
        let metricreading = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    metric_id: this.state.metric_id , 
                            
                    reading_timestamp: this.state.reading_timestamp , 
                            
                    value: this.state.value , 
                            
                    created_at: this.state.created_at , 
                            
                    updated_at: this.state.updated_at  
                        };
        console.log('metricreading => ' + JSON.stringify(metricreading));

        // step 5
        if(this.state.id === '_add'){
            MetricReadingService.createMetricReading(metricreading).then(res =>{
                this.props.navigate('/metricreading');
            });
        }else{
            MetricReadingService.updateMetricReading(metricreading, this.state.id).then( res => {
                this.props.navigate('/metricreading');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeMetricIdHandler= (event) => {
            this.setState({metric_id: event.target.value});
        }
        
        changeReadingTimestampHandler= (event) => {
            this.setState({reading_timestamp: event.target.value});
        }
        
        changeValueHandler= (event) => {
            this.setState({value: event.target.value});
        }
        
        changeCreatedAtHandler= (event) => {
            this.setState({created_at: event.target.value});
        }
        
        changeUpdatedAtHandler= (event) => {
            this.setState({updated_at: event.target.value});
        }
            cancel(){
        this.props.navigate('/metricreading');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add MetricReading</h3>
        }else{
            return <h3 className="text-center">Update MetricReading</h3>
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
                                            <label> Id: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Metric: </label>
                                            <input placeholder="" name="metric_id" className="form-control" 
                                                value={this.state.metric_id} onChange={this.changeMetricIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Reading: </label>
                                            <input placeholder="" name="reading_timestamp" className="form-control" 
                                                value={this.state.reading_timestamp} onChange={this.changeReadingTimestampHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Value: </label>
                                            <input placeholder="" name="value" className="form-control" 
                                                value={this.state.value} onChange={this.changeValueHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_at" className="form-control" 
                                                value={this.state.created_at} onChange={this.changeCreatedAtHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Updated: </label>
                                            <input placeholder="" name="updated_at" className="form-control" 
                                                value={this.state.updated_at} onChange={this.changeUpdatedAtHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateMetricReading}>Save</button>
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

export default withNavigation(MetricReadingCreateComponent);