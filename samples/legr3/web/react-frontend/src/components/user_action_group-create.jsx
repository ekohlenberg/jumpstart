import React, { Component } from 'react'
import UserActionGroupService from '../services/user_action_group-service';
import { withNavigation } from './with-navigation';


class UserActionGroupCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    user_id: '' ,
                
                    action_group_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeUserIdHandler = this.changeUserIdHandler.bind(this);
                                    
                    this.changeActionGroupIdHandler = this.changeActionGroupIdHandler.bind(this);
                        this.saveOrUpdateUserActionGroup = this.saveOrUpdateUserActionGroup.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("UserActionGroup componentDidMount() ID= " + this.state.id )
            UserActionGroupService.getUserActionGroupById(this.state.id).then( (res) =>{
                let useractiongroup = res.data;
                this.setState({

                            id: useractiongroup.id ,
                        
                            user_id: useractiongroup.user_id ,
                        
                            action_group_id: useractiongroup.action_group_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateUserActionGroup = (e) => {
        e.preventDefault();
        let useractiongroup = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    user_id: this.state.user_id , 
                            
                    action_group_id: this.state.action_group_id  
                        };
        console.log('useractiongroup => ' + JSON.stringify(useractiongroup));

        // step 5
        if(this.state.id === '_add'){
            UserActionGroupService.createUserActionGroup(useractiongroup).then(res =>{
                this.props.navigate('/useractiongroup');
            });
        }else{
            UserActionGroupService.updateUserActionGroup(useractiongroup, this.state.id).then( res => {
                this.props.navigate('/useractiongroup');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeUserIdHandler= (event) => {
            this.setState({user_id: event.target.value});
        }
        
        changeActionGroupIdHandler= (event) => {
            this.setState({action_group_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/useractiongroup');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add UserActionGroup</h3>
        }else{
            return <h3 className="text-center">Update UserActionGroup</h3>
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
                                            <label> Member ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Username: </label>
                                            <input placeholder="" name="user_id" className="form-control" 
                                                value={this.state.user_id} onChange={this.changeUserIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Action Group: </label>
                                            <input placeholder="" name="action_group_id" className="form-control" 
                                                value={this.state.action_group_id} onChange={this.changeActionGroupIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateUserActionGroup}>Save</button>
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

export default withNavigation(UserActionGroupCreateComponent);