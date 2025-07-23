import React, { Component } from 'react'
import ScheduleService from '../services/schedule-service';
import { withNavigation } from './with-navigation';


class ScheduleCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    cron_expression: '' ,
                
                    next_run_time: '' ,
                
                    last_run_time: '' ,
                
                    status: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeCronExpressionHandler = this.changeCronExpressionHandler.bind(this);
                                    
                    this.changeNextRunTimeHandler = this.changeNextRunTimeHandler.bind(this);
                                    
                    this.changeLastRunTimeHandler = this.changeLastRunTimeHandler.bind(this);
                                    
                    this.changeStatusHandler = this.changeStatusHandler.bind(this);
                        this.saveOrUpdateSchedule = this.saveOrUpdateSchedule.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Schedule componentDidMount() ID= " + this.state.id )
            ScheduleService.getScheduleById(this.state.id).then( (res) =>{
                let schedule = res.data;
                this.setState({

                            id: schedule.id ,
                        
                            cron_expression: schedule.cron_expression ,
                        
                            next_run_time: schedule.next_run_time ,
                        
                            last_run_time: schedule.last_run_time ,
                        
                            status: schedule.status 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateSchedule = (e) => {
        e.preventDefault();
        let schedule = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    cron_expression: this.state.cron_expression , 
                            
                    next_run_time: this.state.next_run_time , 
                            
                    last_run_time: this.state.last_run_time , 
                            
                    status: this.state.status  
                        };
        console.log('schedule => ' + JSON.stringify(schedule));

        // step 5
        if(this.state.id === '_add'){
            ScheduleService.createSchedule(schedule).then(res =>{
                this.props.navigate('/schedule');
            });
        }else{
            ScheduleService.updateSchedule(schedule, this.state.id).then( res => {
                this.props.navigate('/schedule');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeCronExpressionHandler= (event) => {
            this.setState({cron_expression: event.target.value});
        }
        
        changeNextRunTimeHandler= (event) => {
            this.setState({next_run_time: event.target.value});
        }
        
        changeLastRunTimeHandler= (event) => {
            this.setState({last_run_time: event.target.value});
        }
        
        changeStatusHandler= (event) => {
            this.setState({status: event.target.value});
        }
            cancel(){
        this.props.navigate('/schedule');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Schedule</h3>
        }else{
            return <h3 className="text-center">Update Schedule</h3>
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
                                            <label> : </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="cron_expression" className="form-control" 
                                                value={this.state.cron_expression} onChange={this.changeCronExpressionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="next_run_time" className="form-control" 
                                                value={this.state.next_run_time} onChange={this.changeNextRunTimeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="last_run_time" className="form-control" 
                                                value={this.state.last_run_time} onChange={this.changeLastRunTimeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="status" className="form-control" 
                                                value={this.state.status} onChange={this.changeStatusHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateSchedule}>Save</button>
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

export default withNavigation(ScheduleCreateComponent);