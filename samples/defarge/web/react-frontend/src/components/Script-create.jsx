import React, { Component } from 'react'
import ScriptService from '../services/script-service';
import { withNavigation } from './with-navigation';


class ScriptCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    source: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeSourceHandler = this.changeSourceHandler.bind(this);
                        this.saveOrUpdateScript = this.saveOrUpdateScript.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Script componentDidMount() ID= " + this.state.id )
            ScriptService.getScriptById(this.state.id).then( (res) =>{
                let script = res.data;
                this.setState({

                            id: script.id ,
                        
                            name: script.name ,
                        
                            source: script.source 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateScript = (e) => {
        e.preventDefault();
        let script = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    source: this.state.source  
                        };
        console.log('script => ' + JSON.stringify(script));

        // step 5
        if(this.state.id === '_add'){
            ScriptService.createScript(script).then(res =>{
                this.props.navigate('/script');
            });
        }else{
            ScriptService.updateScript(script, this.state.id).then( res => {
                this.props.navigate('/script');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeSourceHandler= (event) => {
            this.setState({source: event.target.value});
        }
            cancel(){
        this.props.navigate('/script');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Script</h3>
        }else{
            return <h3 className="text-center">Update Script</h3>
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
                                            <label> Script ID: </label>
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
                                            <label> Source Code: </label>
                                            <input placeholder="" name="source" className="form-control" 
                                                value={this.state.source} onChange={this.changeSourceHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateScript}>Save</button>
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

export default withNavigation(ScriptCreateComponent);