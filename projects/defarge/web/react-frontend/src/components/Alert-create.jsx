import React, { Component } from 'react'
import AlertService from '../services/alert-service';
import { withNavigation } from './with-navigation';


class AlertCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    alert_rule_id: '' ,
                
                    metric_event_id: '' ,
                
                    triggered_at: '' ,
                
                    resolved_at: '' ,
                
                    status: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeAlertRuleIdHandler = this.changeAlertRuleIdHandler.bind(this);
                                    
                    this.changeMetricEventIdHandler = this.changeMetricEventIdHandler.bind(this);
                                    
                    this.changeTriggeredAtHandler = this.changeTriggeredAtHandler.bind(this);
                                    
                    this.changeResolvedAtHandler = this.changeResolvedAtHandler.bind(this);
                                    
                    this.changeStatusHandler = this.changeStatusHandler.bind(this);
                        this.saveOrUpdateAlert = this.saveOrUpdateAlert.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Alert componentDidMount() ID= " + this.state.id )
            AlertService.getAlertById(this.state.id).then( (res) =>{
                let alert = res.data;
                this.setState({

                            id: alert.id ,
                        
                            alert_rule_id: alert.alert_rule_id ,
                        
                            metric_event_id: alert.metric_event_id ,
                        
                            triggered_at: alert.triggered_at ,
                        
                            resolved_at: alert.resolved_at ,
                        
                            status: alert.status 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateAlert = (e) => {
        e.preventDefault();
        let alert = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    alert_rule_id: this.state.alert_rule_id , 
                            
                    metric_event_id: this.state.metric_event_id , 
                            
                    triggered_at: this.state.triggered_at , 
                            
                    resolved_at: this.state.resolved_at , 
                            
                    status: this.state.status  
                        };
        console.log('alert => ' + JSON.stringify(alert));

        // step 5
        if(this.state.id === '_add'){
            AlertService.createAlert(alert).then(res =>{
                this.props.navigate('/alert');
            });
        }else{
            AlertService.updateAlert(alert, this.state.id).then( res => {
                this.props.navigate('/alert');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeAlertRuleIdHandler= (event) => {
            this.setState({alert_rule_id: event.target.value});
        }
        
        changeMetricEventIdHandler= (event) => {
            this.setState({metric_event_id: event.target.value});
        }
        
        changeTriggeredAtHandler= (event) => {
            this.setState({triggered_at: event.target.value});
        }
        
        changeResolvedAtHandler= (event) => {
            this.setState({resolved_at: event.target.value});
        }
        
        changeStatusHandler= (event) => {
            this.setState({status: event.target.value});
        }
            cancel(){
        this.props.navigate('/alert');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Alert</h3>
        }else{
            return <h3 className="text-center">Update Alert</h3>
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
                                            <label> Alert: </label>
                                            <input placeholder="" name="alert_rule_id" className="form-control" 
                                                value={this.state.alert_rule_id} onChange={this.changeAlertRuleIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Metric: </label>
                                            <input placeholder="" name="metric_event_id" className="form-control" 
                                                value={this.state.metric_event_id} onChange={this.changeMetricEventIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Triggered: </label>
                                            <input placeholder="" name="triggered_at" className="form-control" 
                                                value={this.state.triggered_at} onChange={this.changeTriggeredAtHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Resolved: </label>
                                            <input placeholder="" name="resolved_at" className="form-control" 
                                                value={this.state.resolved_at} onChange={this.changeResolvedAtHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Status: </label>
                                            <input placeholder="" name="status" className="form-control" 
                                                value={this.state.status} onChange={this.changeStatusHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateAlert}>Save</button>
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

export default withNavigation(AlertCreateComponent);