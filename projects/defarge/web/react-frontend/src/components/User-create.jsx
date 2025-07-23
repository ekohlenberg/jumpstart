import React, { Component } from 'react'
import UserService from '../services/user-service';
import { withNavigation } from './with-navigation';


class UserCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    first_name: '' ,
                
                    last_name: '' ,
                
                    username: '' ,
                
                    email: '' ,
                
                    created_date: '' ,
                
                    last_login_date: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeFirstNameHandler = this.changeFirstNameHandler.bind(this);
                                    
                    this.changeLastNameHandler = this.changeLastNameHandler.bind(this);
                                    
                    this.changeUsernameHandler = this.changeUsernameHandler.bind(this);
                                    
                    this.changeEmailHandler = this.changeEmailHandler.bind(this);
                                    
                    this.changeCreatedDateHandler = this.changeCreatedDateHandler.bind(this);
                                    
                    this.changeLastLoginDateHandler = this.changeLastLoginDateHandler.bind(this);
                        this.saveOrUpdateUser = this.saveOrUpdateUser.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("User componentDidMount() ID= " + this.state.id )
            UserService.getUserById(this.state.id).then( (res) =>{
                let user = res.data;
                this.setState({

                            id: user.id ,
                        
                            first_name: user.first_name ,
                        
                            last_name: user.last_name ,
                        
                            username: user.username ,
                        
                            email: user.email ,
                        
                            created_date: user.created_date ,
                        
                            last_login_date: user.last_login_date 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateUser = (e) => {
        e.preventDefault();
        let user = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    first_name: this.state.first_name , 
                            
                    last_name: this.state.last_name , 
                            
                    username: this.state.username , 
                            
                    email: this.state.email , 
                            
                    created_date: this.state.created_date , 
                            
                    last_login_date: this.state.last_login_date  
                        };
        console.log('user => ' + JSON.stringify(user));

        // step 5
        if(this.state.id === '_add'){
            UserService.createUser(user).then(res =>{
                this.props.navigate('/user');
            });
        }else{
            UserService.updateUser(user, this.state.id).then( res => {
                this.props.navigate('/user');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeFirstNameHandler= (event) => {
            this.setState({first_name: event.target.value});
        }
        
        changeLastNameHandler= (event) => {
            this.setState({last_name: event.target.value});
        }
        
        changeUsernameHandler= (event) => {
            this.setState({username: event.target.value});
        }
        
        changeEmailHandler= (event) => {
            this.setState({email: event.target.value});
        }
        
        changeCreatedDateHandler= (event) => {
            this.setState({created_date: event.target.value});
        }
        
        changeLastLoginDateHandler= (event) => {
            this.setState({last_login_date: event.target.value});
        }
            cancel(){
        this.props.navigate('/user');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add User</h3>
        }else{
            return <h3 className="text-center">Update User</h3>
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
                                            <label> User ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> First: </label>
                                            <input placeholder="" name="first_name" className="form-control" 
                                                value={this.state.first_name} onChange={this.changeFirstNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Last: </label>
                                            <input placeholder="" name="last_name" className="form-control" 
                                                value={this.state.last_name} onChange={this.changeLastNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Username: </label>
                                            <input placeholder="" name="username" className="form-control" 
                                                value={this.state.username} onChange={this.changeUsernameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Email: </label>
                                            <input placeholder="" name="email" className="form-control" 
                                                value={this.state.email} onChange={this.changeEmailHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Created: </label>
                                            <input placeholder="" name="created_date" className="form-control" 
                                                value={this.state.created_date} onChange={this.changeCreatedDateHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Last Login: </label>
                                            <input placeholder="" name="last_login_date" className="form-control" 
                                                value={this.state.last_login_date} onChange={this.changeLastLoginDateHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateUser}>Save</button>
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

export default withNavigation(UserCreateComponent);