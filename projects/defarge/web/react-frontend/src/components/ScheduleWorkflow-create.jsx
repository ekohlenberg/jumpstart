import React, { Component } from 'react'
import ScheduleWorkflowService from '../services/schedule_workflow-service';
import { withNavigation } from './with-navigation';


class ScheduleWorkflowCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    schedule_id: '' ,
                
                    workflow_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeScheduleIdHandler = this.changeScheduleIdHandler.bind(this);
                                    
                    this.changeWorkflowIdHandler = this.changeWorkflowIdHandler.bind(this);
                        this.saveOrUpdateScheduleWorkflow = this.saveOrUpdateScheduleWorkflow.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("ScheduleWorkflow componentDidMount() ID= " + this.state.id )
            ScheduleWorkflowService.getScheduleWorkflowById(this.state.id).then( (res) =>{
                let scheduleworkflow = res.data;
                this.setState({

                            id: scheduleworkflow.id ,
                        
                            schedule_id: scheduleworkflow.schedule_id ,
                        
                            workflow_id: scheduleworkflow.workflow_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateScheduleWorkflow = (e) => {
        e.preventDefault();
        let scheduleworkflow = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    schedule_id: this.state.schedule_id , 
                            
                    workflow_id: this.state.workflow_id  
                        };
        console.log('scheduleworkflow => ' + JSON.stringify(scheduleworkflow));

        // step 5
        if(this.state.id === '_add'){
            ScheduleWorkflowService.createScheduleWorkflow(scheduleworkflow).then(res =>{
                this.props.navigate('/scheduleworkflow');
            });
        }else{
            ScheduleWorkflowService.updateScheduleWorkflow(scheduleworkflow, this.state.id).then( res => {
                this.props.navigate('/scheduleworkflow');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeScheduleIdHandler= (event) => {
            this.setState({schedule_id: event.target.value});
        }
        
        changeWorkflowIdHandler= (event) => {
            this.setState({workflow_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/scheduleworkflow');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add ScheduleWorkflow</h3>
        }else{
            return <h3 className="text-center">Update ScheduleWorkflow</h3>
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
                                            <input placeholder="" name="schedule_id" className="form-control" 
                                                value={this.state.schedule_id} onChange={this.changeScheduleIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="workflow_id" className="form-control" 
                                                value={this.state.workflow_id} onChange={this.changeWorkflowIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateScheduleWorkflow}>Save</button>
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

export default withNavigation(ScheduleWorkflowCreateComponent);