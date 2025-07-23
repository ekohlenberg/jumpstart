import React, { Component } from 'react'
import OperationService from '../services/operation-service';
import { withNavigation } from './with-navigation';


class OperationCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    objectname: '' ,
                
                    methodname: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeObjectnameHandler = this.changeObjectnameHandler.bind(this);
                                    
                    this.changeMethodnameHandler = this.changeMethodnameHandler.bind(this);
                        this.saveOrUpdateOperation = this.saveOrUpdateOperation.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Operation componentDidMount() ID= " + this.state.id )
            OperationService.getOperationById(this.state.id).then( (res) =>{
                let operation = res.data;
                this.setState({

                            id: operation.id ,
                        
                            objectname: operation.objectname ,
                        
                            methodname: operation.methodname 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOperation = (e) => {
        e.preventDefault();
        let operation = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    objectname: this.state.objectname , 
                            
                    methodname: this.state.methodname  
                        };
        console.log('operation => ' + JSON.stringify(operation));

        // step 5
        if(this.state.id === '_add'){
            OperationService.createOperation(operation).then(res =>{
                this.props.navigate('/operation');
            });
        }else{
            OperationService.updateOperation(operation, this.state.id).then( res => {
                this.props.navigate('/operation');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeObjectnameHandler= (event) => {
            this.setState({objectname: event.target.value});
        }
        
        changeMethodnameHandler= (event) => {
            this.setState({methodname: event.target.value});
        }
            cancel(){
        this.props.navigate('/operation');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Operation</h3>
        }else{
            return <h3 className="text-center">Update Operation</h3>
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
                                            <label> Action ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Object: </label>
                                            <input placeholder="" name="objectname" className="form-control" 
                                                value={this.state.objectname} onChange={this.changeObjectnameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Method: </label>
                                            <input placeholder="" name="methodname" className="form-control" 
                                                value={this.state.methodname} onChange={this.changeMethodnameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOperation}>Save</button>
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

export default withNavigation(OperationCreateComponent);