import React, { Component } from 'react'
import WorkflowService from '../services/workflow-service';
import { withNavigation } from './with-navigation';


class WorkflowCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    parent_workflow_id: '' ,
                
                    name: '' ,
                
                    description: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeParentWorkflowIdHandler = this.changeParentWorkflowIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                        this.saveOrUpdateWorkflow = this.saveOrUpdateWorkflow.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Workflow componentDidMount() ID= " + this.state.id )
            WorkflowService.getWorkflowById(this.state.id).then( (res) =>{
                let workflow = res.data;
                this.setState({

                            id: workflow.id ,
                        
                            parent_workflow_id: workflow.parent_workflow_id ,
                        
                            name: workflow.name ,
                        
                            description: workflow.description 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateWorkflow = (e) => {
        e.preventDefault();
        let workflow = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    parent_workflow_id: this.state.parent_workflow_id , 
                            
                    name: this.state.name , 
                            
                    description: this.state.description  
                        };
        console.log('workflow => ' + JSON.stringify(workflow));

        // step 5
        if(this.state.id === '_add'){
            WorkflowService.createWorkflow(workflow).then(res =>{
                this.props.navigate('/workflow');
            });
        }else{
            WorkflowService.updateWorkflow(workflow, this.state.id).then( res => {
                this.props.navigate('/workflow');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeParentWorkflowIdHandler= (event) => {
            this.setState({parent_workflow_id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
            cancel(){
        this.props.navigate('/workflow');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Workflow</h3>
        }else{
            return <h3 className="text-center">Update Workflow</h3>
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
                                            <input placeholder="" name="parent_workflow_id" className="form-control" 
                                                value={this.state.parent_workflow_id} onChange={this.changeParentWorkflowIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> : </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateWorkflow}>Save</button>
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

export default withNavigation(WorkflowCreateComponent);