import React, { Component } from 'react'
import UserPasswordService from '../services/user_password-service';
import { withNavigation } from './with-navigation';


class UserPasswordCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    user_id: '' ,
                
                    password_hash: '' ,
                
                    expiry: '' ,
                
                    needs_reset: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeUserIdHandler = this.changeUserIdHandler.bind(this);
                                    
                    this.changePasswordHashHandler = this.changePasswordHashHandler.bind(this);
                                    
                    this.changeExpiryHandler = this.changeExpiryHandler.bind(this);
                                    
                    this.changeNeedsResetHandler = this.changeNeedsResetHandler.bind(this);
                        this.saveOrUpdateUserPassword = this.saveOrUpdateUserPassword.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("UserPassword componentDidMount() ID= " + this.state.id )
            UserPasswordService.getUserPasswordById(this.state.id).then( (res) =>{
                let userpassword = res.data;
                this.setState({

                            id: userpassword.id ,
                        
                            user_id: userpassword.user_id ,
                        
                            password_hash: userpassword.password_hash ,
                        
                            expiry: userpassword.expiry ,
                        
                            needs_reset: userpassword.needs_reset 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateUserPassword = (e) => {
        e.preventDefault();
        let userpassword = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    user_id: this.state.user_id , 
                            
                    password_hash: this.state.password_hash , 
                            
                    expiry: this.state.expiry , 
                            
                    needs_reset: this.state.needs_reset  
                        };
        console.log('userpassword => ' + JSON.stringify(userpassword));

        // step 5
        if(this.state.id === '_add'){
            UserPasswordService.createUserPassword(userpassword).then(res =>{
                this.props.navigate('/userpassword');
            });
        }else{
            UserPasswordService.updateUserPassword(userpassword, this.state.id).then( res => {
                this.props.navigate('/userpassword');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeUserIdHandler= (event) => {
            this.setState({user_id: event.target.value});
        }
        
        changePasswordHashHandler= (event) => {
            this.setState({password_hash: event.target.value});
        }
        
        changeExpiryHandler= (event) => {
            this.setState({expiry: event.target.value});
        }
        
        changeNeedsResetHandler= (event) => {
            this.setState({needs_reset: event.target.value});
        }
            cancel(){
        this.props.navigate('/userpassword');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add UserPassword</h3>
        }else{
            return <h3 className="text-center">Update UserPassword</h3>
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
                                            <label> User ID: </label>
                                            <input placeholder="" name="user_id" className="form-control" 
                                                value={this.state.user_id} onChange={this.changeUserIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Password: </label>
                                            <input placeholder="" name="password_hash" className="form-control" 
                                                value={this.state.password_hash} onChange={this.changePasswordHashHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Expiry: </label>
                                            <input placeholder="" name="expiry" className="form-control" 
                                                value={this.state.expiry} onChange={this.changeExpiryHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Needs Reset: </label>
                                            <input placeholder="" name="needs_reset" className="form-control" 
                                                value={this.state.needs_reset} onChange={this.changeNeedsResetHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateUserPassword}>Save</button>
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

export default withNavigation(UserPasswordCreateComponent);