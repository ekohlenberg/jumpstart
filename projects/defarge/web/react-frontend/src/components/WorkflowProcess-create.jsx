import React, { Component } from 'react'
import WorkflowProcessService from '../services/workflow_process-service';
import { withNavigation } from './with-navigation';


class WorkflowProcessCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    workflow_id: '' ,
                
                    process_id: '' ,
                
                    execution_sequence: '' ,
                
                    server_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeWorkflowIdHandler = this.changeWorkflowIdHandler.bind(this);
                                    
                    this.changeProcessIdHandler = this.changeProcessIdHandler.bind(this);
                                    
                    this.changeExecutionSequenceHandler = this.changeExecutionSequenceHandler.bind(this);
                                    
                    this.changeServerIdHandler = this.changeServerIdHandler.bind(this);
                        this.saveOrUpdateWorkflowProcess = this.saveOrUpdateWorkflowProcess.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("WorkflowProcess componentDidMount() ID= " + this.state.id )
            WorkflowProcessService.getWorkflowProcessById(this.state.id).then( (res) =>{
                let workflowprocess = res.data;
                this.setState({

                            id: workflowprocess.id ,
                        
                            workflow_id: workflowprocess.workflow_id ,
                        
                            process_id: workflowprocess.process_id ,
                        
                            execution_sequence: workflowprocess.execution_sequence ,
                        
                            server_id: workflowprocess.server_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateWorkflowProcess = (e) => {
        e.preventDefault();
        let workflowprocess = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    workflow_id: this.state.workflow_id , 
                            
                    process_id: this.state.process_id , 
                            
                    execution_sequence: this.state.execution_sequence , 
                            
                    server_id: this.state.server_id  
                        };
        console.log('workflowprocess => ' + JSON.stringify(workflowprocess));

        // step 5
        if(this.state.id === '_add'){
            WorkflowProcessService.createWorkflowProcess(workflowprocess).then(res =>{
                this.props.navigate('/workflowprocess');
            });
        }else{
            WorkflowProcessService.updateWorkflowProcess(workflowprocess, this.state.id).then( res => {
                this.props.navigate('/workflowprocess');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeWorkflowIdHandler= (event) => {
            this.setState({workflow_id: event.target.value});
        }
        
        changeProcessIdHandler= (event) => {
            this.setState({process_id: event.target.value});
        }
        
        changeExecutionSequenceHandler= (event) => {
            this.setState({execution_sequence: event.target.value});
        }
        
        changeServerIdHandler= (event) => {
            this.setState({server_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/workflowprocess');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add WorkflowProcess</h3>
        }else{
            return <h3 className="text-center">Update WorkflowProcess</h3>
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
                                            <input placeholder="" name="workflow_id" className="form-control" 
                                                value={this.state.workflow_id} onChange={this.changeWorkflowIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="process_id" className="form-control" 
                                                value={this.state.process_id} onChange={this.changeProcessIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Sequence: </label>
                                            <input placeholder="" name="execution_sequence" className="form-control" 
                                                value={this.state.execution_sequence} onChange={this.changeExecutionSequenceHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="server_id" className="form-control" 
                                                value={this.state.server_id} onChange={this.changeServerIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateWorkflowProcess}>Save</button>
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

export default withNavigation(WorkflowProcessCreateComponent);