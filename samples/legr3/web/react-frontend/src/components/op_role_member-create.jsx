import React, { Component } from 'react'
import OpRoleMemberService from '../services/op_role_member-service';
import { withNavigation } from './with-navigation';


class OpRoleMemberCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    user_id: '' ,
                
                    op_role_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeUserIdHandler = this.changeUserIdHandler.bind(this);
                                    
                    this.changeOpRoleIdHandler = this.changeOpRoleIdHandler.bind(this);
                        this.saveOrUpdateOpRoleMember = this.saveOrUpdateOpRoleMember.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("OpRoleMember componentDidMount() ID= " + this.state.id )
            OpRoleMemberService.getOpRoleMemberById(this.state.id).then( (res) =>{
                let oprolemember = res.data;
                this.setState({

                            id: oprolemember.id ,
                        
                            user_id: oprolemember.user_id ,
                        
                            op_role_id: oprolemember.op_role_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateOpRoleMember = (e) => {
        e.preventDefault();
        let oprolemember = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    user_id: this.state.user_id , 
                            
                    op_role_id: this.state.op_role_id  
                        };
        console.log('oprolemember => ' + JSON.stringify(oprolemember));

        // step 5
        if(this.state.id === '_add'){
            OpRoleMemberService.createOpRoleMember(oprolemember).then(res =>{
                this.props.navigate('/oprolemember');
            });
        }else{
            OpRoleMemberService.updateOpRoleMember(oprolemember, this.state.id).then( res => {
                this.props.navigate('/oprolemember');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeUserIdHandler= (event) => {
            this.setState({user_id: event.target.value});
        }
        
        changeOpRoleIdHandler= (event) => {
            this.setState({op_role_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/oprolemember');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add OpRoleMember</h3>
        }else{
            return <h3 className="text-center">Update OpRoleMember</h3>
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
                                            <label> Role: </label>
                                            <input placeholder="" name="op_role_id" className="form-control" 
                                                value={this.state.op_role_id} onChange={this.changeOpRoleIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateOpRoleMember}>Save</button>
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

export default withNavigation(OpRoleMemberCreateComponent);