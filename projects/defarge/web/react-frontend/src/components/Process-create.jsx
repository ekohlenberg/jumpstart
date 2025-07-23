import React, { Component } from 'react'
import ProcessService from '../services/process-service';
import { withNavigation } from './with-navigation';


class ProcessCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    script_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeScriptIdHandler = this.changeScriptIdHandler.bind(this);
                        this.saveOrUpdateProcess = this.saveOrUpdateProcess.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Process componentDidMount() ID= " + this.state.id )
            ProcessService.getProcessById(this.state.id).then( (res) =>{
                let process = res.data;
                this.setState({

                            id: process.id ,
                        
                            name: process.name ,
                        
                            script_id: process.script_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateProcess = (e) => {
        e.preventDefault();
        let process = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    script_id: this.state.script_id  
                        };
        console.log('process => ' + JSON.stringify(process));

        // step 5
        if(this.state.id === '_add'){
            ProcessService.createProcess(process).then(res =>{
                this.props.navigate('/process');
            });
        }else{
            ProcessService.updateProcess(process, this.state.id).then( res => {
                this.props.navigate('/process');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeScriptIdHandler= (event) => {
            this.setState({script_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/process');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Process</h3>
        }else{
            return <h3 className="text-center">Update Process</h3>
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
                                            <label> Process ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Script: </label>
                                            <input placeholder="" name="script_id" className="form-control" 
                                                value={this.state.script_id} onChange={this.changeScriptIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateProcess}>Save</button>
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

export default withNavigation(ProcessCreateComponent);