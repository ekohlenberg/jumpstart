import React, { Component } from 'react'
import ResourceTypeService from '../services/resource_type-service';
import { withNavigation } from './with-navigation';


class ResourceTypeCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateResourceType = this.saveOrUpdateResourceType.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("ResourceType componentDidMount() ID= " + this.state.id )
            ResourceTypeService.getResourceTypeById(this.state.id).then( (res) =>{
                let resourcetype = res.data;
                this.setState({

                            id: resourcetype.id ,
                        
                            name: resourcetype.name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateResourceType = (e) => {
        e.preventDefault();
        let resourcetype = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name  
                        };
        console.log('resourcetype => ' + JSON.stringify(resourcetype));

        // step 5
        if(this.state.id === '_add'){
            ResourceTypeService.createResourceType(resourcetype).then(res =>{
                this.props.navigate('/resourcetype');
            });
        }else{
            ResourceTypeService.updateResourceType(resourcetype, this.state.id).then( res => {
                this.props.navigate('/resourcetype');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
            cancel(){
        this.props.navigate('/resourcetype');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add ResourceType</h3>
        }else{
            return <h3 className="text-center">Update ResourceType</h3>
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
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateResourceType}>Save</button>
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

export default withNavigation(ResourceTypeCreateComponent);