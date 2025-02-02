import React, { Component } from 'react'
import MonitoredResourceService from '../services/monitored_resource-service';
import { withNavigation } from './with-navigation';


class MonitoredResourceCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    resource_type: '' ,
                
                    ip_address: '' ,
                
                    description: '' ,
                
                    created_at: '' ,
                
                    updated_at: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeResourceTypeHandler = this.changeResourceTypeHandler.bind(this);
                                    
                    this.changeIpAddressHandler = this.changeIpAddressHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                                    
                    this.changeCreatedAtHandler = this.changeCreatedAtHandler.bind(this);
                                    
                    this.changeUpdatedAtHandler = this.changeUpdatedAtHandler.bind(this);
                        this.saveOrUpdateMonitoredResource = this.saveOrUpdateMonitoredResource.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("MonitoredResource componentDidMount() ID= " + this.state.id )
            MonitoredResourceService.getMonitoredResourceById(this.state.id).then( (res) =>{
                let monitoredresource = res.data;
                this.setState({

                            id: monitoredresource.id ,
                        
                            name: monitoredresource.name ,
                        
                            resource_type: monitoredresource.resource_type ,
                        
                            ip_address: monitoredresource.ip_address ,
                        
                            description: monitoredresource.description ,
                        
                            created_at: monitoredresource.created_at ,
                        
                            updated_at: monitoredresource.updated_at 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateMonitoredResource = (e) => {
        e.preventDefault();
        let monitoredresource = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    resource_type: this.state.resource_type , 
                            
                    ip_address: this.state.ip_address , 
                            
                    description: this.state.description , 
                            
                    created_at: this.state.created_at , 
                            
                    updated_at: this.state.updated_at  
                        };
        console.log('monitoredresource => ' + JSON.stringify(monitoredresource));

        // step 5
        if(this.state.id === '_add'){
            MonitoredResourceService.createMonitoredResource(monitoredresource).then(res =>{
                this.props.navigate('/monitoredresource');
            });
        }else{
            MonitoredResourceService.updateMonitoredResource(monitoredresource, this.state.id).then( res => {
                this.props.navigate('/monitoredresource');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeResourceTypeHandler= (event) => {
            this.setState({resource_type: event.target.value});
        }
        
        changeIpAddressHandler= (event) => {
            this.setState({ip_address: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
        
        changeCreatedAtHandler= (event) => {
            this.setState({created_at: event.target.value});
        }
        
        changeUpdatedAtHandler= (event) => {
            this.setState({updated_at: event.target.value});
        }
            cancel(){
        this.props.navigate('/monitoredresource');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add MonitoredResource</h3>
        }else{
            return <h3 className="text-center">Update MonitoredResource</h3>
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
                                            <label> Id: </label>
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
                                            <label> Resource: </label>
                                            <input placeholder="" name="resource_type" className="form-control" 
                                                value={this.state.resource_type} onChange={this.changeResourceTypeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Ip: </label>
                                            <input placeholder="" name="ip_address" className="form-control" 
                                                value={this.state.ip_address} onChange={this.changeIpAddressHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Description: </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_at" className="form-control" 
                                                value={this.state.created_at} onChange={this.changeCreatedAtHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Updated: </label>
                                            <input placeholder="" name="updated_at" className="form-control" 
                                                value={this.state.updated_at} onChange={this.changeUpdatedAtHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateMonitoredResource}>Save</button>
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

export default withNavigation(MonitoredResourceCreateComponent);