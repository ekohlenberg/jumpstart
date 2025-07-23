import React, { Component } from 'react'
import OpRoleService from '../services/op_role-service';
import { withNavigation } from './with-navigation';


class OpRoleCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateOpRole = this.saveOrUpdateOpRole.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("OpRole componentDidMount() ID= " + this.state.id )
            OpRoleService.getOpRoleById(this.state.id).then( (res) =>{
                let oprole = res.data;
                this.setState({

                            id: oprole.id ,
                        
                            name: oprole.name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOpRole = (e) => {
        e.preventDefault();
        let oprole = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name  
                        };
        console.log('oprole => ' + JSON.stringify(oprole));

        // step 5
        if(this.state.id === '_add'){
            OpRoleService.createOpRole(oprole).then(res =>{
                this.props.navigate('/oprole');
            });
        }else{
            OpRoleService.updateOpRole(oprole, this.state.id).then( res => {
                this.props.navigate('/oprole');
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
        this.props.navigate('/oprole');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add OpRole</h3>
        }else{
            return <h3 className="text-center">Update OpRole</h3>
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
                                            <label> Role ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Role Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOpRole}>Save</button>
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

export default withNavigation(OpRoleCreateComponent);