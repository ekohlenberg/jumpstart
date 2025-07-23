import React, { Component } from 'react'
import ServerService from '../services/server-service';
import { withNavigation } from './with-navigation';


class ServerCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    type: '' ,
                
                    address: '' ,
                
                    port: '' ,
                
                    is_default: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeTypeHandler = this.changeTypeHandler.bind(this);
                                    
                    this.changeAddressHandler = this.changeAddressHandler.bind(this);
                                    
                    this.changePortHandler = this.changePortHandler.bind(this);
                                    
                    this.changeIsDefaultHandler = this.changeIsDefaultHandler.bind(this);
                        this.saveOrUpdateServer = this.saveOrUpdateServer.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Server componentDidMount() ID= " + this.state.id )
            ServerService.getServerById(this.state.id).then( (res) =>{
                let server = res.data;
                this.setState({

                            id: server.id ,
                        
                            name: server.name ,
                        
                            type: server.type ,
                        
                            address: server.address ,
                        
                            port: server.port ,
                        
                            is_default: server.is_default 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateServer = (e) => {
        e.preventDefault();
        let server = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    type: this.state.type , 
                            
                    address: this.state.address , 
                            
                    port: this.state.port , 
                            
                    is_default: this.state.is_default  
                        };
        console.log('server => ' + JSON.stringify(server));

        // step 5
        if(this.state.id === '_add'){
            ServerService.createServer(server).then(res =>{
                this.props.navigate('/server');
            });
        }else{
            ServerService.updateServer(server, this.state.id).then( res => {
                this.props.navigate('/server');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeTypeHandler= (event) => {
            this.setState({type: event.target.value});
        }
        
        changeAddressHandler= (event) => {
            this.setState({address: event.target.value});
        }
        
        changePortHandler= (event) => {
            this.setState({port: event.target.value});
        }
        
        changeIsDefaultHandler= (event) => {
            this.setState({is_default: event.target.value});
        }
            cancel(){
        this.props.navigate('/server');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Server</h3>
        }else{
            return <h3 className="text-center">Update Server</h3>
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
                                            <label> Server ID: </label>
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
                                            <label> Type: </label>
                                            <input placeholder="" name="type" className="form-control" 
                                                value={this.state.type} onChange={this.changeTypeHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Address: </label>
                                            <input placeholder="" name="address" className="form-control" 
                                                value={this.state.address} onChange={this.changeAddressHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Port: </label>
                                            <input placeholder="" name="port" className="form-control" 
                                                value={this.state.port} onChange={this.changePortHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Is Default: </label>
                                            <input placeholder="" name="is_default" className="form-control" 
                                                value={this.state.is_default} onChange={this.changeIsDefaultHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateServer}>Save</button>
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

export default withNavigation(ServerCreateComponent);