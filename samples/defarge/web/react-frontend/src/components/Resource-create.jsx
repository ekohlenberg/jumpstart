import React, { Component } from 'react'
import ResourceService from '../services/resource-service';
import { withNavigation } from './with-navigation';


class ResourceCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    resource_type_id: '' ,
                
                    ip_address: '' ,
                
                    description: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeResourceTypeIdHandler = this.changeResourceTypeIdHandler.bind(this);
                                    
                    this.changeIpAddressHandler = this.changeIpAddressHandler.bind(this);
                                    
                    this.changeDescriptionHandler = this.changeDescriptionHandler.bind(this);
                        this.saveOrUpdateResource = this.saveOrUpdateResource.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Resource componentDidMount() ID= " + this.state.id )
            ResourceService.getResourceById(this.state.id).then( (res) =>{
                let resource = res.data;
                this.setState({

                            id: resource.id ,
                        
                            name: resource.name ,
                        
                            resource_type_id: resource.resource_type_id ,
                        
                            ip_address: resource.ip_address ,
                        
                            description: resource.description 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateResource = (e) => {
        e.preventDefault();
        let resource = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    resource_type_id: this.state.resource_type_id , 
                            
                    ip_address: this.state.ip_address , 
                            
                    description: this.state.description  
                        };
        console.log('resource => ' + JSON.stringify(resource));

        // step 5
        if(this.state.id === '_add'){
            ResourceService.createResource(resource).then(res =>{
                this.props.navigate('/resource');
            });
        }else{
            ResourceService.updateResource(resource, this.state.id).then( res => {
                this.props.navigate('/resource');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeResourceTypeIdHandler= (event) => {
            this.setState({resource_type_id: event.target.value});
        }
        
        changeIpAddressHandler= (event) => {
            this.setState({ip_address: event.target.value});
        }
        
        changeDescriptionHandler= (event) => {
            this.setState({description: event.target.value});
        }
            cancel(){
        this.props.navigate('/resource');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Resource</h3>
        }else{
            return <h3 className="text-center">Update Resource</h3>
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
                                            <label> ID: </label>
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
                                            <input placeholder="" name="resource_type_id" className="form-control" 
                                                value={this.state.resource_type_id} onChange={this.changeResourceTypeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Address: </label>
                                            <input placeholder="" name="ip_address" className="form-control" 
                                                value={this.state.ip_address} onChange={this.changeIpAddressHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Description: </label>
                                            <input placeholder="" name="description" className="form-control" 
                                                value={this.state.description} onChange={this.changeDescriptionHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateResource}>Save</button>
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

export default withNavigation(ResourceCreateComponent);