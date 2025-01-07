import React, { Component } from 'react'
import UserOrgService from '../services/user_org-service';
import { withNavigation } from './with-navigation';


class UserOrgCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    org_id: '' ,
                
                    user_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeOrgIdHandler = this.changeOrgIdHandler.bind(this);
                                    
                    this.changeUserIdHandler = this.changeUserIdHandler.bind(this);
                        this.saveOrUpdateUserOrg = this.saveOrUpdateUserOrg.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("UserOrg componentDidMount() ID= " + this.state.id )
            UserOrgService.getUserOrgById(this.state.id).then( (res) =>{
                let userorg = res.data;
                this.setState({

                            id: userorg.id ,
                        
                            org_id: userorg.org_id ,
                        
                            user_id: userorg.user_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateUserOrg = (e) => {
        e.preventDefault();
        let userorg = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    org_id: this.state.org_id , 
                            
                    user_id: this.state.user_id  
                        };
        console.log('userorg => ' + JSON.stringify(userorg));

        // step 5
        if(this.state.id === '_add'){
            UserOrgService.createUserOrg(userorg).then(res =>{
                this.props.navigate('/userorg');
            });
        }else{
            UserOrgService.updateUserOrg(userorg, this.state.id).then( res => {
                this.props.navigate('/userorg');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeOrgIdHandler= (event) => {
            this.setState({org_id: event.target.value});
        }
        
        changeUserIdHandler= (event) => {
            this.setState({user_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/userorg');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add UserOrg</h3>
        }else{
            return <h3 className="text-center">Update UserOrg</h3>
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
                                            <label> User Org ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Organization ID: </label>
                                            <input placeholder="" name="org_id" className="form-control" 
                                                value={this.state.org_id} onChange={this.changeOrgIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> User ID: </label>
                                            <input placeholder="" name="user_id" className="form-control" 
                                                value={this.state.user_id} onChange={this.changeUserIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateUserOrg}>Save</button>
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

export default withNavigation(UserOrgCreateComponent);