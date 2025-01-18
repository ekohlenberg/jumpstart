import React, { Component } from 'react'
import ActionGroupService from '../services/action_group-service';
import { withNavigation } from './with-navigation';


class ActionGroupCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateActionGroup = this.saveOrUpdateActionGroup.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("ActionGroup componentDidMount() ID= " + this.state.id )
            ActionGroupService.getActionGroupById(this.state.id).then( (res) =>{
                let actiongroup = res.data;
                this.setState({

                            id: actiongroup.id ,
                        
                            name: actiongroup.name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateActionGroup = (e) => {
        e.preventDefault();
        let actiongroup = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name  
                        };
        console.log('actiongroup => ' + JSON.stringify(actiongroup));

        // step 5
        if(this.state.id === '_add'){
            ActionGroupService.createActionGroup(actiongroup).then(res =>{
                this.props.navigate('/actiongroup');
            });
        }else{
            ActionGroupService.updateActionGroup(actiongroup, this.state.id).then( res => {
                this.props.navigate('/actiongroup');
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
        this.props.navigate('/actiongroup');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add ActionGroup</h3>
        }else{
            return <h3 className="text-center">Update ActionGroup</h3>
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
                                            <label> Group ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Group Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateActionGroup}>Save</button>
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

export default withNavigation(ActionGroupCreateComponent);