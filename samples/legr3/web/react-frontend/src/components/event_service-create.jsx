import React, { Component } from 'react'
import EventServiceService from '../services/event_service-service';
import { withNavigation } from './with-navigation';


class EventServiceCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    event_type: '' ,
                
                    objectname_filter: '' ,
                
                    methodname_filter: '' ,
                
                    script_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeEventTypeHandler = this.changeEventTypeHandler.bind(this);
                                    
                    this.changeObjectnameFilterHandler = this.changeObjectnameFilterHandler.bind(this);
                                    
                    this.changeMethodnameFilterHandler = this.changeMethodnameFilterHandler.bind(this);
                                    
                    this.changeScriptIdHandler = this.changeScriptIdHandler.bind(this);
                        this.saveOrUpdateEventService = this.saveOrUpdateEventService.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("EventService componentDidMount() ID= " + this.state.id )
            EventServiceService.getEventServiceById(this.state.id).then( (res) =>{
                let eventservice = res.data;
                this.setState({

                            id: eventservice.id ,
                        
                            event_type: eventservice.event_type ,
                        
                            objectname_filter: eventservice.objectname_filter ,
                        
                            methodname_filter: eventservice.methodname_filter ,
                        
                            script_id: eventservice.script_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateEventService = (e) => {
        e.preventDefault();
        let eventservice = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    event_type: this.state.event_type , 
                            
                    objectname_filter: this.state.objectname_filter , 
                            
                    methodname_filter: this.state.methodname_filter , 
                            
                    script_id: this.state.script_id  
                        };
        console.log('eventservice => ' + JSON.stringify(eventservice));

        // step 5
        if(this.state.id === '_add'){
            EventServiceService.createEventService(eventservice).then(res =>{
                this.props.navigate('/eventservice');
            });
        }else{
            EventServiceService.updateEventService(eventservice, this.state.id).then( res => {
                this.props.navigate('/eventservice');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeEventTypeHandler= (event) => {
            this.setState({event_type: event.target.value});
        }
        
        changeObjectnameFilterHandler= (event) => {
            this.setState({objectname_filter: event.target.value});
        }
        
        changeMethodnameFilterHandler= (event) => {
            this.setState({methodname_filter: event.target.value});
        }
        
        changeScriptIdHandler= (event) => {
            this.setState({script_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/eventservice');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add EventService</h3>
        }else{
            return <h3 className="text-center">Update EventService</h3>
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
                                            <label> Event Type: </label>
                                            <input placeholder="" name="event_type" className="form-control" 
                                                value={this.state.event_type} onChange={this.changeEventTypeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Object Filter: </label>
                                            <input placeholder="" name="objectname_filter" className="form-control" 
                                                value={this.state.objectname_filter} onChange={this.changeObjectnameFilterHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Method Filter: </label>
                                            <input placeholder="" name="methodname_filter" className="form-control" 
                                                value={this.state.methodname_filter} onChange={this.changeMethodnameFilterHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Script ID: </label>
                                            <input placeholder="" name="script_id" className="form-control" 
                                                value={this.state.script_id} onChange={this.changeScriptIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateEventService}>Save</button>
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

export default withNavigation(EventServiceCreateComponent);