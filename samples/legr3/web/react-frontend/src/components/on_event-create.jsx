import React, { Component } from 'react'
import OnEventService from '../services/on_event-service';
import { withNavigation } from './with-navigation';


class OnEventCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    objectname: '' ,
                
                    methodname: '' ,
                
                    script_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeObjectnameHandler = this.changeObjectnameHandler.bind(this);
                                    
                    this.changeMethodnameHandler = this.changeMethodnameHandler.bind(this);
                                    
                    this.changeScriptIdHandler = this.changeScriptIdHandler.bind(this);
                        this.saveOrUpdateOnEvent = this.saveOrUpdateOnEvent.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("OnEvent componentDidMount() ID= " + this.state.id )
            OnEventService.getOnEventById(this.state.id).then( (res) =>{
                let onevent = res.data;
                this.setState({

                            id: onevent.id ,
                        
                            objectname: onevent.objectname ,
                        
                            methodname: onevent.methodname ,
                        
                            script_id: onevent.script_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOnEvent = (e) => {
        e.preventDefault();
        let onevent = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    objectname: this.state.objectname , 
                            
                    methodname: this.state.methodname , 
                            
                    script_id: this.state.script_id  
                        };
        console.log('onevent => ' + JSON.stringify(onevent));

        // step 5
        if(this.state.id === '_add'){
            OnEventService.createOnEvent(onevent).then(res =>{
                this.props.navigate('/onevent');
            });
        }else{
            OnEventService.updateOnEvent(onevent, this.state.id).then( res => {
                this.props.navigate('/onevent');
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
        
        changeScriptIdHandler= (event) => {
            this.setState({script_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/onevent');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add OnEvent</h3>
        }else{
            return <h3 className="text-center">Update OnEvent</h3>
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
                                            <label> Event ID: </label>
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
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Script ID: </label>
                                            <input placeholder="" name="script_id" className="form-control" 
                                                value={this.state.script_id} onChange={this.changeScriptIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOnEvent}>Save</button>
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

export default withNavigation(OnEventCreateComponent);