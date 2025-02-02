import React, { Component } from 'react'
import AlertRuleService from '../services/alert_rule-service';
import { withNavigation } from './with-navigation';


class AlertRuleCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    metric_id: '' ,
                
                    name: '' ,
                
                    condition: '' ,
                
                    threshold: '' ,
                
                    recipients: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeMetricIdHandler = this.changeMetricIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeConditionHandler = this.changeConditionHandler.bind(this);
                                    
                    this.changeThresholdHandler = this.changeThresholdHandler.bind(this);
                                    
                    this.changeRecipientsHandler = this.changeRecipientsHandler.bind(this);
                        this.saveOrUpdateAlertRule = this.saveOrUpdateAlertRule.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("AlertRule componentDidMount() ID= " + this.state.id )
            AlertRuleService.getAlertRuleById(this.state.id).then( (res) =>{
                let alertrule = res.data;
                this.setState({

                            id: alertrule.id ,
                        
                            metric_id: alertrule.metric_id ,
                        
                            name: alertrule.name ,
                        
                            condition: alertrule.condition ,
                        
                            threshold: alertrule.threshold ,
                        
                            recipients: alertrule.recipients 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateAlertRule = (e) => {
        e.preventDefault();
        let alertrule = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    metric_id: this.state.metric_id , 
                            
                    name: this.state.name , 
                            
                    condition: this.state.condition , 
                            
                    threshold: this.state.threshold , 
                            
                    recipients: this.state.recipients  
                        };
        console.log('alertrule => ' + JSON.stringify(alertrule));

        // step 5
        if(this.state.id === '_add'){
            AlertRuleService.createAlertRule(alertrule).then(res =>{
                this.props.navigate('/alertrule');
            });
        }else{
            AlertRuleService.updateAlertRule(alertrule, this.state.id).then( res => {
                this.props.navigate('/alertrule');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeMetricIdHandler= (event) => {
            this.setState({metric_id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeConditionHandler= (event) => {
            this.setState({condition: event.target.value});
        }
        
        changeThresholdHandler= (event) => {
            this.setState({threshold: event.target.value});
        }
        
        changeRecipientsHandler= (event) => {
            this.setState({recipients: event.target.value});
        }
            cancel(){
        this.props.navigate('/alertrule');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add AlertRule</h3>
        }else{
            return <h3 className="text-center">Update AlertRule</h3>
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
                                            <label> Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Condition: </label>
                                            <input placeholder="" name="condition" className="form-control" 
                                                value={this.state.condition} onChange={this.changeConditionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Threshold: </label>
                                            <input placeholder="" name="threshold" className="form-control" 
                                                value={this.state.threshold} onChange={this.changeThresholdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Recipients: </label>
                                            <input placeholder="" name="recipients" className="form-control" 
                                                value={this.state.recipients} onChange={this.changeRecipientsHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateAlertRule}>Save</button>
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

export default withNavigation(AlertRuleCreateComponent);