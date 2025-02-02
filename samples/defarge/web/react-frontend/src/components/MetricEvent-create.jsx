import React, { Component } from 'react'
import MetricEventService from '../services/metric_event-service';
import { withNavigation } from './with-navigation';


class MetricEventCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    metric_id: '' ,
                
                    event_time: '' ,
                
                    value: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeMetricIdHandler = this.changeMetricIdHandler.bind(this);
                                    
                    this.changeEventTimeHandler = this.changeEventTimeHandler.bind(this);
                                    
                    this.changeValueHandler = this.changeValueHandler.bind(this);
                        this.saveOrUpdateMetricEvent = this.saveOrUpdateMetricEvent.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("MetricEvent componentDidMount() ID= " + this.state.id )
            MetricEventService.getMetricEventById(this.state.id).then( (res) =>{
                let metricevent = res.data;
                this.setState({

                            id: metricevent.id ,
                        
                            metric_id: metricevent.metric_id ,
                        
                            event_time: metricevent.event_time ,
                        
                            value: metricevent.value 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateMetricEvent = (e) => {
        e.preventDefault();
        let metricevent = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    metric_id: this.state.metric_id , 
                            
                    event_time: this.state.event_time , 
                            
                    value: this.state.value  
                        };
        console.log('metricevent => ' + JSON.stringify(metricevent));

        // step 5
        if(this.state.id === '_add'){
            MetricEventService.createMetricEvent(metricevent).then(res =>{
                this.props.navigate('/metricevent');
            });
        }else{
            MetricEventService.updateMetricEvent(metricevent, this.state.id).then( res => {
                this.props.navigate('/metricevent');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeMetricIdHandler= (event) => {
            this.setState({metric_id: event.target.value});
        }
        
        changeEventTimeHandler= (event) => {
            this.setState({event_time: event.target.value});
        }
        
        changeValueHandler= (event) => {
            this.setState({value: event.target.value});
        }
            cancel(){
        this.props.navigate('/metricevent');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add MetricEvent</h3>
        }else{
            return <h3 className="text-center">Update MetricEvent</h3>
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
                                            <label> Metric: </label>
                                            <input placeholder="" name="metric_id" className="form-control" 
                                                value={this.state.metric_id} onChange={this.changeMetricIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Event Time: </label>
                                            <input placeholder="" name="event_time" className="form-control" 
                                                value={this.state.event_time} onChange={this.changeEventTimeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Value: </label>
                                            <input placeholder="" name="value" className="form-control" 
                                                value={this.state.value} onChange={this.changeValueHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateMetricEvent}>Save</button>
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

export default withNavigation(MetricEventCreateComponent);