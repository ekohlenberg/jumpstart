import React, { Component } from 'react'
import ExecutionService from '../services/execution-service';
import { withNavigation } from './with-navigation';


class ExecutionCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    token: '' ,
                
                    process_id: '' ,
                
                    start_time: '' ,
                
                    end_time: '' ,
                
                    status: '' ,
                
                    log_output: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeTokenHandler = this.changeTokenHandler.bind(this);
                                    
                    this.changeProcessIdHandler = this.changeProcessIdHandler.bind(this);
                                    
                    this.changeStartTimeHandler = this.changeStartTimeHandler.bind(this);
                                    
                    this.changeEndTimeHandler = this.changeEndTimeHandler.bind(this);
                                    
                    this.changeStatusHandler = this.changeStatusHandler.bind(this);
                                    
                    this.changeLogOutputHandler = this.changeLogOutputHandler.bind(this);
                        this.saveOrUpdateExecution = this.saveOrUpdateExecution.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Execution componentDidMount() ID= " + this.state.id )
            ExecutionService.getExecutionById(this.state.id).then( (res) =>{
                let execution = res.data;
                this.setState({

                            id: execution.id ,
                        
                            token: execution.token ,
                        
                            process_id: execution.process_id ,
                        
                            start_time: execution.start_time ,
                        
                            end_time: execution.end_time ,
                        
                            status: execution.status ,
                        
                            log_output: execution.log_output 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateExecution = (e) => {
        e.preventDefault();
        let execution = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    token: this.state.token , 
                            
                    process_id: this.state.process_id , 
                            
                    start_time: this.state.start_time , 
                            
                    end_time: this.state.end_time , 
                            
                    status: this.state.status , 
                            
                    log_output: this.state.log_output  
                        };
        console.log('execution => ' + JSON.stringify(execution));

        // step 5
        if(this.state.id === '_add'){
            ExecutionService.createExecution(execution).then(res =>{
                this.props.navigate('/execution');
            });
        }else{
            ExecutionService.updateExecution(execution, this.state.id).then( res => {
                this.props.navigate('/execution');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeTokenHandler= (event) => {
            this.setState({token: event.target.value});
        }
        
        changeProcessIdHandler= (event) => {
            this.setState({process_id: event.target.value});
        }
        
        changeStartTimeHandler= (event) => {
            this.setState({start_time: event.target.value});
        }
        
        changeEndTimeHandler= (event) => {
            this.setState({end_time: event.target.value});
        }
        
        changeStatusHandler= (event) => {
            this.setState({status: event.target.value});
        }
        
        changeLogOutputHandler= (event) => {
            this.setState({log_output: event.target.value});
        }
            cancel(){
        this.props.navigate('/execution');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Execution</h3>
        }else{
            return <h3 className="text-center">Update Execution</h3>
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
                                            <label> Execution ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Token: </label>
                                            <input placeholder="" name="token" className="form-control" 
                                                value={this.state.token} onChange={this.changeTokenHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Process: </label>
                                            <input placeholder="" name="process_id" className="form-control" 
                                                value={this.state.process_id} onChange={this.changeProcessIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Start Time: </label>
                                            <input placeholder="" name="start_time" className="form-control" 
                                                value={this.state.start_time} onChange={this.changeStartTimeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> End Time: </label>
                                            <input placeholder="" name="end_time" className="form-control" 
                                                value={this.state.end_time} onChange={this.changeEndTimeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Status: </label>
                                            <input placeholder="" name="status" className="form-control" 
                                                value={this.state.status} onChange={this.changeStatusHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Log Output: </label>
                                            <input placeholder="" name="log_output" className="form-control" 
                                                value={this.state.log_output} onChange={this.changeLogOutputHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateExecution}>Save</button>
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

export default withNavigation(ExecutionCreateComponent);